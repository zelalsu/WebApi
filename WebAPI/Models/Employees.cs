﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Employees
    {//veritabanındaki columnların get set edilevilmesi
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public string MailId { get; set; }
        public DateTime? DOJ { get; set; }//boş geçebilir olması için ? eklenir
    }
}