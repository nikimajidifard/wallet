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
        string CreateLabel(LabelDto labeldto, int walledId);
        string UpdateLabel(LabelDto labeldto);
        string DeleteLabel(int labelId);
        LabelDto GetLabel(int labelId);
        List<LabelDto> GetAllLabels();
    }
}
