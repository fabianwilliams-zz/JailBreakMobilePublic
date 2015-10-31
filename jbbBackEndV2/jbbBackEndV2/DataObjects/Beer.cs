using Microsoft.WindowsAzure.Mobile.Service;

namespace jbbBackEndV2.DataObjects
{
   public class Beer : EntityData
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Abv { get; set; }
        public double Ibu { get; set; }
        public string Taste { get; set; }
        public string ProName { get; set; }
        public string Smu { get; set; }
        public bool Ontapyn { get; set; }
        public string Utbid { get; set; }
    }
}
