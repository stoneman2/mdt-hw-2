using System;
namespace Program
{
    //////////////////////////////////////////////////////////////////////////////////////////
    // STONEMAN INC. COPYRIGHT 2023, ALL RIGHTS RESERVED | Friends, please don't copy me.   //
    //////////////////////////////////////////////////////////////////////////////////////////
    public static class HW1_Triangle
    {
        public static int DoFactorial(int number)
        {
            if (number == 0)
            {
                return 1;
            }

            for (int i = number - 1; i > 0; i--)
            {
                number *= i;
            }
            return number;
        }
        public static int GetValue(int lines, int index)
        {
            return DoFactorial(lines) / ( DoFactorial(index) * DoFactorial(lines - index) );
        }
        public static bool IsValidRow(int lines)
        {
            if (lines < 0)
            {
                Console.WriteLine("Invalid Pascal’s triangle row number.");
                return false;
            }
            return true;
        }
        public static void InitTriangle(int lines)
        {
            if (IsValidRow(lines))
            {
                for (int n = 0; n <= lines; n++)
                {
                    if (n == 0)
                    {
                        Console.WriteLine(1);
                        continue;
                    }

                    for (int r = 0; r < (n + 1); r++)
                    {
                        Console.Write(GetValue(n, r) + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
        public static void TriangleQuestion(string[] args)
        {
            while(true)
            {
                Console.Write("Enter the number of rows: ");
                InitTriangle(int.Parse(Console.ReadLine()));
            }
        }
    }

    public static class HW2_DNA_REPLICATION
    {
        public static bool IsValidSequence(string halfDNASequence)
        {
            foreach(char nucleotide in halfDNASequence)
            {
                if(!"ATCG".Contains(nucleotide))
                {
                    return false;
                }
            }
            return true;
        }

        public static string ReplicateSeqeunce(string halfDNASequence)
        {
            string result = "";
            foreach(char nucleotide in halfDNASequence)
            {
                result += "TAGC"["ATCG".IndexOf(nucleotide)];
            }
            return result;
        }
        public static void Retry()
        {
            Console.Write("Do you want to process another sequence? (Y/N) : ");
            string answer = Console.ReadLine();
            if(answer == "Y")
            {
                InitDNA();
            }
            else if(answer == "N")
            {
                return;
            }
            else
            {
                Console.WriteLine("Please input Y or N.");
                Retry();
            }
        }
        
        public static void BeginSequence(string DNA)
        {
            Console.WriteLine("Do you want to replicate it? (Y/N) : ");
            string answer = Console.ReadLine();

            if(answer == "Y")
            {
                Console.WriteLine("Replicated half DNA sequence: {0}", ReplicateSeqeunce(DNA));
                Retry();
            }
            else if(answer == "N")
            {
                Retry();
            }
            else
            {
                Console.WriteLine("Please input Y or N.");
                BeginSequence(DNA);
            }
        }
        public static void InitDNA()
        {
            Console.Write("Enter the DNA sequence: ");
            string DNA = Console.ReadLine();

            if (IsValidSequence(DNA))
            {
                Console.WriteLine("Current half DNA sequence: {0}", DNA);
                BeginSequence(DNA);
            }
            else
            {
                Console.WriteLine("That half DNA sequence is invalid.");
                Retry();
            }
        }
    }

    public static class HW3_Legendary_Matrix
    {
        static void CalculateMatrix(float[,] matrix, string sign)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("Enter the matrix #2, row {0}, column {1}: ", i + 1, j + 1);
                    if (sign == "+")
                    {
                        matrix[i, j] += float.Parse(Console.ReadLine());
                    }
                    else if (sign == "-")
                    {
                        matrix[i, j] -= float.Parse(Console.ReadLine());
                    }
                }
            }

            Console.WriteLine("The matrix is: ");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("|  ");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(Math.Round(matrix[i, j], 1) + "  ");
                }
                Console.Write("|");
                Console.WriteLine();
            }

            BeginHW3();
        }
        static void FillMatrix(float[,] matrix, string sign)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("Enter the matrix #1, row {0}, column {1}: ", i + 1, j + 1);
                    matrix[i, j] = float.Parse(Console.ReadLine());
                }
            }

            CalculateMatrix(matrix, sign);
        }
        static void BeginMatrix(string sign)
        {
            Console.Write("Enter the matrix width: ");
            int width = int.Parse(Console.ReadLine());
            Console.Write("Enter the matrix height: ");
            int height = int.Parse(Console.ReadLine());

            float[,] matrix = new float[width, height];
            FillMatrix(matrix, sign);
        }
        public static void BeginHW3()
        {
            Console.Write("Enter '+' or '-': ");
            string sign = Console.ReadLine();
            
            if (sign == "+" || sign == "-")
            {
                BeginMatrix(sign);
            }
        }
    }

    public static class HW4_Investor
    {
        static void CalculatePopularArea(int length, int retention, int[] road)
        {
            int mostPopular = 0;
            int tempIndex = 0;

            // Select road segment to start.
            for (int i = retention; i < (length - retention); i++)
            {
                // Console.WriteLine("Retention: {0} | i: {1} | i - retention: {2}", retention, i, i - retention);
                int tempAdd = 0;
                // Count left and right.
                for (int j = i - retention; j <= i + retention; j++)
                {
                    tempAdd += road[j];
                }

                // Compare and assign.
                if (tempAdd > mostPopular)
                {
                    mostPopular = tempAdd;
                    tempIndex = i;
                }
            }

            Console.WriteLine("Most popular area is road #{0} with {1} inhabitants.", tempIndex + 1, mostPopular);
        }
        static void InitRoad(int length, int retention)
        {
            int[] road = new int[length];

            for (int i = 0; i < length; i++)
            {
                Console.Write("Enter road segment inhabitants for segment {0}: ", i + 1);
                road[i] = int.Parse(Console.ReadLine());
            }

            CalculatePopularArea(length, retention, road);
        }
        public static void BeginHW4()
        {
            Console.Write("Enter number of road segments: ");
            int length = int.Parse(Console.ReadLine()); 
            Console.Write("Enter max retention length: ");
            int retention = int.Parse(Console.ReadLine());

            InitRoad(length, retention);
        }
    }

    static class HomeworkSelector
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose homework number: ");
            Console.WriteLine("1. Pascal's Triangle");
            Console.WriteLine("2. DNA Replication");
            Console.WriteLine("3. Legendary Matrix");
            Console.WriteLine("4. Store Placement");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());
            switch(choice) {
                case 1:
                    HW1_Triangle.TriangleQuestion(args);
                    break;
                case 2:
                    HW2_DNA_REPLICATION.InitDNA();
                    break;
                case 3:
                    HW3_Legendary_Matrix.BeginHW3();
                    break;
                case 4:
                    HW4_Investor.BeginHW4();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Please input 1, 2, 3 or 4.");
                    Main(args);
                    break;
            }
        }
    }
}