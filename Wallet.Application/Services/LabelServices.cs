using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Contracts;
using Wallet.Application.DTOs;
using Wallet.Infrastructure.Data;
using wallet.Domain.Entities;
using Label = wallet.Domain.Entities.Label;

namespace Wallet.Application.Services
{
    public class LabelServices : ILabel
    {
        private readonly WalletDBContext _dbContext;
        private readonly IMapper _mapper;
        public LabelServices(WalletDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper= mapper;
        }
        public string CreateLabel(LabelDto labeldto,string labelName, float desiredAmount, int WalletId)
        {
            var wallet = _dbContext.Wallets.FirstOrDefault(w => w.WalletId == WalletId);
            if (wallet == null) { return "wallet not found"; }

            var label = _mapper.Map<Label>(labeldto);
            label.LabelName = labelName;
            label.DesiredAmount = desiredAmount;
            label.WalletId = WalletId;
            label.Wallet = wallet;
            _dbContext.Add(label);
            _dbContext.SaveChanges();
            return "label was created";
        }

        public string DeleteLabel(string labelName)
        {
            throw new NotImplementedException();
        }

        public List<LabelDto> GetAllLabels()
        {
            throw new NotImplementedException();
        }

        public LabelDto GetLabel(string labelName)
        {
            throw new NotImplementedException();
        }

        public string UpdateLabel(string labelName, float currentDesiredAmount)
        {
            throw new NotImplementedException();
        }
    }
}
