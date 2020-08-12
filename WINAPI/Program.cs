using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Reflection;

namespace WINAPI
{
    public unsafe class Program
    {
        [DllImport("KernelBase.dll")]
        public static extern void Beep(int Hz, int time);
        static void Main(string[] args)
        {
            //QwQ
            //有些的注释是抄的MSDN文档的，所以翻译可能有点不准
        }
    }
}
