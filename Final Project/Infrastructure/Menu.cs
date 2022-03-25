using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Infrastructure
{
    public enum Menu:byte
    {
        
        MarkaAdd=1,
        MarkaEdit,
        MarkaRemove,
        MarkaSingle,
        MarkasAll,


        ModelAdd,
        ModelEdit,
        ModelRemove,
        ModelSingle,
        ModelsAll,

        CarAdd,
        CarEdit,
        CarRemove,
        CarSingle,
        CarAll,

        All,
        Exit

    }
}
