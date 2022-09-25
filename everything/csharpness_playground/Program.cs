/*
** Resources to see:
** Old program style? np: https://learn.microsoft.com/en-us/dotnet/core/tutorials/top-level-templates#use-the-old-program-style
** Official .NET documentation: https://learn.microsoft.com/en-us/dotnet/core/tutorials/debugging-with-visual-studio-code?pivots=dotnet-6-0
** Debugging: https://code.visualstudio.com/docs/editor/debugging#_launch-configurations
** Read about "Solutions" in the .NET documentations
*/

// .NET 6.0+ template
// Console.WriteLine("Hello, World!");

// .NET 5.0 template
/* 
	namespace Program
	{
		class Program
		{
			static void Main(string[], args)
			{
				Console.WriteLine("Hello World!");
			}
		}
	}
*/

static int add(int x, int y)
{
	int result = x + y;
	return result;
}

int MAX_INT = 0b1111111111111111111111111111111;
int MIN_INT = 0b1111111111111111111111111111111 << 31;
int x = 60;
double y = 60.60;
char z = 'z';
string str = "my string";

Console.WriteLine(add(2, 2));
float floatA = 2.3f;
double doubleA = 12;
sbyte sbyteA = 14;

int intA = (int)doubleA;
short shortA = (short)intA;
Console.WriteLine(intA);
double doubleB = 2.123456789;
float floatB = (float)doubleB;
Console.WriteLine(floatB);

//Look into ToInt, ToString, and so on...