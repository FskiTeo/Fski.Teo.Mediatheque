using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatheque.Core.Model
{
    public class Etagere
    {
        public int EtagereId { get; set; }

        [MaxLength(50)]
        public string Emplacement { get; set; }

        public List<CD> listeDeCDs { get; set; } = new List<CD>();


        public Etagere() { }
        
    }
}
