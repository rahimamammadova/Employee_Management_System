﻿using EMS_DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DAL.Dtos
{
    public class EmployeeSystemAppDto:BaseDto
    {
        public Guid EmployeeId { get; set; }
        [Display(Name = "Employee name")]
        public string EmployeeName { get; set; }
        [Display(Name = "System title")]
        public Guid SystemAppId { get; set; }
        public string SystemAppTitle { get; set; }
    }
}
