using Microsoft.AspNetCore.Mvc;
using Wallet.Application.Services;
using Wallet.Application.Contracts;
using wallet.Domain.Entities;
using Wallet.Application.DTOs;

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



        public WalletController(IWallet WalletService, IUser UserService, ICompany CompanyService, IVoucher VoucherService, ILabel LabelService, INotification NotificationService, ITransaction transactionService)
        {
            this.WalletService = WalletService;
            this.UserService = UserService;
            this.CompanyService = CompanyService;
            this.VoucherService = VoucherService;
            this.LabelService = LabelService;
            this.NotificationService = NotificationService;
            this.TransactionService = transactionService;
        }

        //WALLET
        [HttpPost]
        [Route("AddWallet")]
        public ActionResult<string> AddWallet(WalletEDto walletDto, int companyId)
        {
            var response = WalletService.CreateWallet(walletDto, companyId);
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
        public ActionResult<string> AddLabel(LabelDto labeldto, string labelName, float desiredAmount, int WalletId)
        {
            var response = LabelService.CreateLabel(labeldto,labelName,desiredAmount,WalletId);
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
            var vouchers = VoucherService.GetVouchers();
            return Ok(vouchers);
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
        [HttpPost]
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
        }
        // END OF NOTIFICAIION METHOd

        // ///////////////////////////////////transaction/////////////////////////////////////////////////////

        [HttpGet]
        [Route("GetTransaction")]
        public ActionResult<NotificationDto> GetTransaction(int transactionId)
        {
            var transaction = TransactionService.GetTransaction(transactionId);
            return Ok(transaction);
        }

        [HttpGet]
        [Route("GetALLTransactions")]
        public ActionResult<List<NotificationDto>> GetAllTransactions()
        {
            var transactions = TransactionService.GetALLTransactions();
            return Ok(transactions);
        }

        [HttpPost]
        [Route("DepositTransaction")]
        public ActionResult<string> Deposit(int walletId, float amount, LabelDto labeldto)
        {
            var response = TransactionService.Deposit(walletId, amount,labeldto);
            return Ok(response);
        }
        [HttpPost]
        [Route("WithDrawTransaction")]
        public ActionResult<string> Withdraw(int walletId, float amount, LabelDto labeldto)
        {
            var response = TransactionService.Withdraw(walletId, amount,labeldto);
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
    }
}
