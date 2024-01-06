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
        string CreateLabel(string labelName, float desiredAmount);
        string UpdateLabel(string labelName, float currentDesiredAmount);
        string DeleteLabel(string labelName);
        LabelDto GetLabel(string labelName);
        List<LabelDto> GetAllLabels();
    }
}
