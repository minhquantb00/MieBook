using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Voucher",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Voucher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "DiscountPercent",
                table: "Voucher",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Voucher",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "UserVoucher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiredTime",
                table: "UserVoucher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "UserVoucher",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "VoucherId",
                table: "UserVoucher",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "VoucherStatus",
                table: "UserVoucher",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "RoleId",
                table: "UserRole",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "UserRole",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Banner",
                table: "TopicBook",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TopicBook",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "BookId",
                table: "ShippingMethodBook",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ShippingMethodBook",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "ShippingMethodId",
                table: "ShippingMethodBook",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "ShippingMethod",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ShippingMethod",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ShippingMethod",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ShippingMethod",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "ShippingMethod",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Role",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Role",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "RefreshToken",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiredTime",
                table: "RefreshToken",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "RefreshToken",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "RefreshToken",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "RankCustomer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "DiscountPercent",
                table: "RankCustomer",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RankCustomer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PaymentMethod",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "ConversationId",
                table: "Participant",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Participant",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "ParticipantId",
                table: "Participant",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Participant",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "BookId",
                table: "FavoriteBook",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "FavoriteBook",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "FavoriteBook",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "FavoriteBook",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "BookId",
                table: "EventBook",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DiscountEventId",
                table: "EventBook",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DiscountEvent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "DiscountEventId",
                table: "DiscountEvent",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DiscountPercent",
                table: "DiscountEvent",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "DiscoutEventStatus",
                table: "DiscountEvent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "DiscountEvent",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EventName",
                table: "DiscountEvent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "DiscountEvent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "DiscountEvent",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Conversation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Creator",
                table: "Conversation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteTime",
                table: "Conversation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Conversation",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Conversation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "UserDeleteId",
                table: "Conversation",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactText",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Hotline",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmCode",
                table: "ConfirmEmail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "ConfirmEmail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiredTime",
                table: "ConfirmEmail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmed",
                table: "ConfirmEmail",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "ConfirmEmail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Collection",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Collection",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfProducts",
                table: "Collection",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Collection",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Collection",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ChatMessageId",
                table: "ChatMessageParticipantStates",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsSeen",
                table: "ChatMessageParticipantStates",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "ParticipantId",
                table: "ChatMessageParticipantStates",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "SeenTime",
                table: "ChatMessageParticipantStates",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "ChatMessage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "ConversationId",
                table: "ChatMessage",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "ChatMessage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorId",
                table: "ChatMessage",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteTime",
                table: "ChatMessage",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ChatMessage",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "ChatMessage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "UserDeleteId",
                table: "ChatMessage",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Category",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfProducts",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Category",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BookId",
                table: "CartItem",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CartId",
                table: "CartItem",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "CartItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "CartItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "UnitPrice",
                table: "CartItem",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "CartItem",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Cart",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Cart",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Cart",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "BookId",
                table: "BookReview",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "BookReview",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "BookReview",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfStars",
                table: "BookReview",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewTime",
                table: "BookReview",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "BookReview",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AverageRating",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                table: "Book",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "CollectionId",
                table: "Book",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Book",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "InventoryNumber",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ManufactureDate",
                table: "Book",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPages",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Book",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PriceAfterDiscount",
                table: "Book",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "SoldQuantity",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "TopicBookId",
                table: "Book",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Book",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BillId",
                table: "BillDetail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "BookId",
                table: "BillDetail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "BillDetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "BillDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "UnitPrice",
                table: "BillDetail",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Bill",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "BillStatus",
                table: "Bill",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Bill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Bill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PayTime",
                table: "Bill",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PaymentMethodId",
                table: "Bill",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "ReasonForRefusal",
                table: "Bill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ShippingFee",
                table: "Bill",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<long>(
                name: "ShippingMethodId",
                table: "Bill",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<double>(
                name: "TotalPriceAfterDiscount",
                table: "Bill",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalPriceBeforeDiscount",
                table: "Bill",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "TradingCode",
                table: "Bill",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Bill",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Bill",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserVoucherId",
                table: "Bill",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AddressUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "AddressUser",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "AddressUser",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_UserVoucher_UserId",
                table: "UserVoucher",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVoucher_VoucherId",
                table: "UserVoucher",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingMethodBook_BookId",
                table: "ShippingMethodBook",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingMethodBook_ShippingMethodId",
                table: "ShippingMethodBook",
                column: "ShippingMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_ConversationId",
                table: "Participant",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_ParticipantId",
                table: "Participant",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_UserId",
                table: "Participant",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteBook_BookId",
                table: "FavoriteBook",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteBook_UserId",
                table: "FavoriteBook",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EventBook_BookId",
                table: "EventBook",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_EventBook_DiscountEventId",
                table: "EventBook",
                column: "DiscountEventId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountEvent_DiscountEventId",
                table: "DiscountEvent",
                column: "DiscountEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversation_UserDeleteId",
                table: "Conversation",
                column: "UserDeleteId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmEmail_UserId",
                table: "ConfirmEmail",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Collection_UserId",
                table: "Collection",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessageParticipantStates_ChatMessageId",
                table: "ChatMessageParticipantStates",
                column: "ChatMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessageParticipantStates_ParticipantId",
                table: "ChatMessageParticipantStates",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_ConversationId",
                table: "ChatMessage",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_CreatorId",
                table: "ChatMessage",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_UserDeleteId",
                table: "ChatMessage",
                column: "UserDeleteId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_BookId",
                table: "CartItem",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CartId",
                table: "CartItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId",
                table: "Cart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookReview_BookId",
                table: "BookReview",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookReview_UserId",
                table: "BookReview",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_CategoryId",
                table: "Book",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_CollectionId",
                table: "Book",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_TopicBookId",
                table: "Book",
                column: "TopicBookId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_BillId",
                table: "BillDetail",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_BookId",
                table: "BillDetail",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_PaymentMethodId",
                table: "Bill",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_ShippingMethodId",
                table: "Bill",
                column: "ShippingMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_UserId",
                table: "Bill",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_UserVoucherId",
                table: "Bill",
                column: "UserVoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressUser_UserId",
                table: "AddressUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressUser_User_UserId",
                table: "AddressUser",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_PaymentMethod_PaymentMethodId",
                table: "Bill",
                column: "PaymentMethodId",
                principalTable: "PaymentMethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_ShippingMethod_ShippingMethodId",
                table: "Bill",
                column: "ShippingMethodId",
                principalTable: "ShippingMethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_UserVoucher_UserVoucherId",
                table: "Bill",
                column: "UserVoucherId",
                principalTable: "UserVoucher",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_User_UserId",
                table: "Bill",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetail_Bill_BillId",
                table: "BillDetail",
                column: "BillId",
                principalTable: "Bill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetail_Book_BookId",
                table: "BillDetail",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Category_CategoryId",
                table: "Book",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Collection_CollectionId",
                table: "Book",
                column: "CollectionId",
                principalTable: "Collection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_TopicBook_TopicBookId",
                table: "Book",
                column: "TopicBookId",
                principalTable: "TopicBook",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookReview_Book_BookId",
                table: "BookReview",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookReview_User_UserId",
                table: "BookReview",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_User_UserId",
                table: "Cart",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Book_BookId",
                table: "CartItem",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Cart_CartId",
                table: "CartItem",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessage_Conversation_ConversationId",
                table: "ChatMessage",
                column: "ConversationId",
                principalTable: "Conversation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessage_Participant_CreatorId",
                table: "ChatMessage",
                column: "CreatorId",
                principalTable: "Participant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessage_User_UserDeleteId",
                table: "ChatMessage",
                column: "UserDeleteId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessageParticipantStates_ChatMessage_ChatMessageId",
                table: "ChatMessageParticipantStates",
                column: "ChatMessageId",
                principalTable: "ChatMessage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessageParticipantStates_Participant_ParticipantId",
                table: "ChatMessageParticipantStates",
                column: "ParticipantId",
                principalTable: "Participant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Collection_User_UserId",
                table: "Collection",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConfirmEmail_User_UserId",
                table: "ConfirmEmail",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Conversation_User_UserDeleteId",
                table: "Conversation",
                column: "UserDeleteId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountEvent_DiscountEvent_DiscountEventId",
                table: "DiscountEvent",
                column: "DiscountEventId",
                principalTable: "DiscountEvent",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventBook_Book_BookId",
                table: "EventBook",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventBook_DiscountEvent_DiscountEventId",
                table: "EventBook",
                column: "DiscountEventId",
                principalTable: "DiscountEvent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteBook_Book_BookId",
                table: "FavoriteBook",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteBook_User_UserId",
                table: "FavoriteBook",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Participant_Conversation_ConversationId",
                table: "Participant",
                column: "ConversationId",
                principalTable: "Conversation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Participant_Participant_ParticipantId",
                table: "Participant",
                column: "ParticipantId",
                principalTable: "Participant",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Participant_User_UserId",
                table: "Participant",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_User_UserId",
                table: "RefreshToken",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingMethodBook_Book_BookId",
                table: "ShippingMethodBook",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingMethodBook_ShippingMethod_ShippingMethodId",
                table: "ShippingMethodBook",
                column: "ShippingMethodId",
                principalTable: "ShippingMethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Role_RoleId",
                table: "UserRole",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_User_UserId",
                table: "UserRole",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserVoucher_User_UserId",
                table: "UserVoucher",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserVoucher_Voucher_VoucherId",
                table: "UserVoucher",
                column: "VoucherId",
                principalTable: "Voucher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressUser_User_UserId",
                table: "AddressUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Bill_PaymentMethod_PaymentMethodId",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_Bill_ShippingMethod_ShippingMethodId",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_Bill_UserVoucher_UserVoucherId",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_Bill_User_UserId",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_BillDetail_Bill_BillId",
                table: "BillDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_BillDetail_Book_BookId",
                table: "BillDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Category_CategoryId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Collection_CollectionId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_TopicBook_TopicBookId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_BookReview_Book_BookId",
                table: "BookReview");

            migrationBuilder.DropForeignKey(
                name: "FK_BookReview_User_UserId",
                table: "BookReview");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_User_UserId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Book_BookId",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Cart_CartId",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessage_Conversation_ConversationId",
                table: "ChatMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessage_Participant_CreatorId",
                table: "ChatMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessage_User_UserDeleteId",
                table: "ChatMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessageParticipantStates_ChatMessage_ChatMessageId",
                table: "ChatMessageParticipantStates");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessageParticipantStates_Participant_ParticipantId",
                table: "ChatMessageParticipantStates");

            migrationBuilder.DropForeignKey(
                name: "FK_Collection_User_UserId",
                table: "Collection");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfirmEmail_User_UserId",
                table: "ConfirmEmail");

            migrationBuilder.DropForeignKey(
                name: "FK_Conversation_User_UserDeleteId",
                table: "Conversation");

            migrationBuilder.DropForeignKey(
                name: "FK_DiscountEvent_DiscountEvent_DiscountEventId",
                table: "DiscountEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_EventBook_Book_BookId",
                table: "EventBook");

            migrationBuilder.DropForeignKey(
                name: "FK_EventBook_DiscountEvent_DiscountEventId",
                table: "EventBook");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteBook_Book_BookId",
                table: "FavoriteBook");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteBook_User_UserId",
                table: "FavoriteBook");

            migrationBuilder.DropForeignKey(
                name: "FK_Participant_Conversation_ConversationId",
                table: "Participant");

            migrationBuilder.DropForeignKey(
                name: "FK_Participant_Participant_ParticipantId",
                table: "Participant");

            migrationBuilder.DropForeignKey(
                name: "FK_Participant_User_UserId",
                table: "Participant");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_User_UserId",
                table: "RefreshToken");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingMethodBook_Book_BookId",
                table: "ShippingMethodBook");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingMethodBook_ShippingMethod_ShippingMethodId",
                table: "ShippingMethodBook");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Role_RoleId",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_User_UserId",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVoucher_User_UserId",
                table: "UserVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVoucher_Voucher_VoucherId",
                table: "UserVoucher");

            migrationBuilder.DropIndex(
                name: "IX_UserVoucher_UserId",
                table: "UserVoucher");

            migrationBuilder.DropIndex(
                name: "IX_UserVoucher_VoucherId",
                table: "UserVoucher");

            migrationBuilder.DropIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_ShippingMethodBook_BookId",
                table: "ShippingMethodBook");

            migrationBuilder.DropIndex(
                name: "IX_ShippingMethodBook_ShippingMethodId",
                table: "ShippingMethodBook");

            migrationBuilder.DropIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken");

            migrationBuilder.DropIndex(
                name: "IX_Participant_ConversationId",
                table: "Participant");

            migrationBuilder.DropIndex(
                name: "IX_Participant_ParticipantId",
                table: "Participant");

            migrationBuilder.DropIndex(
                name: "IX_Participant_UserId",
                table: "Participant");

            migrationBuilder.DropIndex(
                name: "IX_FavoriteBook_BookId",
                table: "FavoriteBook");

            migrationBuilder.DropIndex(
                name: "IX_FavoriteBook_UserId",
                table: "FavoriteBook");

            migrationBuilder.DropIndex(
                name: "IX_EventBook_BookId",
                table: "EventBook");

            migrationBuilder.DropIndex(
                name: "IX_EventBook_DiscountEventId",
                table: "EventBook");

            migrationBuilder.DropIndex(
                name: "IX_DiscountEvent_DiscountEventId",
                table: "DiscountEvent");

            migrationBuilder.DropIndex(
                name: "IX_Conversation_UserDeleteId",
                table: "Conversation");

            migrationBuilder.DropIndex(
                name: "IX_ConfirmEmail_UserId",
                table: "ConfirmEmail");

            migrationBuilder.DropIndex(
                name: "IX_Collection_UserId",
                table: "Collection");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessageParticipantStates_ChatMessageId",
                table: "ChatMessageParticipantStates");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessageParticipantStates_ParticipantId",
                table: "ChatMessageParticipantStates");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessage_ConversationId",
                table: "ChatMessage");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessage_CreatorId",
                table: "ChatMessage");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessage_UserDeleteId",
                table: "ChatMessage");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_BookId",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_CartId",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_Cart_UserId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_BookReview_BookId",
                table: "BookReview");

            migrationBuilder.DropIndex(
                name: "IX_BookReview_UserId",
                table: "BookReview");

            migrationBuilder.DropIndex(
                name: "IX_Book_CategoryId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_CollectionId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_TopicBookId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_BillDetail_BillId",
                table: "BillDetail");

            migrationBuilder.DropIndex(
                name: "IX_BillDetail_BookId",
                table: "BillDetail");

            migrationBuilder.DropIndex(
                name: "IX_Bill_PaymentMethodId",
                table: "Bill");

            migrationBuilder.DropIndex(
                name: "IX_Bill_ShippingMethodId",
                table: "Bill");

            migrationBuilder.DropIndex(
                name: "IX_Bill_UserId",
                table: "Bill");

            migrationBuilder.DropIndex(
                name: "IX_Bill_UserVoucherId",
                table: "Bill");

            migrationBuilder.DropIndex(
                name: "IX_AddressUser_UserId",
                table: "AddressUser");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "UserVoucher");

            migrationBuilder.DropColumn(
                name: "ExpiredTime",
                table: "UserVoucher");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserVoucher");

            migrationBuilder.DropColumn(
                name: "VoucherId",
                table: "UserVoucher");

            migrationBuilder.DropColumn(
                name: "VoucherStatus",
                table: "UserVoucher");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "Banner",
                table: "TopicBook");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "TopicBook");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "ShippingMethodBook");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ShippingMethodBook");

            migrationBuilder.DropColumn(
                name: "ShippingMethodId",
                table: "ShippingMethodBook");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "ShippingMethod");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ShippingMethod");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ShippingMethod");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ShippingMethod");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "ShippingMethod");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "ExpiredTime",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "RankCustomer");

            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "RankCustomer");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "RankCustomer");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "PaymentMethod");

            migrationBuilder.DropColumn(
                name: "ConversationId",
                table: "Participant");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Participant");

            migrationBuilder.DropColumn(
                name: "ParticipantId",
                table: "Participant");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Participant");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "FavoriteBook");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "FavoriteBook");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "FavoriteBook");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FavoriteBook");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "EventBook");

            migrationBuilder.DropColumn(
                name: "DiscountEventId",
                table: "EventBook");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "DiscountEvent");

            migrationBuilder.DropColumn(
                name: "DiscountEventId",
                table: "DiscountEvent");

            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "DiscountEvent");

            migrationBuilder.DropColumn(
                name: "DiscoutEventStatus",
                table: "DiscountEvent");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "DiscountEvent");

            migrationBuilder.DropColumn(
                name: "EventName",
                table: "DiscountEvent");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "DiscountEvent");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "DiscountEvent");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Conversation");

            migrationBuilder.DropColumn(
                name: "Creator",
                table: "Conversation");

            migrationBuilder.DropColumn(
                name: "DeleteTime",
                table: "Conversation");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Conversation");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Conversation");

            migrationBuilder.DropColumn(
                name: "UserDeleteId",
                table: "Conversation");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "ContactText",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "Hotline",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "ConfirmCode",
                table: "ConfirmEmail");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "ConfirmEmail");

            migrationBuilder.DropColumn(
                name: "ExpiredTime",
                table: "ConfirmEmail");

            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                table: "ConfirmEmail");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ConfirmEmail");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Collection");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Collection");

            migrationBuilder.DropColumn(
                name: "NumberOfProducts",
                table: "Collection");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Collection");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Collection");

            migrationBuilder.DropColumn(
                name: "ChatMessageId",
                table: "ChatMessageParticipantStates");

            migrationBuilder.DropColumn(
                name: "IsSeen",
                table: "ChatMessageParticipantStates");

            migrationBuilder.DropColumn(
                name: "ParticipantId",
                table: "ChatMessageParticipantStates");

            migrationBuilder.DropColumn(
                name: "SeenTime",
                table: "ChatMessageParticipantStates");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "ChatMessage");

            migrationBuilder.DropColumn(
                name: "ConversationId",
                table: "ChatMessage");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "ChatMessage");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "ChatMessage");

            migrationBuilder.DropColumn(
                name: "DeleteTime",
                table: "ChatMessage");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ChatMessage");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "ChatMessage");

            migrationBuilder.DropColumn(
                name: "UserDeleteId",
                table: "ChatMessage");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "NumberOfProducts",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "BookReview");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "BookReview");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "BookReview");

            migrationBuilder.DropColumn(
                name: "NumberOfStars",
                table: "BookReview");

            migrationBuilder.DropColumn(
                name: "ReviewTime",
                table: "BookReview");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BookReview");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "InventoryNumber",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "ManufactureDate",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "NumberOfPages",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "PriceAfterDiscount",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "SoldQuantity",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "TopicBookId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "BillDetail");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "BillDetail");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "BillDetail");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "BillDetail");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "BillDetail");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "BillStatus",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "PayTime",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "PaymentMethodId",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "ReasonForRefusal",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "ShippingFee",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "ShippingMethodId",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "TotalPriceAfterDiscount",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "TotalPriceBeforeDiscount",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "TradingCode",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "UserVoucherId",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AddressUser");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "AddressUser");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AddressUser");
        }
    }
}
