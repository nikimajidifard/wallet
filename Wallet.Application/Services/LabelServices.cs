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
using static Wallet.Application.Services.UserServices;
using System.ComponentModel.Design;

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

        public List<LabelDto> GetAllLabels()
        {
            var labels = _dbContext.Labels.ToList();
            var LabelDtos = _mapper.Map<List<LabelDto>>(labels);
            return LabelDtos;
        }


        public LabelDto GetLabel(int labelId)
        {
            var label = _dbContext.Labels.FirstOrDefault(l => l.LabelId == l.LabelId);
            if (label == null)
            {
                throw new LabelNotFoundException("label with ID {labelId} not found", labelId);
            }
            label.LabelId = labelId;
            var labeldto = _mapper.Map<LabelDto>(label);
            return labeldto;
        }
        public string UpdateLabel(LabelDto labeldto)
        {
            var label = _mapper.Map<Label>(labeldto);
            _dbContext.Labels.Update(label);
            _dbContext.SaveChanges();
            return "label was updated";

        }

        public string DeleteLabel(int labelId)
        {
            var label = _dbContext.Labels.FirstOrDefault(c => c.LabelId == labelId);
            _dbContext.Labels.Remove(label);
            _dbContext.SaveChanges();
            return "label was removed";

        }
    }
    public class LabelNotFoundException : Exception
    {
        public LabelNotFoundException(string message, int id) : base(message) { }
    }
}
