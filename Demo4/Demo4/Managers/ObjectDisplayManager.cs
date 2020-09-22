using Demo4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo4.Managers
{
    public class ObjectDisplayManager <T> where T : IDisplayablecs
    {
        private T item;

        public ObjectDisplayManager(T item)
        {
            this.item = item;
        }

        public void Show()
        {
            //Console.WriteLine(item.)
        }

        public void Show2<K>()
        {

        }
    }
}
