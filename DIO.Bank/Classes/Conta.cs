using System;

namespace DIO.Bank
{
    public class Conta
    {
        // private é uma forma de encapsular para que nao tenham acesso diretamente ao atributo
        private TipoConta TipoConta {get; set;}//Atributo da conta
        private string Nome {get; set;}//Atributo da conta
        private double Saldo {get; set;}//Atributo da conta
        private double Credito {get; set;}//Atributo da conta

        //Metodo contrutor
        public Conta (TipoConta tipoConta, double saldo, double credito, string nome) {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            if(this.Saldo - valorSaque < (this.Credito *-1)){
                Console.WriteLine("Saldo Insulficiente");
                return false;
            }
            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
        }

        //metodo para retornar informações da conta
        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo + " | ";
            retorno += "Credito: " + this.Credito; 
            return retorno ;
        }
    }
}