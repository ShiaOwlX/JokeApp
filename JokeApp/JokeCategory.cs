using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeApp
{
    [Flags]
    public enum JokeCategory
    {
        Any = 0,
        Programming = 1,
        Miscellaneous = 2,
        Dark = 4,
        Pun = 8,
        Spooky = 16,
        Christmas = 32
    }

}
