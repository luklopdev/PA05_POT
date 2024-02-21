/*
Dla danych dwóch liczb naturalnych a i b, wyznaczyć ostatnią cyfrę liczby ab.

Zadanie
Napisz program, który:
wczyta ze standardowego wejścia: podstawę a oraz wykładnik b,
wyznaczy ostatnią cyfrę liczby ab,
wypisze wynik na standardowe wyjście.
Wejście
W pierwszej linii wejścia znajduje się jedna liczba całkowia D (1≤D≤10), oznaczjąca liczbę przypadków do rozważenia. Opis każdego przypadku podany jest w jednym wierszu, zawierającym dwie liczby naturalne a i b oddzielone pojedynczym odstępem (spacją), takie, że (1 ≤ a,b ≤ 1 000 000 000).

Wyjście
Dla każdego przypadku z wejścia Twój program powinien wypisać (w osobnej linii dla każdego przypadku z wejścia) cyfrę jedności liczby ab zapisanej dziesiętnie.

Przykład
Dla danych wejściowych:
2
2 3
3 3
poprawną odpowiedzią jest:
8
7

 */

ushort t = Convert.ToUInt16(Console.ReadLine());

if (t < 1 || t > 10)
    throw new ArgumentOutOfRangeException(nameof(t));

Dictionary<ushort, ushort[]> lastDigitsDictionary = new Dictionary<ushort, ushort[]>()
{
    [0] = new ushort[] { 0 },
    [1] = new ushort[] { 1 },
    [2] = new ushort[] { 2, 4, 8, 6 },
    [3] = new ushort[] { 3, 9, 7, 1 },
    [4] = new ushort[] { 4, 6 },
    [5] = new ushort[] { 5 },
    [6] = new ushort[] { 6 },
    [7] = new ushort[] { 7, 9, 3, 1 },
    [8] = new ushort[] { 8, 4, 2, 6 },
    [9] = new ushort[] { 9, 1 },
};

for (int i = 0; i < t; i++)
{
    var inputs = Console.ReadLine()?.Split(" ");
    uint a = Convert.ToUInt32(inputs![0]);
    uint b = Convert.ToUInt32(inputs[1]);

    if (a < 1 || a > 1_000_000_000 || b < 1 || b > 1_000_000_000)
        throw new ArgumentOutOfRangeException();

    var lastDigitsArray = lastDigitsDictionary[GetLastDigitsOfBasic(a)];
    Console.WriteLine(GetLastDigitOfPower(b, lastDigitsArray));
}

ushort GetLastDigitsOfBasic(uint a) => Convert.ToUInt16(a % 10);

ushort GetLastDigitOfPower(uint b, ushort[] lastDigitsArray)
{
    var pow = lastDigitsArray.Length;

    var tempB = b;
    ushort length = Convert.ToUInt16(lastDigitsArray.Length - 1);
    ushort index = length;

    while (tempB % pow != 0)
    {
        tempB--;

        if (index == length)
            index = 0;
        else
            index++;

    }

    var result = lastDigitsArray[index];

    return result;
}
