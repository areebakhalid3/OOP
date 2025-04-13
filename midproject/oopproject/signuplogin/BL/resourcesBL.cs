using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signuplogin.BL
{
    class resourcesBL
    {
        public int rscID;
        public string rscName;
        public int rsccategory;
        public int totalqty;
        public int avqty;
        public int borqty;

        public resourcesBL() { }
        public resourcesBL(int rscID,string rscName, int rsccategory, int totalqty, int avqty, int borqty)
        {
            this.rscID = rscID;
            this.rscName = rscName;
            this.rsccategory = rsccategory;
            this.totalqty = totalqty;
            this.avqty = avqty;
            this.borqty = borqty;
        }
    }
}
