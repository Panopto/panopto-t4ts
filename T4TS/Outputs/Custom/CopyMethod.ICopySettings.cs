using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4TS.Outputs.Custom
{
    public partial class CopyMethod
    {
        public interface ICopySettings
        {
            string GetToFieldName(string baseName);
            string GetFromFieldName(string baseName);
            
            bool IsParentCopyMethod(TypeScriptMethod method);
        }
    }
}
