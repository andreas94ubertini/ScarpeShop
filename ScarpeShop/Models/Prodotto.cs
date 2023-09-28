using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace ScarpeShop.Models
{
    public class Prodotto
    {
        public int IdProdotto { get; set; }
        public string Nome { get; set; }
        public string Brand { get; set; }
        public double Prezzo { get; set; }
        public string Descrizione { get; set; }
        public bool Disp {  get; set; }
        public string CoverImg { get; set; }
        public string Img1 { get; set; }
        public string Img2 { get; set; }
        public string SetIcon()
        {
            string icon = "";
            if (Disp)
            {
                icon = "bi bi-check-square text-success";
            }
            else
            {
                icon = "bi bi-square text-danger";
            }
            return icon;
        }
    }
}