using Microsoft.VisualBasic.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Lupita_Kika.Models
{
    public class SalesWithRegisterData
    {
        public SalesWithRegisterData()
        {
        }

        public SalesWithRegisterData(int salesId, DateTime registerInhour, string productName, float lot, float total, int userId)
        {
            SalesId = salesId;
            RegisterInhour = registerInhour;
            ProductName = productName;
            Lot = lot;
            Total = total;
            UserId = userId;
        }

        public int SalesId { get; set; }
        public DateTime RegisterInhour { get; set; }
        public string ProductName { get; set; }
        public float Lot { get; set; }
        public float Total { get; set; }

        public float totalpluslot { get; set; }
        public int UserId { get; set; }
    }

}
