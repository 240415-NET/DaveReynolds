using System.Collections;
using System.Globalization;

namespace practice;

interface IStorable
{
    void Save();
    void Load();
    bool NeedsSave {set; get;}
}

interface IEncryptable
{
    void Encrypt();
    void Decrypt();
}
       class Document : IStorable, IEncryptable
       {
        private string name;
        public Document(string s)
        {
            name = s;
            Console.WriteLine("Created a document with name '{0}'", s);
        }
        public void Save()
        {
            Console.WriteLine("Saving document");
        }
        public void Load()
        {
            Console.WriteLine("Loading document");
        } 
        public bool NeedsSave
        {
            get; set;
        }
        public void Encrypt()
        {Console.WriteLine("encyrpting");}
        public void Decrypt()
        {Console.WriteLine("decrypting");}

       }

class Program
{
    static void Main(string[] args)
    {   
          
        Document d = new Document("test document");
        /*
        if (d is IStorable)
        {d.Save();}

        IStorable istor = d as IStorable;
        if (istor != null)
        {istor.Load();}
        */
        d.Load();
        d.Encrypt();
        d.Save();
        d.Decrypt();
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();

    }

}
