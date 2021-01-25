using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelimeOyunu
{
    class AskQuestion
    {

        public String ask { get; set; }
        public String word { get; set; }
        public override string ToString()
        {
            return ask + word;
        }
    }
}
