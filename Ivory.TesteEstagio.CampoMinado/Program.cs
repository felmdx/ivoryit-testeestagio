using System;

namespace Ivory.TesteEstagio.CampoMinado
{
    class Program
    {   
        static int casasAbertasAtual = 21;
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

            while (campoMinado.JogoStatus == 0)
            {   
                int lin = campoMatriz.GetLength(0);
                int col = campoMatriz.GetLength(1);

                int[,] campoAux = new int[9,9];

                if (Program.comparaCasaseBombas() == false)
                {
                    flag = 1;
                    for (int i = 0; i < lin; i++)
                    {
                        for (int j = 0; j < col; j++)
                        {
                            if (campoMatriz[i,j] == -1)
                            {
                                campoMinado.Abrir(i, j);
                                campoAux = ConverteCampoMinado(campoMinado.Tabuleiro);
                                campoMatriz[i, j] = campoAux[i, j];
                            }
                        }
                    }
                    flag = 0;

                } else
                {   
                    flag = 1;
                    bombasMarcadasAnt = bombasMarcadasAtual;
                    casasAbertasAnt = casasAbertasAtual;

                    for (int i = 0; i < lin; i++)
                    {
                        for (int j = 0; j < col; j++)
                        {
                            switch(campoMatriz[i,j])
                            {
                                case 1:
                                    verificaCasas(campoMinado, campoMatriz, i, j, 1);
                                    break;
                                case 2:
                                    verificaCasas(campoMinado, campoMatriz, i, j, 2);
                                    break;
                                case 3:
                                    verificaCasas(campoMinado, campoMatriz, i, j, 3);
                                    break;
                                case 4:
                                    verificaCasas(campoMinado, campoMatriz, i, j, 4);
                                    break;
                                case 5:
                                    verificaCasas(campoMinado, campoMatriz, i, j, 5);
                                    break;
                                case 6:
                                    verificaCasas(campoMinado, campoMatriz, i, j, 6);
                                    break;
                                case 7:
                                    verificaCasas(campoMinado, campoMatriz, i, j, 7);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    flag = 0;
                    //contaZerosEbombas(campoMatriz);
                }

            }
            if (campoMinado.JogoStatus == 1) Console.WriteLine("Nois");
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
                    return true;
                } else
                {
                    return false;
                }
        }

        //Função que verifica casas ao redor
        public static void verificaCasas(CampoMinado campoMinado, int[,] campoMatriz, int i, int j, int indicador)
        {   
            int contaCasas = 0;
            int contaBombas = 0;
            int[] iBomba = new int[8];
            int[] jBomba = new int[8];
            int[,] campoAux = new int[9,9];

            for (int y = 0; y < 8; y++)
            {
                iBomba[y] = 0;
            }
            for (int z = 0; z < 8; z++)
            {
                jBomba[z] = 0;
            }

            if (i > 0) 
            {
                if (campoMatriz[i - 1, j] == -1)
                {
                    contaCasas++;
                } else if (campoMatriz[i - 1, j] == -2 )
                {
                    contaBombas++;
                    iBomba[0] = i - 1;
                    jBomba[0] = j;
                }
            }

            if (i < 8)
            {
                if (campoMatriz[i + 1, j] == -1 && i < 8)
                {
                    contaCasas++;
                } else if (campoMatriz[i + 1, j] == -2 && i < 8)
                {
                    contaBombas++;
                    iBomba[1] = i + 1;
                    jBomba[1] = j;
                }
            }

            if (j > 0) 
            {
                if (campoMatriz[i, j - 1] == -1)
                {
                    contaCasas++;
                } else if (campoMatriz[i, j - 1] == -2)
                {
                    contaBombas++;
                    iBomba[2] = i;
                    jBomba[2] = j - 1;
                }
            }

            if (j < 8)
            {
                if (campoMatriz[i, j + 1] == -1)
                {
                    contaCasas++;
                } else if (campoMatriz[i, j + 1] == -2)
                {
                    contaBombas++;
                    iBomba[3] = i;
                    jBomba[3] = j + 1;
                }
            }

            if (i > 0 && j > 0)
            {
                if (campoMatriz[i - 1, j - 1] == -1)
                {
                    contaCasas++;
                } else if (campoMatriz[i - 1, j - 1] == -2)
                {
                    contaBombas++;
                    iBomba[4] = i - 1;
                    jBomba[4] = j - 1;
                }
            }

            if (i > 0 && j < 8)
            {
                if (campoMatriz[i - 1, j + 1] == -1)
                {
                    contaCasas++;
                } else if (campoMatriz[i - 1, j + 1] == -2)
                {
                    contaBombas++;
                    iBomba[5] = i - 1;
                    jBomba[5] = j + 1;
                }
            }

            if (i < 8 && j > 0)
            {
                if (campoMatriz[i + 1, j - 1] == -1)
                {
                    contaCasas++;
                } else if (campoMatriz[i + 1, j - 1] == -2)
                {
                    contaBombas++;
                    iBomba[6] = i + 1;
                    jBomba[6] = j - 1;
                }
            }

            if (i < 8 && j < 8)
            {
                if (campoMatriz[i + 1, j + 1] == -1)
                {
                    contaCasas++;
                } else if (campoMatriz[i + 1, j + 1] == -2)
                {
                    contaBombas++;
                    iBomba[7] = i + 1;
                    jBomba[7] = j + 1;
                }
            }

            if (contaCasas == indicador)
            {
                for (int w = 0; w < 8; w++)
                {
                    if (iBomba[w] != 0)
                    {
                        campoMatriz[iBomba[w], jBomba[w]] = -2;
                        bombasMarcadasAtual++;
                    }
                }
            }

            Console.WriteLine(contaCasas);
            Console.WriteLine(contaBombas);
            Console.WriteLine();

            if (contaBombas == indicador)
            {
                if (contaCasas > contaBombas)
                {
                    for (int w = 0; w < 8; w++)
                    {
                        if (iBomba[w] == 0)
                        {
                            campoMinado.Abrir(iBomba[w], jBomba[w]);
                            Console.WriteLine(campoMinado.Tabuleiro);
                            Console.WriteLine();
                            campoAux = ConverteCampoMinado(campoMinado.Tabuleiro);
                            campoMatriz[iBomba[w], jBomba[w]] = campoAux[iBomba[w], jBomba[w]];
                            casasAbertasAtual++;
                        }
                    }
                }
            }

        }
    }
}
