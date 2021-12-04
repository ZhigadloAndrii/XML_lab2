using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scientists
{
    public interface IStrategy
    {
        List<Scientist> Search(Scientist _scientist, string path);
    }
}
