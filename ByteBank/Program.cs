using System;
using System.Collections.Generic;
using System.IO;
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
				CarregarContas();
			}
			catch (Exception)
			{
				Console.WriteLine("Catch no método Main!");
			}

			Console.WriteLine("Execução finalizada, tecle enter para sair ...");
			Console.ReadLine();
		}

		private static void CarregarContas()
		{
			using (LeitorDeArquivos leitor = new LeitorDeArquivos("teste.txt"))
			{
				leitor.LerProximaLinha();
			}

			// -----------------------

			//LeitorDeArquivos leitor = null;

			//try
			//{
			//	leitor = new LeitorDeArquivos("contas.txt");

			//	leitor.LerProximaLinha();
			//	leitor.LerProximaLinha();
			//	leitor.LerProximaLinha();
			//}
			////catch (IOException)
			////{
			////	Console.WriteLine("Exceção do tipo IOException capturada e tratada!");
			////}
			//finally
			//{
			//	Console.WriteLine("Executando finally");

			//	if (leitor != null)
			//		leitor.Fechar();
			//}
		}

		private static void TestaInnerException()
		{
			try
			{
				ContaCorrente conta = new ContaCorrente(475, 273298);
				ContaCorrente conta2 = new ContaCorrente(123, 44444);

				//conta2.Transferir(10000, conta);

				//conta.Depositar(50);
				//Console.WriteLine(conta.Saldo);
				conta.Sacar(100000);
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
				Console.WriteLine(ex.Saldo);
				Console.WriteLine(ex.ValorSaque);

				Console.WriteLine(ex.StackTrace);

				Console.WriteLine(ex.Message);
				Console.WriteLine("Exceção do tipo SaldoInsuficienteException");
			}
			catch (OperacaoFinanceiraException ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);

				Console.WriteLine("Informações da INNER EXCEPTION");
				Console.WriteLine(ex.InnerException.Message);
				Console.WriteLine(ex.InnerException.StackTrace);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
			}

		}
	}
}
