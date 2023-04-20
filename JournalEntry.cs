using System;
using lab10;

namespace lab13
{
	public class JournalEntry
	{
        public string NameCollection { get; set; }
        public string ChangeCollection { get; set; }
        public string Obj { get; set; }

        public override string ToString()
        {
            return "----------\n" +
                NameCollection + "\n" +
                ChangeCollection + "\n" +
                Obj + 
                "----------\n";
        }

        public JournalEntry(string collName, string action, string obj)
		{
            this.NameCollection = collName;
            this.ChangeCollection = action;
            this.Obj = obj;
        }
	}
}

