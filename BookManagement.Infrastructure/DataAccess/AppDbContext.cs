using BookManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Infrastructure.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Download> Download { get; set; }
        public DbSet<MediaFile> MediaFile { get; set; }
        public DbSet<MediaFolder> MediaFolder { get; set; }
        public DbSet<MediaStorage> MediaStorage { get; set; }
        public DbSet<AddressUser> AddressUser { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<BillDetail> BillDetail { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ChatMessage> ChatMessage { get; set; }
        public DbSet<ChatMessageParticipantStates> ChatMessageParticipantStates { get; set; }
        public DbSet<Collection> Collection { get; set; }
        public DbSet<ConfirmEmail> ConfirmEmail { get; set; }
        public DbSet<Conversation> Conversation { get; set; }
        public DbSet<DiscountEvent> DiscountEvent { get; set; }
        public DbSet<EventBook> EventBook { get; set; }
        public DbSet<FavoriteBook> FavoriteBook { get; set; }
        public DbSet<Participant> Participant { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<RankCustomer> RankCustomer { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<ShippingMethod> ShippingMethod { get; set; }
        public DbSet<ShippingMethodBook> ShippingMethodBook { get; set; }
        public DbSet<TopicBook> TopicBook { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserVoucher> UserVoucher { get; set; }
        public DbSet<Voucher> Voucher { get; set; }
        public DbSet<BookReview> BookReview { get; set; }
        public DbSet<Contact> Contact { get; set; }
    }
}
