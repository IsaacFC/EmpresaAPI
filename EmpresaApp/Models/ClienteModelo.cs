using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaApp.Models
{
    public class ClienteModelo
    {
        [Key]
        public int ClienteId { get; set; }

        [Column(TypeName ="varChar(100)")]
        public string Nombre { get; set; }

        [Column(TypeName = "varChar(13)")]
        public string Rfc { get; set; }

        [Column(TypeName = "varChar(20)")]
        public string Estado { get; set; }

        [Column(TypeName = "varChar(30)")]
        public string Municipio { get; set; }

        [Column(TypeName = "varChar(200)")]
        public string Direccion { get; set; }
    }
}
