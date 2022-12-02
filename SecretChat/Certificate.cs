using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretChat
{
    public class Certificate
    {                            
        public string Name { get; set; }
        public string Hash { get; set; }
        public string PubKey { get; set; }
        public string ServerPubKey { get; set; }
        public string Signature { get; set; }
        public bool IsValid { get; set; }
    }
}
