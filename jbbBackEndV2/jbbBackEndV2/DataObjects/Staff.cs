using Microsoft.WindowsAzure.Mobile.Service;

namespace jbbBackEndV2.DataObjects
{
   public class Staff : EntityData
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string PicUrl { get; set; }
    }
}
