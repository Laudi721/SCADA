﻿using Database.GenericMethods.Models;
using Database.Scada.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Scada.Models
{
    [Table("Contractors")]
    public class Contractor : IModel
    {
        public Contractor()
        {
            ProductionOrders = new List<ProductionOrder>();
            Addresses = new List<Address>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public string NIP { get; set; }

        public string REGON { get; set; }

        public virtual List<ProductionOrder> ProductionOrders { get; set; }

        public virtual List<Address> Addresses { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? TimeDeleted { get; set; }
    }
}
