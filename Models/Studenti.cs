using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Web;
using Newtonsoft.Json;

namespace Skola.Models
{
    public class Studenti
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string JMBG { get; set; }
        public string MestoRođenja { get; set; }
    }

}
