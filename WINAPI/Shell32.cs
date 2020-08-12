using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WINAPI
{
    public struct tagMODULEENTRY32
    {
        public uint dwSize; //结构的大小（以字节为单位）。在调用模块 32First函数之前，请将此成员设置为 。如果未初始化dwSize，模块32First将失败。
        public uint th32ModuleID; //此成员不再使用，并且始终设置为 1。
        public uint th32ProcessID; //要检查其模块的进程的标识符。
        public uint GlblcntUsage; //模块的负载计数通常没有意义，通常等于 0xFFFF。
        public uint ProccntUsage; //模块的负载计数（与GlblcntUsage 相同），这通常没有意义，通常等于 0xFF。
        public byte[] modBaseAddr; //模块在拥有过程中的基本地址。
        public uint modBaseSize; //模块的大小（以字节为单位）。
        public IntPtr hModule; //拥有过程上下文中的模块句柄。
        public byte[] szModule; //模块名称。
        public byte[] szExePath; //模块路径。
    }
    public static class Shell32
    {
        /// <summary>
        /// 显示运行对话框<br/>
        /// 粒子：IntPtr hIcon = new System.Windows.Forms.Form().Icon.Handle;<br/>
        /// Shell32.RunFileDlg(User32.GetDesktopWindow(),<br/>
        /// hIcon,<br/>
        /// null,<br/>
        /// "创建新任务",<br/>
        /// "Windows 将根据您所输入的名称，为您打开相应的程序、文件夹、文档或者Internet 资源。",<br/>
        /// 0x20);
        /// </summary>
        /// <param name="hwndOwner">父窗口句柄</param>
        /// <param name="hIcon">图标句柄</param>
        /// <param name="lpstrDirectory"></param>
        /// <param name="lpstrTitle">标题</param>
        /// <param name="lpstrDescription">提示信息</param>
        /// <param name="uFlags"></param>
        [DllImport("Shell32.dll", EntryPoint = "#61", CharSet = CharSet.Auto)]
        public static extern void RunFileDlg(IntPtr hwndOwner, IntPtr hIcon, string lpstrDirectory, string lpstrTitle, string lpstrDescription, int uFlags);
        /// <summary>
        /// 显示一个对话框，允许用户从嵌入在资源（如可执行文件或 DLL 文件）中的可用选择中选择图标。
        /// </summary>
        /// <param name="hWnd">父窗口的句柄。此值可以是0。</param>
        /// <param name="pszIconPath">指向包含包含图标的默认资源的空终止、完全限定路径的字符串的指针。</param>
        /// <param name="cchIconPath">pszIconPath 中的字符数，包括终止的 NULL字符。</param>
        /// <param name="piIconIndex">指向在条目上指定初始选择的索引的整数的指针，当此函数成功返回时，将接收所选图标的索引。</param>
        /// <returns>如果成功，返回 1;否则，0。</returns>
        [DllImport("Shell32.dll")]
        public static extern int PickIconDlg(IntPtr hWnd, ref string pszIconPath, uint cchIconPath, ref int piIconIndex);
        /// <summary>
        /// 释放系统分配给将文件名传输到应用程序的内存。
        /// </summary>
        /// <param name="hDrop">描述丢弃文件的结构的标识符。</param>
        [DllImport("Shell32.dll")]
        public static extern void DragFinish(IntPtr hDrop);
        /// <summary>
        /// 对指定文件执行操作。
        /// </summary>
        /// <param name="hwnd">用于显示 UI 或错误消息的父窗口的句柄。如果操作未与窗口关联，则此值可以是NULL。</param>
        /// <param name="lpOperation">执行方式：<br/>
        /// edit： 启动编辑器并打开文档进行编辑。如果lpFile不是文档文件，则函数将失败。<br/>
        /// explore： 浏览lpFile 指定的文件夹。<br/>
        /// find： 在lp 目录指定的目录中启动搜索。<br/>
        /// open： 打开lpFile参数指定的项。该项目可以是文件或文件夹。<br/>
        /// print： 打印lpFile 指定的文件。如果lpFile不是文档文件，则函数将失败。<br/>
        /// runas： 以管理员身份启动应用程序。用户帐户控制 （UAC） 将提示用户同意运行提升的应用程序或输入用于运行应用程序的管理员帐户的凭据。<br/>
        /// NULL： 使用默认方式（如果可用）。如果没有，则使用"open"。
        /// </param>
        /// <param name="lpFile">指定的文件对象</param>
        /// <param name="lpParameters">如果文件对象为可执行程序，则此参数为命令行参数</param>
        /// <param name="lpDirectory">该字符串指定操作的默认（工作）目录。如果此值为NULL，则使用当前工作目录。如果在lpFile中提供了相对路径，则不要对lpDirectory 使用相对路径。</param>
        /// <param name="nShowCmd">指定打开应用程序时如何显示它的标志<br/>如果lpFile指定文档文件，则标志将简单地传递给关联的应用程序。它由应用程序来决定如何处理它。<br/>
        /// 0： 隐藏窗口并激活另一个窗口。<br/>
        /// 1： 激活并显示窗口。如果窗口最小化或最大化，Windows 会将其还原到其原始大小和位置。首次显示窗口时，应用程序应指定此标志。<br/>
        /// 2： 激活窗口，并将它显示为最小化的窗口。<br/>
        /// 3： 激活窗口，并将它显示为最大化的窗口。<br/>
        /// 4： 显示窗口的最新大小和位置。活动窗口保持活动状态。<br/>
        /// 5： 激活窗口并按其当前大小和位置显示窗口。<br/>
        /// 6： 最小化指定的窗口，并激活 z 顺序中的下一个顶级窗口。<br/>
        /// 7： 将窗口显示为最小化的窗口。活动窗口保持活动状态。<br/>
        /// 8： 显示处于当前状态的窗口。活动窗口保持活动状态。<br/>
        /// 9： 激活并显示窗口。如果窗口最小化或最大化，Windows 会将其还原到其原始大小和位置。应用程序在还原最小化的窗口时应指定此标志。<br/>
        /// 10： 根据启动应用程序的程序传递给SW_的"创建过程"结构中指定的"标记"设置显示状态。应用程序应调用此标志的 ShowWindow以设置其主窗口的初始显示状态。
        /// </param>
        /// <returns>
        /// 如果函数成功，它将返回大于 32 的值。如果函数失败，它将返回一个错误值，指示失败的原因。<br/>
        /// 0：操作系统内存或资源不足。<br/>
        /// 2：未找到指定的文件。<br/>
        /// 3：未找到指定的路径。<br/>
        /// 5：操作系统拒绝访问指定文件。<br/>
        /// 8：内存不足，无法完成该操作。<br/>
        /// 11：.exe 文件无效（非 Win32 .exe 或 .exe 映像中的错误）。<br/>
        /// 26：发生共享冲突。<br/>
        /// 27：文件名关联不完整或无效。<br/>
        /// 28：无法完成 DDE 事务，因为请求已定时。<br/>
        /// 29：DDE 事务失败。<br/>
        /// 30：无法完成 DDE 事务，因为正在处理其他 DDE 事务。<br/>
        /// 32：未找到指定的 DLL。<br/>
        /// 31：没有与给定文件扩展名关联的应用程序。如果您尝试打印不可打印的文件，也会返回此错误。
        /// </returns>
        [DllImport("Shell32.dll")]
        public static extern int ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);



    }
}
