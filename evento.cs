using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Exercicio1
{
    public class LogEventArgs : EventArgs
	{
		public DateTime DataHora { set; get; }
		public String Mensagem { set; get; }
	}
}