using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Models
{
    public class CheckedIn
    {
        //Id
        public int Id { get; set; }

        //Dato
        public DateTime Date { get; set; }

        //Værelsesnummer
        public string RoomNumber { get; set; }

        //Antal Voksne
        public int Adults { get; set; }

        //Antal Børn
        public int Children { get; set; }
    }
}
