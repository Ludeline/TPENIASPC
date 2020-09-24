using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TpSamouraiV2.Entities;

namespace TpSamouraiV2.Models
{
    public class SamouraiModel
    {
        public Samourai Samourai { get; set; }
        public List<SelectListItem> Armes { get; set; } = new List<SelectListItem>();
        //Le ? est pour l'énumération
        public int? IdArme { get; set; }
        public List<SelectListItem> ArtMartials { get; set; } = new List<SelectListItem>();
        public List<int> IdsArtMartials { get; set; } = new List<int>();
    }
}