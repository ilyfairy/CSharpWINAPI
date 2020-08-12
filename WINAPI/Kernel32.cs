using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WINAPI
{
    public static unsafe class Kernel32
    {
        public const int STANDARD_RIGHTS_REQUIRED = 0x000F0000;
        public const int SYNCHRONIZE = 0x00100000;

        //OpenProcess.dwDesiredAccess
        public const int PROCESS_CREATE_PROCESS = 0x0080;
        public const int PROCESS_CREATE_THREAD = 0x0002;
        public const int PROCESS_DUP_HANDLE = 0x0040;
        public const int PROCESS_QUERY_INFORMATION = 0x0400;
        public const int PROCESS_QUERY_LIMITED_INFORMATION = 0x1000;
        public const int PROCESS_SET_INFORMATION = 0x0200;
        public const int PROCESS_TERMINATE = 0x0001;
        public const int PROCESS_SET_SESSIONID = 0x0004;
        public const int PROCESS_VM_OPERATION = 0x0008;
        public const int PROCESS_VM_READ = 0x0010;
        public const int PROCESS_VM_WRITE = 0x0020;
        public const int PROCESS_SET_QUOTA = 0x0100;
        public const int PROCESS_SUSPEND_RESUME = 0x0800;
        public const int PROCESS_SET_LIMITED_INFORMATION = 0x2000;
        public const int PROCESS_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE | 0xFFFF;

        public const int GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS = 0x00000004;
        public const int GET_MODULE_HANDLE_EX_FLAG_PIN = 0x00000001;
        public const int GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT = 0x00000002;

        public const int DONT_RESOLVE_DLL_REFERENCES = 0x00000001;
        public const int LOAD_IGNORE_CODE_AUTHZ_LEVEL = 0x00000010;
        public const int LOAD_LIBRARY_AS_DATAFILE = 0x00000002;
        public const int LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE = 0x00000040;
        public const int LOAD_LIBRARY_AS_IMAGE_RESOURCE = 0x00000020;
        public const int LOAD_LIBRARY_SEARCH_APPLICATION_DIR = 0x00000200;
        public const int LOAD_LIBRARY_SEARCH_DEFAULT_DIRS = 0x00001000;
        public const int LOAD_LIBRARY_SEARCH_DLL_LOAD_DIR = 0x00000100;
        public const int LOAD_LIBRARY_SEARCH_SYSTEM32 = 0x00000800;
        public const int LOAD_LIBRARY_SEARCH_USER_DIRS = 0x00000400;
        public const int LOAD_WITH_ALTERED_SEARCH_PATH = 0x00000008;
        public const int LOAD_LIBRARY_REQUIRE_SIGNED_TARGET = 0x00000080;
        public const int LOAD_LIBRARY_SAFE_CURRENT_DIRS = 0x00002000;

        //GlobalAllocu.Flags
        /// <summary>
        /// 结合GMEM_MOVEABLE和GMEM_ZEROINIT。
        /// </summary>
        public const uint GHND = 0x0042;
        /// <summary>
        /// 分配固定内存。返回值是指针。
        /// </summary>
        public const uint GMEM_FIXED = 0x0000;
        /// <summary>
        /// 分配可移动内存。内存块永远不会在物理内存中移动，但是可以在默认堆中移动它们。<br/>
        /// 返回值是内存对象的句柄。要将句柄转换为指针，请使用 GlobalLock函数。<br/>
        /// 该值不能与GMEM_FIXED结合使用。
        /// </summary>
        public const uint GMEM_MOVEABLE = 0x0002;
        /// <summary>
        /// 初始化内存内容为零。
        /// </summary>
        public const uint GMEM_ZEROINIT = 0x0040;
        /// <summary>
        /// 结合GMEM_FIXED和GMEM_ZEROINIT。
        /// </summary>
        public const uint GPTR = 0x0040;





        /// <summary>
        /// 函数用来打开一个已存在的进程对象，并返回进程的句柄。
        /// </summary>
        /// <param name="dwDesiredAccess">
        /// PROCESS_ALL_ACCESS：获取所有权限
        /// PROCESS_CREATE_PROCESS：需要创建一个线程
        /// PROCESS_CREATE_THREAD：需要创建一个线程
        /// PROCESS_DUP_HANDLE：重复使用DuplicateHandle句柄
        /// PROCESS_QUERY_INFORMATION：获得进程信息的权限，如它的退出代码、优先级
        /// PROCESS_QUERY_LIMITED_INFORMATION：获得某些信息的权限，如果获得了PROCESS_QUERY_INFORMATION，也拥有PROCESS_QUERY_LIMITED_INFORMATION权限
        /// PROCESS_SET_INFORMATION：设置某些信息的权限，如进程优先级
        /// PROCESS_SET_QUOTA：设置内存限制的权限，使用SetProcessWorkingSetSize
        /// PROCESS_SUSPEND_RESUME：暂停或恢复进程的权限
        /// PROCESS_TERMINATE：终止一个进程的权限，使用TerminateProcess
        /// PROCESS_VM_OPERATION：操作进程内存空间的权限(可用VirtualProtectEx和WriteProcessMemory)
        /// PROCESS_VM_READ：读取进程内存空间的权限，可使用ReadProcessMemory
        /// PROCESS_VM_WRITE：读取进程内存空间的权限，可使用WriteProcessMemory
        /// SYNCHRONIZE：等待进程终止
        /// </param>
        /// <param name="bInheritHandle">表示所得到的进程句柄是否可以被继承</param>
        /// <param name="dwProcessId">被打开进程的PID</param>
        /// <returns>成功返回值为指定进程的句柄。<br/>
        ///失败返回值为NULL，可调用GetLastError()获得错误代码。</returns>
        [DllImport("Kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, IntPtr dwProcessId);
        /// <summary>
        /// 函数用来打开一个已存在的进程对象，并返回进程的句柄。
        /// </summary>
        /// <param name="dwDesiredAccess">
        /// PROCESS_ALL_ACCESS：获取所有权限
        /// PROCESS_CREATE_PROCESS：需要创建一个线程
        /// PROCESS_CREATE_THREAD：需要创建一个线程
        /// PROCESS_DUP_HANDLE：重复使用DuplicateHandle句柄
        /// PROCESS_QUERY_INFORMATION：获得进程信息的权限，如它的退出代码、优先级
        /// PROCESS_QUERY_LIMITED_INFORMATION：获得某些信息的权限，如果获得了PROCESS_QUERY_INFORMATION，也拥有PROCESS_QUERY_LIMITED_INFORMATION权限
        /// PROCESS_SET_INFORMATION：设置某些信息的权限，如进程优先级
        /// PROCESS_SET_QUOTA：设置内存限制的权限，使用SetProcessWorkingSetSize
        /// PROCESS_SUSPEND_RESUME：暂停或恢复进程的权限
        /// PROCESS_TERMINATE：终止一个进程的权限，使用TerminateProcess
        /// PROCESS_VM_OPERATION：操作进程内存空间的权限(可用VirtualProtectEx和WriteProcessMemory)
        /// PROCESS_VM_READ：读取进程内存空间的权限，可使用ReadProcessMemory
        /// PROCESS_VM_WRITE：读取进程内存空间的权限，可使用WriteProcessMemory
        /// SYNCHRONIZE：等待进程终止
        /// </param>
        /// <param name="bInheritHandle">表示所得到的进程句柄是否可以被继承</param>
        /// <param name="dwProcessId">被打开进程的PID</param>
        /// <returns>成功返回值为指定进程的句柄。<br/>
        ///失败返回值为NULL，可调用GetLastError()获得错误代码。</returns>
        [DllImport("Kernel32.dll")]
        public static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, uint dwProcessId);
        [DllImport("Kernel32.dll")]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, [Out] IntPtr lpNumberOfBytesWritten);
        [DllImport("Kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, [Out] IntPtr lpNumberOfBytesRead); //最正确
        [DllImport("Kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);
        [DllImport("Kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, long lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern bool CloseHandle(UIntPtr hObject);
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern IntPtr CreateFileA(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hFile">
        /// 文件或 I/O 设备的句柄（例如，文件、文件流、物理磁盘、卷、控制台缓冲区、磁带驱动器、套接字、通信资源、邮件插槽或管道）。<br/>
        /// hFile参数必须已使用写入访问权限创建。有关详细信息，请参阅通用访问权限和文件安全性和访问权限。<br/>
        /// 对于异步写入操作，hFile 可以是使用 FILE_FLAG_OVERLAPPED标志或套接字或接受函数返回的套接字句柄使用CreateFile 函数打开的任何句柄。
        /// </param>
        /// <param name="lpBuffer">指向包含要写入文件或设备的数据的缓冲区的指针。<br/>
        /// 此缓冲区必须在写入操作期间保持有效。在写入操作完成之前，调用方不得使用此缓冲区。</param>
        /// <param name="nNumberOfBytesToWrite">要写入文件或设备的字节数。
        /// <br/>值为零指定空写入操作。</param>
        /// <param name="lpNumberOfBytesWritten">指向使用同步 hFile 参数时写入的字节数的变量的指针。在做任何工作或错误检查之前，WriteFile将此值设置为零。如果这是异步操作，则使用此参数的 NULL 以避免出现潜在的错误结果。<br/>
        ///  只有当 lp 上翻转的参数不是 NULL时，此参数才能为NULL。</param>
        /// <param name="lpOverlapped">如果hFile 参数使用FILE_FLAG_OVERLAPPED，则需要指向 OVERLAPPED结构的指针，否则此参数可以是NULL。<br/>
        /// 对于支持字节偏移的hFile，如果使用此参数，则必须指定开始写入文件或设备的字节偏移量。通过设置 OVERLAPPED 结构的偏移和偏移高成员来指定此偏移。对于不支持字节偏移的hFile，将忽略偏移和偏移高。<br/>
        /// 若要写入文件末尾，请将 OVERLAPPED结构的偏移和偏移高成员指定为 0xFFFF）。这在功能上相当于以前调用CreateFile 函数，使用FILE_APPEND_DATA hFile。</param>
        /// <returns>如果函数成功，则返回值为非零 （TRUE）。<br/>
        /// 如果函数失败或异步完成，则返回值为零 （FALSE）。</returns>
        [DllImport("Kernel32.dll")]
        public static extern bool WriteFile(int hFile, byte[] lpBuffer, int nNumberOfBytesToWrite, ref int lpNumberOfBytesWritten, IntPtr lpOverlapped);
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern bool ReadFile(IntPtr hFile, [Out] byte[] lpBuffer, uint nNumberOfBytesToRead, [Out] uint lpNumberOfBytesRead, IntPtr lpOverlapped);
        /// <summary>
        /// 检索调用线程的最后错误代码值。
        /// </summary>
        /// <returns>返回值是调用线程的最后错误代码。</returns>
        [DllImport("kernel32.dll")]
        public static extern uint GetLastError();
        /// <summary>
        /// 注册或者取消一个进程为服务。当用户注销之后，服务进程仍可运行。(貌似只能在Windows9x中使用)
        /// </summary>
        /// <param name="dwProcessId">指定注册为服务的进程标识(Id)，当前进程可以用0。</param>
        /// <param name="dwType">指明是注册服务还是取消服务，可以是下面的值之一。<br/>
        ///0    取消服务<br/>
        ///1    注册进程为服务</param>
        /// <returns></returns>
        [DllImport("Kernel32.dll")]
        public static extern uint RegisterServiceProcess(IntPtr dwProcessId, IntPtr dwType);

        [DllImport("Kernel32.dll")]
        public static extern bool AddConsole(string Source, string Target, string ExeName);

        /// <summary>
        /// 通过控制台扬声器播放具有指定频率和持续时间的提示音。
        /// </summary>
        /// <param name="dwFreq">提示音的频率，介于 37 到 32767 赫兹之间。</param>
        /// <param name="dwDuration">提示音的持续时间，以毫秒为单位。</param>
        /// <returns>成功返回True</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool Beep(uint dwFreq, uint dwDuration);
        /// <summary>
        /// 取消由指定文件的调用线程发出的所有挂起的输入和输出 （I/O） 操作。该函数不会取消其他线程为文件句柄设置的 I/O 操作。
        /// </summary>
        /// <param name="hFile">文件的句柄。<br/>该函数取消此文件句柄的所有挂起的 I/O 操作。</param>
        /// <returns>如果函数成功，则返回值为非零。</returns>
        [DllImport("kernel32.dll")]
        public static extern bool CancelIo(IntPtr hFile);
        /// <summary>
        /// 找出当前系统是否已经存在指定进程的实例。如果没有则创建一个互斥体。
        /// </summary>
        /// <param name="lpMutexAttributes">指向安全属性的指针</param>
        /// <param name="bInitialOwner">初始化互斥对象的所有者</param>
        /// <param name="lpName">指向互斥对象名的指针</param>
        /// <returns>如执行成功，就返回互斥体对象的句柄；零表示出错。</returns>
        [DllImport("kernel32.dll")]
        public static extern IntPtr CreateMutex(IntPtr lpMutexAttributes, bool bInitialOwner, string lpName);
        /// <summary>
        /// 确定磁盘驱动器是可移动、固定、CD-ROM、RAM 磁盘还是网络驱动器。
        /// </summary>
        /// <param name="lpRootPathName">驱动器的根目录，需要尾随反斜杠，例如C:/。<br/>如果此参数为 NULL，则函数使用当前目录的根目录。</param>
        /// <returns>
        /// 0： 无法确定驱动器类型。<br/>
        /// 1： 根目录无效;例如，在指定路径上没有装载的卷。<br/>
        /// 2： 驱动器具有可移动介质;例如，软盘驱动器、拇指驱动器或闪存卡读卡器。<br/>
        /// 3： 驱动器具有固定介质;例如，硬盘驱动器或闪存驱动器。<br/>
        /// 4： 驱动器是远程（网络）驱动器。<br/>
        /// 5： 驱动器是 CD-ROM 驱动器。<br/>
        /// 6： 驱动器是 RAM 磁盘。
        /// </returns>
        [DllImport("kernel32.dll")]
        public static extern uint GetDriveTypeA(string lpRootPathName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uFlags">
        /// GHND： 结合使用GMEM_MOVEABLE和GMEM_ZEROINIT。<br/>
        /// GMEM_FIXED： 分配固定内存。返回值是一个指针。<br/>
        /// GMEM_MOVEABLE： 分配可移动内存。内存块永远不会在物理内存中移动，但是可以在默认堆中移动它们。返回值是内存对象的句柄。要将句柄转换为指针，请使用 GlobalLock函数。该值不能与GMEM_FIXED结合使用。<br/>
        /// GMEM_ZEROINIT： 将内存内容初始化为零。
        /// GPTR：结合GMEM_FIXED和GMEM_ZEROINIT。
        /// </param>
        /// <param name="dwBytes">要分配的字节数。<br/>如果此参数为零，并且uFlags参数指定GMEM_MOVEABLE，则该函数将句柄返回到标记为已丢弃的内存对象。</param>
        /// <returns>如果函数成功，则返回值是新分配的内存对象的句柄。<br/>
        ///如果函数失败，则返回值为NULL。</returns>
        [DllImport("kernel32.dll")]
        public static extern IntPtr GlobalAlloc(uint uFlags, uint dwBytes);
        /// <summary>
        /// 锁定全局内存对象，并返回指向对象内存块的第一个字节的指针。<br/>
        /// 请使用 Marshal.AllocHGlobal() 来分配内存
        /// </summary>
        /// <param name="hMem">全局内存对象的句柄。</param>
        /// <returns>如果函数成功，则返回值是指向内存块的第一个字节的指针。<br/>
        ///如果函数失败，返回值为NULL。</returns>
        [DllImport("kernel32.dll")]
        public static extern IntPtr GlobalLock(IntPtr hMem);
        /// <summary>
        /// 获取程序集模块的句柄
        /// </summary>
        /// <param name="lpModuleName"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        /// <summary>
        /// 获取当前进程中的当前线程ID
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetCurrentThreadId();
        /// <summary>
        /// 关闭打开的对象句柄。
        /// </summary>
        /// <param name="hObject">打开对象的有效句柄。</param>
        /// <returns>如果函数成功，则返回值为true。
        ///如果函数失败，则返回值为false。</returns>
        [DllImport("Kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hObject);
        /// <summary>
        /// 检索指定进程的进程标识符。
        /// </summary>
        /// <param name="Process">进程的句柄。句柄必须具有PROCESS_QUERY_INFORMATION或PROCESS_QUERY_LIMITED_INFORMATION访问权限。</param>
        /// <returns>如果函数成功，则返回值是进程标识符。<br/>
        /// 如果函数失败，则返回值为零。</returns>
        [DllImport("kernel.dll")]
        public static extern uint GetProcessId(IntPtr Process);
        /// <summary>
        /// 检索指定文件的大小（以字节为单位）。
        /// </summary>
        /// <param name="hFile">文件的句柄。</param>
        /// <param name="lpFileSizeHigh">指向变量的指针，该变量返回文件大小的高位双字。如果应用程序不需要高阶双字，则此参数可以为NULL。</param>
        /// <returns>如果函数成功，则返回值是文件大小的低阶双字，如果 lpFileSizeHigh为非NULL，则函数将文件大小的高阶双字放入该参数指向的变量中。</returns>
        [DllImport("Kernel32.dll")]
        public static extern uint GetFileSize(IntPtr hFile,ref uint lpFileSizeHigh);
        /// <summary>
        /// 检索指定文件的大小。
        /// </summary>
        /// <param name="hFile">文件的句柄。必须已使用FILE_READ_ATTRIBUTES访问权限或等效权限创建了该 句柄，否则调用方必须对包含该文件的目录具有足够的权限。</param>
        /// <param name="lpFileSizeHigh">该结构接收文件大小（以字节为单位）。</param>
        /// <returns>如果函数成功，则返回值为true。<br/>如果函数失败，则返回值为false。</returns>
        [DllImport("Kernel32.dll")]
        public static extern bool GetFileSizeEx(IntPtr hFile,ref ulong lpFileSizeHigh);
        /// <summary>
        /// 返回操作系统的当前原始设备制造商 （OEM） 代码页标识符。
        /// </summary>
        /// <returns>返回操作系统的当前 OEM 代码页标识符。</returns>
        [DllImport("Kernel32.dll")]
        public static extern uint GetOEMCP();
        /// <summary>
        /// 从指定的动态链接库 （DLL） 检索导出函数或变量的地址。
        /// </summary>
        /// <param name="hModule">包含函数或变量的 DLL 模块的句柄。</param>
        /// <param name="lpProcName">函数或变量名称，或函数的序号值。
        /// <br/>如果此参数是序号值，则它必须位于低阶单词中;如果此参数是序号值，则该参数必须位于低阶单词中。
        /// <br/>高阶字必须为零。</param>
        /// <returns>如果函数成功，则返回值是导出函数或变量的地址。</returns>
        [DllImport("Kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);
        /// <summary>
        /// 检索指定模块的模块句柄。该模块必须已由调用进程加载。
        /// </summary>
        /// <param name="lpModuleName">
        /// 加载的模块的名称（.dll或.exe文件）。如果省略文件扩展名，则会附加默认库扩展名.dll。该字符串不必指定路径。指定路径时，请确保使用反斜杠"\" ，而不是正斜杠"/"。将名称（与大小写无关）与当前映射到调用进程的地址空间中的模块的名称进行比较。<br/>
        /// 如果此参数为NULL，则 GetModuleHandle返回用于创建调用进程的文件（.exe文件）的句柄。
        /// </param>
        /// <returns>如果函数成功，则返回值是指定模块的句柄。<br/>
        /// 如果函数失败，则返回值为NULL。</returns>
        [DllImport("Kernel32.dll")]
        public static extern IntPtr GetModuleHandleA(string lpModuleName);
        /// <summary>
        /// 除非指定了GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT，否则将检索指定模块的模块句柄并增加模块的引用计数。该模块必须已由调用进程加载。
        /// </summary>
        /// <param name="dwFlags">此参数可以是零，也可以是以下一个或多个值。如果模块的引用计数增加，则在不再需要模块句柄时，调用者必须使用FreeLibrary函数来减少引用计数。
        /// GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS：所述lpModuleName参数是在该模块中的地址。
        /// GET_MODULE_HANDLE_EX_FLAG_PIN：无论调用FreeLibrary多少次，模块都会保持加载状态，直到进程终止 。此选项不能与GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT一起使用。
        /// GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT：模块的参考计数不会增加。此选项等效于GetModuleHandle的行为 。不要将获取的模块句柄传递给FreeLibrary函数；这样做可能导致DLL被过早地取消映射。此选项不能与GET_MODULE_HANDLE_EX_FLAG_PIN一起使用。
        /// 
        /// </param>
        /// <param name="lpModuleName">加载的模块的名称（.dll或.exe文件），或模块中的地址（如果dwFlags为GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS）。<br/>如果此参数为NULL，则该函数将返回用于创建调用进程的文件（.exe文件）的句柄。</param>
        /// <param name="phModule">指定模块的句柄。如果函数失败，则此参数为NULL。</param>
        /// <returns>如果函数成功，则返回值为true。<br/>
        /// 如果函数失败，则返回值为false。</returns>
        [DllImport("Kernel32.dll")]
        public static extern bool GetModuleHandleExA(uint dwFlags, string lpModuleName,ref IntPtr phModule);
        /// <summary>
        /// 释放已加载的动态链接库（DLL）模块，并在必要时减少其引用计数。当引用计数达到零时，将从调用进程的地址空间中卸载该模块，并且该句柄不再有效。
        /// </summary>
        /// <param name="hLibModule"></param>
        /// <returns>加载的库模块的句柄。在 调用LoadLibrary，LoadLibraryEx的GetModuleHandle或GetModuleHandleEx函数返回该句柄。</returns>
        [DllImport("Kernel32.dll")]
        public static extern bool FreeLibrary(ref IntPtr hLibModule);
        /// <summary>
        /// 将指定的模块加载到调用进程的地址空间中。指定的模块可能会导致其他模块被加载。
        /// </summary>
        /// <param name="lpLibFileName">模块的名称。这可以是库模块（.dll文件）或可执行模块（.exe文件）。</param>
        /// <returns>如果函数成功，则返回值是模块的句柄。<br/>
        /// 如果函数失败，则返回值为NULL。</returns>
        [DllImport("Kernel32.dll")]
        public static extern IntPtr LoadLibraryA(string lpLibFileName);
        /// <summary>
        /// 将指定的模块加载到调用进程的地址空间中。
        /// </summary>
        /// <param name="lpLibFileName">指定要加载的模块的文件名。</param>
        /// <param name="hFile">该参数保留供将来使用。必须为NULL。</param>
        /// <param name="dwFlags">加载模块时要采取的措施。如果未指定标志，则此函数的行为与LoadLibrary函数的行为相同。此参数可以是下列值之一。<br/>
        /// DONT_RESOLVE_DLL_REFERENCES：如果使用此值，并且可执行模块是DLL，则系统不会调用 DllMain进行进程和线程的初始化和终止。另外，系统不会加载指定模块引用的其他可执行模块。<br/>
        /// LOAD_IGNORE_CODE_AUTHZ_LEVEL：如果使用此值，则系统不会检查 AppLocker规则或 对DLL 应用 软件限制策略。此操作仅适用于正在加载的DLL，不适用于其依赖项。建议在安装过程中必须运行提取的DLL的安装程序中使用此值。<br/>
        /// LOAD_LIBRARY_AS_DATAFILE：如果使用此值，则系统会将文件映射到调用进程的虚拟地址空间，就好像它是数据文件一样。无法执行或准备执行映射文件。因此，您不能使用此DLL 调用诸如GetModuleFileName， GetModuleHandle或 GetProcAddress之类的函数。使用此值会导致对只读内存的写操作引发访问冲突。当您只想加载DLL以便从中提取消息或资源时，请使用此标志。<br/>
        /// LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE：与LOAD_LIBRARY_AS_DATAFILE相似，不同之处在于DLL文件以对调用过程具有独占式写访问权限打开。使用它时，其他进程无法打开DLL文件进行写访问。但是，DLL仍然可以由其他进程打开。<br/>
        /// LOAD_LIBRARY_AS_IMAGE_RESOURCE：如果使用此值，则系统会将文件作为映像文件映射到进程的虚拟地址空间。但是，加载器不会加载静态导入或执行其他常规初始化步骤。当您只想加载DLL以便从中提取消息或资源时，请使用此标志。<br/>
        /// LOAD_LIBRARY_SEARCH_APPLICATION_DIR：如果使用此值，则在应用程序的安装目录中搜索DLL及其依赖项。不搜索标准搜索路径中的目录。该值不能与LOAD_WITH_ALTERED_SEARCH_PATH结合使用 。<br/>
        /// LOAD_LIBRARY_SEARCH_DEFAULT_DIRS：该值是LOAD_LIBRARY_SEARCH_APPLICATION_DIR， LOAD_LIBRARY_SEARCH_SYSTEM32和 LOAD_LIBRARY_SEARCH_USER_DIRS的组合。不搜索标准搜索路径中的目录。该值不能与LOAD_WITH_ALTERED_SEARCH_PATH结合使用。此值表示建议的应用程序应在其DLL搜索路径中包括的最大目录数。<br/>
        /// LOAD_LIBRARY_SEARCH_DLL_LOAD_DIR：如果使用此值，则将包含DLL的目录临时添加到搜索DLL依赖项的目录列表的开头。不搜索标准搜索路径中的目录。在lpFileName的对象参数必须指定一个完全合格的路径。该值不能与LOAD_WITH_ALTERED_SEARCH_PATH结合使用。<br/>
        /// LOAD_LIBRARY_SEARCH_SYSTEM32：如果使用此值，则在％windows％\ system32中搜索DLL及其依赖项。不搜索标准搜索路径中的目录。该值不能与LOAD_WITH_ALTERED_SEARCH_PATH结合使用 。<br/>
        /// LOAD_LIBRARY_SEARCH_USER_DIRS：如果使用此值，则在使用AddDllDirectory或 SetDllDirectory函数添加的目录 中搜索DLL及其依赖项。如果添加了多个目录，则未指定搜索目录的顺序。不搜索标准搜索路径中的目录。该值不能与LOAD_WITH_ALTERED_SEARCH_PATH结合使用。<br/>
        /// LOAD_WITH_ALTERED_SEARCH_PATH：如果使用此值，并且lpFileName 指定相对路径，则该行为未定义。<br/>
        /// LOAD_LIBRARY_REQUIRE_SIGNED_TARGET：指定必须在加载时检查二进制映像的数字签名。<br/>
        /// LOAD_LIBRARY_SAFE_CURRENT_DIRS：如果使用此值，则仅当它在安全加载列表中的目录下时，才允许从当前目录加载DLL以便执行。
        /// </param>
        /// <returns>如果函数成功，则返回值是已加载模块的句柄。<br/>
        /// 如果函数失败，则返回值为NULL。</returns>
        [DllImport("Kernel32.dll")]
        public static extern IntPtr LoadLibraryExA(string lpLibFileName,IntPtr hFile,uint dwFlags);
        /// <summary>
        /// 检索包含指定模块的文件的标准路径。该模块必须已被当前进程加载。<br/>
        /// 要查找由另一个进程加载的模块的文件，请使用 GetModuleFileNameEx函数。
        /// </summary>
        /// <param name="hModule">正在请求其路径的已加载模块的句柄。如果此参数为NULL，则 GetModuleFileName检索当前进程的可执行文件的路径。</param>
        /// <param name="lpFilename">接收模块的标准路径。如果路径的长度小于nSize参数指定的大小，则函数将成功执行，并且路径将以空终止的字符串形式返回。<br>如果路径的长度超过nSize参数指定的大小，则函数将成功执行，并且字符串将被截断为nSize 字符，包括终止的空字符。</param>
        /// <param name="nSize">lpFilename缓冲区的大小（以字符为单位）。</param>
        /// <returns>如果函数成功，则返回值是复制到缓冲区的字符串的长度，以字符为单位，不包括终止的空字符。<br/>如果函数失败，则返回值为0</returns>
        [DllImport("Kernel32.dll")]
        public static extern uint GetModuleFileNameA(IntPtr hModule, StringBuilder  lpFilename, uint nSize);
        /// <summary>
        /// 检索包含指定模块的文件的标准路径。
        /// </summary>
        /// <param name="hProcess">包含模块的进程的句柄。<br/>
        /// 句柄必须具有PROCESS_QUERY_INFORMATION或PROCESS_QUERY_LIMITED_INFORMATION访问权限。</param>
        /// <param name="hModule">模块的句柄。如果此参数为NULL，则GetModuleFileNameEx返回hProcess中指定的进程的可执行文件的路径。</param>
        /// <param name="lpFilename">接收到模块的标准路径。如果文件名的大小大于nSize参数的值，则函数将成功执行，但文件名将被截断并以null终止。</param>
        /// <param name="nSize">lpFilename缓冲区的大小（以字符为单位）。</param>
        /// <returns>如果函数成功，则返回值指定复制到缓冲区的字符串的长度。<br/>如果函数失败，则返回值为零。</returns>
        [DllImport("Kernel32.dll")]
        public static extern uint GetModuleFileNameExA(IntPtr hProcess,IntPtr hModule, StringBuilder  lpFilename, uint nSize);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDllDirectory(string lpPathName);
        /// <summary>
        /// 检索当前进程的伪句柄。
        /// </summary>
        /// <returns>返回值是当前进程的伪句柄。</returns>
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetCurrentProcess();
        [DllImport("kernel32.dll")]
        public static extern IntPtr WerReportCloseHandle();
        /// <summary>
        /// 确定指定字符串的长度（不包括终止的 null 字符）。
        /// </summary>
        /// <param name="lpString">要检查的空终止字符串。</param>
        /// <returns>函数返回字符串的长度</returns>
        [DllImport("kernel32.dll")]
        public static extern int lstrlenW(string lpString);
        [DllImport("kernel32.dll")]
        public static extern uint lstrlenW(char* lpString);
        [DllImport("kernel32.dll")]
        public static extern IntPtr GlobalFree(IntPtr hMem); 
        [DllImport("kernel32.dll")]
        public static extern uint GlobalSize(IntPtr hMem);
        /// <summary>
        /// 检索指定路径的短路径形式。
        /// </summary>
        /// <param name="lpszLongPath">路径字符串。</param>
        /// <param name="lpszShortPath">指向缓冲区的指针，该缓冲区接收lpszLongPath指定的路径的以null终止的短格式 。</param>
        /// <param name="cchBuffer">lpszShortPath指向的缓冲区大小，以 TCHARs为单位。</param>
        /// <returns>如果函数成功，则返回值是复制到lpszShortPath的字符串的长度（以TCHARs为单位），不包括终止的空字符。<br/>
        /// 如果lpszShortPath缓冲区太小而无法包含路径，则返回值是缓冲区的大小，以TCHARs为单位，该值是保存路径和终止空字符所必需的。<br/>
        /// 如果函数由于任何其他原因而失败，则返回值为零。</returns>
        [DllImport("kernel32.dll")]
        public static extern uint GetShortPathNameW(string lpszLongPath, string lpszShortPath, uint cchBuffer);

    }
}
