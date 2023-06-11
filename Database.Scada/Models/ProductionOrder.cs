﻿using Database.GenericMethods.Models;
using Database.Scada.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Database.Scada.Models
{
    [Table("ProductionOrders")]
    public class ProductionOrder : IModel
    {
        public ProductionOrder()
        {
            Operations = new List<Operation>();
        }

        [Key]
        public int Id { get; set; }

        public string OrderNumber { get; set; }

        public virtual List<Operation> Operations { get; set; }

        public Contractor Contractor { get; set; }

        public int ContractorId { get; set; }

        public Product Product { get; set; }

        public int ProductId { get; set; }

        public decimal Quanity { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDateTime{ get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime RealizationDateTime { get; set;}

        public bool IsDeleted { get; set; }

        public DateTime? TimeDeleted { get; set; }
    }
}
