using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepoget<CLASS, ID>
    {
        CLASS GetByUserId(ID id);
        List<CLASS> GetAllByUserId(ID id);
    }
}
