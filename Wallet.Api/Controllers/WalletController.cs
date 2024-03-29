﻿using Microsoft.AspNetCore.Mvc;
using Wallet.Application.Services;
using Wallet.Application.Contracts;
using wallet.Domain.Entities;
using Wallet.Application.DTOs;
using AutoMapper.Internal.Mappers;
using System.ComponentModel.Design;
using wallet.Domain.Entities;
using wallet.Domain.Enums;

namespace Wallet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : Controller
    {

        private readonly IWallet WalletService;
        private readonly IUser UserService;
        private readonly ICompany CompanyService;
        private readonly IVoucher VoucherService;
        private readonly ILabel LabelService;
        private readonly INotification NotificationService;
        private readonly ITransaction TransactionService;
        private readonly ISearchUser SearchUser;
        private readonly ISearchCompany SearchCompany;
        private readonly ISearchWalletE SearchWallet;
        private readonly ISearchTransaction SearchTransaction;
        private readonly ISearchEngine SearchEngine;



        public WalletController(IWallet WalletService, IUser UserService, ICompany CompanyService, IVoucher VoucherService, ILabel LabelService, INotification NotificationService, ITransaction TransactionService, ISearchCompany SearchCompany, ISearchTransaction SearchTransaction, ISearchUser SearchUser, ISearchWalletE SearchWallet
            )
        {
            this.WalletService = WalletService;
            this.UserService = UserService;
            this.CompanyService = CompanyService;
            this.VoucherService = VoucherService;
            this.LabelService = LabelService;
            this.NotificationService = NotificationService;
            this.TransactionService = TransactionService;
            this.SearchCompany = SearchCompany;
            this.SearchTransaction = SearchTransaction;
            this.SearchUser = SearchUser;
            this.SearchWallet = SearchWallet;
        }

        //WALLET
        [HttpPost]
        [Route("AddWallet")]
        public ActionResult<string> AddWallet(WalletEDto walletDto, int userId)
        {
            var response = WalletService.CreateWallet(walletDto, userId);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetWallet")]
        public ActionResult<WalletEDto> GetWallet(int walletId)
        {
            var wallet = WalletService.GetWallet(walletId);
            return Ok(wallet);
        }

        [HttpGet]
        [Route("GetWallets")]
        public ActionResult<List<WalletEDto>> GetWallets()
        {
            var wallets = WalletService.GetWallets();
            return Ok(wallets);
        }

        [HttpGet]
        [Route("GetWalletBalance")]
        public ActionResult<float> GetBalance(int walletId)
        {
            var balance = WalletService.GetBalance(walletId);
            return Ok(balance);
        }

        [HttpGet]
        [Route("GetLabelsOfWallet")]
        public ActionResult<List<LabelDto>> GetLabels(int walletId)
        {
            var wallets = WalletService.GetLabels(walletId);
            return Ok(wallets);
        }
        [HttpDelete]
        [Route("DeleteWallet")]
        public ActionResult<string> DeleteWallet(int walletId)
        {
            var response = WalletService.DeleteWallet(walletId);
            return Ok(response);
        }
        // END WALLET METHODS

        // ///////////////////////////////////////////USER//////////////////////////////////////////////////
        [HttpPost]
        [Route("AddUser")]
        public ActionResult<string> AddUser(UserDto userDto, int CompanyId)
        {
            var response = UserService.CreateUser(userDto, CompanyId);
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateUser")]
        public ActionResult<string> UpdateUser(UserDto userDto)
        {
            var response = UserService.UpdateUser(userDto);
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public ActionResult<string> DeleteUser(int userId)
        {
            var user = UserService.DeleteUser(userId);
            return Ok(user);
        }

        [HttpGet]
        [Route("GetUsers")]
        public ActionResult<List<UserDto>> GetUsers()
        {
            var users = UserService.GetALLUsers();
            return Ok(users);
        }

        [HttpGet]
        [Route("GetUser")]
        public ActionResult<UserDto> GetUser(int UserId)
        {
            var user = UserService.GetUser(UserId);
            return Ok(user);
        }
        //End of user methods

        // ///////////////////////////////////////////Company//////////////////////////////////////////////
        [HttpPost]
        [Route("AddCompany")]
        public ActionResult<string> AddCompany(CompanyDto companyDto)
        {
            var response = CompanyService.CreateCompany(companyDto);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetCompany")]
        public ActionResult<CompanyDto> GetCompany(int companyId)
        {
            var company = CompanyService.GetCompany(companyId);
            return Ok(company);
        }

        [HttpGet]
        [Route("GetALLCompanies")]
        public ActionResult<List<CompanyDto>> GetALLCompanies()
        {
            var companies = CompanyService.GetALLCompanies();
            return Ok(companies);
        }
        [HttpPut]
        [Route("UpdateCompany")]
        public ActionResult<string> UpdateCompany(CompanyDto companyDto)
        {
            var response = CompanyService.UpdateCompany(companyDto);
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteCompany")]
        public ActionResult<string> DeleteCompany(int companyId)
        {
            var response = CompanyService.DeleteCompany(companyId);
            return Ok(response);
        }

        //End of company methods

        // /////////////////////////////////////label//////////////////////////////////////////////////////
        [HttpPost]
        [Route("AddLabel")]
        public ActionResult<string> AddLabel(LabelDto labeldto, int walletID)
        {
            var response = LabelService.CreateLabel(labeldto,walletID);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetLabel")]
        public ActionResult<LabelDto> GetLabel(int labelId)
        {
            var label = LabelService.GetLabel(labelId);
            return Ok(label);
        }

        [HttpGet]
        [Route("GetALLLabels")]
        public ActionResult<List<LabelDto>> GetALLLabels()
        {
            var labels = LabelService.GetAllLabels();
            return Ok(labels);
        }
        [HttpPut]
        [Route("UpdateLabel")]
        public ActionResult<string> UpdateLabel(LabelDto labelDto)
        {
            var response = LabelService.UpdateLabel(labelDto);
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteLabel")]
        public ActionResult<string> DeleteLabel(int labelId)
        {
            var response = LabelService.DeleteLabel(labelId);
            return Ok(response);
        }

        //End of voucher methods 

        // ////////////////////////////////////voucher//////////////////////////////////////////////////
        [HttpPost]
        [Route("AddVoucher")]
        public ActionResult<string> AddVoucher(VoucherDto voucherDto, int walltDest, int walletId)
        {
            var response = VoucherService.CreateVoucher(voucherDto, walltDest, walletId);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetVoucher")]
        public ActionResult<VoucherDto> GetVoucher(int voucherId)
        {
            var voucher = VoucherService.GetVoucher(voucherId);
            return Ok(voucher);
        }

        [HttpGet]
        [Route("GetALLVouchers")]
        public ActionResult<List<VoucherDto>> GetALLVouchers()
        {
            var vouchers = VoucherService.GetVouchers();
            return Ok(vouchers);
        }
        [HttpPut]
        [Route("UpdateVoucher")]
        public ActionResult<string> UpdateVoucher(VoucherDto voucherDto)
        {
            var response = VoucherService.UpdateVoucher(voucherDto);
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteVoucher")]
        public ActionResult<string> DeleteVoucher(int voucherId)
        {
            var response = VoucherService.DeleteVoucher(voucherId);
            return Ok(response);
        }

        //  END OF VOUCHER METHODS 
        // ///////////////////////////////Notification/////////////////////////////////////////////////
        /*[HttpPost]
        [Route("Notify")]
        public ActionResult<string> Notify(NotificationDto Notif, int transactionId, string message)
        {
            var response = NotificationService.Notify(Notif, transactionId, message);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetNotification")]
        public ActionResult<NotificationDto> GetNotification(int notifId)
        {
            var notification = NotificationService.GetNotification(notifId);
            return Ok(notification);
        }

        [HttpGet]
        [Route("GetALLNotifications")]
        public ActionResult<List<NotificationDto>> GetAllNotifications()
        {
            var notifications = NotificationService.GetAllNotifications();
            return Ok(notifications);
        }*/
        // END OF NOTIFICAIION METHOd

        // ///////////////////////////////////transaction/////////////////////////////////////////////////////

        [HttpGet]
        [Route("GetTransaction")]
        public ActionResult<TransactionDto> GetTransaction(int transactionId)
        {
            var transaction = TransactionService.GetTransaction(transactionId);
            return Ok(transaction);
        }

        [HttpGet]
        [Route("GetALLTransactions")]
        public ActionResult<List<TransactionDto>> GetAllTransactions()
        {
            var transactions = TransactionService.GetALLTransactions();
            return Ok(transactions);
        }

        [HttpPost]
        [Route("DepositTransaction")]
        public ActionResult<string> Deposit(int walletId, float amount, string? labelname)
        {
            var response = TransactionService.Deposit(walletId, amount,labelname);
            return Ok(response);
        }
        [HttpPost]
        [Route("WithDrawTransaction")]
        public ActionResult<string> Withdraw(int walletId, float amount, string? labelname)
        {
            var response = TransactionService.Withdraw(walletId, amount,labelname);
            return Ok(response);
        }
        [HttpPost]
        [Route("MoveTransaction")]
        public ActionResult<string> Move(int sourceWalletId, int destWalletId, float amount)
        {
            var response = TransactionService.Move(sourceWalletId, destWalletId, amount);
            return Ok(response);
        }

        // END OF THE TRANSACTION METHODS
        /////////////// /////////////////Search company ///////////////////////////////////////////////
        [HttpGet]
        [Route("CompanybyNumber")]
        public ActionResult<CompanyDto> GetCompanybyCompanyNo(string CompanyNo)
        {
            var companies = SearchCompany.GetCompanybyCompanyNo(CompanyNo);
            return Ok(companies);
        }

        [HttpGet]
        [Route("CompanybyId")]
        public ActionResult<CompanyDto> GetCompanybyId(int CompanyId)
        {
            var companies = SearchCompany.GetCompanybyId(CompanyId);
            return Ok(companies);
        }
        [HttpGet]
        [Route("CompanybyLocation")]
        public ActionResult<CompanyDto> GetCompanybyLocation(string CompanyLocation)
        {
            var companies = SearchCompany.GetCompanybyLocation(CompanyLocation);
            return Ok(companies);
        }
        [HttpGet]
        [Route("CompanybyRate")]
        public ActionResult<CompanyDto> GetCompanybyRate(float CompanyRate)
        {
            var companies = SearchCompany.GetCompanybyRate(CompanyRate);
            return Ok(companies);
        }
        [HttpGet]
        [Route("CompanybyName")]
        public ActionResult<CompanyDto> GetCompanybyName(string CompanyName)
        {
            var companies = SearchCompany.GetCompanybyName(CompanyName);
            return Ok(companies);
        }
        // END OF COMPANY METHODS
        //////////////////////////////WALLET SEARCH////////////////////////////////////////////////
        [HttpGet]
        [Route("WalletbyId")]
        public ActionResult<WalletEDto> GetWalletbyId(int WalletID)
        {
            var wallet = SearchWallet.GetWalletbyId(WalletID);
            return Ok(wallet);
        }

        [HttpGet]
        [Route("WalletbyUserId")]
        public ActionResult<List<WalletEDto>> GetWalletbyUserId(int UserId)
        {
            var wallets = SearchWallet.GetWalletbyUserId(UserId);
            return Ok(wallets);
        }
        [HttpGet]
        [Route("WalletbyBalance")]
        public ActionResult<List<WalletEDto>> GetWalletbyBalance(float WalletBalance)
        {
            var wallets = SearchWallet.GetWalletbyBalance(WalletBalance);
            return Ok(wallets);
        }
        [HttpGet]
        [Route("WalletbyState")]
        public ActionResult<List<WalletEDto>> GetWalletbyState(bool State)
        {
            var wallets = SearchWallet.GetWalletbyState(State);
            return Ok(wallets);
        }
        //    END OF WALLET SEARCH METHOS
        /////////////////////////////////Search user//////////////////////////////////////////////////
        [HttpGet]
        [Route("UserbyId")]
        public ActionResult<UserDto> GetUserbyId(int userID)
        {
            var user = SearchUser.GetUserbyId(userID);
            return Ok(user);
        }

        [HttpGet]
        [Route("UserbyUsername")]
        public ActionResult<UserDto> GetUserbyUsername(string userName)
        {
            var user = SearchUser.GetUserbyUsername(userName);
            return Ok(user);
        }
        [HttpGet]
        [Route("UserbyPhone")]
        public ActionResult<UserDto> GetUserbyPhone(string userPhone)
        {
            var user = SearchUser.GetUserbyPhone(userPhone);
            return Ok(user);
        }
        [HttpGet]
        [Route("UserbyCompany")]
        public ActionResult<List<UserDto>> GetUsersbyCompany(int companyID)
        {
            var users = SearchUser.GetUsersbyCompany(companyID);
            return Ok(users);
        }
        [HttpGet]
        [Route("UserbyWallet")]
        public ActionResult<UserDto> GetUserbywallet(int walletId)
        {
            var users = SearchUser.GetUsersbyCompany(walletId);
            return Ok(users);
        }
        [HttpGet]
        [Route("UserbyRole")]
        public ActionResult<UserDto> GetUserbyRole(string userRole)
        {
            var users = SearchUser.GetUserbyRole(userRole);
            return Ok(users);
        }
        //  END OF USER SEARCH METHODS 
        //////////////////////////////// TRANSACTION SEARCH METHODS ////////////////////////////////////
        [HttpGet]
        [Route("TransactionbyId")]
        public ActionResult<TransactionDto> GetTransactionbyId(int TransactionId)
        {
            var transaction = SearchTransaction.GetTransactionbyId(TransactionId);
            return Ok(transaction);
        }
        [HttpGet]
        [Route("TransactionbyType")]
        public ActionResult<TransactionDto> GetTransactionbyType(TransactionType TransactionType)
        {
            var transactions = SearchTransaction.GetTransactionbyType(TransactionType);
            return Ok(transactions);
        }
        [HttpGet]
        [Route("TransactionbyTime")]
        public ActionResult<TransactionDto> GetTransactionbyTime(DateTime TransactionTime)
        {
            var transactions = SearchTransaction.GetTransactionbyTime(TransactionTime);
            return Ok(transactions);
        }
        [HttpGet]
        [Route("TransactionbyValue")]
        public ActionResult<List<TransactionDto>> GetTransactionbyValue(float TransactionValue)
        {
            var transactions = SearchTransaction.GetTransactionbyValue(TransactionValue);
            return Ok(transactions);
        }
        [HttpGet]
        [Route("TransactionbyWallet")]
        public ActionResult<List<TransactionDto>> GetTransactionbyWallet(int WalletId)
        {
            var transactions = SearchTransaction.GetTransactionbyValue(WalletId);
            return Ok(transactions);
        }
        
        [HttpGet]
        [Route("TransactionbyStatus")]
        public ActionResult<List<TransactionDto>> GetTransactionbyWalletStatus(Status status)
        {
            var transactions = SearchTransaction.GetTransactionbyWalletStatus(status);
            return Ok(transactions);
        }
        // END OF SEARCH TRANSACTION METHODS
        //////////////   








    }
}
