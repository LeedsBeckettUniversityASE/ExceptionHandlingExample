namespace ExceptionHandlingWithMethods
{
    /// <summary>
    /// Simple program to illustrate passing error codes using methods (old fashioned) and exceptions.
    /// D J Mullier 2/23
    /// </summary>
    internal class Program
    {
        const int CHANCE = 10;
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
                Console.WriteLine("Processing failed."+e.Message);
                return;
            }

            Console.WriteLine("***SUCCESS***");
        }
        
        public int method1()
        {
            int err;
            Console.WriteLine("Method 1 processing....");
            Console.WriteLine("Method 1 processing....");
            err = method3();
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

            err = method2();
            return err;
        }

        public int method2()
        {
            Console.WriteLine("Method 2 processing....");
            Console.WriteLine("Method 2 processing....");
            Console.WriteLine("Method 2 processing....");
            Console.WriteLine("Method 2 processing....");
            Random rnd = new Random();

            int err = rnd.Next(CHANCE
                );
            if (err == 0)
                return -2;

            err = method3();
            return err;
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

            err =1;
            return err;
        }

        public int except1()
        {
            int err = 0;
            Console.WriteLine("Except 1 processing....");
            Console.WriteLine("Except 1 processing....");
            try
            {
                except2();
            }
            catch(ApplicationException e)
            {
                throw new ApplicationException(e.Message+ "Except 1 parsed two parts. ");
            }
            Console.WriteLine("Except 1 processing....");
            Console.WriteLine("Except 1 processing....");
            Random rnd = new Random();
            err = rnd.Next(CHANCE);
            if (err ==0)
            {
                throw new ApplicationException("Except 1 failed. ");
            }
            return err;
        }

        public int except2()
        {
            int err = 0;
            Console.WriteLine("Except 2 processing....");
            Console.WriteLine("Except 2 processing....");
          
            except3();  //here we don't care (for whatever reason) whether this fails or succeeds, we are just going to ignore it. It's up to the developer at this instance
          
            Console.WriteLine("Except 2 processing....");
            Console.WriteLine("Except 2 processing....");
            Random rnd = new Random();
            err = rnd.Next(CHANCE);
            if (err == 0)
            {
                throw new ApplicationException("Except 2 failed. ");
            }
            return err;
        }

        public int except3()
        {
            int err = 0;
            Console.WriteLine("Except 3 processing....");
            Console.WriteLine("Except 3 processing....");
           
            Console.WriteLine("Except 3 processing....");
            Console.WriteLine("Except 3 processing....");
            Random rnd = new Random();
            err = 0;// rnd.Next(CHANCE);
            if (err == 0)
            {
                throw new ApplicationException("Except 3 failed. ");
            }
            return err;
        }
    }
}