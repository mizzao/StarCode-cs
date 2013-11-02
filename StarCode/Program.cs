using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starcraft
{
	class Program
	{
		static void Main(string[] args)
		{			
			var sc = new Starcode();

			var output = sc.Decrypt("#tyn1j54!FD", "some_key");

			Console.WriteLine(output);

			Console.ReadLine();
		}
	}
}
