using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wallet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyLocation = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CompanyRate = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    CompanyNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UserPhone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UserRole = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WalletE",
                columns: table => new
                {
                    WalletId = table.Column<int>(type: "int", nullable: false),
                    WalletBalance = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    WalletType = table.Column<int>(type: "int", nullable: false),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletE", x => x.WalletId);
                    table.ForeignKey(
                        name: "FK_WalletE_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Label",
                columns: table => new
                {
                    LabelId = table.Column<int>(type: "int", nullable: false),
                    LabelName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DesiredAmount = table.Column<float>(type: "real", maxLength: 100, nullable: false),
                    CurrentAmount = table.Column<float>(type: "real", maxLength: 100, nullable: false),
                    WalletId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Label", x => x.LabelId);
                    table.ForeignKey(
                        name: "FK_Label_WalletE_WalletId",
                        column: x => x.WalletId,
                        principalTable: "WalletE",
                        principalColumn: "WalletId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "voucher",
                columns: table => new
                {
                    VoucherId = table.Column<int>(type: "int", nullable: false),
                    DestVoucherId = table.Column<int>(type: "int", nullable: false),
                    VoucherDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VoucherStatus = table.Column<int>(type: "int", nullable: false),
                    VoucherAmount = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    WalletId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voucher", x => x.VoucherId);
                    table.ForeignKey(
                        name: "FK_voucher_WalletE_WalletId",
                        column: x => x.WalletId,
                        principalTable: "WalletE",
                        principalColumn: "WalletId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionType = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    TransactionStatus = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    TransactionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionValue = table.Column<float>(type: "real", maxLength: 100, nullable: false),
                    WalletId = table.Column<int>(type: "int", nullable: false),
                    LabelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transaction_Label_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Label",
                        principalColumn: "LabelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_WalletE_WalletId",
                        column: x => x.WalletId,
                        principalTable: "WalletE",
                        principalColumn: "WalletId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    NotifId = table.Column<int>(type: "int", nullable: false),
                    NotificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NotificationType = table.Column<int>(type: "int", nullable: false),
                    NotifMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionId1 = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.NotifId);
                    table.ForeignKey(
                        name: "FK_Notification_Transaction_TransactionId1",
                        column: x => x.TransactionId1,
                        principalTable: "Transaction",
                        principalColumn: "TransactionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notification_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "EmailNotification",
                columns: table => new
                {
                    NotifId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailNotification", x => x.NotifId);
                    table.ForeignKey(
                        name: "FK_EmailNotification_Notification_NotifId",
                        column: x => x.NotifId,
                        principalTable: "Notification",
                        principalColumn: "NotifId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PushNotification",
                columns: table => new
                {
                    NotifId = table.Column<int>(type: "int", nullable: false),
                    DeviceId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PushNotification", x => x.NotifId);
                    table.ForeignKey(
                        name: "FK_PushNotification_Notification_NotifId",
                        column: x => x.NotifId,
                        principalTable: "Notification",
                        principalColumn: "NotifId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SMSNotification",
                columns: table => new
                {
                    NotifId = table.Column<int>(type: "int", nullable: false),
                    Phonenumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMSNotification", x => x.NotifId);
                    table.ForeignKey(
                        name: "FK_SMSNotification_Notification_NotifId",
                        column: x => x.NotifId,
                        principalTable: "Notification",
                        principalColumn: "NotifId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Label_WalletId",
                table: "Label",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_TransactionId1",
                table: "Notification",
                column: "TransactionId1");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UserId",
                table: "Notification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_LabelId",
                table: "Transaction",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_WalletId",
                table: "Transaction",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CompanyID",
                table: "User",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_voucher_WalletId",
                table: "voucher",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletE_UserId",
                table: "WalletE",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailNotification");

            migrationBuilder.DropTable(
                name: "PushNotification");

            migrationBuilder.DropTable(
                name: "SMSNotification");

            migrationBuilder.DropTable(
                name: "voucher");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Label");

            migrationBuilder.DropTable(
                name: "WalletE");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
