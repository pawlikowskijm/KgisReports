using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.ReportingServices
{
    public class ReportParameter
    {
        public enum ParameterType
        {
            String,
            Email,
            PhoneNumber
        }

        public string Name { get; set; }
        public string Prompt { get; set; }
        public string Value { get; set; }
        public Type ValueType { get; set; }
        public ParameterType Type
        {
            get
            {
                if (Name?.ToLower().Contains("mail") == true || Value?.Contains("@") == true)
                {
                    return ParameterType.Email;
                }
                else
                    return ParameterType.String;
            }
        }
        public string DefaultValue { get; set; }
    }
}
