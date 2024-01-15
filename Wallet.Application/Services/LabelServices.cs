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
using Wallet.Application.Services;
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
        public string CreateLabel(LabelDto labeldto, int walledId)
        {
            var label = _mapper.Map<wallet.Domain.Entities.Label>(labeldto);
            var wallet = _dbContext.Wallets.FirstOrDefault(w => w.WalletId == w.WalletId);
            if (wallet == null) { return "wallet not found"; }

            if ((label.DesiredAmount < wallet.WalletBalance) && (label.CurrentAmount < wallet.WalletBalance))
            {
                label.WalletId = walledId;
                label.Wallet = wallet; ;
                _dbContext.Add(label);
                _dbContext.SaveChanges();
                return "label was created";
            }
            return "the value of label more than wallet balance";
            
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
            var label = _mapper.Map<wallet.Domain.Entities.Label>(labeldto);
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
