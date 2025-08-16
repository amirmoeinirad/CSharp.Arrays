
// Amir Moeini Rad
// May 31, 2025

// Main Concept: Arrays in C#.NET, Upcasting and Downcasting


using System;


namespace Arrays
{
    internal class Father
    {
        // Field
        protected string fatherName;


        // Default constructor
        public Father()
        {
            fatherName = "Ahmad";
        }


        // Custom constructor
        public Father(string name)
        {
            fatherName = name;
        }


        // Property to access the name
        public string Name
        {
            get
            {
                return fatherName;
            }
        }
    }



    //////////////////////////////////////////////



    internal class Child : Father
    {
        // Field
        private string childName;


        // Default constructor
        public Child()
        {
            childName = "Amir";
        }


        // Custom constructor that calls the base class constructor        
        public Child(string cName, string fName) : base(fName)
        {
            childName = cName;
        }


        // Property to access the name
        public new string Name
        {
            get
            {
                return childName;
            }
        }
    }



    //////////////////////////////////////////////



    // The main application class
    internal class ArrayApp
    {
        static void Main()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("Arrays in C#.NET...");
            Console.WriteLine("-------------------\n");


            // A one-dimensional array of integers
            int[] intArray = new int[10];

            for (int i = 0; i <= 9; i++)
                intArray[i] = i + 1;

            Console.Write("The values of the array:");
            foreach (int i in intArray)
            {
                Console.Write(" {0}", i);
            }


            Console.Write("\nThe length of the array: {0}\n", intArray.Length);


            // A one-dimensional array of strings
            string name = "\nApollo";
            foreach (char ch in name)
                Console.Write(ch);


            /*------------------------------------------------------------*/


            // A two-dimensional rectangular array (2 x 3)
            char[,] scoresArray = new char[,] { { 'a', 'b', 'c' }, { 'A', 'B', 'C' } };

            Console.WriteLine("\n\nscoresArray[1,2]: {0}", scoresArray[1, 2]);

            Console.WriteLine("\nThe total number of elements in 'scoresArray' is: {0}", scoresArray.Length);
            Console.WriteLine("The number of rows in 'scoresArray' is: {0}", scoresArray.GetLength(0));
            Console.WriteLine("The number of columns in 'scoresArray' is: {0}", scoresArray.GetLength(1));


            /*------------------------------------------------------------*/


            // A two-dimensional jagged array
            char[][] lettersJaggedArray = new char[4][];
            lettersJaggedArray[0] = new char[] { 'A', 'm', 'i', 'r' };
            lettersJaggedArray[1] = new char[] { 'M', 'o', 'i', 'n', 'i' };
            lettersJaggedArray[2] = new char[] { 'R', 'a', 'd' };
            lettersJaggedArray[3] = new char[] { 'x', 'y' };

            Console.WriteLine("\nlettersJaggedArray[1][3]: {0}", lettersJaggedArray[1][3]);

            Console.WriteLine("\nThe number of rows or arrays in 'lettersJaggedArray' is: {0}", lettersJaggedArray.Length);
            Console.WriteLine("The number of elements in subarray 'lettersJaggedArray[0]' is: {0}", lettersJaggedArray[0].Length);

            Console.WriteLine("\nThe elements in lettersJaggedArray[0]:");
            for (int i = 0; i < lettersJaggedArray[0].Length; i++)
            {
                Console.WriteLine("letters[0][{0}]: {1}", i, lettersJaggedArray[0][i]);
            }


            // Note: The difference between array.Length & array.GetLength().


            Console.WriteLine();


            /*------------------------------------------------------------*/


            // UPCASTING


            Console.WriteLine("-----------------\n");


            Father FatherObject = new Father();
            Child ChildObject = new Child();

            Father[] TestArray = new Father[3];
            TestArray[0] = FatherObject;
            TestArray[1] = ChildObject as Father; // In practice, ChildObject cannot be converted to Father (explicit upcasting).
            TestArray[2] = ChildObject;

            for (int i = 0; i < TestArray.Length; i++)
            {
                Console.WriteLine("TestArray[{0}]: {1}", i, TestArray[i].GetType());
            }


            Console.WriteLine();


            // (1) Upcasting (implicit conversion).
            Father FatherObject1 = new Father();
            Child ChildObject1 = new Child("Arman", "Mahmood");
            Console.WriteLine("FatherObject1's Name: {0}", FatherObject1.Name);
            Console.WriteLine("ChildObject1's Name: {0}", ChildObject1.Name);

            // The FatherObject2's Name is the same as ChildObject2's Father Name.
            FatherObject1 = ChildObject1;
            Console.WriteLine("After Upcasting...");
            Console.WriteLine("FatherObject1's Name: {0}", FatherObject1.Name);
            Console.WriteLine("ChildObject1's Name: {0}\n", ChildObject1.Name);


            /*------------------------------------------------------------*/


            // DOWNCASTING


            // (2) Downcasting (explicit conversion)
            Father FatherObject2 = new Father("Mahdi");
            Child ChildObject2 = new Child("Hassan", "Hossein");
            Console.WriteLine("FatherObject2's Name: {0}", FatherObject2.Name);
            Console.WriteLine("ChildObject2's Name: {0}", ChildObject2.Name);

            // This will not compile because ChildObject2 is not a Father.
            // ChildObject2 = (Child)FatherObject2;
            // But
            // Child part will be added to Father part. Now, FatherObject3 also contains ChildObject3's properties.
            FatherObject2 = ChildObject2;
            // Now, the following Downcasting is possible.
            ChildObject2 = (Child)FatherObject2;
            Console.WriteLine("After Downcasting...");
            Console.WriteLine("FatherObject2's Name: {0}", FatherObject2.Name);
            Console.WriteLine("ChildObject2's Name: {0}", ChildObject2.Name);


            Console.WriteLine("\nDone.");
        }
    }
}

/*

In general, downcasting a base class to a derived class is not allowed in C#.
The reason is that the base class does not have the properties or methods of the derived class.

*/