using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.DefineClass
{
    /// <summary>
    /// 内存读写类
    /// </summary>
    public class MemoryUtils
    {
        #region
        //从指定内存中读取字节集数据
        [DllImport("kernel32.dll", EntryPoint = "ReadProcessMemory")]
        private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, IntPtr lpNumberOfBytesRead);

        //从指定内存中写入字节集数据
        [DllImport("kernel32.dll", EntryPoint = "WriteProcessMemory")]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, IntPtr lpNumberOfBytesWritten);

        //打开一个已存在的进程对象，并返回进程的句柄
        [DllImport("kernel32.dll", EntryPoint = "OpenProcess")]
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        //关闭一个内核对象。其中包括文件、文件映射、进程、线程、安全和同步对象等。
        [DllImport("kernel32.dll")]
        private static extern void CloseHandle(IntPtr hObject);
        #endregion

        private IntPtr _handle = IntPtr.Zero;

        private int _pid = 0;

        public MemoryUtils(int pid)
        {
            _pid = pid;
            _handle = OpenProcess(0x1F0FFF, false, pid);
        }

        ~MemoryUtils()
        {
            CloseHandle(_handle);
        }

        public byte[] ReadToBytes(IntPtr address, int size)
        {
            byte[] buffer = new byte[size];
            ReadProcessMemory(_handle, address, buffer, size, IntPtr.Zero);
            return buffer;
        }
    }
}
