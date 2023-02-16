namespace ExceptionHandlingWithMethods
{
    /// <summary>
    /// Simple program to illustrate passing error codes using methods (old fashioned) and exceptions.
    /// D J Mullier 2/23
    /// </summary>
    internal class Program
    {
        const int CHANCE = 5;  //liklihood that an error will occur (lower number = more likely)
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            new Program();
           
        }

        Program()
        {
            Console.WriteLine("Beginning method version....");
            int err = method1();
            if (err<0)
            {
                Console.WriteLine("process failed with error code "+err);
            }
            else
            {
                Console.WriteLine("***SUCCESS***");
            }


            Console.WriteLine("Beginning exception version....");
            try
            {
                except1();
            }
            catch(ApplicationException e)
            {
                Console.WriteLine("Processing failed. "+e.Message);
                return;
            }

            Console.WriteLine("***SUCCESS***");
        }
        
        public int method1()
        {
            //method capable of failing and also calls other service methods
            int err;
            Console.WriteLine("Method 1 processing....");
            Console.WriteLine("Method 1 processing....");
            err = method3(); //call to service method 3 could fail
            if (err < 0)
            {
                return err;
            }
            Console.WriteLine("Method 1 processing....");
            Console.WriteLine("Method 1 processing....");
            Random rnd = new Random();
           
            err = rnd.Next(CHANCE);
            if (err == 0)
                return -1;

            err = method2(); //call to service method 2 could fail
            return err;
        }

        public int method2()
        {
            //method 2 doesn't actually do anything that would produce an error, but it must still pass error codes back
            int err;
            Console.WriteLine("Method 2 processing....");
            Console.WriteLine("Method 2 processing....");
            Console.WriteLine("Method 2 processing....");
            Console.WriteLine("Method 2 processing....");
           
            err = method3(); //call to service method 3 could fail
            if (err < 0)
            {
                return err;
            }
            else
            {
                return 1;  //simply passing a code on increases coupling as higher level methods need to know what lower level codes mean
            }
        }

        public int method3()
        {
            Console.WriteLine("Method 3 processing....");
            Console.WriteLine("Method 3 processing....");
            Console.WriteLine("Method 3 processing....");
            Console.WriteLine("Method 3 processing....");
            Random rnd = new Random();

            int err = rnd.Next(CHANCE/2);
            if (err == 0)
                return -3;

            return 1; //success
        }


        //now for the exception handling versions
        public void except1()
        {
            int err = 0;
            Console.WriteLine("Except 1 processing....");
            Console.WriteLine("Except 1 processing....");
            try
            {
                except3();
            }
            catch(ApplicationException e)
            {
                throw new ApplicationException(e.Message+ "Except 1 parsed two parts. ");
            }
            Console.WriteLine("Except 1 processing....");
            Console.WriteLine("Except 1 processing....");
            Random rnd = new Random();
            err = rnd.Next(CHANCE);
            err = 0; //uncomment to force fail or set to one for force pass
            except2();        
            if (err ==0)
            {
               
                throw new ApplicationException("Except 1 failed. ");
            }
           
           
        }

        public void except2()
        {
            int err = 0;
            Console.WriteLine("Except 2 processing....");
            Console.WriteLine("Except 2 processing....");
            Console.WriteLine("Except 2 processing....");
            Console.WriteLine("Except 2 processing....");
            except3();  //here we don't care (for whatever reason) whether this fails or succeeds, we are just going to ignore it and let the exception travel up until it is caught elsewhere. It's up to the developer at this instance
        }

        public void except3()
        {
            int err = 0;
            Console.WriteLine("Except 3 processing....");
            Console.WriteLine("Except 3 processing....");
           
            Console.WriteLine("Except 3 processing....");
            Console.WriteLine("Except 3 processing....");
            Random rnd = new Random();
            err =  rnd.Next(CHANCE);
            err = 0; //uncomment to force fail or set to one for force pass
            if (err == 0)
            {
                throw new ApplicationException($"Except 3 failed with code {err}. ");
            }
           
        }
    }
}