using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Contracts;
using Wallet.Application.DTOs;
using Wallet.Infrastructure.Data;
using wallet.Domain.Entities;
using System.ComponentModel.Design;


namespace Wallet.Application.Services
{
    public class VoucherServices : IVoucher
    {
        private readonly WalletDBContext _dbContext;
        private readonly IMapper _mapper;
        public VoucherServices(WalletDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public string CreateVoucher(VoucherDto voucherdto, int voucherDest, int walletid)
        {
            var wallet = _dbContext.Wallets.FirstOrDefault(w => w.WalletId == walletid);
            if (wallet == null) { return "wallet not found"; }
            var voucher = _mapper.Map<Voucher>(voucherdto);
            voucher.Wallet = wallet;
            voucher.WalletId = walletid; // the source wallet which published voucher
            voucher.DestVoucherId = voucherDest;
            _dbContext.Add(voucher);
            _dbContext.SaveChanges();
            return "voucher was created";
        }
        public List<VoucherDto> GetVouchers()
        {
            var vouchers = _dbContext.Vouchers.ToList();
            var voucherDtos = _mapper.Map<List<VoucherDto>>(vouchers);
            return voucherDtos;
        }
        public VoucherDto GetVoucher(int voucherId)
        {
            var voucher = _dbContext.Vouchers.FirstOrDefault(v => v.VoucherId == voucherId);
            if (voucher == null)
            {
                throw new VoucherNotFoundException("Voucher with ID {voucherId} not found", voucherId);
            }
            voucher.VoucherId = voucherId;
            var voucherdto = _mapper.Map<VoucherDto>(voucher);
            return voucherdto;
        }

        public string UpdateVoucher(VoucherDto voucherdto)
        {
            var voucher = _mapper.Map<Voucher>(voucherdto);
            _dbContext.Vouchers.Update(voucher);
            _dbContext.SaveChanges();
            return "voucher was updated";
        }


        public string DeleteVoucher(int voucherID)
        {
            var voucher = _dbContext.Vouchers.FirstOrDefault(c => c.VoucherId == voucherID);
            _dbContext.Vouchers.Remove(voucher);
            _dbContext.SaveChanges();
            return "voucher was removed";
        }
    }
    public class VoucherNotFoundException : Exception
    {
        public VoucherNotFoundException(string message, int id) : base(message) { }
    }
}
