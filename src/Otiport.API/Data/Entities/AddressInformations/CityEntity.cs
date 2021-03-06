﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Otiport.API.Data.Entities.AddressInformations
{
    [Table("Cities")]
    public class CityEntity : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public virtual CountryEntity Country { get; set; }
    }
}
