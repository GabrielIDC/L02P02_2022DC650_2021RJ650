﻿using System.ComponentModel.DataAnnotations.Schema;

namespace L02P02_2022DC650_2021RJ650.Models
{
    [Table("pedido_detalle")]
    public class pedido_detalle
    {
        public int id { get; set; }
        public int id_pedido { get; set; }
        public int id_libro { get; set; }
        public DateTime? created_at { get; set; }
    }
}
