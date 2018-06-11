using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebServices.Models
{
    public class Reservation
    {
        [Required]
        public int ReservationId { get; set; }
        [Required]
        public string ClientName { get; set; }
        [Required]
        public string Location { get; set; }

    }
}