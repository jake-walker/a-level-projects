using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Techniques_HW
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SEQUENCE");
            Sequence();

            Console.WriteLine("SELECTION");
            Selection();

            Console.WriteLine("ITERATION");
            Iteration();

            Console.WriteLine("RECURSION");
            Recursion(20);

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }

        static void Sequence()
        {
            // Sequence means that code statements runs in order that they
            // are put.

            Console.WriteLine("This runs first.");
            Console.WriteLine("This runs second.");
            // Both of these sentences are shown in the terminal, in the correct order.
        }

        static void Selection()
        {
            // Selection means that the code can make decisions and change what it
            // does depending on those decisions.

            // Get the day of the week.
            DayOfWeek day = DateTime.Now.DayOfWeek;
            
            // If the day is Friday
            if (day == DayOfWeek.Friday)
            {
                // Show a message about Friday.
                Console.WriteLine("Finally! It's Friday.");
            } else if (day == DayOfWeek.Sunday)
            {
                // Show a message about Sunday.
                Console.WriteLine("Make the most of the last day of the weekend!");
            } else
            {
                // Show a message if the day isn't Friday and Sunday.
                Console.WriteLine($"It is {day.ToString()}, today.");
            }
        }
        
        static void Iteration()
        {
            // Iteration is code that repeats a set number of times or until a condition
            // is met.

            // This loop runs 10 times. It is a count controlled loop.
            for (int i = 0; i < 10; i++)
            {
                // This prints the current number of the loop.
                Console.WriteLine($"The number is: {i}");
            }
            // This loop will output the numbers 0 to 9.

            string input = "";
            // This loop runs until the user enters stop. It is a condition controlled
            // loop.
            Console.WriteLine("Type 'stop' then press enter to continue...");
            while (input != "stop")
            {
                input = Console.ReadLine();
            }
        }

        // This function will output all the numbers up to the target number.
        static void Recursion(int targetNumber, int currentNumber = 0)
        {
            // This prints the current number.
            Console.WriteLine(currentNumber);

            // If the target number hasn't been met yet, the function needs to be called
            // again.
            if (currentNumber < targetNumber)
            {
                // This calls the function that we are in again. Passing in the target
                // number and the next number to print out.
                Recursion(targetNumber, currentNumber + 1);
            }
        }

        // Define a global variable, it can be accessed anywhere in this class.
        const string GlobalVariable = "I am a global variable.";
        
        static void GlobalAndLocalVariables()
        {
            // This creates a new local variable, it can only be accessed in this
            // function.
            string localVariable = "I am a local variable.";

            // This prints out the global variable, this works because the variable exists
            // in the context/scope of the class.
            Console.WriteLine(GlobalVariable);

            // This prints out the local variable, this works because it can access the variable
            // as it is defined in this function.
            Console.WriteLine(localVariable);
        }

        static void GlobalAndLocalVariables2()
        {
            // This line prints out the global variable. It can still be accessed
            // from this function because it is defined in the class.
            Console.WriteLine(GlobalVariable);

            // The following line doesn't work as the local variable isn't
            // defined in this context/scope, so it can't be accessed.
            // Console.WriteLine(localVariable);
        }

        static void FunctionAndProcedures()
        {
            // Functions usually require an input and always return back an output.
            int result = Function(4);

            // The result of the function can then be used later in the code.
            Console.WriteLine($"Func Result: {result}");

            // Procedures sometimes have an input and don't return anything back.
            // Procedures are just a set of instructions.
            Procedure(4);
        }
        
        static int Function(int input)
        {
            // Functions will always return back a value.
            return input * 2;
        }

        static void Procedure(int input)
        {
            // Procedures will just follow a set of instructions, for example:
            // printing a value to the console.
            Console.WriteLine(input * 2);
        }

        // Parameters can be passed into functions, the function will then use these
        // values to complete a task. Some of the parameters can be assigned default
        // values which can be used if that value isn't passed in.
        static void ParameterPassing(int required, int optional = 5)
        {
            // The parameters can then be used as local variables within the function.
            Console.WriteLine($"First Parameter: {required}, Second Parameter: {optional}");
        }
    }
}
