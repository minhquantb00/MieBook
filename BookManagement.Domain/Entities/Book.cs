using BookManagement.Commons.Base;
using BookManagement.Commons.Enums;
using BookManagement.Commons.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Entities
{
    public class Book : BaseEntity<long>, IHasCreationTime, IHasModificationTime
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int SoldQuantity { get; set; } = 0;
        public string ImageUrl { get; set; }
        public string Author { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int NumberOfPages { get; set; }
        public double PriceAfterDiscount { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public int AverageRating { get; set; }
        public Enumerate.BookStatus Status { get; set; } = Enumerate.BookStatus.DangBan;
        public int InventoryNumber { get; set; }
        public long? CollectionId { get; set; }
        public virtual Collection? Collection { get; set; }
        public long? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public long? TopicBookId { get; set; }   
        public virtual TopicBook? TopicBook { get; set; }
        public virtual ICollection<EventBook>? EventBooks { get; set; }
        public virtual ICollection<FavoriteBook>? FavoriteBooks { get; set; }
        public virtual ICollection<BookReview>? BookReviews { get; set; }
        public virtual ICollection<CartItem>? CartItems { get; set; }
        public virtual ICollection<ShippingMethodBook>? ShippingMethods { get; set; }
        public virtual ICollection<BillDetail>? BillDetails { get; set; }
    }
}
