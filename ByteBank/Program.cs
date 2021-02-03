using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				ContaCorrente conta = new ContaCorrente(475, 273298);
				ContaCorrente conta2 = new ContaCorrente(123, 44444);

				conta2.Transferir(-10, conta);

				conta.Depositar(50);
				Console.WriteLine(conta.Saldo);
				conta.Sacar(-500);
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine("Ocorreu uma exceção do tipo ArgumentException!");
				Console.WriteLine(ex.Message);
				Console.WriteLine("Argumento com problema: {0}", ex.ParamName);
				//Console.WriteLine(ex.StackTrace);
			}
			catch (SaldoInsuficienteException ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine("Exceção do tipo SaldoInsuficienteException");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
			}

			Console.ReadLine();
		}
	}
}
