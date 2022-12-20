class Program
{
    static void Main(string[] args)
    {
        int sum = 0;
        List<string> myList;
        myList.Add("A");
        for (int i = 4;i<=1000; i++)
        {
            if ((i % 4 == 0) || (i % 6 == 0))
            {
                sum += i;
            }
        }
        Console.WriteLine(sum);
        Console.ReadLine();
    }
}