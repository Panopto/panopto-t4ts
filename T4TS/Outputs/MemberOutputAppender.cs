using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4TS.Outputs;

namespace T4TS
{
    public class MemberOutputAppender : OutputAppender<TypeScriptMember>
    {
        public MemberOutputAppender(
            OutputSettings settings,
            TypeContext typeContext)
                : base(
                      settings,
                      typeContext)
        {
        }

        public override void AppendOutput(
            StringBuilder output,
            int baseIndentation,
            TypeScriptMember member)
        {
            this.AppendIndendation(
                output,
                baseIndentation);

            bool isOptional = member.Optional;
            TypeName outputName = this.TypeContext.ResolveOutputTypeName(member.Type);

            string name = member.Name;
            if (this.Settings.MembersToCamelCase)
            {
                name = OutputSettings.ToCamelCase(name);
            }
            output.AppendFormat("{0}{1}: {2}",
                name,
                (isOptional ? "?" : ""),
                outputName.QualifiedName
            );
            
            output.AppendLine(";");
        }
    }
}
