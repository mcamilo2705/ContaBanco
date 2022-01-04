﻿using System;
using System.Collections.Generic;
namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listConta = new List<Conta>();
        static void Main(string[] args)
        {
           // Conta minhaConta = new Conta(); //instacia objeto conta
           // Conta minhaConta = new Conta(TipoConta.PessoaFisica, 0,0, "Marcos Henrique Camilo da Silva" );
           
           string opcaoUsuario = ObterOpcaoUsuario();

           while(opcaoUsuario.ToUpper() != "X")
           {
               switch(opcaoUsuario)
               {
                   case "1" :
                        ListarContas();
                        break;
                   case "2" :
                        InserirContas();
                        break;
                   case "3" :
                        Transferir();
                        break;
                   case "4" :
                        Sacar();
                        break;
                   case "5" :
                        Depositar();
                        break;
                   case "6" :
                        Console.Clear();
                        break;
                    default: 
                        throw new ArgumentOutOfRangeException();
               }
                opcaoUsuario = ObterOpcaoUsuario();
           }
           Console.WriteLine("Obrigado por utilizar nossos serviços");
           Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o numero da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o numero da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listConta[indiceContaOrigem].Transferir(valorTransferencia, listConta[indiceContaDestino]);

        }
        private static void Depositar()
        {
            Console.WriteLine("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listConta[indiceConta].Depositar(valorDeposito);
        }
        private static void Sacar()
        {
            Console.WriteLine("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listConta[indiceConta].Sacar(valorSaque);
        }
        private static void InserirContas()
        {
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Digite 1 para Conta Fisica ou 2 para juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o credito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            // criando/instanciando um objeto Conta
            Conta novaConta = new Conta (tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);
            listConta.Add(novaConta);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas: ");
            if(listConta.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i = 0; i < listConta.Count; i++)
            {
                Conta conta = listConta[i];
                Console.WriteLine("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Santander ao seu dispor");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("6- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            //variavel para receber uma opção
            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
