using System;
using System.IO;

class Program
{
    public int solve(int A)
    {
        int[] primeFactorCount = new int[A + 1];

        for (int i = 2; i <= A; i++)
        {
            // i is prime if no prime factor assigned yet
            if (primeFactorCount[i] == 0)
            {
                // increment count for all multiples of i
                for (int j = i; j <= A; j += i)
                {
                    primeFactorCount[j]++;
                }
            }
        }

        int lucky = 0;
        for (int i = 2; i <= A; i++)
        {
            if (primeFactorCount[i] == 2)
                lucky++;
        }

        return lucky;
    }

    static void Main(string[] args)
    {
        string inputPath = "input.txt";
        string outputPath = "output.txt";
        string input = File.Exists(inputPath) ? File.ReadAllText(inputPath) : string.Empty;
        int A = int.Parse(input.Trim());
        int result = new Program().solve(A);
        File.WriteAllText(outputPath, result.ToString());
    }
}
