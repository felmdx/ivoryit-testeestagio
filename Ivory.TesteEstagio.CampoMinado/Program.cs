using System;

namespace Ivory.TesteEstagio.CampoMinado
{
    class Program
    {   
        static void Main(string[] args)
        {
            var campoMinado = new CampoMinado();
            Console.WriteLine("Início do jogo\n===========");
            Console.WriteLine(campoMinado.Tabuleiro);
            Console.WriteLine();

            // Realize sua codificação a partir deste ponto, boa sorte!

            int k = 0;
            int[,] campoMatriz = new int[9,9];

            while (campoMinado.JogoStatus == 0)
            {   
                Console.WriteLine(k + " iteração:");
                Console.WriteLine(campoMinado.Tabuleiro);
                Console.WriteLine();
                campoMatriz = verificaBombas(Program.ConverteCampoMinado(campoMinado.Tabuleiro));

                int lin = campoMatriz.GetLength(0);
                int col = campoMatriz.GetLength(1);

                for (int i = 0; i < lin; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        abreCasas(campoMinado, campoMatriz, i, j, campoMatriz[i,j]);
                    }
                
                }
                k++;
            }
            if (campoMinado.JogoStatus == 1) 
            {   
                Console.WriteLine(k + " iteração:");
                Console.WriteLine(campoMinado.Tabuleiro);
                Console.WriteLine();
                Console.WriteLine("Ganhamos :D");
                Console.WriteLine("Fim de jogo \n==============");
            }
            else  
            {   
                Console.WriteLine(k + " iteração:");
                Console.WriteLine(campoMinado.Tabuleiro);
                Console.WriteLine();
                Console.WriteLine("Perdemos :c");
                Console.WriteLine("Fim de jogo \n==============");
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

        //Função que verifica quais casas são bombas e coloca "flag" chamada -2
        public static int[,] verificaBombas(int[,] campoMatriz)
        {   
            int indicador = -10;
            int linhas = campoMatriz.GetLength(0);
            int colunas = campoMatriz.GetLength(1);

            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    indicador = campoMatriz[i,j];
                    if (indicador >= 1)
                    {
                        int contaCasas = 0;
                        int[] iBomba = new int[8];
                        int[] jBomba = new int[8];

                        for (int y = 0; y < 8; y++)
                        {
                            iBomba[y] = -10;
                        }
                        for (int z = 0; z < 8; z++)
                        {
                            jBomba[z] = -10;
                        }

                        if (i > 0) 
                        {
                            if (campoMatriz[i - 1, j] == -1 || campoMatriz[i - 1, j] == -2 )
                            {
                                contaCasas++;
                                iBomba[0] = i - 1;
                                jBomba[0] = j;
                            }
                        }

                        if (i < 8)
                        {
                            if (campoMatriz[i + 1, j] == -1 || campoMatriz[i + 1, j] == -2)
                            {
                                contaCasas++;
                                iBomba[1] = i + 1;
                                jBomba[1] = j;
                            }
                        }

                        if (j > 0) 
                        {
                            if (campoMatriz[i, j - 1] == -1 || campoMatriz[i, j - 1] == -2)
                            {
                                contaCasas++;
                                iBomba[2] = i;
                                jBomba[2] = j - 1;
                            }
                        }

                        if (j < 8)
                        {
                            if (campoMatriz[i, j + 1] == -1 || campoMatriz[i, j + 1] == -2)
                            {
                                contaCasas++;
                                iBomba[3] = i;
                                jBomba[3] = j + 1;
                            }
                        }

                        if (i > 0 && j > 0)
                        {
                            if (campoMatriz[i - 1, j - 1] == -1 || campoMatriz[i - 1, j - 1] == -2)
                            {
                                contaCasas++;
                                iBomba[4] = i - 1;
                                jBomba[4] = j - 1;
                            }
                        }

                        if (i > 0 && j < 8)
                        {
                            if (campoMatriz[i - 1, j + 1] == -1 || campoMatriz[i - 1, j + 1] == -2)
                            {
                                contaCasas++;
                                iBomba[5] = i - 1;
                                jBomba[5] = j + 1;
                            }
                        }

                        if (i < 8 && j > 0)
                        {
                            if (campoMatriz[i + 1, j - 1] == -1 || campoMatriz[i + 1, j - 1] == -2)
                            {
                                contaCasas++;
                                iBomba[6] = i + 1;
                                jBomba[6] = j - 1;
                            }
                        }

                        if (i < 8 && j < 8)
                        {
                            if (campoMatriz[i + 1, j + 1] == -1 || campoMatriz[i + 1, j + 1] == -2)
                            {
                                contaCasas++;
                                iBomba[7] = i + 1;
                                jBomba[7] = j + 1;
                            }
                        }

                        if (contaCasas == indicador)
                        {   
                            for (int w = 0; w < 8; w++)
                            {
                                if (iBomba[w] != -10)
                                {   
                                    campoMatriz[iBomba[w], jBomba[w]] = -2;
                                }
                            }
                        }
                    }
                }
            }
            return campoMatriz;
        }


        //Função que verifica casas que não são bomba e as abre no campo minado original
        public static void abreCasas(CampoMinado campoMinado, int[,] campoMatriz, int i, int j, int indicador)
        {   
            int contaCasas = 0;
            int contaBombas = 0;
            int[] iCasa = new int[8];
            int[] jCasa = new int[8];
            int[,] campoAux = new int[9,9];

            for (int y = 0; y < 8; y++)
            {
                iCasa[y] = 0;
            }
            for (int z = 0; z < 8; z++)
            {
                jCasa[z] = 0;
            }

            if (i > 0) 
            {
                if (campoMatriz[i - 1, j] == -1)
                {
                    contaCasas++;
                    iCasa[0] = i - 1;
                    jCasa[0] = j;
                } 
                else if (campoMatriz[i - 1, j] == -2 )
                {
                    contaCasas++;
                    contaBombas++;
                }
            }

            if (i < 8)
            {
                if (campoMatriz[i + 1, j] == -1 && i < 8)
                {
                    contaCasas++;
                    iCasa[1] = i + 1;
                    jCasa[1] = j;
                } 
                else if (campoMatriz[i + 1, j] == -2 && i < 8)
                {   
                    contaCasas++;
                    contaBombas++;
                }
            }

            if (j > 0) 
            {
                if (campoMatriz[i, j - 1] == -1)
                {
                    contaCasas++;
                    iCasa[2] = i;
                    jCasa[2] = j - 1;
                } 
                else if (campoMatriz[i, j - 1] == -2)
                {   
                    contaCasas++;
                    contaBombas++;
                }
            }

            if (j < 8)
            {
                if (campoMatriz[i, j + 1] == -1)
                {
                    contaCasas++;
                    iCasa[3] = i;
                    jCasa[3] = j + 1;
                } 
                else if (campoMatriz[i, j + 1] == -2)
                {   
                    contaCasas++;
                    contaBombas++;
                }
            }

            if (i > 0 && j > 0)
            {
                if (campoMatriz[i - 1, j - 1] == -1)
                {
                    contaCasas++;
                    iCasa[4] = i - 1;
                    jCasa[4] = j - 1;
                } 
                else if (campoMatriz[i - 1, j - 1] == -2)
                {   
                    contaCasas++;
                    contaBombas++;
                }
            }

            if (i > 0 && j < 8)
            {
                if (campoMatriz[i - 1, j + 1] == -1)
                {
                    contaCasas++;
                    iCasa[5] = i - 1;
                    jCasa[5] = j + 1;
                } 
                else if (campoMatriz[i - 1, j + 1] == -2)
                {   
                    contaCasas++;
                    contaBombas++;
                }
            }

            if (i < 8 && j > 0)
            {
                if (campoMatriz[i + 1, j - 1] == -1)
                {
                    contaCasas++;
                    iCasa[6] = i + 1;
                    jCasa[6] = j - 1;
                } 
                else if (campoMatriz[i + 1, j - 1] == -2)
                {   
                    contaCasas++;
                    contaBombas++;
                }
            }

            if (i < 8 && j < 8)
            {
                if (campoMatriz[i + 1, j + 1] == -1)
                {
                    contaCasas++;
                    iCasa[7] = i + 1;
                    jCasa[7] = j + 1;
                } 
                else if (campoMatriz[i + 1, j + 1] == -2)
                {   
                    contaCasas++;
                    contaBombas++;
                }
            }
       
            if (contaCasas > contaBombas && contaBombas == indicador)
            {   
                    for (int w = 0; w < 8; w++)
                    {
                        if (campoMatriz[iCasa[w], jCasa[w]] == -1)
                        {   
                            campoMinado.Abrir(iCasa[w] + 1, jCasa[w] + 1);
                        }
                    }
            }
        }
    }
}