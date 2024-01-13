using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.DTOs;

namespace Wallet.Application.Contracts
{
    public interface ILabel
    {
        string CreateLabel(LabelDto Label,string labelName, float desiredAmount, int WalletId);
        string UpdateLabel(LabelDto labeldto);
        string DeleteLabel(LabelDto labeldto);
        LabelDto GetLabel(int labelId);
        List<LabelDto> GetAllLabels();
    }
}
