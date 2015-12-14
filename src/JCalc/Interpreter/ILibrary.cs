using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCalc.Interpreter
{
    public interface ILibrary
    {
        Dictionary<string, InternalFunction> GetFunctions();
    }
}
