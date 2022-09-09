using System;
using System.Collections.Generic;
using System.Text;

public class ScientificCalculator
{
	public static double EvaluateExpression(string expression)
	{
		char[] chrs = expression.Trim().ToCharArray();

		Stack<double> numbers = new Stack<double>();

		Stack<char> operators = new Stack<char>();

		for (int i = 0; i < chrs.Length; i++)
		{
			

			
			if (char.IsDigit(chrs[i]))
			{
				StringBuilder number = new StringBuilder();

				while (i < chrs.Length && char.IsDigit(chrs[i]))
				{
					number.Append(chrs[i++]);
				}
				numbers.Push(int.Parse(number.ToString()));

				i--;
			}

			else if (chrs[i].Equals('('))
			{
				operators.Push(chrs[i]);
			}

			else if (chrs[i].Equals(')'))
			{
				while (!operators.Peek().Equals('('))
				{
					numbers.Push(Calculate(operators.Pop(), numbers.Pop(), numbers.Pop()));
	 			}
				operators.Pop();
			}

		
			else if (chrs[i] == '+' || chrs[i] == '-' || chrs[i] == '*' || chrs[i] == '/')
			{

				while (operators.Count > 0 && CheckOperatorPrecedence(chrs[i], operators.Peek()))
				{
					numbers.Push(Calculate(operators.Pop(), numbers.Pop(), numbers.Pop()));
				}
				operators.Push(chrs[i]);
			}
		}

		while (operators.Count > 0)
		{
			numbers.Push(Calculate(operators.Pop(), numbers.Pop(), numbers.Pop()));
		}

		return numbers.Pop();
	}

	
	public static bool CheckOperatorPrecedence(char op1, char op2)
	{
		if (op2 == '(' || op2 == ')')
		{
			return false;
		}
		if ((op1 == '*' || op1 == '/') &&
			(op2 == '+' || op2 == '-'))
		{
			return false;
		}
		else
		{
			return true;
		}
	}

	public static double Calculate(char operatr, double num2, double num1)
	{
		switch (operatr)
		{
			case '+':
				return num1 + num2;
			case '-':
				return num1 - num2;
			case '*':
				return num1 * num2;
			case '/':
				if (num2 == 0)
				{
					throw new
					System.NotSupportedException(
						"Cannot divide by zero");
				}
				return num1 / num2;
		}
		return 0;
	}

	
	
}

