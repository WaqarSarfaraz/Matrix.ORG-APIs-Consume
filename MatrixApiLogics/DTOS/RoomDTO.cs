using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixApiLogics.DTOS
{
  public  class RoomDTO
    {
        public List<detail> Rooms { get; set; }
    }
    public class detail
    {
        public string Roomid { get; set; }
        public string Name { get; set; }
    }
}
