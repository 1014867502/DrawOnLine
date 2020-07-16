using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawOnLine1
{
    public class SortClass
    {
        private DateTime? id;
        private float value;
       

        public DateTime? Id { get => id; set => id = value; }
        public float Value { get => value; set => this.value = value; }

        public SortClass(DateTime id,float value)
        {
            this.Id = id;
            this.Value = value;
        }

        public SortClass(DateTime? id, float value)
        {
            this.Id = id;
            this.Value = value;
        }
    }
    
}
