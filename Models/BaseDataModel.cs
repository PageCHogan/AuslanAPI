using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AuslanAPI.Models.Enums;

namespace AuslanAPI.Models
{
    public class BaseDataModel
    {
        public int ID { get; set; }
        public RecordStatus Status { get; set; }
        public DateTime Created { get; set; }

        public BaseDataModel()
        {
            ID = 0;
            Status = RecordStatus.Active;
            Created = DateTime.Now;
        }
    }
}
