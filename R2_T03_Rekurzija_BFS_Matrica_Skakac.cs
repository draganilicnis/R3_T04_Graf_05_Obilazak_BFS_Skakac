// https://petlja.org/sr-Latn-RS/biblioteka/r/Zbirka2/broj_poteza_konja
// https://arena.petlja.org/sr-Latn-RS/competition/r2-t04-05-lavirint#tab_134649
// https://onlinegdb.com/vA4QfwKDo
// https://raw.githubusercontent.com/draganilicnis/R3_T04_Graf_05_Obilazak_BFS_Skakac/refs/heads/main/R2_T03_Rekurzija_BFS_Matrica_Skakac.cs

using System;
using System.Collections.Generic;
class R2_T03_Rekurzija_BFS_Matrica_Skakac
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());      // Dimenzija table 2 <= n <= 50
        int[,] A = new int[n, n];                   // Matrica: Svaki element matrice cuva najmanji broj poteza skakaca do tog polja (inicijalno = -1)
        for (int i = 0; i < n; i++) for (int j = 0; j < n; j++) A[i, j] = -1;

        int[] dx = { -2, -2, -1, -1, 1, 1, 2, 2 };  // Pomeraji po x: 8 smera kretanja skakaca (cirilicno G)
        int[] dy = { -1, 1, -2, 2, -2, 2, -1, 1 };  // Pomeraji po y: 8 smera kretanja skakaca (cirilicno G)  

        Queue<(int, int)> Red = new Queue<(int, int)>();    // Red uredjenih parova (x,y) koordinata
        
        Red.Enqueue((0, 0));                        // Poceto polje (gornji levi ugao), kao uredjeni par (0,0) dodajemo u Red
        A[0, 0] = 0;                                // Elementu matrice na pocetnom polju (gornji levi ugao) postavljamo vrednost 0 -> Potreban najmanji broj poteza je 0.

        while (Red.Count > 0)                       // Sve dok Red ima elemente (odnosno nije prazan)
        {
            var (x, y) = Red.Dequeue();             // Red: Uzimamo prvi element (sa vrha) iz reda
            for (int d = 0; d < 8; d++)             // Za svaki od svih 8 smerova skakaca (cirilicno G)
            {
                int x1 = x + dx[d];                 // x koordinata za sledeci potez (skok)
                int y1 = y + dy[d];                 // y koordinata za sledeci potez (skok)
                if (x1 >= 0 && x1 < n && y1 >= 0 && y1 < n && A[x1, y1] == -1) // Da li je sledece polje (x1, y1) unutar matrice i da li je NEOBELEZNO 
                {
                    A[x1, y1] = A[x, y] + 1;        // Ako jeste, minimalni broj poteza za to polje je vece za 1 u odnosnu na prethodno polje sa kojeg je skocio
                    Red.Enqueue((x1, y1));          // i dodajemo koordinate tog novog polja (x1, y1) u Red
                }
            }
        }

        for (int i = 0; i < n; i++)                 // Stampanje matrice
        {
            for (int j = 0; j < n; j++)
                Console.Write((A[i, j] == -1)? "- " : A[i, j] + " ");
            Console.WriteLine();
        }
    }
}
