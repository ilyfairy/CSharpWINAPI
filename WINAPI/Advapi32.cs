using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WINAPI
{
    class Advapi32
    {
        /// <summary>
        /// OpenProcessToken函数打开与进程关联的访问令牌。
        /// </summary>
        /// <param name="ProcessHandle">打开其访问令牌的进程的句柄。进程必须具有PROCESS_QUERY_INFORMATION访问权限。</param>
        /// <param name="DesiredAccess">指定指定访问令牌的已请求访问类型的访问掩码。这些请求的访问类型与令牌的任意访问控制列表（DACL） 进行比较，以确定授予或拒绝哪些访问。</param>
        /// <param name="TokenHandle">指向在函数返回时标识新打开的访问令牌的句柄的指针。</param>
        /// <returns>如果函数成功，则返回值为true。
        ///如果函数失败，则返回值为false。</returns>
        [DllImport("user32.dll")]
        public static extern bool OpenProcessToken(IntPtr ProcessHandle,uint DesiredAccess,ref IntPtr TokenHandle); 
    }
}
