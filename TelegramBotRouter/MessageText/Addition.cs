using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotRouter
{
    class Addition
    {
        public string addition { get; set; } = null;
        public Addition() { }
        public Addition(string addt) { addition = addt; }
        public void ChangeAddition(string query)
        {
            try
            {
                addition = query.Split(' ')[1];
            }
            catch
            {
                addition = null;
            }
        }

        public void CheckAddition()
        {
            //addition = addition.Trim();

            if (addition=="" || addition == null)
            {
                addition=null;
                return;
            }

            for (int i = 1; i < addition.Length-1; i++)
            {
                if(addition[i] == '.')
                {
                    addition = null;
                    return;
                }
               
            }
        }
    }
}
