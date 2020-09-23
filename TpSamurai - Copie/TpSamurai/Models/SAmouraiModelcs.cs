using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TpSamurai.Entities;

namespace TpSamurai.Models
{
    public class SAmouraiModelcs
    {
        public Samourai Samourai { get; set; }
        public List<SelectListItem> Armes { get; set; } = new List<SelectListItem>();
        //Le ? est pour l'énumération
        public int? IdArme { get; set; }
    }
}