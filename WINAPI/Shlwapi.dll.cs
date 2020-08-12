using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WINAPI
{
    
    public static class Shlwapi
    {
        /// <summary>
        /// 处理 DLL 的安装和设置。
        /// </summary>
        /// <param name="bInstall">如果正在安装DLL，为 true;如果正在安装 DLL，将实现 true。如果正在卸载，请为 false。</param>
        /// <param name="pszCmdLine">由regsvr32 传递的字符串，指示要使用的设置过程。此值可以是NULL。</param>
        /// <returns>如果成功，则返回0</returns>
        [DllImport("Shlwapi.dll")]
        public static extern int DllInstall(bool bInstall, string pszCmdLine);
    }
}
