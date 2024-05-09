using System.Collections;
using System.Linq;

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
        
        d.Load();
        d.Encrypt();
        d.Save();
        d.Decrypt();
        */
        Console.WriteLine("\nPress Enter to continue...");
        string s = Console.ReadLine().ToLower();
        string bb = new string(s.Reverse().ToArray());
        Console.WriteLine(bb);

        //char a= Convert.ToChar(Console.ReadLine().ToLower());
         //a++;
        
         string code= "";
        s.ToLower();

        for(int i = 0; i<aa.Length;i++)
        {
            switch (aa[i])

            {
                case 'a':
                code +="01";
                break;
                 case 'b':
                code +="02";
                break;
                 case 'c':
                code +="03";
                break;
                 case 'd':
                code +="04";
                break;
                 case 'e':
                code +="05";
                break;
                 case 'f':
                code +="06";
                break;
                 case 'g':
                code +="07";
                break;
                 case 'h':
                code +="08";
                break;
                 case 'i':
                code +="09";
                break;
                 case 'j':
                code +="10";
                break;
                 case 'k':
                code +="11";
                break;
                 case 'l':
                code +="12";
                break;
                 case 'm':
                code +="13";
                break;
                 case 'n':
                code +="14";
                break;
                 case 'o':
                code +="15";
                break;
                 case 'p':
                code +="16";
                break;
                 case 'q':
                code +="17";
                break;
                 case 'r':
                code +="18";
                break;
                 case 's':
                code +="19";
                break;
                 case 't':
                code +="20";
                break;
                 case 'u':
                code +="21";
                break;
                 case 'v':
                code +="22";
                break;
                 case 'w':
                code +="23";
                break;
                 case 'x':
                code +="24";
                break;
                 case 'y':
                code +="25";
                break;
                 case 'z':
                code +="26";
                break;


            }

        }
        Console.WriteLine(code);
    
    }

}
