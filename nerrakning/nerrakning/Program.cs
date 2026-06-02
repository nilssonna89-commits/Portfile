Console.WriteLine("Välkommen till FizzBuzz!");

foreach (var i in Enumerable.Range(1, 100))
{
    Console.WriteLine(i);
}

Console.Write("skriv ett tal mellan 1 och 30: ");
int tal = int.Parse(Console.ReadLine());


if (tal == 3 || tal == 6 || tal == 9 || tal == 12  || tal == 15 || tal == 18 || tal == 21 || tal == 24 || tal == 27 || tal == 30)
{
    Console.WriteLine("Fizz");
}
else if (tal == 5 || tal == 10 || tal == 15 || tal == 20 || tal == 25 || tal == 30)
{
    Console.WriteLine("Buzz");
}
else if (tal == 15 || tal == 30)
{
    Console.WriteLine("FizzBuzz");
}
else
{
    Console.WriteLine(tal);
}