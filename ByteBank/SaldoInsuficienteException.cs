using System;
namespace ByteBank
{
	public class SaldoInsuficienteException : Exception
	{
		public double Saldo { get; }
		public double ValorSaque { get; }

		public SaldoInsuficienteException(string mensagem) : base(mensagem)
		{

		}

		public SaldoInsuficienteException()
		{

		}

		public SaldoInsuficienteException(double saldo, double valorSaque) : this("Tentativa de saque do valor de " + valorSaque + " em uma conta com o saldo de " + saldo + ".")
		{
			Saldo = saldo;
			ValorSaque = valorSaque;
		}
	}
}
