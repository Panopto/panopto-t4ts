using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4TS.Outputs
{
    public class OutputSettings
    {
        /// <summary>
        /// The version of Typescript that is targeted
        /// </summary>
        public Version CompatibilityVersion { get; set; }

        public bool OpenBraceOnNextLine { get; set; }

        public bool OrderInterfacesByReference { get; set; }

        public bool IsDeclaration { get; set; }

        public bool MembersToCamelCase { get; set; }


        public OutputSettings()
        {
            this.CompatibilityVersion = new Version(0, 9, 1, 1);
            this.IsDeclaration = true;
        }


        public static string ToCamelCase(string name)
        {
            string result;
            if (name[0] >= 'a'
                && name[0] <= 'z')
            {
                result = name;
            }
            else
            {
                int lowerIndex = 1;
                while (lowerIndex < name.Length
                    && name[lowerIndex] >= 'A'
                    && name[lowerIndex] <= 'Z')
                {
                    lowerIndex++;
                }

                if (lowerIndex == 1)
                {
                    result = name[0].ToString().ToLower()
                        + name.Substring(1);
                }
                else if (lowerIndex == name.Length)
                {
                    result = name.ToLower();
                }
                else
                {
                    result = name.Substring(0, lowerIndex - 1).ToLower()
                        + name.Substring(lowerIndex - 1);
                }
            }
            return result;
        }
    }
}
