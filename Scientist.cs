using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scientists
{
    public class Scientist
    {
        public string Name { get; set; } = String.Empty;
        public string Faculty { get; set; } = String.Empty;
        public string Department { get; set; } = String.Empty;
        public string Laboratory { get; set; } = String.Empty;
        public string Position { get; set; } = String.Empty;
        public string Activity { get; set; } = String.Empty;

        public bool Compare(Scientist temp)
        {
            if(this.Name == temp.Name && this.Faculty == temp.Faculty && this.Department == temp.Department &&
                this.Laboratory == temp.Laboratory && this.Position == temp.Position && this.Activity == temp.Activity)
            {
                return true;
            }
            return false;
        }
    }
}
