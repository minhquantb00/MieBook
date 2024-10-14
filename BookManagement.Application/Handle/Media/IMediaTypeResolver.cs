using BookManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.Handle.Media
{
    public interface IMediaTypeResolver
    {
        MediaType Resolve(string extension, string mimeType = null);
    }

    public static class IMediaTypeResolverExtensions
    {
        public static MediaType Resolve(this IMediaTypeResolver resolver, MediaFile file)
        {
            Guard.Guard.NotNull(file, nameof(file));
            return resolver.Resolve(file.Extension, file.MimeType);
        }
    }
}
