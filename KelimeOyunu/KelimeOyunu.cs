using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelimeOyunu
{
    class KelimeOyunu:DbContext

    {
        public DbSet<AskQuestion> AskQuestions { get; set; }
    }
}
