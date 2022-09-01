using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File.Domain.Model
{
    public class PayloadFile
    {
        public string Name { get; private set; }
        public byte[] File { get; private set; }
        public string FileTypeMime { get; private set; }

        public PayloadFile(string name, byte[] file, string fileTypeMime)
        {
            Name = name;
            File = file;
            FileTypeMime = fileTypeMime;
        }
    }
}
