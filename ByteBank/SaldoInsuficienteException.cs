using System;
namespace ByteBank
{
	public class SaldoInsuficienteException : OperacaoFinanceiraException
	{
		public double Saldo { get; }
		public double ValorSaque { get; }

		public SaldoInsuficienteException()
		{

		}

		public SaldoInsuficienteException(string mensagem) : base(mensagem)
		{

		}

		public SaldoInsuficienteException(double saldo, double valorSaque) : this("Tentativa de saque do valor de " + valorSaque + " em uma conta com o saldo de " + saldo + ".")
		{
			Saldo = saldo;
			ValorSaque = valorSaque;
		}

		public SaldoInsuficienteException(string mensagem, Exception excecaoInterna) : base(mensagem, excecaoInterna)
		{

		}
	}
}
