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
        string CreateLabel(string LabelName, float DesiredAmount);
        string UpdateLabel(string LabelName, float CurrentDesiredAmount);
        string DeleteLabel(string LabelName);
        LabelDto GetLabel(string LabelName);
        List<LabelDto> GetAllLabels();
    }
}
