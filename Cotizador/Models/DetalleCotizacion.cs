﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cotizador.Models
{
    public class DetalleCotizacion
    {
        [Key]
        public int id { get; set; }
        public int idproducto { get; set; }
        public int idcotizacion { get; set; }
        [Required]
        public int cantidad { get; set; } //Cantidad a cotizar
        [Required]
        public decimal PrecioCotizacion { get; set; }
        [ForeignKey("idproducto")]
        public Producto Servicios { get; set; }
        [ForeignKey("idcotizacion")]
        public Cotizaciones cotizador { get; set; }
    }
}