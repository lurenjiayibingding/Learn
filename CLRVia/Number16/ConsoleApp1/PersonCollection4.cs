using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class PersonCollection4 : IEnumerable
    {
        private Person[] personCollection;
        public PersonCollection4(Person[] persons)
        {
            personCollection = persons;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            int i = 0;
            while (i < personCollection.Length)
            {
                yield return personCollection[i];
                i++;
            }
            yield break;
        }
    }
}
