using System;
using lab10;

namespace lab13
{
	public class CollectionHandlerEventArgs
	{
		public string NameCollection;
		public string ChangeCollection;
		public Printing Obj;

		public CollectionHandlerEventArgs(string collName, string action, Printing elementRef)
		{
			this.NameCollection = collName;
            this.ChangeCollection = action;
            this.Obj = elementRef;
        }
	}
}

