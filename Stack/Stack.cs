using DataStructures.Stack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class Program
    {
        private string expression;
        LinkedListStack<string> S = new LinkedListStack<string>();

        private string Expression()
        {
            int val1, val2, ans;
            for (int i = 0; i < expression.Length; i++)
            {
                String c = expression.Substring(i, 1);
                if (c.Equals("*"))
                {
                    val1 = int.Parse(S.Pop());
                    val2 = int.Parse(S.Pop());
                    ans = val2 * val1;
                    S.Push(ans.ToString());
                }
                else if (c.Equals("+"))
                {
                    val1 = int.Parse(S.Pop());
                    val2 = int.Parse(S.Pop());
                    ans = val2 + val1;
                    S.Push(ans.ToString());
                }
                else if (c.Equals("-"))
                {
                    val1 = int.Parse(S.Pop());
                    val2 = int.Parse(S.Pop());
                    ans = val2 - val1;
                    S.Push(ans.ToString());
                }
                else if (c.Equals("/"))
                {
                    val1 = int.Parse(S.Pop());
                    val2 = int.Parse(S.Pop());
                    ans = val2 / val1;
                    S.Push(ans.ToString());
                }
                else
                {
                    S.Push(c);
                }
            }
            return S.Pop();
        }

        public static string Run(string expression)
        {
            Program e = new Program();
            e.expression = expression;
            return e.Expression();
        }
        static void Main(string[] args)
        {

            Console.WriteLine(Program.Run("231*+9-")); //Post-Fix Uygulaması

            Console.WriteLine("");

            var charset = new char[] { 'm', 'e', 'r', 't' };
            var stack1 = new DataStructures.Stack.Stack<char>();
            var stack2 = new DataStructures.Stack.Stack<char>(StackType.LinkedList);

            foreach (var c in charset)
            {
                Console.WriteLine(c);
                stack1.Push(c);
                stack2.Push(c);
            }

            Console.WriteLine("\nPeek");
            Console.WriteLine($"Stack1 : {stack1.Peek()} ");
            Console.WriteLine($"Stack2 : {stack2.Peek()} ");

            Console.WriteLine("\nCount");
            Console.WriteLine($"Stack1 : {stack1.Count} ");
            Console.WriteLine($"Stack2 : {stack2.Count} ");

            Console.WriteLine("\nPop");
            Console.WriteLine($"Stack1 : {stack1.Pop()} has been removed ");
            Console.WriteLine($"Stack2 : {stack2.Pop()} has been removed ");

            Console.WriteLine("\nCount");
            Console.WriteLine($"Stack1 : {stack1.Count} ");
            Console.WriteLine($"Stack2 : {stack2.Count} ");

            Console.WriteLine("\nPeek");
            Console.WriteLine($"Stack1 : {stack1.Peek()} ");
            Console.WriteLine($"Stack2 : {stack2.Peek()} ");

        }
    }
}
