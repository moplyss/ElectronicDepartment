﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDepartment.Web.Shared.Cafedra.Responce
{
    public class GetCafedraViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Phone { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
