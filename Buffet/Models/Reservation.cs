using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Models
{
    public class Reservation
    {
        //Id
        public int Id { get; set; }

        //Dato
        public DateTime Date { get; set; }

        //Antal Voksne
        public int Adults { get; set; }

        //Antal Børn
        public int Children { get; set; }
    }
}
