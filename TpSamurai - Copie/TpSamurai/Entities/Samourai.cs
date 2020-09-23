using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TpSamurai.Entities
{
    public class Samourai : Abstract
    {
        public int Id { get; set; }
        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual Arme Arme { get; set; }
        public List<ArtMartial> ArtMartials { get; set; }
    }
}