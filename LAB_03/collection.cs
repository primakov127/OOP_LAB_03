using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_03
{
    public class collection<T> : IDisposable
    {
        private static collection<T> instance;

        private bool disposed = false;

        private T[] items = new T[0];
        public int Count { get; private set; }

        private collection()
        {
            Count = 0;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);  // Удаляет из списка финализации => Не вызывать деструктор
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Console.WriteLine("Файл успешно закрыт");
                }
                disposed = false;
            }
        }

        ~collection()
        {
            Dispose(false);
            Console.WriteLine("Финализатор");
        }

        public static collection<T> getInstance()
        {
            if (instance == null)
                instance = new collection<T>();
            return instance;
        }

        public void addItem(T item)
        {
            Array.Resize(ref items, items.Count() + 1);
            items[items.Count() - 1] = item;
            Count++;
        }

        public void removeItem(T item)
        {
            items[Array.IndexOf(items, item)] = items[items.Count() - 1];
            Array.Resize(ref items, items.Count() - 1);
            Count--;
        }

        public T this[int index]
        {
            get {
                return items[index];
                }
            set {
                items[index] = value;
                }
        }


        public IEnumerable<T> getItems()
        {
            return items;
        }

        public void printAll()
        {
            Console.WriteLine();
            foreach (var oneitem in getItems())
            {
                Console.WriteLine(oneitem.ToString());
            }
            Console.WriteLine();
        }

        public bool attend(T item)
        {
            bool rc = false;
            foreach (var oneitem in getItems())
            {
                if (item.ToString() == oneitem.ToString())
                    rc = true;
            }
            return rc;
        }

        public collection<T> Merge(collection<T> second)
        {
            collection<T> table = new collection<T>();
            foreach (var oneitem in second.getItems())
            {
                if (!(this.attend(oneitem)))
                    table.addItem(oneitem);
            }
            return table;
        }
    }
}
