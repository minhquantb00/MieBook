using BookManagement.Commons.Base;
using BookManagement.Commons.Enums;
using BookManagement.Commons.Features;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Entities
{
    public class User : BaseEntity<long>, IHasCreationTime, IHasModificationTime, IActivatable, IDeletable
    {
        public string Email { get; set; }
        public string NickName { get; set; }
        public string FullName { get; set; }
        public Enumerate.Gender? Gender { get; set; } = Enumerate.Gender.KhongXacDinh;
        public string Password {  get; set; }
        public string PhoneNumber { get; set; }
        public string PinCode { get; set; }
        public long? AddressDefaultId { get; set; }
        public int Point { get; set; } = 0;
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public long? RankCustomerId { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<UserRole>? UserRoles { get; set; }
        public virtual ICollection<AddressUser>? AddressUsers { get; set; }
        public virtual ICollection<ConfirmEmail>? ConfirmEmails { get; set; }
        public virtual ICollection<RefreshToken>? RefreshTokens { get; set; }
        public virtual ICollection<Collection>? Collections { get; set; }
        public virtual ICollection<UserVoucher>? UserVouchers { get; set; }
        public virtual ICollection<FavoriteBook>? FavoriteBooks { get; set; }
        public virtual ICollection<BookReview>? BookReviews { get; set; }
        public virtual ICollection<Cart>? Carts { get; set; }
        public virtual ICollection<Bill>? Bills { get; set; }
        public virtual ICollection<ChatMessage>? ChatMessages { get; set; }
        public virtual ICollection<Participant>? Participants { get; set; }
        public virtual ICollection<Conversation>? Conversations { get; set; }
    }
}
