using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class PersonCollection1 : IEnumerable
    {
        private Person[] personCollection;
        public PersonCollection1(Person[] persons)
        {
            personCollection = persons;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new PersonEnumerator(personCollection);
        }
    }

    public class PersonEnumerator : IEnumerator
    {
        private Person[] personCollection;

        private Person current;

        private int index;

        public PersonEnumerator(Person[] persons)
        {
            index = -1;
            personCollection = persons;
        }

        /// <summary>
        /// 
        /// </summary>
        object IEnumerator.Current
        {
            get
            {
                return current;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool IEnumerator.MoveNext()
        {
            if (index < personCollection.Length - 1)
            {
                index++;
                current = personCollection[index];
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        void IEnumerator.Reset()
        {
            index = -1;
        }
    }
}
