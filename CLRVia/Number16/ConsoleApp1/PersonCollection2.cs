using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class PersonCollection2 : IEnumerable<Person>
    {

        private Person[] personCollection;
        public PersonCollection2(Person[] persons)
        {
            personCollection = persons;
        }
        IEnumerator<Person> IEnumerable<Person>.GetEnumerator()
        {
            int i = 0;
            while (i < personCollection.Length)
            {
                yield return personCollection[i];
                i++;
            }
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return null;
        }
    }
}
