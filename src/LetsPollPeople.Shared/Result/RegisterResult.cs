using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsPollPeople.Shared
{
    public class RegisterResult
    {
        public bool IsRegistered {  get; set; }
        public List<string> ErrorMessages { get; set; }

        public RegisterResult() {
            IsRegistered  = false;
            ErrorMessages = new List<string>();
        }
    }
}
