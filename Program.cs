using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        
        // Nesta variável, armazenamos a conta que está logada atualmente.
        static Conta contaLogin = new Conta();
        static void Main(string[] args)
        {

            string login = LoginUsuario();
            while(login != "X")
            {
                switch(login){
                    case "1":
                        Autenticar();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "X":
                        return;
                    default:
                        Console.WriteLine("Escolha uma opção válida!");
                        break;
                }
                login = LoginUsuario();
            }
            
        }

        private static void Transferir(){
            Console.WriteLine("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());
            if(listContas.Count < indiceContaDestino){
                Console.WriteLine("Conta de destino inválida! Transferência abortada!");
                return;
            } else {
            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());
            contaLogin.Transferir(valorTransferencia, listContas[indiceContaDestino - 1]);
            }
        }

        private static void Depositar(){
            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());
            contaLogin.Depositar(valorDeposito);
        }

        private static void Sacar(){
            Console.WriteLine("Digite o núumero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            contaLogin.Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            if(listContas.Count == 0){
                Console.WriteLine("Não há contas cadastradas");
                return;
            }
            for(int i = 0; i < listContas.Count; i++){
                Conta conta = listContas[i];
                Console.Write("ID: {0} - ", i + 1);
                Console.WriteLine(conta);
            }
        }


        public static void Autenticar(){
            Console.WriteLine();
            Console.WriteLine("Digite o Identificador Unico da sua conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            if(listContas.Count < indiceConta) {
                Console.WriteLine("Número de Identificador inválido!");
            } else {
                contaLogin = listContas[indiceConta - 1];
                Console.WriteLine("Digite a senha da sua conta: ");
                string senha = Console.ReadLine().ToUpper();
                if(contaLogin.Autenticar(senha)){
                    ObterOpcaoUsuario();
                }
            }
            contaLogin.SaldoUltimoLogin = contaLogin.Saldo;
        }

        public static string LoginUsuario (){
            Console.WriteLine();
            Console.WriteLine("Bem vindo ao DIO Internet Banking!");
            Console.WriteLine("Por favor, escolha uma opção abaixo: ");
            Console.WriteLine("1 - Acessar minha conta");
            Console.WriteLine("2 - Criar minha conta");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;

        }

        public static void ObterOpcaoUsuario(){
            string opcaoUsuario;
            do{
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!");
            Console.WriteLine("Escolha a opção desejada!");
            Console.WriteLine("1 - Sacar");
            Console.WriteLine("2 - Depositar");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Listar as contas atuais");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Voltar ao menu anterior");
            Console.WriteLine();

            opcaoUsuario = Console.ReadLine().ToUpper();
            
                switch(opcaoUsuario)
                {
                    case "1":   
                        Sacar();
                        break;
                    case "2":
                        Depositar();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        ListarContas();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Escolha uma opção válida!");
                        break;
                }
            }while(opcaoUsuario != "X");
        }
        
        public static void InserirConta () {
            Console.Write("Digite 1 para Pessoa Física ou 2 para Pessoa Jurídica: ");
            int tipoConta = int.Parse(Console.ReadLine());
            Console.Write("Digite o nome do cliente: ");
            string nome = Console.ReadLine();
            Console.Write("Digite a sua senha: ");
            string senha = Console.ReadLine().ToUpper();
            // Implementamos que todo novo cliente não tem saldo inicial, é zerado
            // No começo, todos tem um crédito de 500

            /*
            Console.Write("Digite o saldo inicial: ");
            double saldoInicial = double.Parse(Console.ReadLine());
            Console.Write("Digite o crédito: ");
            double credito = double.Parse(Console.ReadLine());
            */
            Conta novaConta = new Conta(0, 500, (TipoConta)tipoConta, nome, senha);
            listContas.Add(novaConta);
            Console.WriteLine("Conta adicionada!");
            Console.WriteLine();
            Console.Write("SEU IDENTIFICADOR ÚNICO É: {0}", listContas.Count);
            Console.WriteLine();

        }
    }
}
