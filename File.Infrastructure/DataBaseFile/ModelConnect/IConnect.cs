using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File.Infrastructure.DataBaseFile.ModelConnect
{
    public interface IConnect
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
