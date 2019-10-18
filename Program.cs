using System;

namespace CampoMinado
{
    class Program
    {
        const int TAMX = 5;
        const int TAMY = 5;

        static void Main(string[] args)
        {
            var campo = new string[TAMX,TAMY];
            var campoView = new string[TAMX,TAMY];
            int chances = 3;
            int x, y;

            Console.Clear();
            Console.WriteLine("\n");

            PlantBomb(campo, campoView);
            ImprimeCampo(campoView);

            while (chances > 0)
            {
                Console.Write("Informe a coordenada X: ");
                x = Convert.ToInt32(Console.ReadLine());

                Console.Write("Informe a coordenada Y: ");
                y = Convert.ToInt32(Console.ReadLine());
                
                Console.Clear();
                
                chances = CheckBomb(x, y, campo, campoView, chances);
            }

            Console.WriteLine("Suas chances acabaram.....");
        }

        static void PlantBomb(string[,] campo, string[,] campoV)
        {
            for (int i = 0; i < TAMX; i++)
            {
                for (int j = 0; j < TAMY; j++)
                {
                    Random random = new Random();
                    var n = random.Next(1, 100);
                    campo[j,i] = Convert.ToString(n%2);
                    campoV[j,i] = "0";
                }
            }
        }

        static void ImprimeCampo(string[,] campo)
        {
            Console.WriteLine("    [0] [1] [2] [3] [4]");
            for (int i = 0; i < TAMX; i++)
            {
                Console.Write($"[{i}] ");
                for (int j = 0; j < TAMY; j++)
                {
                    Console.Write($" {campo[j,i]}  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static int CheckBomb(int x, int y, string[,] campo, string[,] campoV, int chances)
        {
            if(campo[x,y] == "1")
            {
                chances--;
                Console.WriteLine($"Você atingiu uma bomba! Restam {chances} tentativas.\n");
                campo[x,y] = "X";
                campoV[x,y] = "X";
            }
            else if(campo[x,y] == "0")
            {
                Console.WriteLine("Ufa! Sem bomba!\n");
                campo[x,y] = "_";
                campoV[x,y] = "_";
            }
            else if(campo[x,y] == "X" || campo[x,y] == "_")
            {
                Console.WriteLine("Você já tentou essa posição!");
            }

            ImprimeCampo(campoV);
            return chances;
        }
    }
}
