﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wallet.Infrastructure.Data;

#nullable disable

namespace Wallet.Infrastructure.Migrations
{
    [DbContext(typeof(WalletDBContext))]
    partial class WalletDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("wallet.Domain.Entities.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("CompanyLocation")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CompanyNo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<float>("CompanyRate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasDefaultValue(0f);

                    b.HasKey("CompanyId");

                    b.ToTable("Company", (string)null);
                });

            modelBuilder.Entity("wallet.Domain.Entities.Label", b =>
                {
                    b.Property<int>("LabelId")
                        .HasColumnType("int");

                    b.Property<float>("CurrentAmount")
                        .HasMaxLength(100)
                        .HasColumnType("real");

                    b.Property<float>("DesiredAmount")
                        .HasMaxLength(100)
                        .HasColumnType("real");

                    b.Property<string>("LabelName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("WalletId")
                        .HasColumnType("int");

                    b.HasKey("LabelId");

                    b.HasIndex("WalletId");

                    b.ToTable("Label", (string)null);
                });

            modelBuilder.Entity("wallet.Domain.Entities.Notification", b =>
                {
                    b.Property<int>("NotifId")
                        .HasColumnType("int");

                    b.Property<string>("NotifMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NotificationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NotificationType")
                        .HasColumnType("int");

                    b.Property<int>("TransactionId1")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("NotifId");

                    b.HasIndex("TransactionId1");

                    b.HasIndex("UserId");

                    b.ToTable("Notification", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("wallet.Domain.Entities.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"));

                    b.Property<int>("LabelId")
                        .HasColumnType("int");

                    b.Property<int>("TransactionStatus")
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TransactionType")
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.Property<float>("TransactionValue")
                        .HasMaxLength(100)
                        .HasColumnType("real");

                    b.Property<int>("WalletId")
                        .HasColumnType("int");

                    b.HasKey("TransactionId");

                    b.HasIndex("LabelId");

                    b.HasIndex("WalletId");

                    b.ToTable("Transaction", (string)null);
                });

            modelBuilder.Entity("wallet.Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyID")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("UserPhone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("UserRole")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("UserId");

                    b.HasIndex("CompanyID");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("wallet.Domain.Entities.Voucher", b =>
                {
                    b.Property<int>("VoucherId")
                        .HasColumnType("int");

                    b.Property<int>("DestVoucherId")
                        .HasColumnType("int");

                    b.Property<float>("VoucherAmount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasDefaultValue(0f);

                    b.Property<DateTime>("VoucherDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("VoucherStatus")
                        .HasColumnType("int");

                    b.Property<int>("WalletId")
                        .HasColumnType("int");

                    b.HasKey("VoucherId");

                    b.HasIndex("WalletId");

                    b.ToTable("voucher", (string)null);
                });

            modelBuilder.Entity("wallet.Domain.Entities.WalletE", b =>
                {
                    b.Property<int>("WalletId")
                        .HasColumnType("int");

                    b.Property<bool>("IsBlocked")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<float>("WalletBalance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasDefaultValue(0f);

                    b.Property<int>("WalletType")
                        .HasColumnType("int");

                    b.HasKey("WalletId");

                    b.HasIndex("UserId");

                    b.ToTable("WalletE", (string)null);
                });

            modelBuilder.Entity("wallet.Domain.Entities.EmailNotification", b =>
                {
                    b.HasBaseType("wallet.Domain.Entities.Notification");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.ToTable("EmailNotification", (string)null);
                });

            modelBuilder.Entity("wallet.Domain.Entities.PushNotification", b =>
                {
                    b.HasBaseType("wallet.Domain.Entities.Notification");

                    b.Property<string>("DeviceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("PushNotification", (string)null);
                });

            modelBuilder.Entity("wallet.Domain.Entities.SMSNotification", b =>
                {
                    b.HasBaseType("wallet.Domain.Entities.Notification");

                    b.Property<string>("Phonenumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("SMSNotification", (string)null);
                });

            modelBuilder.Entity("wallet.Domain.Entities.Label", b =>
                {
                    b.HasOne("wallet.Domain.Entities.WalletE", "Wallet")
                        .WithMany("Labels")
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("wallet.Domain.Entities.Notification", b =>
                {
                    b.HasOne("wallet.Domain.Entities.Transaction", "Transaction")
                        .WithMany()
                        .HasForeignKey("TransactionId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wallet.Domain.Entities.User", null)
                        .WithMany("Notifications")
                        .HasForeignKey("UserId");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("wallet.Domain.Entities.Transaction", b =>
                {
                    b.HasOne("wallet.Domain.Entities.Label", "Label")
                        .WithMany("Transactions")
                        .HasForeignKey("LabelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wallet.Domain.Entities.WalletE", "Wallet")
                        .WithMany("Transactions")
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Label");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("wallet.Domain.Entities.User", b =>
                {
                    b.HasOne("wallet.Domain.Entities.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("wallet.Domain.Entities.Voucher", b =>
                {
                    b.HasOne("wallet.Domain.Entities.WalletE", "Wallet")
                        .WithMany("Vouchers")
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("wallet.Domain.Entities.WalletE", b =>
                {
                    b.HasOne("wallet.Domain.Entities.User", "User")
                        .WithMany("Wallets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("wallet.Domain.Entities.EmailNotification", b =>
                {
                    b.HasOne("wallet.Domain.Entities.Notification", null)
                        .WithOne()
                        .HasForeignKey("wallet.Domain.Entities.EmailNotification", "NotifId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("wallet.Domain.Entities.PushNotification", b =>
                {
                    b.HasOne("wallet.Domain.Entities.Notification", null)
                        .WithOne()
                        .HasForeignKey("wallet.Domain.Entities.PushNotification", "NotifId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("wallet.Domain.Entities.SMSNotification", b =>
                {
                    b.HasOne("wallet.Domain.Entities.Notification", null)
                        .WithOne()
                        .HasForeignKey("wallet.Domain.Entities.SMSNotification", "NotifId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("wallet.Domain.Entities.Company", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("wallet.Domain.Entities.Label", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("wallet.Domain.Entities.User", b =>
                {
                    b.Navigation("Notifications");

                    b.Navigation("Wallets");
                });

            modelBuilder.Entity("wallet.Domain.Entities.WalletE", b =>
                {
                    b.Navigation("Labels");

                    b.Navigation("Transactions");

                    b.Navigation("Vouchers");
                });
#pragma warning restore 612, 618
        }
    }
}
