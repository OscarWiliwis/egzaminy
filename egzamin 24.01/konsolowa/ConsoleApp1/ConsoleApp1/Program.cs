using System;

class Program
{
    static void Main(string[] args)
    {
        string pesel = "55030101193";

        Console.WriteLine("Podaj numer PESEL (11 cyfr, domyślny to 55030101193):");
        string input = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(input) && input.Length == 11)
        {
            pesel = input;
        }

        char plec = SprawdzPlec(pesel);
        string plecString = (plec == 'K') ? "Kobieta" : "Mężczyzna";

        Console.WriteLine($"Płeć: {plecString}");

        bool isValid = SprawdzSumeKontrolna(pesel);

        if (isValid)
        {
            Console.WriteLine("Numer PESEL jest poprawny.");
        }
        else
        {
            Console.WriteLine("Numer PESEL jest niepoprawny.");
        }
    }

    static char SprawdzPlec(string pesel)
    {
        int plecCyfra = int.Parse(pesel[9].ToString());
        return (plecCyfra % 2 == 0) ? 'K' : 'M';
    }

    /**********************************************
    nazwa funkcji: SprawdzSumeKontrolna
    opis funkcji: Funkcja sprawdza poprawność numeru PESEL na podstawie sumy kontrolnej.
    parametry: pesel - string, numer PESEL jako 11-cyfrowy ciąg znaków.
    zwracany typ i opis: bool - true, jeśli suma kontrolna jest poprawna, w przeciwnym razie false.
    autor: 00000000000
    ***********************************************/
    static bool SprawdzSumeKontrolna(string pesel)
    {
        int[] wagi = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
        int suma = 0;

        for (int i = 0; i < 10; i++)
        {
            suma += int.Parse(pesel[i].ToString()) * wagi[i];
        }

        int M = suma % 10;
        int R = (M == 0) ? 0 : (10 - M);
        int ostatniaCyfra = int.Parse(pesel[10].ToString());

        return R == ostatniaCyfra;
    }
}
