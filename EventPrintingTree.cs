using System;
using lab12;
using lab10;



namespace lab13
{
	public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);


	public class EventPrintingTree : PrintingTree
	{
        public event CollectionHandler CollectionCountChanged;
        public event CollectionHandler CollectionReferenceChanged;


        public string Name;


        public EventPrintingTree(string name)
        {
            this.Name = name;
        }


        public virtual void OnCollectionCountChanged(object source, CollectionHandlerEventArgs args)
        {
            if (CollectionCountChanged != null)
                CollectionCountChanged(source, args);
        }


        public virtual void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
        {
            if (CollectionReferenceChanged != null)
                CollectionReferenceChanged(source, args);
        }


        public override bool Remove(string key)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(this.Name, "delete", this[key]));
            return base.Remove(key);
        }


        public override void Add(string key, Printing value)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(this.Name, "add", value));
            base.Add(key, value);
        }


        public override Printing this[string key]
        {
            get
            {
                return base[key];
            }
            set
            {
                OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs(this.Name, "changed", this[key]));
                base[key] = value;
            }
        }
    }
}

