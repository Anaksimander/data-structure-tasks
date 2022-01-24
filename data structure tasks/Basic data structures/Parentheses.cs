using System;
using System.Collections.Generic;
using System.Text;

namespace data_structure_tasks
{
    class Parentheses
    {
        Stack<(char value,int num)> bracketStack;
        int generalCount;
        string str;
        public Parentheses()
        {
            str = Console.ReadLine();

            bracketStack = new Stack<(char,int)>(str.Length);
            generalCount = 0;
        }
        
        public void CheackOut()
        {
            foreach (var item in str)
            {
                generalCount++;
                if ((item == '(') || (item == '{') || (item == '['))
                {
                    bracketStack.Push((item, generalCount));

                }
                else
                if ((item == ')') || (item == '}') || (item == ']'))
                {
                    if ((bracketStack.Count != 0) &&
                        ((bracketStack.Peek().value == '(' && item == ')') ||
                         (bracketStack.Peek().value == '{' && item == '}') ||
                         (bracketStack.Peek().value == '[' && item == ']')))
                    {
                        bracketStack.Pop();
                    }
                    else
                    {
                        Console.WriteLine(generalCount);
                        return;
                    }
                }
            }
            if(bracketStack.Count == 0)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine(bracketStack.Peek().num);
            }

        }

    }
}
