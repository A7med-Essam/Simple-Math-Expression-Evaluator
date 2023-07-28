namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter Math EQ:");
                var input = Console.ReadLine();
                if (input != null)
                {
                    var USER_EQ = App.Start(input);
                    global::System.Console.WriteLine($"{input} = {Calc(USER_EQ)}");
                }
            }
        }

        private static double Calc(MathExpression EQ)
        {
            switch (EQ.Operation)
            {
                case MathOperation.addition:
                    return (EQ.LeftSideOperant + EQ.RightSideOperant);

                case MathOperation.division:
                    return (EQ.LeftSideOperant / EQ.RightSideOperant);

                case MathOperation.Sin:
                    return (Math.Sin(EQ.RightSideOperant));

                case MathOperation.multiply:
                    return (EQ.LeftSideOperant * EQ.RightSideOperant);

                case MathOperation.Tan:
                    return (Math.Tan(EQ.RightSideOperant));

                case MathOperation.Cos:
                    return (Math.Cos(EQ.RightSideOperant));

                case MathOperation.mod:
                    return (EQ.LeftSideOperant % EQ.RightSideOperant);

                case MathOperation.subtraction:
                    return (EQ.LeftSideOperant - EQ.RightSideOperant);

                case MathOperation.Power:
                    return (Math.Pow(EQ.LeftSideOperant, EQ.RightSideOperant));
                default:
                    return 0;
            }
        }
    }
}