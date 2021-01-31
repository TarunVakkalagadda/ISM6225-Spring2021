using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace openKattis
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1 : Enter the number of rows for the traingle:");
            try { 
            int n = Convert.ToInt32(Console.ReadLine());
            printTriangle(n);
            Console.WriteLine();
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Question 2:
            Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
            try
            {
                int n2 = Convert.ToInt32(Console.ReadLine());
                printPellSeries(n2);
                Console.WriteLine();
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
            }

             //Question 3:
            Console.WriteLine("Q3 : Enter the number to check if squareSums exist:");
            try
            {
                int n3 = Convert.ToInt32(Console.ReadLine());
                bool flag = squareSums(n3);
                if (flag)
                {
                    Console.WriteLine("Yes, the number can be expressed as a sum of squares of 2 integers");
                }
                else
                {
                    Console.WriteLine("No, the number cannot be expressed as a sum of squares of 2 integers");
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Question - 4
            int[] arr = { 1, 3, 1, 5, 4 };
            Console.WriteLine("Q4: Enter the absolute difference to check");
            int k = Convert.ToInt32(Console.ReadLine());
            int n4 = diffPairs(arr, k);
            Console.WriteLine("There exists {0} pairs with the given difference {1} ", n4,k);


            //Question 5:

            List<string> emails = new List<string>();
            emails.Add("dis.email + bull@usf.com");
            emails.Add("dis.e.mail+bob.cathy@usf.com");
            emails.Add("disemail+david@us.f.com");
            int ans5 = UniqueEmails(emails);
            Console.WriteLine("Q5: The number of unique emails is " + ans5);

            //Question 6:

            string[,] paths = new string[,] { { "London", "New York" }, { "New York", "Tampa" },
                                        { "Delhi", "London" } };
            string destination = DestCity(paths);
            Console.WriteLine("Q6: Destination city is " + destination);





        }

        private static void printTriangle(int n)
        {
            /*For getting prints for rows and colums using 2 loops. Using row-- as a counter to reduce the no of 
             count of rows during iteration.*/
            try
            {
                if (n != 0 && n > 0)
                {
                    int i, j, row_count;//intialisations
                    row_count = n - 1;//row count intialisation
                    for (j = 1; j <= n; j++)
                    {
                        for (i = 1; i <= row_count; i++)
                            Console.Write(" ");
                        row_count--;
                        for (i = 1; i <= 2 * j - 1; i++)//printing the no of stars based on the formula - 2*(j-1)
                            Console.Write("*");
                        Console.Write("\n");
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Invalid entry" + e.Message);
            }

        }



        private static void printPellSeries(int n2)
        {
            try
            {
                int temp = 0;//temporary variable to store the value during the loop
                int prev = 0;//first value in pell series
                int current = 1;//Second value in pell series
                while (n2 > 0)
                    /*Pell series is defined using the formula tn+1 = 2*t(n) + t(n-1)*/
                {
                    temp = 2 * current + prev;//calculates the pell value for tn+1
                    Console.Write(prev+",");//prints the previous value tn
                    prev = current;//swapping the previous value to current value
                    current = temp;//swapping current value to 
                    n2--;//decrementing the value of n to match the loop condition.

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid entry" + e.Message);
                throw;
            }
        }



            private static bool squareSums(int n3)
        {
            /*Taking an input number n3, running it in loop with i^2 less than n3 to reduce the number of loops checking for each case untill
             we find the match. Looping through each number untill the combination is equal to n3*/
            try
            {
                for (double i = 0; i * i <= n3; i++)//External loop for starts from 0 & runs till i^2 <= n3
                {
                    for (double j = 0; j * j <= n3; j++)//internal loop which does the same process.
                    {
                        if (i * i + j * j == n3)//checking for the condition stated in the question.
                        {
                            return true;

                        }
                        else { }

                    }


                }
                return false;

            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid entry" + e.Message);

                throw;
            }
        }


        private static int diffPairs(int[] nums, int k)
        {
            try
            {
                int count = 0;//Count initialisation

                for (int i = 0; i < nums.Length - 1; i++)//Running the loop to n-1 to avoid outOfRangeError which would be coming from 2nd loop.
                {
                    for (int j = i + 1; j < nums.Length; j++)//Running the loop with i+1 to avoid checking the current element.
                    {
                        if (nums[i] - nums[j] == k || nums[j] - nums[i] == k)//Checking the difference  between current number and next number to find if it is equal to k 
                        {
                            count++;//incrementing the count when the condition is successful.
                        }
                    }

                }
                return count;
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }


        private static int UniqueEmails(List<string> emails)
            /*Using string operations like spliting, replacing and trimming the end result*/
        {
            HashSet<String> uniqueEmail = new HashSet<String>();//Using HashSet to store only unique instances.
            try
            {
                foreach (var names in emails)//loping through each elements of list.
                {
                    var temp = names.Split('@');//spliting based on @, gives 2 values 
                    var check = temp[0].Split('+');//using the first value and splitting with + - again gives 2 values
                    var next_ = check[0].Replace(".", "");//using the first value and changing special charecter to whitespace
                    var trim = next_.TrimEnd();//trim the space at the end
                    uniqueEmail.Add(trim + "@" + temp[1]);//concating the trimed version of the element with the domain name & adding it to the hashset.


                }
                return uniqueEmail.Count;//returns count of all the unique instances.
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        private static string DestCity(string[,] paths)
            /*I have created 2 lists to store all sources in one place and all destinations at one place. Then i am using the concept of sets
             to find the destination.*/
        {
            List<string> source = new List<string>();//all sources go into this list
            List<string> destination = new List<string>();//all destinations go into this list
            int count = 1;//counter
            string x = "";//final output
            try
            {
                /*Looping through each element and using a counter variable with mod of 2 to send into source and destination*/
                foreach (String val in paths)
                {
                    if (count % 2 == 0)
                    {
                        destination.Add(val);
                        count += 1;

                    }
                    else
                    {
                        source.Add(val);
                        count += 1;

                    }
                }
                IEnumerable<string> query = destination.Except(source);//Used to get the difference between 2 lists.
                foreach (var str in query)//getting the output and storing into  variable
                {
                    x = str;
                }
                return x;


            }
            catch (Exception)
            {

                throw;
            }


        }





        
        
    }
}


