using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISVLM2017.Domain.Entities
{
    [Table("TB_CAJA_DETALLE")]
    public partial  class CajaDetalle
    {
        [Key]
        public int cajadetalle_id { get; set; }
        public System.DateTime cajadetalle_fecha { get; set; }
        public int cajadetalle_billete_docientos { get; set; }
        public int cajadetalle_billete_cien { get; set; }
        public int cajadetalle_billete_cincuenta { get; set; }
        public int cajadetalle_billete_veinte { get; set; }
        public int cajadetalle_billete_diez { get; set; }
        public string cajadetalle_descripcion { get; set; }
    }

   
}
