using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftthemeTask
{
    public class AmountSolver
    {
        public int[] coins = { 1, 2, 5, 10, 20, 50, 100, 200 }; // Array with coins equivalent
        uint[][] array; 

        public AmountSolver() {
            array = new uint[coins.Length][];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new uint[201];
            }

            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array[i].Length; j++)
                    array[i][j] = 0;
            array[0][0] = 1;
            countAmount();
        }  // These constructor without parameters count ways for 200 pesso (2 pounds). If you want more -
                                   // use construcor with parameter
        public AmountSolver(uint amount) { 
            array = new uint[coins.Length][];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new uint[amount];
            }
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array[i].Length; j++)
                    array[i][j] = 0;
            array[0][0] = 1;
            countAmount();
        } // Constructor with parameters allow you to increase Sum (instead of 2 pounds)

        public void countAmount() 
        {
            for (int i = 0; i < array[0].Length; i++) // length+1?
                for (int j = 0; j < coins.Length; j++)
                    for (int k = j; k < coins.Length; k++)
                        if (i + coins[k] <= array[0].Length-1)
                            array[k][i + coins[k]] += array[j][i];
        } // This metod count amount of ways for every Sum in between of 1 and 200 (for construcor without parameters)
                                      // and in between 1 and Sum you entered (for constructor with parameters)
                                      // THIS method is also part of the constructors.
        public void getAnswer() {
            int sum;
            uint answer = 0;
            Console.WriteLine("Enter sum in what you're interested: ");
            int.TryParse(Console.ReadLine(),out sum);

            try
            {
                for (int i = 0; i < array.Length; i++)
                    answer += array[i][sum];
                if (answer == 0) Console.WriteLine("You can'not use monets to form 0 pounds sum");
                else Console.WriteLine("The are {0} ways to form {1} pesso", answer, sum);
                Console.ReadKey();
            } catch (System.IndexOutOfRangeException ex) {
                Console.WriteLine("Those sum is out of counted range!");
                getAnswer();
            }
        } // This method allow you to enter SUM and return amount of ways to create this SUM by using coins from array.

    }
}
