using System;

namespace DIO.Bank {
    public class Conta {
        
        public string Nome {get; set;}
        public string Senha {get; set;}

        public double Saldo {get; set;}
        public double SaldoUltimoLogin {get; set;}

        public double Credito {get; set;}

        public TipoConta TipoConta {get; set;}
        
        
        // Construtor vazio para armazenar no Program.cs a conta que está logada atualmente
        public Conta(){}

        public Conta (double saldo, double credito, TipoConta tipoConta, string nome, string senha){
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;
            this.TipoConta = tipoConta;
            this.Senha = senha;
            this.SaldoUltimoLogin = saldo;
        }

        public bool Sacar(double valorSaque){
            if (this.Saldo - valorSaque < (this.Credito *-1)) {
                return false;
            } else {
                this.Saldo -= valorSaque;
                Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
                return true;
            }
        }

        public bool Autenticar(string senha){
            if(this.Senha == senha){
                Console.WriteLine("Usuário autenticado com sucesso!");
                if(this.Saldo != this.SaldoUltimoLogin){
                    Console.WriteLine("Você recebeu {0} de transferências desde o último login!", this.Saldo - this.SaldoUltimoLogin);
                    Console.WriteLine("Seu saldo agora é de: {0}", this.Saldo);
                }
                return true;
            } else {
                Console.WriteLine("Senha incorreta!");
                return false;
            }
        }

        public bool Depositar(double valorDepositar) {
            this.Saldo += valorDepositar;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            return true;
        }

        public bool Transferir (double valorTransferencia, Conta contaDestino){
            if(this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
                return true;
            } else {
                return false;
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome  + " | ";
            // Não queremos que outros usuários vejam dados privados de outros usuários.
            // Apenas mostraremos o necessário para fazer a transferência para outra pessoa
            // retorno += "Saldo " + this.Saldo + " | ";
            // retorno += "Crédito " + this.Credito + " | ";
            return retorno;
        }

    }
}