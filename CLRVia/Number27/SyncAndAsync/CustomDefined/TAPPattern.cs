using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncAndAsync.CustomDefined
{
    /// <summary>
    /// TAP模式
    /// </summary>
    internal class TAPPattern
    {
        public async Task ReadFile(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
            }
        }
    }
}
