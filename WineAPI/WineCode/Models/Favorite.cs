using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineCode.Models
{
    public class Favorite
    {
        public int FavoriteId { get; set; }
        public List<Wine> Favorites { get; set; } = new List<Wine>();
       
    }
}
