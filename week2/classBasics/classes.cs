namespace classBasics.Classes
{
    public class ExampleClass
    {
        //fields
        //unique to each instance of a type
        //allowing individual objects
        public string exampleString{get;set;}

        public static int instanceCount;
        
        //Access Modifiers - for encapsulation/abstraction
        //public - avaaiable everywhere
        //private - allowing accessable within object
        //internal - only accessable within assembly (project or program)
        //protected - accessable to child(INHERITIANCE!!!)

        //readonly only assigned at initialization or in constructor
        private readonly int maxLimit = 100;
        public int GetMaxLimit()
        {
            return this.maxLimit;
        }

        // Object Initializers
        // Allow properties to be initialized witht call constructors
        //property
        //these are a pattern of fields in classes
        //public datatype name
        //these properties can have {get; set;}
        public string name {get; set;}
        public int age1 {get; set;}
    }
//constructors in c# are special methosd used to initialize new instance of a class
//they are called at initializtion and 
    
    
    
    
//initializing class person
   public class Person
    {
        private string firstName = "First";
        private string lastName = "Last";
        private string Email = "E@mail.com";
        private int age = 18;
        private bool onHoliday = false;

        public Person()
        {

        }


//creating constructor no return type since this returns the class
    public Person(string firstName, string lastName, string Email, int age, bool onHoliday)
    {
        //change this to set methods below
        /*
        this.firstName = firstName;
        this.lastName = lastName;
        this.Email = Email;
        this.age = age;
        this.onHoldiay = onHoliday;
        */
        SetFirstName(firstName);
        SetLastName(lastName);
        SetEmail(Email);
        SetAge(age);
        SetOnHoldiday(onHoliday); 
    }


        public string GetFirstName()
            {
                return this.firstName;
            }

        public void SetFirstName(string firstName)
            {
               if (firstName.Count() == 0){return;}
                this.firstName = firstName.Trim();
            }
        public string GetLastName()
            {
                return this.lastName;
            }

        public void SetLastName(string lastName)
            {
                this.lastName = lastName;
            }

        public string GetEmail()
            {
                return this.Email;
            }

        public void SetEmail(string Email)
            {
                this.Email = Email;
            }
        public int GetAge()
            {
                return this.age;
            }

        public void SetAge(int age)
            {
                this.age = age;
            }
        public bool GetOnHoliday()
            {
                return this.onHoliday;
            }

        public void SetOnHoldiday(bool onHoliday)
            {
                this.onHoliday = onHoliday;
            }

        //overrides implict ToString in Console.WriteLine
       public override string ToString()
        {
            return $"FirstName: {firstName}\nLastName: {lastName}\n Email: {Email}\n Age: {age}\n On Vacation: {onHoliday}";
        }
       /* public string PrettyPrint(Person)
        {
            return $"FirstName: {firstName}\nLastName: {lastName}\n Email: {Email}\n Age: {age}\n On Vacation: {onHoliday}";
        }*/
    }
}