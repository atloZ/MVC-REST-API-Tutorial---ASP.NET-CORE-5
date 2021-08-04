﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformDemo.Models
{
    public class Ticket
    {
        [FromQuery(Name ="tId")]
        public int TicketId { get; set; }
        [FromRoute(Name ="pId")]
        public int ProjektId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
