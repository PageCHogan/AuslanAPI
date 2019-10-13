using static AuslanAPI.Models.Enums;

namespace AuslanAPI.Models
{
    public class SignwordDataModel : BaseDataModel
    {
        public string Signword { get; set; }
        public SignCategory Category { get; set; }
        public string Image { get; set; }
    }
}