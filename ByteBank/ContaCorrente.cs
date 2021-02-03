// using _05_ByteBank;

using System;

namespace ByteBank
{
	public class ContaCorrente
	{
		public Cliente Titular { get; set; }

		public static double TaxaOperacao { get; private set; }
		public static int TotalDeContasCriadas { get; private set; }

		public int Agencia { get; }
		public int Numero { get; }


		private double _saldo = 100;

		public double Saldo
		{
			get
			{
				return _saldo;
			}
			set
			{
				if (value < 0)
				{
					return;
				}

				_saldo = value;
			}
		}


		public ContaCorrente(int agencia, int numero)
		{
			if (numero <= 0)
				throw new ArgumentException("Número da Conta deve ser maior que 0!", nameof(numero));

			if (agencia <= 0)
				throw new ArgumentException("Agencia deve ser maior que 0!", nameof(agencia));

			Agencia = agencia;
			Numero = numero;

			TotalDeContasCriadas++;
			TaxaOperacao = 30 / TotalDeContasCriadas;
		}


		public void Sacar(double valor)
		{
			if (valor < 0)
				throw new ArgumentException("Valor inválido para o saque!", nameof(valor));


			if (_saldo < valor)
			{
				//throw new SaldoInsuficienteException("Saldo insuficiente para o saque no valor de " + valor);
				throw new SaldoInsuficienteException(Saldo, valor);
			}

			_saldo -= valor;
		}

		public void Depositar(double valor)
		{
			_saldo += valor;
		}


		public void Transferir(double valor, ContaCorrente contaDestino)
		{
			if (valor < 0)
				throw new ArgumentException("Valor inválido para o transferência!", nameof(valor));

			Sacar(valor);
			contaDestino.Depositar(valor);
		}
	}
}
