using MyException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleException
{
    [Serializable]
    public class DiskFullExceptionArgs : ExceptionArgs
    {
        private readonly string m_diskpath;

        public DiskFullExceptionArgs(string diskPath)
        {
            m_diskpath = diskPath;
        }

        public string DiskPath
        {
            get
            {
                return m_diskpath;
            }
            set
            {
            }
        }

        public override string Message
        {
            get
            {
                if (string.IsNullOrEmpty(m_diskpath))
                {
                    return base.Message;
                }
                else
                {
                    return "磁盘" + m_diskpath + base.Message;
                }
            }
        }
    }
}
