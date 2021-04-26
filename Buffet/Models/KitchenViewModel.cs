using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Buffet.Models
{
    public class KitchenViewModel
    {
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public IEnumerable<Reservation> Reservations { get; set; }
        public IEnumerable<CheckedIn> CheckedIns { get; set; }

        public int ExpectedChildren => Reservations.Sum(r => r.Children);
        public int ExpectedAdults => Reservations.Sum(r => r.Adults);
        public int ExpectedGuests => ExpectedChildren + ExpectedAdults;
        public int ChildrenCheckedIn => CheckedIns.Sum(c => c.Children);
        public int AdultsCheckedIn => CheckedIns.Sum(c => c.Adults);
        public int ChildrenNotCheckedIn => ExpectedChildren - ChildrenCheckedIn;
        public int AdultsNotCheckedIn => ExpectedAdults - AdultsCheckedIn;
        public int TotalNotCheckedIn => ChildrenNotCheckedIn + AdultsNotCheckedIn;

    }
}