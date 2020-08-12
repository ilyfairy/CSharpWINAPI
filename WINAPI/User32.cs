using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WINAPI
{

    public struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }

    public struct tagCWPRETSTRUCT
    {
        public IntPtr lResult;
        public int lParam;
        public uint wParam;
        public uint message;
        public IntPtr hwnd;
    }
    /// <summary>
    /// 包含有关键盘输入事件的信息。
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct tagKBDLLHOOKSTRUCT
    {
        /// <summary>
        /// 定一个虚拟键码。该代码必须有一个价值的范围1至254
        /// </summary>
        public int vkCode;
        /// <summary>
        /// 指定的硬件扫描码
        /// </summary>
        public int scanCode;
        /// <summary>
        /// 下表描述了此值的布局。<br/>
        /// 第0位：指定密钥是扩展键，如功能键还是数字键盘上的键。如果键是扩展键，则值为 1;如果该键是扩展键，则值为 1。否则，它是 0。<br/>
        /// 第1位：指定事件是否从在较低完整性级别运行的进程中注入。如果是这种情况，则值为 1;如果是，则值为 1。否则，它是 0。请注意，每当设置位 1 时，也会设置位 4。<br/>
        /// 第2~3：保留。<br/>
        /// 第4位：指定是否注入了事件。如果是这种情况，则值为 1;如果是，则值为 1。否则，它是 0。请注意，在设置位 4 时，不一定设置位 1。<br/>
        /// 第5位：上下文代码。如果按下 ALT 键，则值为 1;如果按下 ALT 键，则该值为 1。否则，它是 0。<br/>
        /// 第6位：保留。<br/>
        /// 第7位：转换状态。如果按下键，则值为 0;如果正在释放该值，则值为 1。<br/>
        /// </summary>
        public int flags;
        /// <summary>
        /// 此消息的时间戳，相当于GetMessageTime 将返回此消息的时间。
        /// </summary>
        public int time;
        /// <summary>
        /// 与消息关联的其他信息。
        /// </summary>
        public int dwExtraInfo;
    }
    /// <summary>
    /// 包含有关 GUI 线程的信息。
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct tagGUITHREADINFO
    {
        /// <summary>
        /// 此结构体的大小，使用Marshal.SizeOf来获取大小
        /// </summary>
        public uint cbSize;
        /// <summary>
        /// 线程状态。此成员可以是以下一个或多个值。<br/>
        /// GUI_CARETBLINKING：护理器的闪烁状态。如果护套可见，将设置此位。<br/>
        /// GUI_INMENUMODE：线程的菜单状态。如果线程处于菜单模式，将设置此位。<br/>
        /// GUI_INMOVESIZE：线程的移动状态。如果线程位于移动或大小循环中，则设置此位。<br/>
        /// GUI_POPUPMENUMODE：线程的弹出式菜单状态。如果线程具有活动弹出式菜单，将设置此位。<br/>
        /// GUI_SYSTEMMENUMODE：线程的系统菜单状态。如果线程处于系统菜单模式，将设置此位。<br/>
        /// </summary>
        public uint flags;
        /// <summary>
        /// 线程中活动窗口的句柄。
        /// </summary>
        public IntPtr hwndActive;
        /// <summary>
        /// 具有键盘焦点的窗口的句柄。
        /// </summary>
        public IntPtr hwndFocus;
        /// <summary>
        /// 捕获鼠标的窗口的句柄。
        /// </summary>
        public IntPtr hwndCapture;
        /// <summary>
        /// 拥有任何活动菜单的窗口的句柄。
        /// </summary>
        public IntPtr hwndMenuOwner;
        /// <summary>
        /// 移动或大小循环中窗口的句柄。
        /// </summary>
        public IntPtr hwndMoveSize;
        /// <summary>
        /// 显示护用的窗口的句柄。
        /// </summary>
        public IntPtr hwndCaret;
        /// <summary>
        /// 在客户端坐标中，相对于 hwndCaret 成员指定的窗口，在客户端坐标中，看向的界矩形。
        /// </summary>
        public RECT rcCaret;
    }
    /// <summary>
    /// 包含来自线程的消息队列的消息信息。
    /// </summary>
    struct tagMSG
    {
        /// <summary>
        /// 窗口过程接收消息的窗口的句柄。当消息是线程消息时，此成员为NULL。
        /// </summary>
        IntPtr hwnd;
        /// <summary>
        /// 消息标识符。应用程序只能使用低单词;高字由系统保留。
        /// </summary>
        uint message;
        /// <summary>
        /// 有关消息的其他信息。
        /// </summary>
        uint wParam;
        /// <summary>
        /// 有关消息的其他信息。
        /// </summary>
        int lParam;
        /// <summary>
        /// 消息发布的时间。
        /// </summary>
        uint time;
        /// <summary>
        /// 发布消息时，屏幕坐标中的光标位置。
        /// </summary>
        Point pt;
        uint lPrivate;
    }
    /// <summary>
    /// 包含标题栏信息。
    /// </summary>
    public struct tagTITLEBARINFO
    {
        /// <summary>
        /// 结构的大小（以字节为单位）。调用方必须将此成员设置为sizeof(tagTITLEBARINFO)。
        /// </summary>
        public uint cbSize;
        /// <summary>
        /// 标题栏的坐标。这些坐标包括除窗口菜单之外的所有标题栏元素。
        /// </summary>
        public RECT rcTitleBar;
        /// <summary>
        /// 接收标题栏每个元素的值的数组。以下是数组表示的标题栏元素。<br/>
        /// 0：标题栏本身。<br/>
        /// 1：保留。<br/>
        /// 2：	最小化按钮。<br/>
        /// 3：最大化按钮。<br/>
        /// 4：帮助按钮。<br/>
        /// 5：关闭按钮。<br/>
        /// 元素的值：<br/>
        /// STATE_SYSTEM_FOCUSABLE：元素可以接受焦点。<br/>
        /// STATE_SYSTEM_INVISIBLE：元素不可见。<br/>
        /// STATE_SYSTEM_OFFSCREEN：元素没有可见的表示形式。<br/>
        /// STATE_SYSTEM_UNAVAILABLE：该元素不可用。<br/>
        /// STATE_SYSTEM_PRESSED：元素处于按下状态。
        /// </summary>
        public uint[] rgstate;
    }


    /// <summary>
    /// USER32.DLL
    /// </summary>
    public static unsafe class User32
    {
        static void test()
        {




        }
        public delegate bool EnumThreadWndProc(IntPtr hwnd, int lParam);
        public delegate bool WndEnumProc(IntPtr hWnd, int lParam);
        public delegate int HookProc(int nCode, int wParam, IntPtr lParam);
        public delegate void Timerproc(IntPtr Arg1, uint Arg2, ref uint Arg3, uint Arg4);



        //SetWindowsHookEx.idHook&HookProc.nCode
        /// <summary>
        /// 安装一个挂钩过程，在系统将消息发送到目标窗口过程之前监视消息。
        /// </summary>
        public const int WH_CALLWNDPROC = 4;
        /// <summary>
        /// 安装一个挂钩过程，用于监视消息在目标窗口过程处理后。
        /// </summary>
        public const int WH_CALLWNDPROCRET = 12;
        /// <summary>
        /// 安装一个挂钩过程，该过程接收对 CBT 应用程序有用的通知。<br/>
        /// 在以下事件之前，系统都会调用WH_ CBT Hook子程,这些事件包括:<br/>
        /// 1、激活，建立，销毁，最小化，最大化，移动,改变尺寸等窗口事件;<br/>
        /// 2、完成系统指令;<br/>
        /// 3、来自系统消息队列中的移动鼠标，键盘事件;<br/>
        /// 4、设置输入焦点事件;<br/>
        /// 5、同步系统消息队列事件。<br/>
        /// </summary>
        public const int WH_CBT = 5;
        public const int WH_DEBUG = 9;
        public const int WH_FOREGROUNDIDLE = 11;
        public const int WH_GETMESSAGE = 3;
        public const int WH_JOURNALPLAYBACK = 1;
        public const int WH_JOURNALRECORD = 0;
        public const int WH_KEYBOARD = 2;
        public const int WH_KEYBOARD_LL = 13;
        public const int WH_MOUSE = 7;
        public const int WH_MOUSE_LL = 14;
        public const int WH_MSGFILTER = -1;
        public const int WH_SHELL = 10;
        public const int WH_SYSMSGFILTER = 6;

        public const int WM_KEYUP = 0x101;

        //tagGUITHREADINFO .flags
        public const uint GUI_CARETBLINKING = 0x00000001;
        public const uint GUI_INMOVESIZE = 0x0000002;
        public const uint GUI_INMENUMODE = 0x0000004;
        public const uint GUI_SYSTEMMENUMODE = 0x0000008;
        public const uint GUI_POPUPMENUMODE = 0x00000010;

        //GetWindow.uCmd
        public const int GW_HWNDFIRST = 0;
        public const int GW_HWNDLAST = 1;
        public const int GW_HWNDNEXT = 2;
        public const int GW_HWNDPREV = 3;
        public const int GW_OWNER = 4;
        public const int GW_CHILD = 5;
        public const int GW_ENABLEDPOPUP = 6;

        //tagTITLEBARINFO.rcTitleBar
        public const uint STATE_SYSTEM_FOCUSABLE = 0x00100000;
        public const uint STATE_SYSTEM_INVISIBLE = 0x00008000;
        public const uint STATE_SYSTEM_OFFSCREEN = 0x00010000;
        public const uint STATE_SYSTEM_UNAVAILABLE = 0x00000001;
        public const uint STATE_SYSTEM_PRESSED = 0x0000008;

        //ShowWindow.nCmdShow
        public const int SW_HIDE = 0;
        public const int SW_SHOWNORMAL = 1;
        public const int SW_SHOWMINIMIZED = 2;
        public const int SW_SHOWMAXIMIZED = 3;
        public const int SW_MAXIMIZE = 3;
        public const int SW_SHOWNOACTIVATE = 4;
        public const int SW_SHOW = 5;
        public const int SW_MINIMIZE = 6;
        public const int SW_SHOWMINNOACTIVE = 7;
        public const int SW_SHOWNA = 8;
        public const int SW_RESTORE = 9;
        public const int SW_SHOWDEFAULT = 10;
        public const int SW_FORCEMINIMIZE = 11;

        //TileWindows.wHow
        public const int MDITILE_VERTICAL = 0x0000;
        public const int MDITILE_HORIZONTAL = 0x0001;

        public const int MDITILE_SKIPDISABLED = 0x0001;

        //GetSystemMetrics.nIndex
        public const int SM_ARRANGE = 56;
        public const int SM_CLEANBOOT =67;
        public const int SM_CMONITORS = 80;
        public const int SM_CMOUSEBUTTONS = 43;
        public const int SM_CONVERTIBLESLATEMODE = 0x2003;
        public const int SM_CXBORDER = 5;
        public const int SM_CXCURSOR = 13;
        public const int SM_CXDLGFRAME = 17;
        public const int SM_CXDOUBLECLK = 36;
        public const int SM_CXDRAG = 68;
        public const int SM_CXEDGE = 45;
        public const int SM_CXFIXEDFRAME = 7;
        public const int SM_CXFOCUSBORDER = 83;
        public const int SM_CXFRAME = 32;
        public const int SM_CXFULLSCREEN = 16;
        public const int SM_CXHSCROLL = 21;
        public const int SM_CXHTHUMB = 10;
        public const int SM_CXICON = 11;
        public const int SM_CXICONSPACING = 38;
        public const int SM_CXMAXIMIZED = 61;
        public const int SM_CXMAXTRACK = 59;
        public const int SM_CXMENUCHECK = 71;
        public const int SM_CXMENUSIZE = 54;
        public const int SM_CXMIN = 28;
        public const int SM_CXMINIMIZED = 57;
        public const int SM_CXMINSPACING = 47;
        public const int SM_CXMINTRACK = 34;
        public const int SM_CXPADDEDBORDER = 92;
        public const int SM_CXSCREEN = 0;
        public const int SM_CXSIZE = 30;
        public const int NAMESM_CXSIZEFRAME = 32;
        public const int SM_CXSMICON = 49;
        public const int SM_CXSMSIZE = 52;
        public const int SM_CXVIRTUALSCREEN = 78;
        public const int SM_CXVSCROLL = 2;
        public const int SM_CYBORDER = 6;
        public const int SM_CYCAPTION = 4;
        public const int SM_CYCURSOR = 14;
        public const int SM_CYDLGFRAME = 8;
        public const int SM_CYDOUBLECLK = 37;
        public const int SM_CYDRAG = 69;
        public const int SM_CYEDGE = 46;
        public const int SM_CYFIXEDFRAME = 8;
        public const int SM_CYFOCUSBORDER = 84;
        public const int SM_CYFRAME = 33;
        public const int SM_CYFULLSCREEN = 17;
        public const int SM_CYHSCROLL = 3;
        public const int SM_CYICON = 12;
        public const int SM_CYICONSPACING = 39;
        public const int SM_CYKANJIWINDOW = 18;
        public const int SM_CYMAXIMIZED = 62;
        public const int SM_CYMAXTRACK = 60;
        public const int SM_CYMENU = 15;
        public const int SM_CYMENUCHECK = 72;
        public const int SM_CYMENUSIZE = 55;
        public const int SM_CYMIN = 29;
        public const int SM_CYMINIMIZED = 58;
        public const int SM_CYMINSPACING = 48;
        public const int SM_CYMINTRACK = 35;
        public const int SM_CYSCREEN = 1;
        public const int SM_CYSIZE = 31;
        public const int SM_CYSIZEFRAME = 33;
        public const int SM_CYSMCAPTION = 51;
        public const int SM_CYSMICON = 50;
        public const int SM_CYSMSIZE = 53;
        public const int SM_CYVIRTUALSCREEN = 79;
        public const int SM_CYVSCROLL = 20;
        public const int SM_CYVTHUMB = 9;
        public const int SM_DBCSENABLED = 42;
        public const int SM_DEBUG = 22;
        public const int SM_DIGITIZER = 94;
        public const int SM_IMMENABLED = 82;
        public const int SM_MAXIMUMTOUCHES = 95;
        public const int SM_MEDIACENTER = 87;
        public const int SM_MENUDROPALIGNMENT = 40;
        public const int SM_MIDEASTENABLED = 74;
        public const int SM_MOUSEPRESENT = 19;
        public const int SM_MOUSEHORIZONTALWHEELPRESENT = 91;
        public const int SM_MOUSEWHEELPRESENT = 75;
        public const int SM_NETWORK = 63;
        public const int SM_PENWINDOWS = 41;
        public const int SM_REMOTECONTROL = 0x2001;
        public const int SM_REMOTESESSION = 0x1000;
        public const int SM_SAMEDISPLAYFORMAT = 81;
        public const int SM_SECURE = 44;
        public const int SM_SERVERR2 = 89;
        public const int SM_SHOWSOUNDS = 70;
        public const int SM_SHUTTINGDOWN = 0x2000;
        public const int SM_SLOWMACHINE = 73;
        public const int SM_STARTER = 88;
        public const int SM_SWAPBUTTON = 23;
        public const int SM_SYSTEMDOCKED = 0x2004;
        public const int SM_TABLETPC = 86;
        public const int SM_XVIRTUALSCREEN = 76;
        public const int SM_YVIRTUALSCREEN = 77;

        //SendMessage.Msg
        /// <summary>
        /// 设置窗口的文本。<br/>
        /// wParam：NULL<br/>
        /// lParam：需要设置的字符串<br/>
        /// 返回值：如果设置了文本，则返回值为TRUE。
        /// </summary>
        public const uint WM_SETTEXT = 0x000C;
        /// <summary>
        /// 将对应于窗口的文本复制为调用方提供的缓冲区。<br/>
        /// wParam：要复制的最大字符数，包括终止的 null 字符。<br/>
        /// lParam：指向要接收文本的缓冲区的指针。<br/>
        /// 返回值是复制的字符数，不包括终止的 null 字符。<br/>
        /// </summary>
        public const uint WM_GETTEXT = 0x000D;
        /// <summary>
        /// 设置按钮的样式。<br/>
        /// wParam：按钮样式。此参数可以是按钮样式的组合。<br/>
        /// lParam：指定是否重绘按钮。TRUE 的值重绘按钮;FALSE 的值不会重绘按钮。<br/>
        /// 返回值：始终为0
        /// </summary>
        public const uint BM_SETSTYLE = 0x00F4;
        /// <summary>
        /// 设置窗口是否能够被重画
        /// wParam：如果此参数为 TRUE，则可以在更改后重绘内容。如果此参数为 FALSE，则在更改后无法重绘内容。
        /// lParam：未使用此参数。
        /// 返回值：如果应用程序处理此消息，则返回零。
        /// </summary>
        public const uint WM_SETREDRAW = 0x000B;
        /// <summary>
        /// 非只读或禁用的编辑控件在WM_CTLCOLOREDIT时将消息发送到其父窗口。<br/>
        /// 通过响应此消息，父窗口可以使用指定的设备上下文句柄来设置编辑控件的文本和背景颜色。<br/>
        /// wParam：编辑控件窗口的设备上下文的句柄。<br/>
        /// lParam：编辑控件的句柄。<br/>
        /// 返回值：如果应用程序处理此消息，它必须返回画笔的句柄。系统使用画笔绘制编辑控件的背景。
        /// </summary>
        public const uint WM_CTLCOLOREDIT = 0x0133;





        /// <summary>
        /// 设置指定窗口的显示状态。
        /// </summary>
        /// <param name="hWnd">窗口的句柄。</param>
        /// <param name="nCmdShow">控制窗口的显示方式。如果启动应用程序的程序提供STARTUPINFO结构，则在应用程序首次调用ShowWindow时将忽略此参数。否则，第一次调用ShowWindow时，该值应为WinMain函数在其nCmdShow参数中获得的值。在随后的调用中，此参数可以是下列值之一。<br/>
        /// SW_SHOWNORMAL：激活并显示一个窗口。如果窗口最小化或最大化，则系统会将其还原到其原始大小和位置。首次显示窗口时，应用程序应指定此标志。<br/>
        /// SW_HIDE：隐藏该窗口并激活另一个窗口。<br/>
        /// SW_MAXIMIZE：最大化指定的窗口。<br/>
        /// SW_MINIMIZE：最小化指定的窗口并以Z顺序激活下一个顶级窗口。<br/>
        /// SW_RESTORE：激活并显示窗口。如果窗口最小化或最大化，则系统会将其还原到其原始大小和位置。恢复最小化窗口时，应用程序应指定此标志。<br/>
        /// SW_SHOW：激活窗口并以其当前大小和位置显示它。<br/>
        /// SW_SHOWDEFAULT：根据启动应用程序的程序传递给CreateProcess函数的STARTUPINFO结构中指定的SW_值设置显示状态。<br/>
        /// SW_SHOWMAXIMIZED：激活窗口并将其显示为最大化窗口。<br/>
        /// SW_SHOWMINIMIZED：激活窗口并将其显示为最小化窗口。<br/>
        /// SW_SHOWMINNOACTIVE：将窗口显示为最小化窗口。该值类似于SW_SHOWMINIMIZED，除了未激活窗口。<br/>
        /// SW_SHOWNA：以当前大小和位置显示窗口。该值与SW_SHOW相似，除了不激活窗口。<br/>
        /// SW_SHOWNOACTIVATE：显示窗口的最新大小和位置。该值类似于SW_SHOWNORMAL，除了未激活窗口。<br/>
        /// SW_FORCEMINIMIZE：最小化一个窗口，即使拥有该窗口的线程没有响应。仅当最小化来自其他线程的窗口时，才应使用此标志。
        /// </param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        /// <summary>
        /// 检索具有指定关系（Z-Order 或所有者）到指定窗口的窗口的句柄。
        /// </summary>
        /// <param name="hWnd">窗口的句柄。根据 uCmd 参数的值，检索到的窗口句柄是相对于此窗口的。</param>
        /// <param name="uCmd">
        /// 指定窗口与其句柄要检索的窗口之间的关系。此参数可以是以下值之一。<br/>
        /// GW_CHILD：如果指定的窗口是父窗口，则检索到的句柄标识 Z 顺序顶部的子窗口;如果指定的窗口是父窗口，则该句柄将标识该窗口。否则，检索到的句柄为NULL。函数检查指定窗口的仅子窗口。它不检查后代窗口。<br/>
        /// GW_ENABLEDPOPUP：检索到的句柄标识指定窗口拥有的已启用弹出窗口（搜索使用使用"GW_HWNDNEXT"否则，如果没有启用的弹出窗口，则检索到的句柄是指定窗口的句柄。<br/>
        /// GW_HWNDFIRST：检索到的句柄标识在 Z 顺序中最高的相同类型的窗口。如果指定的窗口是最顶层的窗口，则句柄标识最顶层的窗口。如果指定的窗口是顶级窗口，则句柄标识顶级窗口。如果指定的窗口是子窗口，则句柄标识同级窗口。<br/>
        /// GW_HWNDLAST：检索到的句柄标识 Z 顺序中最低的相同类型的窗口。如果指定的窗口是最顶层的窗口，则句柄标识最顶层的窗口。如果指定的窗口是顶级窗口，则句柄标识顶级窗口。如果指定的窗口是子窗口，则句柄标识同级窗口。<br/>
        /// GW_HWNDNEXT：检索到的句柄标识 Z 顺序中指定窗口下方的窗口。如果指定的窗口是最顶层的窗口，则句柄标识最顶层的窗口。如果指定的窗口是顶级窗口，则句柄标识顶级窗口。如果指定的窗口是子窗口，则句柄标识同级窗口。<br/>
        /// GW_HWNDPREV：检索到的句柄标识 Z 顺序中指定窗口上方的窗口。如果指定的窗口是最顶层的窗口，则句柄标识最顶层的窗口。如果指定的窗口是顶级窗口，则句柄标识顶级窗口。如果指定的窗口是子窗口，则句柄标识同级窗口。<br/>
        /// GW_OWNER：检索到的句柄标识指定窗口的所有者窗口（如果有）。
        /// </param>
        /// <returns>如果函数成功，则返回值为窗口句柄。如果不存在与指定窗口的指定关系的窗口，则返回值为0。</returns>
        [DllImport("User32.dll")]
        public static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);
        /// <summary>
        /// 检索 Z 顺序中的下一个或上一个窗口的句柄。<br/>请参考GetWindow()
        /// </summary>
        /// <param name="hWnd">窗口的句柄。根据 wCmd 参数的值，检索到的窗口句柄是相对于此窗口的。</param>
        /// <param name="uCmd"></param>
        /// <returns>返回窗口句柄</returns>
        public static IntPtr GetNextWindow(IntPtr hWnd, uint uCmd)
        {
            return GetWindow(hWnd, uCmd);
        }
        [DllImport("User32.dll")]
        public static extern IntPtr GetDesktopWindow();
        /// <summary>
        /// 显示消息窗口
        /// </summary>
        /// <param name="hWnd">要创建的消息框的所有者窗口的句柄。如果此参数为NULL，则消息框没有所有者窗口。</param>
        /// <param name="lpText">要显示的消息。如果字符串由多行组成，则可以使用回车符和/或换行符分隔每行之间的行。</param>
        /// <param name="lpCaption">对话框标题。如果此参数为NULL，则默认标题是"错误"。</param>
        /// <param name="uType">
        /// 0x000000002： 消息框包含三个按钮：中止、重试和忽略。<br/>
        /// 0x0000006： 消息框包含三个按钮：取消、重试、继续。<br/>
        /// 0x000004000： 向消息框中添加"帮助"按钮。当用户单击"帮助"按钮或按下 F1 时，系统会向WM_HELP发送一条错误消息。<br/>
        /// 0x00000000： 消息框包含一个按钮：确定。这是默认值。<br/>
        /// 0x000000001： 消息框包含两个按钮：确定和取消。<br/>
        /// 0x0000005： 消息框包含两个按钮：重试和取消。<br/>
        /// 0x0000004： 消息框包含两个按钮：是和否。<br/>
        /// 0x0000000003： 消息框包含三个按钮：是、否 和取消。
        /// </param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, uint uType);
        /// <summary>
        /// 改变指定窗口的位置和大小。
        /// </summary>
        /// <param name="hWnd">指定窗口的句柄。</param>
        /// <param name="X">指定窗口的左边的新位置。</param>
        /// <param name="Y">指定了窗口的顶部的新位置。</param>
        /// <param name="nWidth">指定窗口的新宽度。</param>
        /// <param name="nHeight">指定窗口的新高度。</param>
        /// <param name="bRepaint">指定是否要重画窗口。</param>
        /// <returns></returns>
        [DllImport("User32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        /// <summary>
        /// 更改指定窗口的标题栏的文本（如果有）<br/>如果指定的窗口是控件，则控件的文本将更改。但是，SetWindowText无法更改其他应用程序中控件的文本。
        /// </summary>
        /// <param name="hWnd">要更改其文本的窗口或控件的句柄。</param>
        /// <param name="text">新标题或控件文本。</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern int SetWindowText(IntPtr hWnd, string text);
        [DllImport("User32.dll")]
        public static extern int SetWindowText(IntPtr hWnd, char[] text);
        /// <summary>
        /// 启用或禁用对指定窗口或控件的鼠标和键盘输入<br/>禁用输入时，窗口不会接收输入，如鼠标单击和按键。<br/>启用输入后，窗口将接收所有输入。
        /// </summary>
        /// <param name="hWnd">要启用或禁用窗口的句柄。</param>
        /// <param name="bEnable">指示是启用还是禁用窗口。如果此参数为true，则启用该窗口。如果参数为false，则禁用该窗口。</param>
        /// <returns>如果窗口以前已禁用，则返回值为非零。<br/>
        ///如果窗口以前未禁用，则返回值为零。</returns>
        [DllImport("	User32.dll")]
        public static extern bool EnableWindow(IntPtr hWnd, bool bEnable);
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        [DllImport("User32.dll")]
        public static extern IntPtr GetActiveWindow();
        /// <summary>
        /// 检索前台窗口（用户当前使用窗口的句柄）。系统为创建前景窗口的线程分配的优先级略高于其他线程。
        /// </summary>
        /// <returns>返回值是前台窗口的句柄。<br/>在某些情况下，前台窗口可以是NULL，例如当窗口失去激活时。</returns>
        [DllImport("User32.dll")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("User32.dll")]
        public static extern IntPtr FindWindowA(string lpClassName, string lpWindowName);
        [DllImport("User32.dll")]
        public static extern IntPtr FindWindowExA(IntPtr hWndParent, IntPtr hWndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(int vKey);
        [DllImport("User32.dll")]
        public static extern bool ClipCursor(RECT lpRect);
        [DllImport("User32.dll", EntryPoint = "SetCursorPos")]
        public static extern int SetCursorPos(int x, int y);
        /// <summary>
        /// 将一个指定窗口的客户端区域或者整个屏幕从一个设备上下文(DC)中提取一个句柄。
        /// </summary>
        /// <param name="hDC">要检索 DC 的窗口的句柄。如果此值为NULL ，GetDC将检索整个屏幕的 DC。</param>
        /// <returns>如果函数成功，则返回值是指定窗口工作区的 DC 句柄。
        ///如果函数失败，返回值为NULL。</returns>
        [DllImport("user32.dll ")]
        public static extern IntPtr GetDC(IntPtr hDC);
        /// <summary>
        /// 使用桌面图案或墙纸填充指定句柄中的区域。
        /// </summary>
        /// <param name="hdc">要绘画的DC句柄</param>
        /// <returns>如果函数成功，则返回值为非零。
        ///如果函数失败，则返回值为零。</returns>
        [DllImport("user32.dll")]
        public static extern bool PaintDesktop(IntPtr hdc);
        /// <summary>
        /// 打开剪贴板进行检查，并防止其他应用程序修改剪贴板内容。
        /// </summary>
        /// <param name="hWndNewOwner">要与打开的剪贴板关联的窗口句柄。如果此参数为NULL，则打开的剪贴板与当前任务关联。</param>
        /// <returns>如果函数成功，则返回值为true<br/>如果函数失败，则返回值为false</returns>
        [DllImport("user32.dll")]
        public static extern bool OpenClipboard(IntPtr hWndNewOwner);
        /// <summary>
        /// 清空剪贴板，将手柄释放到剪贴板中的数据。然后，函数将剪贴板的所有权分配给当前打开剪贴板的窗口。
        /// </summary>
        /// <returns>如果函数成功，则返回值为true<br/>如果函数失败，则返回值为false</returns>
        [DllImport("user32.dll")]
        public static extern bool EmptyClipboard();
        /// <summary>
        /// 将数据以指定的剪贴板格式放在剪贴板上。窗口必须是当前剪贴板所有者，并且应用程序必须已调用Open 剪贴板函数。<br/>
        /// 剪贴板所有者在调用SetClipboardData之前不得调用OpenClipboard。
        /// </summary>
        /// <param name="uFormat">剪贴板格式，此参数可以是注册格式或任何标准剪贴板格式。<br/>
        /// 1：以NULL结尾的ANSI字符集字符串。它在每行末尾包含一个carriage return和linefeed字符，这是最简单的剪切板数据格式<br/>
        /// 2：与设备相关的位图格式。位图是通过位图句柄传送给剪贴簿的。<br/>
        /// 3：以旧的metafile格式存放的「图片」。<br/>
        /// 4：包含Microsoft 「符号连结」数据格式的整体内存块。这种格式用在Microsoft的Multiplan、Chart和Excel程序之间交换数据，它是一种ASCII码格式。<br/>
        /// 5：包含数据交换格式(DIF)之数据的整体内存块。用于把数据送到VisiCalc电子表格程序中。这也是一种ASCII码格式<br/>
        /// 7：含有文字数据(与1类似)的内存块。但是它使用的是OEM字符集。<br/>
        /// 8：定义一个设备无关位图的内存块。<br/>
        /// 9：调色盘句柄。<br/>
        /// 10：与Windows的笔式输入扩充功能联合使用<br/>
        /// 11：使用资源交换文件格式（Resource Interchange File Format）的多媒体数据。<br/>
        /// 12：声音（波形）文件。<br/>
        /// 13：含有Unicode文字的内存快。与CF_TEXT类似，它在每一行的末尾包含一个carriage return和linefeed字符，以及一个NULL字符(两个0字节)以表示数据结束。13针对UNICONDE格式<br/>
        /// 14：增强型metafile（32位Windows支持的）句柄。<br/>
        /// 15：与拖放服务相关的文件列表。
        /// </param>
        /// <param name="hMem">指定格式的数据句柄。<br/>此参数可以是NULL，指示窗口在请求时以指定的剪贴板格式（呈现格式）提供数据</param>
        /// <returns>如果函数成功，则返回值是数据的句柄。<br/>
        ///如果函数失败，返回值为NULL。
        /// </returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);
        /// <summary>
        /// 关闭剪贴板。
        /// </summary>
        /// <returns>
        /// 如果函数成功，则返回值为true。
        ///如果函数失败，则返回值为false。
        /// </returns>
        [DllImport("user32.dll")]
        public static extern bool CloseClipboard();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uFormat">剪贴板格式。<br/>有关标准剪贴板格式的说明请参考EmptyClipboard()</param>
        /// <returns>如果函数成功，则返回值是指定格式的剪贴板对象的句柄。<br/>
        ///如果函数失败，返回值为NULL。</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetClipboardData(uint uFormat);
        /// <summary>
        /// 设置指定进程的优先级类。此值以及进程的每个线程的优先级值决定了每个线程的基本优先级。
        /// </summary>
        /// <param name="hProcess">进程的句柄。</param>
        /// <param name="dwPriorityClass">
        /// 0x00008000： 优先级高于0x00000020但低于 0x00000080 的流程。<br/>
        /// 0x00004000： 优先级高于0x000000040但低于 0x00000020的过程。<br/>
        /// 0x00000080： 执行必须立即执行的时间关键任务的过程。进程的线程抢占正常或空闲优先级类类进程的线程。例如任务列表，它必须在用户调用时快速响应，而不考虑操作系统上的负载。使用高优先级类时要格外小心，因为高优先级类应用程序可以使用几乎所有可用的 CPU 时间。<br/>
        /// 0x000000040： 没有特殊计划需求的流程。<br/>
        /// 0x00100000： 开始后台处理模式。系统会降低进程（及其线程）的资源调度优先级，以便它可以执行后台工作，而不会显著影响前台的活动。只有当hProcess是当前进程的句柄时，才能指定此值。如果进程已处于后台处理模式，则函数将失败。Windows 服务器 2003 和 Windows XP：不支持此值。<br/>
        /// 0x00200000： 结束后台处理模式。系统还原进程（及其线程）的资源调度优先级，就像进程进入后台处理模式之前一样。只有当hProcess是当前进程的句柄时，才能指定此值。如果进程不在后台处理模式下，则函数将失败。Windows 服务器 2003 和 Windows XP：不支持此值。<br/>
        /// 0x00000100： 具有最高优先级的进程。进程的线程抢占了所有其他进程的线程，包括执行重要任务的操作系统进程。例如，执行时间间隔超过一个很短的实时进程可能会导致磁盘缓存不刷新或导致鼠标无响应。
        /// </param>
        /// <returns>如果函数成功，则返回值为非零。<br/>
        ///如果函数失败，则返回值为零。</returns>
        [DllImport("user32.dll")]
        public static extern bool SetPriorityClass(IntPtr hProcess, uint dwPriorityClass);

        [DllImport("user32.dll")]
        public static extern int EnumWindows(WndEnumProc ewp, int lParam);

        [DllImport("user32.dll")]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int nMaxCount);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, char[] text, int nMaxCount);
        [DllImport("user32.dll")]
        public static extern bool IsWindowVisible(int hWnd);
        [DllImport("user32.dll")]
        public static extern int GetWindowTextLength(int hWnd);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);

        /// <summary>
        /// 启动 Windows 帮助 （Winhelp.exe） 并传递指示应用程序请求的帮助性质的其他数据。
        /// </summary>
        /// <param name="hWndMain">请求帮助的窗口句柄。</param>
        /// <param name="lpszHelp">包含路径的空终止字符串的地址以及WinHelp要显示的帮助文件的名称。</param>
        /// <param name="uCommand">请求的帮助类型。<br/>请参考dwData</param>
        /// <param name="dwData">其他数据。使用的值取决于uCommand 参数的值。<br/>
        /// 0x0102：执行帮助宏或宏字符串。 dwData：指定要运行的帮助宏的名称的字符串的地址。如果字符串指定多个宏名称，则名称必须用分号分隔。对于某些宏，必须使用宏名称的简短形式，因为 Windows 帮助不支持长名称。<br/>
        /// 0x0003：在 .hpj 文件的 [选项] 部分中显示由"内容"选项指定的主题。此命令用于向后兼容性。 dwData：忽略;设置为 0。<br/>
        /// 0x0001：显示由 .hpj 文件的 [MAP] 部分中定义的指定上下文标识符标识的主题。 dwData：包含主题的上下文标识符。<br/>
        /// 0x000A：显示所选窗口的帮助菜单，然后在弹出窗口中显示所选控件的主题。dwData：DWORD 对数组的地址。每个对中的第一个 DWORD 是控件标识符，第二个 DWORD 是主题的上下文标识符。数组必须由一对零 {0，0} 终止。如果不想向特定控件添加帮助，请将其上下文标识符设置为 -1。<br/>
        /// 0x0008：显示"帮助主题"对话框。 dwData：忽略;设置为 0。<br/>
        /// 0x0009：保 Windows 帮助显示正确的帮助文件。如果显示不正确的帮助文件，则 Windows 帮助将打开正确的帮助文件;如果显示"帮助"文件不正确，则"Windows 帮助"将打开正确的帮助文件。否则，没有操作。 dwData：忽略;设置为 0。<br/>
        /// 0x0004：如果 Winhlp32.hlp 文件可用，则显示如何使用 Windows 帮助的帮助。 dwData：忽略;设置为 0。<br/>
        /// 0x0003：在 .hpj 文件的 [选项] 部分中显示由"内容"选项指定的主题。此命令用于向后兼容性。 dwData：忽略;设置为 0。<br/>
        /// 0x0101：如果存在完全匹配，则在关键字表中显示与指定关键字匹配的主题。如果有多个匹配项，则显示"索引"以及"找到的主题"列表中列出的主题。 dwData：关键字字符串的地址。多个关键字必须用分号分隔。<br/>
        /// 0x0201：在替代关键字表中显示关键字指定的主题。  dwData：指定表脚注字符和关键字的MULTIKEYHELP结构的地址。<br/>
        /// 0x0105：如果存在完全匹配，则在关键字表中显示与指定关键字匹配的主题。如果有多个匹配项，则显示"找到的主题"对话框。若要在不传递关键字的情况下显示索引，请使用指向空字符串的指针。 dwData：关键字字符串的地址。多个关键字必须用分号分隔。
        /// 0x0002：通知 Windows 帮助不再需要它。如果没有其他应用程序寻求帮助，Windows 将关闭 Windows 帮助。 dwData：忽略;设置为 0。<br/>
        /// 0x0005：指定内容主题。如果用户单击"内容"按钮时，Windows帮助将显示此主题，如果帮助文件没有关联的 .cnt 文件。 dwData：包含内容主题的上下文标识符。<br/>
        /// 0x000D：设置后续弹出窗口的位置。 dwData：包含位置数据。使用MAKELONG将水平和垂直坐标串联到单个值中。弹出窗口的位置就像调用弹出窗口时鼠标光标位于指定点一样。<br/>
        /// 0x0203：显示 Windows 帮助窗口（如果该窗口已最小化或在内存中），并按指定设置其大小和位置。 dwData：HELPWININFO 结构的地址，该结构指定主帮助或辅助帮助窗口的大小和位置。<br/>
        /// 0x8000：指示命令用于 Windows 帮助的训练卡实例。使用带边 OR 运算符将此命令与其他命令合并。 dwData：取决于此命令组合的命令。<br/>
        /// 0x000C：在弹出窗口中显示由 hWndMain参数标识的控件的主题。dwData：DWORD 对数组的地址。每个对中的第一个 DWORD 是控件标识符，第二个 DWORD 是主题的上下文标识符。数组必须由一对零 {0，0} 终止。如果不想向特定控件添加帮助，请将其上下文标识符设置为 -1。
        /// </param>
        /// <returns>如果成功，则返回true，否则为false。</returns>
        [DllImport("User32.dll")]
        public static extern bool WinHelp(IntPtr hWndMain, string lpszHelp, uint uCommand, uint dwData);

        [DllImport("User32.dll")]
        public static extern bool ActivateKeyboardLayout(IntPtr hWndMain, string lpszHelp, uint uCommand, uint dwData);
        /// <summary>
        /// 释放设备上下文环境（DC）供其他应用程序使用。
        /// </summary>
        /// <param name="hWnd">指向要释放的设备上下文环境所在的窗口的句柄。</param>
        /// <param name="hDC">指向要释放的设备上下文环境的句柄。</param>
        /// <returns>如果释放成功，则返回值为1；<br/>如果没有释放成功，则返回值为0。</returns>
        [DllImport("User32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        /// <summary>
        /// 删除指定的设备上下文环境（DC）。
        /// </summary>
        /// <param name="hWnd">设备上下文环境的句柄。</param>
        /// <returns>成功返回true；失败返回false。</returns>
        [DllImport("User32.dll")]
        public static extern int DeleteDC(IntPtr hdc);
        /// <summary>
        /// SetWindowsHookEx的委托，用于处理钩子的事件
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>

        /// <summary>
        /// 将应用程序定义的挂钩过程安装到挂钩链中。
        /// </summary>
        /// <param name="idHook">
        /// WH_CALLWNDPROC：安装一个挂钩过程，在系统将消息发送到目标窗口过程之前监视消息。<br/>
        /// WH_CALLWNDPROCRET：安装一个挂钩过程，用于监视消息在目标窗口过程处理后。<br/>
        /// WH_CBT：安装一个挂钩过程，该过程接收对 CBT 应用程序有用的通知。<br/>
        /// WH_DEBUG：安装用于调试其他挂钩过程的挂钩过程。<br/>
        /// WH_FOREGROUNDIDLE：安装在应用程序前台线程即将变为空闲时将调用的挂钩过程。此挂钩可用于在空闲时间执行低优先级任务。<br/>
        /// WH_GETMESSAGE：安装一个挂钩过程，用于监视发布到消息队列的消息。<br/>
        /// WH_JOURNALPLAYBACK：安装一个挂钩过程，该过程将以前由WH_JOURNALRECORD记录的消息。<br/>
        /// WH_JOURNALRECORD：安装一个挂钩过程，记录发布到系统消息队列的输入消息。此挂钩可用于录制宏。<br/>
        /// WH_KEYBOARD：安装监视击键消息的挂钩过程。<br/>
        /// WH_KEYBOARD_LL：安装监视低级键盘输入事件的挂钩过程。<br/>
        /// WH_MOUSE：安装监视鼠标消息的挂钩过程。<br/>
        /// WH_MOUSE_LL：安装监视低级鼠标输入事件的挂钩过程。<br/>
        /// WH_MSGFILTER：安装一个挂钩过程，用于监视在对话框、消息框、菜单或滚动条中因输入事件而生成的消息。<br/>
        /// WH_SHELL：安装一个挂钩过程，该过程接收对 shell 应用程序有用的通知。<br/>
        /// WH_SYSMSGFILTER：安装一个挂钩过程，用于监视在对话框、消息框、菜单或滚动条中因输入事件而生成的消息。挂钩过程监视与调用线程在同一桌面上的所有应用程序的所有消息。
        /// </param>
        /// <param name="lpfn">指向挂钩过程的方法。如果dwThreadId参数为零或指定由其他进程创建的线程的标识符，则 lpfn参数必须指向 DLL 中的挂钩过程。否则，lpfn可以指向与当前进程关联的代码中的挂钩过程。</param>
        /// <param name="hmod">包含lpfn参数指向的挂钩过程的 DLL 句柄。如果 dwThreadId参数指定当前进程创建的线程，并且挂钩过程位于与当前进程关联的代码中，则必须将hMod参数设置为NULL。</param>
        /// <param name="threadId">要指定的线程ID，如果设置为0则表示当前线程</param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hmod, uint threadId);

        /// <summary>
        /// 卸载钩子。<br/>
        /// 删除SetWindowsHookEx 函数安装在挂钩链中的挂钩过程。
        /// </summary>
        /// <param name="pHookHandle">要卸载的挂钩的句柄。此参数是上一次调用SetWindowsHookEx 获得的挂钩句柄。</param>
        /// <returns>如果函数成功，则返回值为true。
        /// 如果函数失败，则返回值为false。</returns>
        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(IntPtr pHookHandle);
        /// <summary>
        /// 传递钩子
        /// </summary>
        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(IntPtr pHookHandle, int nCodem, Int32 wParam, IntPtr lParam);

        /// <summary>
        /// 获取全部按键状态
        /// </summary>
        /// <param name="pbKeyState"></param>
        /// <returns>非0表示成功</returns>
        [DllImport("user32.dll")]
        public static extern int GetKeyboardState(byte[] pbKeyState);
        /// <summary>
        /// 通过将句柄传递到每个子窗口（进而将句柄）传递到应用程序定义的回调函数，枚举属于指定父窗口的子窗口。
        /// </summary>
        /// <param name="hWndParent">要枚举其子窗口的父窗口的句柄。如果此参数为NULL，则此函数等效于 EnumWindows。</param>
        /// <param name="lpEnumFunc">指向要指向的方法</param>
        /// <param name="lParam">要传递给回调函数的应用程序定义的值。</param>
        /// <returns>null</returns>
        [DllImport("user32.dll")]
        public static extern bool EnumChildWindows(IntPtr hWndParent, WndEnumProc lpEnumFunc, int lParam);
        /// <summary>
        /// 检查与指定父窗口关联的子窗口的 Z 顺序，并检索 Z 顺序顶部的子窗口的句柄。
        /// </summary>
        /// <param name="hWnd">要检查其子窗口的父窗口的句柄。如果此参数为 NULL，则函数将句柄返回到 Z 顺序顶部的窗口。</param>
        /// <returns>如果函数成功，则返回值是 Z 顺序顶部子窗口的句柄。如果指定的窗口没有子窗口，则返回值为NULL。</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetTopWindow(IntPtr hWnd);
        /// <summary>
        /// 确定指定窗口的可见性状态。
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool IsWindowVisible(IntPtr hWnd);
        /// <summary>
        /// 确定指定的窗口句柄是否标识现有窗口。
        /// </summary>
        /// <param name="hWnd">要测试的窗口的句柄。</param>
        /// <returns>如果窗口句柄标识现有窗口，则返回值为非true。<br/>
        ///如果窗口句柄不标识现有窗口，则返回值为false。</returns>
        [DllImport("user32.dll")]
        public static extern bool IsWindow(IntPtr hWnd);
        /// <summary>
        /// 模拟键盘输入
        /// </summary>
        /// <param name="bVk">虚拟键值</param>
        /// <param name="bScan"> 一般为0</param>
        /// <param name="dwFlags">这里是整数类型  0 为按下，2为释放</param>
        /// <param name="dwExtraInfo">这里是整数类型 一般情况下设成为 0</param>
        [DllImport("user32.dll", EntryPoint = "keybd_event")]
        public static extern void Keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        /// <summary>
        /// 通过将句柄传递到每个窗口（进而将句柄传递到应用程序定义的回调函数）来枚举与线程关联的所有非子窗口。枚举窗口一直持续到最后一个窗口，或者回调函数返回FALSE。
        /// </summary>
        /// <param name="dwThreadId">要枚举其窗口的线程的标识符。</param>
        /// <param name="lpfn">指向EnumThreadWndProc的委托</param>
        /// <param name="lParam">要传递给回调函数的应用程序定义的值。</param>
        /// <returns>如果回调函数返回由dwThreadId指定的线程中所有窗口的 true，则返回值为true。如果回调函数在任何枚举窗口上返回false，或者在dwThreadId指定的线程中找不到窗口，则返回值为false。</returns>
        [DllImport("user32.dll")]
        public static extern bool EnumThreadWindows(IntPtr dwThreadId, EnumThreadWndProc lpfn, int lParam);
        /// <summary>
        /// 检索有关活动窗口或指定 GUI 线程的信息。
        /// </summary>
        /// <param name="idThread">要检索信息的线程的标识符。若要检索此值，请使用GetWindowThreadProcessId函数。如果此参数为NULL，则函数将返回前台线程的信息。</param>
        /// <param name="pgui">指向tagGUITHREADINFO 结构的指针，该结构接收描述线程的信息。请注意，在调用此函数之前，必须将 cbSize 成员设置为该结构体的大小</param>
        /// <returns>如果函数成功，则返回值为true。<br/>
        ///如果函数失败，则返回值为false。</returns>
        [DllImport("user32.dll")]
        public static extern bool GetGUIThreadInfo(IntPtr idThread, ref tagGUITHREADINFO pgui);
        /// <summary>
        /// 检索GetMessage函数检索的最后一条消息的消息时间。时间是一个长整数，用于指定从系统启动到创建消息（也就是说放置在线程的消息队列中）所经过的时间（以毫秒为单位）。
        /// </summary>
        /// <returns>返回值指定消息时间。</returns>
        [DllImport("user32.dll")]
        public static extern int GetMessageTime();
        [DllImport("user32.dll")]
        public static extern bool GetMessage();
        /// <summary>
        /// 确定指定的窗口是否最小化
        /// </summary>
        /// <param name="hWnd">要测试的窗口的句柄。</param>
        /// <returns>如果指定的窗口是最小化的，则返回true，否则返回false</returns>
        [DllImport("user32.dll")]
        public static extern bool IsIconic(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern IntPtr GetPropA(IntPtr hwnd, string lpString);
        /// <summary>
        /// 确定调用线程的消息队列中是否有鼠标按钮或键盘消息。
        /// </summary>
        /// <returns>如果队列包含一个或多个新的鼠标按钮或键盘消息，则返回值为true<br/>如果队列中没有新的鼠标按钮或键盘消息，则返回值为false</returns>
        [DllImport("user32.dll")]
        public static extern bool GetInputState();
        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, ref uint lpdwProcessId);
        /// <summary>
        /// 检索命令行管理程序桌面窗口的句柄。
        /// </summary>
        /// <returns>返回值是命令行管理程序桌面窗口的句柄。如果不存在 Shell 进程，则返回值为NULL。</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetShellWindow();
        /// <summary>
        /// 检索指定窗口所属的类的名称。
        /// </summary>
        /// <param name="hWnd">窗口的句柄，间接地是窗口所属的类。</param>
        /// <param name="lpClassName">接收的字符串</param>
        /// <param name="nMaxCount">lpClassName 缓冲区的长度，以字符表示。缓冲区必须足够大，以包含终止的 null 字符;否则，类名字符串将被截断</param>
        /// <returns>如果函数成功，返回值是复制到缓冲区的字符数，不包括终止的 null 字符。<br/>如果函数失败，则返回值为零。</returns>
        [DllImport("user32.dll")]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        [DllImport("user32.dll")]
        public static extern bool GetTitleBarInfo(IntPtr hwnd, tagTITLEBARINFO pti);
        /// <summary>
        /// 平铺指定父窗口的指定子窗口。
        /// </summary>
        /// <param name="hwndParent">父窗口的句柄。如果此参数为NULL，则假定为桌面窗口。</param>
        /// <param name="wHow"平铺标志。此参数可以是以下值之一-可选地与MDITILE_SKIPDISABLED组合以防止禁用的MDI子窗口被平铺。><br/>
        /// MDITILE_HORIZONTAL：水平平铺窗口。
        /// MDITILE_VERTICAL：垂直平铺窗口。
        /// </param>
        /// <param name="lpRect"></param>
        /// <param name="cKids"></param>
        /// <param name="lpKids"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern ushort TileWindows(IntPtr hwndParent,uint wHow,ref RECT lpRect,uint cKids,ref IntPtr lpKids);
        /// <summary>
        /// 检索指定的系统指标或系统配置设置。<br/>
        ///请注意，GetSystemMetrics检索的所有尺寸均以像素为单位。
        /// </summary>
        /// <param name="nIndex">
        /// 要检索的系统指标或配置设置。此参数可以是下列值之一。请注意，所有SM_CX *值均为宽度，所有SM_CY *值均为高度。还要注意，所有旨在返回布尔数据的设置都将TRUE表示为任何非零值，将FALSE表示为零值。<br/>
        /// SM_ARRANGE：用于指定系统如何排列最小化窗口的标志。<br/>
        /// SM_CLEANBOOT：指定系统如何启动的值：0正常启动、1故障安全启动、2通过网络启动进行故障保护；故障安全启动（也称为“安全启动”，“安全模式”或“干净启动”）会绕过用户启动文件。<br/>
        /// SM_CMONITORS：台式机上的显示器数量。<br/>
        /// SM_CMOUSEBUTTONS：鼠标上的按钮数；如果未安装鼠标，则为零。<br/>
        /// SM_CONVERTIBLESLATEMODE：反映笔记本电脑或平板电脑模式的状态，0表示平板电脑模式，否则非零。当此系统度量标准更改时，系统会通过WM_SETTINGCHANGE在LPARAM中使用“ ConvertibleSlateMode” 发送广播消息。请注意，此系统指标不适用于台式机。在这种情况下，请使用GetAutoRotationState。<br/>
        /// SM_CXBORDER：窗口边框的宽度，以像素为单位。这等效于具有3D外观的窗口的SM_CXEDGE值。<br/>
        /// SM_CXCURSOR：光标的宽度，以像素为单位。系统无法创建其他大小的游标。<br/>
        /// SM_CXDLGFRAME：此值与SM_CXFIXEDFRAME相同。<br/>
        /// SM_CXDOUBLECLK：双击序列中第一次单击位置周围的矩形宽度，以像素为单位。第二次单击必须在SM_CXDOUBLECLK和SM_CYDOUBLECLK定义的矩形内发生，系统才能将两次单击视为双击。两次单击也必须在指定时间内发生。要设置双击矩形的宽度，请使用SPI_SETDOUBLECLKWIDTH 调用 SystemParametersInfo。<br/>
        /// SM_CXDRAG：在拖动操作开始之前，鼠标指针可以移动的鼠标按下点两侧的像素数。这使用户可以轻松地单击和释放鼠标按钮，而不会无意间启动拖动操作。如果该值为负，则将其从鼠标下移点的左侧减去并添加到其右侧。<br/>
        /// SM_CXEDGE：3-D边框的宽度，以像素为单位。此度量标准是SM_CXBORDER的3D对应项。<br/>
        /// SM_CXFIXEDFRAME：具有标题但大小不一的窗口周围边框的厚度，以像素为单位。SM_CXFIXEDFRAME是水平边框的高度，SM_CYFIXEDFRAME是垂直边框的宽度。该值与SM_CXDLGFRAME相同。<br/>
        /// SM_CXFOCUSBORDER：DrawFocusRect绘制 的焦点矩形的左右边缘的宽度。此值以像素为单位。Windows 2000：  不支持此值。<br/>
        /// SM_CXFRAME：此值与SM_CXSIZEFRAME相同。<br/>
        /// SM_CXFULLSCREEN：主显示监视器上全屏窗口的客户区域宽度，以像素为单位。若要获取屏幕的未被系统任务栏或应用程序桌面工具栏遮挡的部分的坐标，请使用SPI_GETWORKAREA值调用 SystemParametersInfo函数。<br/>
        /// SM_CXHSCROLL：水平滚动条上箭头位图的宽度，以像素为单位。<br/>
        /// SM_CXHTHUMB：水平滚动条中拇指框的宽度，以像素为单位。<br/>
        /// SM_CXICON：图标的默认宽度，以像素为单位。该 LoadIcon功能可以加载只与维度SM_CXICON和SM_CYICON指定图标。<br/>
        /// SM_CXICONSPACING：大图标视图中项目的网格单元格宽度，以像素为单位。排列后，每个项目都适合于SM_CYICONSPACING大小为SM_CXICONSPACING的矩形。此值始终大于或等于SM_CXICON。<br/>
        /// SM_CXMAXIMIZED：主显示监视器上最大化的顶级窗口的默认宽度（以像素为单位）。<br/>
        /// SM_CXMAXTRACK：具有标题和边框大小的窗口的默认最大宽度，以像素为单位。该指标指的是整个桌面。用户不能将窗口框架拖动到大于这些尺寸的尺寸。窗口可以通过处理WM_GETMINMAXINFO消息来覆盖此值 。<br/>
        /// SM_CXMENUCHECK：默认菜单复选标记位图的宽度（以像素为单位）。<br/>
        /// SM_CXMENUSIZE：菜单栏按钮的宽度，例如在多文档界面中使用的子窗口关闭按钮，以像素为单位。<br/>
        /// SM_CXMIN：窗口的最小宽度，以像素为单位。<br/>
        /// SM_CXMINIMIZED：最小化窗口的宽度，以像素为单位。<br/>
        /// SM_CXMINSPACING：最小化窗口的网格单元的宽度，以像素为单位。每个最小化的窗口在排列时都适合于此大小的矩形。此值始终大于或等于SM_CXMINIMIZED。<br/>
        /// SM_CXMINTRACK：窗口的最小跟踪宽度，以像素为单位。用户不能将窗口框架拖动到小于这些尺寸的尺寸。窗口可以通过处理WM_GETMINMAXINFO消息来覆盖此值 。<br/>
        /// SM_CXPADDEDBORDER：字幕窗口的边框填充量（以像素为单位）。Windows XP / 2000：  不支持此值。<br/>
        /// SM_CXSCREEN：主显示屏的屏幕宽度，以像素为单位。这与通过调用GetDeviceCaps获得的值相同。<br/>
        /// SM_CXSIZE：窗口标题或标题栏中的按钮宽度，以像素为单位。<br/>
        /// SM_CXSIZEFRAME：可以调整大小的窗口周围的大小边界的厚度，以像素为单位。SM_CXSIZEFRAME是水平边框的宽度，SM_CYSIZEFRAME是垂直边框的高度。此值与SM_CXFRAME相同。<br/>
        /// SM_CXSMICON：小图标的建议宽度（以像素为单位）。小图标通常出现在窗口标题和小图标视图中。<br/>
        /// SM_CXSMSIZE：小标题按钮的宽度，以像素为单位。<br/>
        /// SM_CXVIRTUALSCREEN：虚拟屏幕的宽度，以像素为单位。虚拟屏幕是所有显示监视器的边界矩形。SM_XVIRTUALSCREEN指标是虚拟屏幕左侧的坐标。<br/>
        /// SM_CXVSCROLL：垂直滚动条的宽度，以像素为单位。<br/>
        /// SM_CYBORDER：窗口边框的高度，以像素为单位。这等效于具有3D外观的窗口的SM_CYEDGE值。<br/>
        /// SM_CYCAPTION：字幕区域的高度，以像素为单位。<br/>
        /// SM_CYCURSOR：光标的高度，以像素为单位。系统无法创建其他大小的游标。<br/>
        /// SM_CYDLGFRAME：此值与SM_CYFIXEDFRAME相同。<br/>
        /// SM_CYDOUBLECLK：双击序列中第一次单击位置周围的矩形高度，以像素为单位。第二次单击必须发生在SM_CXDOUBLECLK和SM_CYDOUBLECLK定义的矩形内，以便系统将两次单击视为双击。两次单击也必须在指定时间内发生。要设置双击矩形的高度，请使用SPI_SETDOUBLECLKHEIGHT 调用 SystemParametersInfo。<br/>
        /// SM_CYDRAG：在拖动操作开始之前，鼠标指针可以移动的鼠标下移点上方和下方的像素数。这使用户可以轻松地单击和释放鼠标按钮，而不会无意间启动拖动操作。如果该值为负，则将其从鼠标向下的点上方减去并在其下方添加。<br/>
        /// SM_CYEDGE：3-D边框的高度，以像素为单位。这是SM_CYBORDER的3D对应物。<br/>
        /// SM_CYFIXEDFRAME具有标题但大小不一的窗口周围边框的厚度，以像素为单位。SM_CXFIXEDFRAME是水平边框的高度，SM_CYFIXEDFRAME是垂直边框的宽度。此值与SM_CYDLGFRAME相同。<br/>
        /// SM_CYFOCUSBORDER：DrawFocusRect 绘制的焦点矩形的上下边缘的 高度。此值以像素为单位。Windows 2000：  不支持此值。<br/>
        /// SM_CYFRAME：此值与SM_CYSIZEFRAME相同。<br/>
        /// SM_CYFULLSCREEN：主显示监视器上全屏窗口的客户区域的高度，以像素为单位。要获取未被系统任务栏或应用程序桌面工具栏遮挡的屏幕部分的坐标，请使用SPI_GETWORKAREA值调用 SystemParametersInfo函数。<br/>
        /// SM_CYHSCROLL：水平滚动条的高度，以像素为单位。<br/>
        /// SM_CYICON：图标的默认高度，以像素为单位。该 LoadIcon功能可以加载只与尺寸SM_CXICON和SM_CYICON图标。<br/>
        /// SM_CYICONSPACING：大图标视图中项目的网格单元格高度，以像素为单位。排列后，每个项目都适合于SM_CYICONSPACING大小为SM_CXICONSPACING的矩形。此值始终大于或等于SM_CYICON。<br/>
        /// SM_CYKANJIWINDOW：对于系统的双字节字符集版本，这是屏幕底部的汉字窗口的高度，以像素为单位。<br/>
        /// SM_CYMAXIMIZED：主显示监视器上最大化的顶级窗口的默认高度（以像素为单位）。<br/>
        /// SM_CYMAXTRACK：具有标题和边框大小的窗口的默认最大高度，以像素为单位。该指标指的是整个桌面。用户不能将窗口框架拖动到大于这些尺寸的尺寸。窗口可以通过处理WM_GETMINMAXINFO消息来覆盖此值 。<br/>
        /// SM_CYMENU：单行菜单栏的高度，以像素为单位。<br/>
        /// SM_CYMENUCHECK：默认菜单复选标记位图的高度，以像素为单位。<br/>
        /// SM_CYMENUSIZE：菜单栏按钮的高度，例如多文档界面中使用的子窗口关闭按钮，以像素为单位。<br/>
        /// SM_CYMIN：窗口的最小高度，以像素为单位。<br/>
        /// SM_CYMINIMIZED：最小化窗口的高度，以像素为单位。<br/>
        /// SM_CYMINSPACING：最小化窗口的网格单元的高度，以像素为单位。每个最小化的窗口在排列时都适合于此大小的矩形。此值始终大于或等于SM_CYMINIMIZED。<br/>
        /// SM_CYMINTRACK：窗口的最小跟踪高度，以像素为单位。用户不能将窗口框架拖动到小于这些尺寸的尺寸。窗口可以通过处理WM_GETMINMAXINFO消息来覆盖此值 。<br/>
        /// SM_CYSCREEN：主显示屏的屏幕高度，以像素为单位。这与通过调用GetDeviceCaps获得的值相同。<br/>
        /// SM_CYSIZE：窗口标题或标题栏中按钮的高度，以像素为单位。<br/>
        /// SM_CYSIZEFRAME：可以调整大小的窗口周围的大小边界的厚度，以像素为单位。SM_CXSIZEFRAME是水平边框的宽度，SM_CYSIZEFRAME是垂直边框的高度。此值与SM_CYFRAME相同。<br/>
        /// SM_CYSMCAPTION：小标题的高度，以像素为单位。<br/>
        /// SM_CYSMICON：小图标的建议高度（以像素为单位）。小图标通常出现在窗口标题和小图标视图中。<br/>
        /// SM_CYSMSIZE：小标题按钮的高度，以像素为单位。<br/>
        /// SM_CYVIRTUALSCREEN：虚拟屏幕的高度，以像素为单位。虚拟屏幕是所有显示监视器的边界矩形。SM_YVIRTUALSCREEN指标是虚拟屏幕顶部的坐标。<br/>
        /// SM_CYVSCROLL：垂直滚动条上箭头位图的高度，以像素为单位。<br/>
        /// SM_CYVTHUMB：垂直滚动条中拇指框的高度，以像素为单位。<br/>
        /// SM_DBCSENABLED：如果User32.dll支持DBCS，则为非零；否则为0。否则为0。<br/>
        /// SM_DEBUG：如果安装了User.exe的调试版本，则为非零；否则为0。否则为0。<br/>
        /// SM_DIGITIZER：如果当前操作系统是Windows 7或Windows Server 2008 R2，并且已启动Tablet PC输入服务，则为非零值；否则为0。否则为0。返回值是一个位掩码，用于指定设备支持的数字化仪输入的类型。有关更多信息，请参见备注。Windows Server 2008，Windows Vista和Windows XP / 2000：  不支持此值。<br/>
        /// SM_IMMENABLED：如果启用了输入法管理器/输入法编辑器功能，则为非零；否则为0。否则为0。SM_IMMENABLED指示系统是否准备好在Unicode应用程序上使用基于Unicode的IME。要确保依赖于语言的IME起作用，请检查SM_DBCSENABLED和系统ANSI代码页。否则，可能无法正确执行ANSI到Unicode的转换，或者某些组件（如字体或注册表设置）可能不存在。<br/>
        /// SM_MAXIMUMTOUCHES：如果系统中有数字转换器，则为非零值；否则为0。SM_MAXIMUMTOUCHES返回系统中每个数字转换器支持的最大联系人总数的合计最大值。如果系统仅具有单点触摸数字化仪，则返回值为1。如果系统具有多点触摸数字化仪，则返回值为硬件可以提供的同时联系数。Windows Server 2008，Windows Vista和Windows XP / 2000：  不支持此值。<br/>
        /// SM_MEDIACENTER：如果当前操作系统是Windows XP Media Center Edition，则为非零；否则为0。<br/>
        /// SM_MENUDROPALIGNMENT：如果下拉菜单与相应的菜单栏项目右对齐，则为非零；否则为0。如果菜单左对齐，则为0。<br/>
        /// SM_MIDEASTENABLED：如果系统启用了希伯来语和阿拉伯语言，则为非零值；否则为0。<br/>
        /// SM_MOUSEPRESENT：如果安装了鼠标，则为非零；否则为0。否则为0。由于支持虚拟鼠标，并且由于某些系统检测到端口的存在而不是鼠标的存在，因此该值很少为零。<br/>
        /// SM_MOUSEHORIZONTALWHEELPRESENT：如果安装了带有水平滚轮的鼠标，则为非零值；否则为0。否则为0。<br/>
        /// SM_MOUSEWHEELPRESENT：如果安装了带有垂直滚轮的鼠标，则为非零值；否则为0。否则为0。<br/>
        /// SM_NETWORK：如果存在网络，则设置最低有效位。否则清除。其他位保留供将来使用。<br/>
        /// SM_PENWINDOWS：如果安装了Microsoft Windows for Pen计算扩展，则为非零；否则为0。否则为零。<br/>
        /// SM_REMOTECONTROL：在终端服务环境中使用此系统度量来确定是否正在远程控制当前的终端服务器会话。如果当前会话是远程控制的，则其值为非零；否则为0。否则为0。您可以使用终端服务管理工具，例如终端服务管理器（tsadmin.msc）和shadow.exe，来控制远程会话。当会话受到远程控制时，另一个用户可以查看该会话的内容并可能与之交互。<br/>
        /// SM_REMOTESESSION：此系统指标用于终端服务环境。如果调用过程与终端服务客户端会话相关联，则返回值为非零。如果调用过程与终端服务控制台会话相关联，则返回值为0。Windows Server 2003和Windows XP：  控制台会话不一定是物理控制台。有关更多信息，请参见WTSGetActiveConsoleSessionId。<br/>
        /// SM_SAMEDISPLAYFORMAT：如果所有的显示器都具有相同的颜色格式，则为非零值；否则为0。两个显示器可以具有相同的位深，但颜色格式可以不同。例如，红色，绿色和蓝色像素可以使用不同数量的位进行编码，或者这些位可以位于像素颜色值的不同位置。<br/>
        /// SM_SECURE：该系统指标应被忽略；它总是返回0。<br/>
        /// SM_SERVERR2：内部版本号（如果系统为Windows Server 2003 R2）；否则为0。否则为0。<br/>
        /// SM_SHOWSOUNDS：如果用户要求应用程序在其他情况下仅以可听形式呈现信息，则用户要求该应用以视觉方式呈现信息；否则为非零值；否则为0。<br/>
        /// SM_SHUTTINGDOWN：如果当前会话正在关闭，则为非零；否则为0。否则为0。Windows 2000：  不支持此值。<br/>
        /// SM_SLOWMACHINE：如果计算机具有低端（慢速）处理器，则为非零；否则为0。否则为0。<br/>
        /// SM_STARTER：如果当前操作系统是Windows 7简化版，Windows Vista简化版或Windows XP简化版，则为非零；否则为非零。否则为0。<br/>
        /// SM_SWAPBUTTON：如果鼠标左键和右键的含义互换，则为非零值；否则为0。否则为0。<br/>
        /// SM_SYSTEMDOCKED：反映对接模式的状态，对于非对接模式，该状态为0，否则为非零。当此系统度量标准更改时，系统会通过WM_SETTINGCHANGE在LPARAM中使用“ SystemDockMode” 发送广播消息。<br/>
        /// SM_TABLETPC：如果当前操作系统是Windows XP Tablet PC版本，或者当前操作系统是Windows Vista或Windows 7并且Tablet PC Input服务已启动，则为非零值；否则为非零。否则为0。SM_DIGITIZER设置指示运行Windows 7或Windows Server 2008 R2的设备支持的数字转换器输入的类型。<br/>
        /// SM_XVIRTUALSCREEN：虚拟屏幕左侧的坐标。虚拟屏幕是所有显示监视器的边界矩形。SM_CXVIRTUALSCREEN指标是虚拟屏幕的宽度。<br/>
        /// SM_YVIRTUALSCREEN：虚拟屏幕顶部的坐标。虚拟屏幕是所有显示监视器的边界矩形。SM_CYVIRTUALSCREEN指标是虚拟屏幕的高度。
        /// </param>
        /// <returns>如果该函数成功，则返回值为请求的系统指标或配置设置。<br/>
        ///如果函数失败，则返回值为 0。GetLastError不提供扩展的错误信息。</returns>
        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(int nIndex);
        /// <summary>
        /// 确定窗口是否最大化。
        /// </summary>
        /// <param name="hWnd">要测试的窗口句柄</param>
        /// <returns>如果窗口是最大化的状态，返回true。<br/>
        ///否则返回值为false。</returns>
        [DllImport("user32.dll")]
        public static extern bool IsZoomed(IntPtr hWnd);
        /// <summary>
        /// 销毁指定的计时器。
        /// </summary>
        /// <param name="hWnd">与指定计时器关联的窗口的句柄。此值必须与传递给创建计时器的SetTimer函数的hWnd值相同 。</param>
        /// <param name="uIDEvent">(计时器ID)如果传递给SetTimer的窗口句柄有效，则此参数必须与nIDEvent相同 。</param>
        /// <returns>如果函数成功，则返回值为true。<br/>
        ///如果函数失败，则返回值为false。</returns>
        [DllImport("user32.dll")]
        public static extern bool KillTimer(IntPtr hWnd, uint uIDEvent);
        /// <summary>
        /// 用指定的超时值创建一个计时器。
        /// </summary>
        /// <param name="hWnd">与计时器关联的窗口的句柄。此窗口必须归调用线程所有。<br/>如果将hWnd的NULL值与现有计时器的nIDEvent一起传递，则该计时器将以与现有的非NULL hWnd计时器相同的方式替换。</param>
        /// <param name="nIDEvent">计算器ID；非零计时器标识符。<br/>如果hWnd参数为NULL，并且nIDEvent与现有计时器不匹配，则将其忽略并生成新的计时器ID。<br/>如果hWnd参数不为NULL，并且由hWnd指定的窗口已经具有一个值为nIDEvent的计时器，则现有计时器将被新计时器替换。<br/>当SetTimer替换计时器时，计时器将重置。<br/>因此，将在当前超时值过去之后发送一条消息，但先前设置的超时值将被忽略。如果该调用不是要替换现有的计时器，则如果hWnd为0 ，则nIDEvent应该为0为NULL。</param>
        /// <param name="uElapse">间隔，以毫秒为单位。</param>
        /// <param name="lpTimerFunc">当超时值过去时，指向Timerproc的委托。</param>
        /// <returns>如果函数成功并且hWnd参数为NULL，则返回值为标识新计时器的整数。应用程序可以将此值传递给KillTimer函数以销毁计时器。<br/>
        ///如果函数成功并且hWnd参数不为NULL，则返回值为非零整数。应用程序可以将nIDEvent参数的值传递给KillTimer函数以破坏计时器。<br/>
        ///如果函数无法创建计时器，则返回值为零。要获取扩展的错误信息，请调用GetLastError。</returns>
        [DllImport("user32.dll")]
        public static extern uint SetTimer(IntPtr hWnd, uint nIDEvent, uint uElapse, Timerproc lpTimerFunc);
        /// <summary>
        /// 将最小化的（图标）窗口恢复到其先前的大小和位置；然后激活窗口。
        /// </summary>
        /// <param name="hWnd">要还原和激活的窗口句柄。</param>
        /// <returns>如果函数成功，则返回值为非零。<br/>
        ///如果函数失败，则返回值为零。要获取扩展的错误信息，请调用GetLastError。</returns>
        [DllImport("user32.dll")]
        public static extern bool OpenIcon(IntPtr hWnd);
        /// <summary>
        /// 获取当前光标的句柄。
        /// </summary>
        /// <returns>返回值是当前光标的句柄。如果没有光标，则返回值为NULL。</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetCursor();
        /// <summary>
        /// 将指定的消息发送到窗口。SendMessage函数调用指定窗口的窗口过程，并且在窗口过程处理消息之前不会返回。
        /// </summary>
        /// <param name="hWnd">窗口过程将收到消息的窗口的句柄。如果此参数为 HWND_BROADCAST(0xff)，则消息将发送到系统内的所有顶级窗口，包括禁用或不可见的未拥有窗口、重叠的窗口和弹出窗口</param>
        /// <param name="Msg">要发送的消息。</param>
        /// <param name="wParam">其他特定于消息的信息。</param>
        /// <param name="lParam">其他特定于消息的信息。</param>
        /// <returns>返回值指定消息处理的结果;这取决于发送的消息。</returns>
        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        public static extern int SendMessageW(dynamic hwnd, dynamic wMsg, dynamic wParam, dynamic lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        public static extern int SendMessageW(IntPtr hwnd, uint wMsg, int wParam,  StringBuilder lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessageA(IntPtr hwnd, uint wMsg, int wParam,  StringBuilder lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        public static extern int SendMessageW(IntPtr hwnd, uint wMsg, int wParam,  bool lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        public static extern int SendMessageW(IntPtr hwnd, uint wMsg, int wParam,  char[] lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessageA(IntPtr hwnd, uint wMsg, int wParam,  char[] lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        public static extern int SendMessageW(IntPtr hwnd, uint wMsg, int wParam, ref  char[] lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessageA(IntPtr hwnd, uint wMsg, int wParam, ref  char[] lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        public static extern int SendMessageW(IntPtr hwnd, uint wMsg, int wParam,  char* lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        public static extern int SendMessageW(IntPtr hwnd, uint wMsg, int wParam,  IntPtr lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        public static extern int SendMessageW(IntPtr hwnd, uint wMsg, IntPtr wParam,  IntPtr lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        public static extern int SendMessageW(IntPtr hwnd, uint wMsg, IntPtr wParam,  ref string lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        public static extern int SendMessageW(IntPtr hwnd, uint wMsg, int wParam,  ref string lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        public static extern int SendMessageW(IntPtr hwnd, uint wMsg, IntPtr wParam,  ref IntPtr lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        public static extern int SendMessageW(IntPtr hwnd, uint wMsg, int wParam,  int lParam);
        /// <summary>
        /// GetWindowDC函数检索整个窗口的设备上下文 （DC），包括标题栏、菜单和滚动条。<br/>窗口设备上下文允许在窗口中的任意位置绘画，因为设备上下文的原点是窗口的左上角，而不是工作区。
        /// </summary>
        /// <param name="hWnd">具有要检索的设备上下文的窗口句柄。如果此值为NULL ，GetWindowDC将检索整个屏幕的设备上下文。</param>
        /// <returns>如果函数成功，则返回值是指定窗口的设备上下文的句柄。<br/>
        /// 如果函数失败，返回值为NULL，表示错误或无效的hWnd参数。</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd); 
    }

}