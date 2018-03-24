﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvDTE;

namespace T4TS.Builders
{
    public class DirectEnumBuilder : CodeEnumBuilder
    {
        private DirectSettings settings;

        public DirectEnumBuilder(DirectSettings settings)
        {
            this.settings = settings;
        }

        public TypeScriptEnum Build(
            CodeEnum codeEnum,
            TypeContext typeContext)
        {
            string moduleName = this.settings.GetModuleNameFromNamespace(codeEnum.Namespace);

            bool enumCreated;
            TypeScriptEnum result = typeContext.GetOrCreateEnum(
                moduleName,
                codeEnum.FullName,
                out enumCreated);

            result.Name = codeEnum.Name;

            foreach (CodeVariable member in codeEnum.Members)
            {
                result.Values.Add(new TypeScriptEnumValue()
                    {
                        Name = member.Name,
                        Value = (member.InitExpression != null)
                            ? member.InitExpression.ToString()
                            : null
                    });
            }

            return result;
        }
    }
}