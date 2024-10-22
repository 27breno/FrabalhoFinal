using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        public string Tipo { get; set; } /* FIlme, Serie, Documentario */

        public string Genero { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} Categoria: Formato: {Tipo}, Genero: {Genero} ";
        }
    }
}
