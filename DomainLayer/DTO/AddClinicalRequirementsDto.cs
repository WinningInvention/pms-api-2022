﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class AddClinicalRequirementsDto
    {
        public int PatientBedId { get; set; }
        public string ClinicalRequirements { get; set; }
    }
}
