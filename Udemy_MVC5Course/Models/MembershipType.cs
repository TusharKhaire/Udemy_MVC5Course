﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Udemy_MVC5Course.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short Signupfee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

    }
}