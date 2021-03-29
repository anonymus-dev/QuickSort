using System;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[100]; // Array da riordinare

            CaricaArray(array); // Caricamento dell'array
            StampaArray(array); // Stampa array
            QuickSort(array, 0, array.Length);  // Riordino dell'array
            StampaArray(array); // Stampa array
        }

        /// <summary>
        /// Metodo per caricare un array di interi con valori randomici
        /// </summary>
        /// <param name="vett">Array da caricare</param>
        static void CaricaArray(int[] vett)
        {
            Random rand = new Random();
            for (int i = 0; i < vett.Length; i++)
            {
                vett[i] = rand.Next(Int32.MinValue, Int32.MaxValue);    // Il valore è generato nel range int
            }
        }

        /// <summary>
        /// Metodo per stampare un array
        /// </summary>
        /// <param name="vett">Array da stampare</param>
        static void StampaArray(int[] vett)
        {
            foreach (var item in vett)
            {
                Console.Write($"{item} ");
            }
        }

        /// <summary>
        /// Metodo per riordinare l'array con il QuickSort
        /// </summary>
        /// <param name="vett">Array da riordinare</param>
        /// <param name="min">Limite inferiore per partizionare l'array</param>
        /// <param name="max">Limite superiore per partizionare l'array</param>
        static void QuickSort(int[] vett, int min, int max)
        {
            // Condizione di uscita
            if (max > min)
            {
                #region Variabili
                int[] array = new int[max - min];   // Sotto-array di appoggio
                int i1 = 0; // Indice che scorre l'array dalla prima posizione
                int i2 = array.Length - 1;  // Indice che scorre l'array dall'ultima posizione
                int med = (min + max) / 2;  // Pivot
                #endregion

                // for che scorre le posizioni da riordinare del vettore originale e le ricopia ordinate nel vettore di appoggio
                for (int i = 0; i < array.Length; i++)
                {
                    if (i + min != med) // Se la posizione è diversa dal pivot, riordinala
                    {
                        if (vett[i + min] <= vett[med]) // Se il numero è minore del pivot ricopialo nell'array di appoggio a sinistra
                        {
                            array[i1] = vett[i + min];
                            i1++;   // Incrementa l'indice inferiore
                        }
                        else    // Se il numero è maggiore del pivot ricopialo nell'array di appoggio a destra
                        {
                            array[i2] = vett[i + min];
                            i2--;   // Incrementa l'indice superiore
                        }
                    }
                }

                #region Copia dell'array di appoggio nell'array originale
                array[i1] = vett[med];
                for (int k = 0; k < array.Length; k++)
                {
                    vett[k + min] = array[k];
                }
                #endregion

                // Chiamata ricorsiva del metodo per riordinare la parte inferiore dell'array
                if (i1 - min > 1)
                {
                    QuickSort(vett, min, i1);   
                }
                
                QuickSort(vett, min + i2 + 1, max); // Chiamata ricorsiva del metodo per riordinare la parte superiore dell'array
            }
        }
    }
}