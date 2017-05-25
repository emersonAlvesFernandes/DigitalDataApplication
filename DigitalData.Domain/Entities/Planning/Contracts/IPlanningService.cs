using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.Entities.Planning.Contracts
{
    public interface IPlanningService
    {
        Planning Create(int companyId, int itemId, int? subItemId, Planning planning);

        IEnumerable<Planning> GetSubItemPlanning(int companyId, int itemId, int subItemId);

        IEnumerable<Planning> GetItemPlanning(int companyId, int itemId);

        Planning Get(int idPlanning);

        Planning Update(int idPlanning, Planning planning);

        bool Delete(int idPlanning);
    }
}
