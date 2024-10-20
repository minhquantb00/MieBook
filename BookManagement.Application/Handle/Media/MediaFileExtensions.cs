﻿using BookManagement.Application.Guard;
using BookManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.Handle.Media
{
    public static class MediaFileExtensions
    {
        /// <summary>
        /// Applies Blob to file
        /// </summary>
        /// <param name="blob">The file binary (can be null)</param>
        public static void ApplyBlob(this MediaFile file, byte[] blob)
        {
            Guard.Guard.NotNull(file, nameof(file));

            if (blob == null || blob.LongLength == 0)
            {
                file.MediaStorageId = null;
                file.MediaStorage = null;
            }
            else
            {
                if (file.MediaStorage != null)
                {
                    file.MediaStorage.Data = blob;
                }
                else
                {
                    file.MediaStorage = new MediaStorage { Data = blob };
                }
            }
        }

        /// <summary>
        /// Refreshes file metadata like size, dimensions etc.
        /// </summary>
        /// <param name="stream">The file stream (can be null)</param>
        public static void RefreshMetadata(this MediaFile file, Stream stream)
        {
            Guard.Guard.NotNull(file, nameof(file));

            file.Size = stream != null ? (int)stream.Length : 0;
            file.Width = null;
            file.Height = null;
            file.PixelSize = null;

            if (stream != null && file.MediaType == MediaType.Image)
            {
                try
                {
                    var size = ImageHeader.GetDimensions(stream, file.MimeType);
                    file.Width = size.Width;
                    file.Height = size.Height;
                    file.PixelSize = size.Width * size.Height;
                }
                catch { }
            }
        }
    }
}
