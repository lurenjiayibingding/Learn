using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class PersonCollection5
    {
        private Person[] personCollection;
        public PersonCollection5(Person[] persons)
        {
            personCollection = persons;
        }

        public IEnumerator MyGetEnumerator()
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
