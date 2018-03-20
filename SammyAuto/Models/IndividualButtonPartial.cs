using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SammyAuto.Models
{
    public class IndividualButtonPartial
    {
        public string ButtonType { get; set; }
        public String Action { get; set; }
        public String Glyph { get; set; }
        public String Text { get; set; }

        public int? ServiceId { get; set; }

        public String ActionParametres
        {

            get
            {
                var parameter = new StringBuilder(@"/");
                if (ServiceId != null && ServiceId != 0)
                {
                    parameter.Append(String.Format("{0}", ServiceId));

                }

                return parameter.ToString().Substring(0, parameter.Length);
            }
        }
    }
}
