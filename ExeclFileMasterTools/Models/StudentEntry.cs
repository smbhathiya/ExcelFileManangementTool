using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelFileHandler.Models
{
    public class StudentEntry
    {
        public string Name { get; set; }
        public string WhatsAppNumber { get; set; }
        public string Grade { get; set; }
        public string Medium { get; set; }
        public DateTime? Timestamp { get; set; }

        public string GetUniqueKey()
        {
            return $"{Name}|{WhatsAppNumber}|{Grade}|{Medium}";
        }
    }
}
