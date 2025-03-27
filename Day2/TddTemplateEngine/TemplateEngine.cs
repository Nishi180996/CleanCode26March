using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TemplateEngine
{
    public class TemplateEngine
    {
        private string template;
        private Dictionary<string, string> variables = new Dictionary<string, string>();

        public string Evaluate()
        {
            string fullname = template;
            foreach (var variable in variables)
            {
                fullname = fullname.Replace("{" + variable.Key + "}", variable.Value);
            }

            return fullname;
        }

        public void setTempalate(string template)
        {
            this.template = template;
        }

        public void setVariable(string name, string value)
        {
            variables.Add(name, value);
        }

    }

}