using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4TS.Outputs.Custom
{
    public partial class CopyMethod : TypeScriptMethod
    {
        public static TypeScriptMethod ChangeCaseCopy(
            OutputSettings outputSettings,
            TypeContext typeContext,
            string baseName,
            TypeScriptType containingType,
            string otherTypeLiteral,
            bool toContainingType,
            bool toCamelCase)
        {
            TypeReference otherType = typeContext.GetLiteralReference(otherTypeLiteral);

            TypeScriptMethod result = new TypeScriptMethod();
            result.Name = baseName + containingType.SourceType.UnqualifiedSimpleName;
            result.Appender = new CopyMethod.OutputAppender(
                outputSettings,
                typeContext,
                containingType,
                new CaseChangeCopySettings(
                    toContainingType,
                    toCamelCase),
                toContainingType);

            if (toContainingType)
            {
                result.Arguments = new List<TypeScriptMember>()
                {
                    new TypeScriptMember()
                    {
                        Name = "source",
                        Type = otherType
                    }
                };
                result.Type = containingType;
            }
            else
            {
                result.Arguments = new List<TypeScriptMember>()
                {
                    new TypeScriptMember()
                    {
                        Name = "target",
                        Type = otherType
                    }
                };
                result.Type = otherType;
            }

            return result;
        }

        public static TypeScriptMethod Copy(
            OutputSettings outputSettings,
            TypeContext typeContext,
            string baseName,
            TypeScriptType containingType,
            string otherTypeLiteral,
            bool toContainingType)
        {
            TypeReference otherType = typeContext.GetLiteralReference(otherTypeLiteral);

            TypeScriptMethod result = new TypeScriptMethod();
            result.Name = baseName + containingType.SourceType.UnqualifiedSimpleName;
            result.Appender = new CopyMethod.OutputAppender(
                outputSettings,
                typeContext,
                containingType,
                new SimpleCopySettings(
                    toContainingType,
                    outputSettings.MembersToCamelCase),
                toContainingType);

            if (toContainingType)
            {
                result.Arguments = new List<TypeScriptMember>()
                {
                    new TypeScriptMember()
                    {
                        Name = "source",
                        Type = containingType
                    }
                };
                result.Type = containingType;
            }
            else
            {
                result.Arguments = new List<TypeScriptMember>()
                {
                    new TypeScriptMember()
                    {
                        Name = "target",
                        Type = containingType
                    }
                };
                result.Type = containingType;
            }

            return result;
        }

        protected class SimpleCopySettings : ICopySettings
        {
            private bool toContainingType;
            private bool membersToCamelCase;

            public SimpleCopySettings(
                bool toContainingType,
                bool membersToCamelCase)
            {
                this.toContainingType = toContainingType;
                this.membersToCamelCase = membersToCamelCase;
            }

            public string GetFromFieldName(string baseName)
            {
                return (membersToCamelCase) 
                    ? OutputSettings.ToCamelCase(baseName)
                    : baseName;
            }

            public string GetToFieldName(string baseName)
            {
                return (membersToCamelCase)
                    ? OutputSettings.ToCamelCase(baseName)
                    : baseName;
            }

            public bool IsParentCopyMethod(TypeScriptMethod method)
            {
                bool result = false;

                CopyMethod.OutputAppender appender =
                    method.Appender as CopyMethod.OutputAppender;
                if (appender != null)
                {
                    SimpleCopySettings copySettings =
                        appender.CopySettings as SimpleCopySettings;
                    result = (copySettings != null
                        && copySettings.toContainingType == this.toContainingType);
                }
                return result;
            }
        }

        protected class CaseChangeCopySettings : ICopySettings
        {
            private bool toContainingType;
            private bool toCamelCase;

            public CaseChangeCopySettings(
                bool toContainingType,
                bool toCamelCase)
            {
                this.toContainingType = toContainingType;
                this.toCamelCase = toCamelCase;
            }

            public string GetFromFieldName(string baseName)
            {
                return (toCamelCase)
                    ? baseName
                    : OutputSettings.ToCamelCase(baseName);
            }

            public string GetToFieldName(string baseName)
            {
                return (toCamelCase)
                    ? OutputSettings.ToCamelCase(baseName)
                    : baseName;
            }

            public bool IsParentCopyMethod(TypeScriptMethod method)
            {
                bool result = false;

                CopyMethod.OutputAppender appender =
                    method.Appender as CopyMethod.OutputAppender;
                if (appender != null)
                {
                    CaseChangeCopySettings copySettings =
                        appender.CopySettings as CaseChangeCopySettings;
                    result = (copySettings != null
                        && copySettings.toCamelCase == this.toCamelCase
                        && copySettings.toContainingType == this.toContainingType);
                }
                return result;
            }
        }
    }
}
