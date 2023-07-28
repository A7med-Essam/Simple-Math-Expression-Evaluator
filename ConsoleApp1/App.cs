namespace ConsoleApp1
{
    internal static class App
    {
        private const string symbols = "/*+%^";
        public static MathExpression Start(string args)
        {
            var expr = new MathExpression();
            string token = "";
            bool isLeftSideInit = false;
            bool isOperantInit = false;
            for (int i = 0; i < args.Length; i++)
            {
                var currentChar = args[i];
                if (char.IsDigit(currentChar))
                {
                    token += currentChar;
                    if (i == (args.Length - 1))
                    {
                        expr.RightSideOperant = double.Parse(token);
                        break;
                    }
                }
                else if (symbols.Contains(currentChar))
                {
                    if (!isLeftSideInit)
                    {
                        expr.LeftSideOperant = double.Parse(token);
                        token = "";
                        isLeftSideInit = true;
                    }
                    expr.Operation = ParseOperation(currentChar.ToString());
                    isOperantInit = true;
                }
                else if (char.IsLetter(currentChar))
                {
                    token += currentChar;
                }
                else if (currentChar == '-' && i > 0)
                {
                    if (!isOperantInit)
                    {
                        expr.Operation = ParseOperation(currentChar.ToString());
                        expr.LeftSideOperant = double.Parse(token);
                        isLeftSideInit = isOperantInit = true;
                        token = "";
                    }
                    else
                    {
                        token += currentChar;
                    }
                }
                else if (currentChar == '-' && i == 0)
                {
                    token += currentChar;
                }
                else if (currentChar == ' ')
                {
                    if (ParseOperation(token.ToString()) != MathOperation.None)
                    {
                        expr.Operation = ParseOperation(token.ToString());
                        isOperantInit = true;
                        token = "";
                    }
                    else if (!isLeftSideInit)
                    {
                        expr.LeftSideOperant = double.Parse(token);
                        isLeftSideInit = true;
                        token = "";
                    }

                }
            }
            return expr;
        }

        private static MathOperation ParseOperation(string token)
        {
            switch (token.ToLower())
            {
                case "%":
                case "mod":
                    return MathOperation.mod;
                case "-":
                    return MathOperation.subtraction;
                case "+":
                    return MathOperation.addition;
                case "/":
                    return MathOperation.division;
                case "*":
                    return MathOperation.multiply;
                case "^":
                case "pow":
                    return MathOperation.Power;
                case "sin":
                    return MathOperation.Sin;
                case "cos":
                    return MathOperation.Cos;
                case "tan":
                    return MathOperation.Tan;
                default:
                    return MathOperation.None;
            }
        }
    }
}
