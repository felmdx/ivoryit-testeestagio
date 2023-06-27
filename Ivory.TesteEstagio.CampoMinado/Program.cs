using System;

namespace Ivory.TesteEstagio.CampoMinado
{
    class Program
    {   
        static int casasAbertasAtual = 0;
        static int bombasMarcadasAtual = 0;
        static int casasAbertasAnt = 0;
        static int bombasMarcadasAnt = 0;
        static int flag = 0;

        static void Main(string[] args)
        {
            var campoMinado = new CampoMinado();
            Console.WriteLine("Início do jogo\n=========");
            Console.WriteLine(campoMinado.Tabuleiro);

            // Realize sua codificação a partir deste ponto, boa sorte!

            
            int[,] campoMatriz = new int[9,9];
            campoMatriz = Program.ConverteCampoMinado(campoMinado.Tabuleiro);
            Program.ImprimirCampoMinado(campoMatriz);

            while (campoMinado.JogoStatus == 0)
            {
                if (!Program.comparaCasaseBombas())
                {
                    
                } else
                {                 
                    int lin = campoMatriz.GetLength(0);
                    int col = campoMatriz.GetLength(1);

                    for (int i = 0; i < lin; i++)
                    {
                        for (int j = 0; j < col; j++)
                        {
                            
                        }
                    }
                }
            }
        }
        
        // Função para converter a string em uma matriz, sendo -1 os espaços que não foram abertos ainda
        public static int[,] ConverteCampoMinado(string campoMinadoString)
        {
            string[] linhas = campoMinadoString.Split('\n'); // Divide a string em linhas
            int[,] campoMinado = new int[linhas.Length, (linhas[0].Length - 1)];

            for (int i = 0; i < linhas.Length; i++)
            {
                for (int j = 0; j < linhas[i].Length; j++)
                {
                    if (linhas[i][j] == '-')
                    {
                        campoMinado[i, j] = -1;
                    }
                    else
                    {
                        int numero;
                        if (int.TryParse(linhas[i][j].ToString(), out numero))
                        {
                            campoMinado[i, j] = numero;
                        }
                    }
                }
            }
            return campoMinado;
        }

        // Função que imprime o campo em matriz
        public static void ImprimirCampoMinado(int[,] campoMinado)
        {
            int linhas = campoMinado.GetLength(0);
            int colunas = campoMinado.GetLength(1);

            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    int valor = campoMinado[i, j];
                    Console.Write(valor + " ");
                }
                Console.WriteLine();
            }
        }

        //Função que conta casas abertas
        public static void contaZerosEbombas(int[,] campoMinado)
        {
            int linhas = campoMinado.GetLength(0);
            int colunas = campoMinado.GetLength(1);

            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    if (campoMinado[i,j] == 0)
                    {
                        casasAbertasAtual++;
                    }
                    if (campoMinado[i,j] == -2)
                    {
                        bombasMarcadasAtual++;
                    }
                }
                Console.WriteLine();
            }
        }

        //Função que verifica se vai iterar ou abrir outra casa
        public static bool comparaCasaseBombas(){
                if (flag == 0 && (casasAbertasAtual != casasAbertasAnt || bombasMarcadasAtual != bombasMarcadasAnt))
                {
                    flag = 1;
                    return true;
                } else
                {
                    return false;
                }
        }
    }
}
