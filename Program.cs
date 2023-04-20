using lab12;
using lab10;

namespace lab13
{
    public class Program
    {
        public static void Main()
        {
            EventPrintingTree ept1 = new EventPrintingTree("printing tree 1");
            EventPrintingTree ept2 = new EventPrintingTree("printing tree 2");

            Journal j1 = new Journal();
            ept1.CollectionCountChanged += new CollectionHandler(j1.CollectionCountChanged);
            ept1.CollectionReferenceChanged += new CollectionHandler(j1.CollectionReferenceChanged);

            Journal j2 = new Journal();
            ept1.CollectionReferenceChanged += new CollectionHandler(j2.CollectionReferenceChanged);
            ept2.CollectionReferenceChanged += new CollectionHandler(j2.CollectionReferenceChanged);


            for (int i = 0; i < 10; i++)
            {
                Book b = new Book();
                ept1.Add(i.ToString(), b);
                ept2.Add(i.ToString(), b);
            }

            ept1["2"] = new Magazine();
            ept2["1"] = new Magazine();

            ept1.Remove("4");
            ept2.Remove("5");


            Console.WriteLine("journal 1: \n");
            foreach(var je in j1.journal)
            {
                Console.WriteLine(je);
            }

            Console.WriteLine("journal 2: \n");
            foreach (var je in j2.journal)
            {
                Console.WriteLine(je);
            }
        }
    }
}