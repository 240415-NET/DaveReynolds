using System.ComponentModel;

namespace classBasics.TodoList
{

public class TodoItem
{
//these are the fields that will make up the shape of my object
    private string Description = "Default";
    private bool status =false; 
    private int EstimatedTime = 60; //int as min
    private string DueDate = "4/24/2024";
    //default constructor 
    //also reffered to as not ARGs constructor
    public TodoItem()
    {

    }
    //specific contstuctors constructor overloading
    //all will make an object , but based on teh arguments provided when the object is call
    //only one constrcutor per object
    public TodoItem(string Description, int EstimatedTime, string DueDate)
    {
        this.Description = Description;
        this.EstimatedTime = EstimatedTime;
        this.DueDate = DueDate;
         }

         //:this() is shorthand to minimise the amount that needs to be written
         //we can use other constructors inside the class and how they implement thier methods
         //commented fields are copied from previous constructor via :this()
    public TodoItem(string Description, int EstimatedTime, string DueDate, bool status) : this (Description, EstimatedTime, DueDate)
    {
       // this.Description = Description;
        //this.EstimatedTime = EstimatedTime;
        //this.DueDate = DueDate;
         this.status = status;
    }
/* this is and all args consturctor
public TodoItem(string Description, int EstimatedTime, string DueDate, bool status) 
    {
       this.Description = Description;
        this.EstimatedTime = EstimatedTime;
        this.DueDate = DueDate;
         this.status = status;
    }
    */
//Methods are how i will interact with the objects
    public string GetDesctription()
    {
        return this.Description;
    }
    public void SetDescription(string Description)
    {
        this.Description = Description;
    }
    public int GetEstimatedTime()
    {
        return this.EstimatedTime;
    }
    public void SetEstimatedTime(int EstimatedTime)
    {
        this.EstimatedTime = EstimatedTime;
    }
    public string GetDueDate()
    {
        return this.DueDate;
    }
    public void SetDueDate(string DueDate)
    {
        this.DueDate = DueDate;
    }
    public bool GetStatus()
    {
        return this.status;
    }
    public void SetStatus(bool status)
    {
        this.status = status;
    }
//override toString to make it look pretty
    public override string ToString()
    {
        string CurrentStatus = "incomplete";
        if (status){CurrentStatus = "complete";}
        return $"{Description} - due: {DueDate}\nStatus: {CurrentStatus}"; //finish with 
    }
    class Program
        {
            static void Main(string[] args)
            {
                TodoItem Item1 = new TodoItem();
                Console.WriteLine(Item1);

                TodoItem Item2 = new TodoItem("Get Milk", 60, "Date", false);
                Console.WriteLine(Item2);
                Console.WriteLine($"Enter Task:\n");
                string Description = Console.ReadLine();

                Console.WriteLine($"estimated time:");
                int EstimatedTime = Convert.ToInt16(Console.ReadLine());

                Console.WriteLine($"Due Date:");
                string DueDate = Console.ReadLine();
               

                TodoItem newitem = new TodoItem(Description, EstimatedTime, DueDate, false);
                Console.WriteLine(newitem);

            }
        }
}
}
