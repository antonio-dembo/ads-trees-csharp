using _arvoreAvl.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArvoreAVL.Utils
{
    public enum Operations
    {
        inserir,
        buscar,
        del
    }

    public class ProgMenu
    {
        public static void ShowProgramMenu()
        {
            var str = new StringBuilder();
            var mockData = new MockDataService();
            AVLTree arvoreAvl = null;
            Node rootWithValue = null;

            while (true)
            {
                Console.Clear();

                str.AppendLine("Digite a operacao desejada (ex: inserir 10):");
                str.AppendLine("\tinserir <chave>");
                str.AppendLine("\tbuscar <chave>");
                str.AppendLine("\tdel <chave>");
                                
                Console.WriteLine(str);
                str.Clear();
                Console.Write("Eu quero: ");
                string input = Console.ReadLine().Trim();

                string[] inputArray = input.Split(" ");

                if (input.Equals(string.Empty))
                {
                    throw new Exception($"{nameof(input)} nao pode ser vazio.");
                }

                if( inputArray.Length == 1 || inputArray.Length > 2)
                {
                    throw new ArgumentOutOfRangeException(nameof(input), 
                        $"Numero de argumentos encontrados {inputArray.Length} esperados 2");
                }

                var operation = inputArray[0];                
                if (operation.Equals(Operations.inserir.ToString()))
                {
                    if (int.TryParse(inputArray[1], out int result))
                    {
                        arvoreAvl ??= new AVLTree();

                        if(rootWithValue == null)
                        {
                            rootWithValue = arvoreAvl.Insert( null, result);
                        }
                        else
                        {
                            _ = arvoreAvl.Insert(rootWithValue, result);
                        }
                                               
                        Console.Write("\nTree: ");
                        mockData.InOrder(rootWithValue);
                    }
                    else
                    {
                        throw new Exception ($"Voce digitou {result}. A chave deve ser inteiro.");
                    }
                }
                else if (operation.Equals(Operations.buscar.ToString()))
                {
                    Console.WriteLine("Call buscar");
                }
                else if (operation.Equals(Operations.del.ToString()))
                {
                    Console.WriteLine("Call deletar");
                }
                else
                {
                    throw new Exception($"{nameof(operation)} {operation} nao está definida.");
                }

               
                bool isExit = false;
                bool isInvalidInput = false;
                                
                do{ 
                    Console.WriteLine("\nDeseja continuar? (Yes / No)");
                    input = Console.ReadLine();

                    if ( !new[] { "yes", "y", "no", "n" }.Contains(input))
                    {
                        Console.WriteLine($"Voce digitou {input}. Opcoes validas: yes / no.");
                        isInvalidInput = true;
                    }
                    else                   
                    {
                        if ( new[] { "no", "n"}.Contains(input.ToLower()))
                        {
                            isExit = true;
                            break;
                        }
                        else { break;  }
                    }                    
                    
                } while (isInvalidInput) ;


                if (isExit)
                {
                    Console.WriteLine("Encerrando o programa.");
                    break;
                }                
            }
        }
    }
}
