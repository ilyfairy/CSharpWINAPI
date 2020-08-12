using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WINAPI
{
    public struct _UNICODE_STRING
    {
       public ushort Length;
        public ushort MaximumLength;
        public string Buffer;
    }

    public struct _OBJECT_ATTRIBUTES
    {
        /// <summary>
        /// 此结构中包含的数据字节数。初始化对象属性宏将此成员大小 （OBJECT_ATTRIBUTES）。
        /// </summary>
        public uint Length;
        /// <summary>
        /// ObjectName 成员指定的路径名称的根对象目录的可选句柄。如果RootDirectory为NULL，则 ObjectName必须指向包含目标对象的完整路径的完全限定对象名称。如果根目录是非NULL的，则 ObjectName指定相对于根目录的对象名称。根目录句柄可以引用文件系统目录或对象管理器命名空间中的对象目录。
        /// </summary>
        public IntPtr RootDirectory;
        /// <summary>
        /// 指向包含要打开句柄的对象的名称的Unicode字符串。这必须是完全限定的对象名称，或由RootDirectory成员指定的目录的相对路径名称。
        /// </summary>
        public _UNICODE_STRING ObjectName;
        /// <summary>
        /// 指定对象句柄属性的标志的位掩。此成员可以包含下表中的一个或多个标志。<br/>
        /// OBJ_INHERIT：此句柄可由当前进程的子进程继承。<br/>
        /// OBJ_PERMANENT：此标志仅适用于对象管理器中命名的对象。默认情况下，当关闭这些对象的所有打开的句柄时，这些对象将被删除。如果指定了此标志，则当关闭所有打开的句柄时，不会删除该对象。驱动程序可以使用ZwMake 临时对象例程使永久对象非永久化。<br/>
        /// OBJ_EXCLUSIVE：如果设置了此标志，并且OBJECT_ATTRIBUTES结构传递到创建对象的例程，则可以独占访问该对象。也就是说，一旦进程向对象打开此类句柄，任何其他进程都无法打开该对象的句柄。<br/>
        /// 如果设置了此标志，并且 OBJECT_ATTRIBUTES结构传递到创建对象句柄的例程，则调用方请求对创建句柄的进程的进程的上下文的对象进行独占访问。只有在创建对象时设置了OBJ_EXCLUSIVE标记时，才能授予此请求。<br/>
        /// OBJ_CASE_INSENSITIVE：如果指定了此标志，则当对象名称成员指向的名称与现有对象的名称匹配时，将使用不区分大小写的比较。否则，使用默认系统设置比较对象名称。<br/>
        /// OBJ_OPENIF：如果通过使用对象句柄向创建对象的例程指定了此标志，并且如果该对象已存在，则该例程应打开该对象。否则，创建对象的例程将返回 NTSTATUS STATUS_OBJECT_NAME_COLLISION。<br/>
        /// OBJ_OPENLINK：如果对象句柄（具有此标志集）传递到打开对象的例程，并且如果对象是符号链接对象，则例程应打开符号链接对象本身，而不是符号链接引用的对象（这是默认行为）。<br/>
        /// OBJ_KERNEL_HANDLE：句柄是在系统进程上下文中创建的，只能从内核模式访问。<br/>
        /// OBJ_FORCE_ACCESS_CHECK：打开句柄的例程应强制对象进行所有访问检查，即使句柄在内核模式下打开。<br/>
        /// OBJ_DONT_REPARSE：如果设置了此标志，则在分析关联对象的名称时将不遵循任何重解析点。如果遇到任何修复，尝试将失败并返回STATUS_REPARSE_POINT_ENCOUNTERED结果。这可用于确定在安全方案中对象路径中是否有任何重新解析点。<br/>
        /// OBJ_IGNORE_IMPERSONATED_DEVICEMAP：设备映射是 DOS 设备名称和系统中设备之间的映射，用于解析 DOS 名称。系统中每个用户都有单独的设备映射，用户可以管理自己的设备映射。通常，在模拟过程中，将使用模拟用户的设备映射。但是，设置此标志时，将改为使用进程用户的设备映射。<br/>
        /// OBJ_VALID_ATTRIBUTES：保留。
        /// </summary>
        public uint Attributes;
        /// <summary>
        /// 在创建对象时SECURITY_DESCRIPTOR指定对象的安全描述符 （ 或） 。如果此成员为NULL，则对象将收到默认安全设置。
        /// </summary>
        public IntPtr SecurityDescriptor;
        /// <summary>
        /// 创建对象时要应用于对象的可选服务质量。用于指示安全模拟级别和上下文跟踪模式（动态或静态）。目前，初始化对象属性宏将此成员设置为NULL。
        /// </summary>
        public IntPtr SecurityQualityOfService;
    }
    public struct _IO_STATUS_BLOCK
    {
        public IntPtr Status__Pointer;
        public uint Information;
    }

    public static class Ntdll
    {
        //NtCreateFile.DesiredAccess
        public const uint DELETE = 0x00010000;
        public const uint FILE_READ_DATA = 0x0001;
        public const uint FILE_READ_ATTRIBUTES = 0x0080;
        public const uint FILE_READ_EA = 0x0008;
        public const uint READ_CONTROL = 0x00020000;
        public const uint FILE_WRITE_DATA = 0x0002;
        public const uint FILE_WRITE_ATTRIBUTES = 0x0100;
        public const uint FILE_WRITE_EA = 0x0010;
        public const uint FILE_APPEND_DATA = 0x0004;
        public const uint WRITE_DAC = 0x00040000;
        public const uint WRITE_OWNER = 0x00080000;
        public const uint SYNCHRONIZE = 0x00100000;
        public const uint FILE_EXECUTE = 0x0020;

        public const uint STANDARD_RIGHTS_READ = READ_CONTROL;
        public const uint STANDARD_RIGHTS_WRITE = READ_CONTROL;
        public const uint STANDARD_RIGHTS_EXECUTE = READ_CONTROL;

        public const uint FILE_GENERIC_READ = STANDARD_RIGHTS_READ | FILE_READ_DATA | FILE_READ_ATTRIBUTES | FILE_READ_EA | SYNCHRONIZE;
        public const uint FILE_GENERIC_WRITE = STANDARD_RIGHTS_WRITE | FILE_WRITE_DATA | FILE_WRITE_ATTRIBUTES | FILE_WRITE_EA | FILE_APPEND_DATA | SYNCHRONIZE;
        public const uint FILE_GENERIC_EXECUTE = STANDARD_RIGHTS_EXECUTE | FILE_READ_ATTRIBUTES | FILE_EXECUTE | SYNCHRONIZE;

        public const uint FILE_LIST_DIRECTORY = 0x0001;
        public const uint FILE_TRAVERSE = 0x0020;

        public const uint OBJ_INHERIT = 0x00000002;
        public const uint OBJ_PERMANENT = 0x00000010;
        public const uint OBJ_EXCLUSIVE = 0x00000020;
        public const uint OBJ_OPENIF = 0x00000080;
        public const uint OBJ_OPENLINK = 0x00000100;
        public const uint OBJ_KERNEL_HANDLE = 0x00000200;
        public const uint OBJ_FORCE_ACCESS_CHECK = 0x00000400;
        public const uint OBJ_IGNORE_IMPERSONATED_DEVICEMAP = 0x00000800;
        public const uint OBJ_DONT_REPARSE = 0x00001000;
        public const uint OBJ_VALID_ATTRIBUTES = 0x00001FF2;
        public const uint OBJ_CASE_INSENSITIVE = 0x00000040;

        public const uint FILE_SUPERSEDED = 0x00000000;
        public const uint FILE_OPENED = 0x00000001;
        public const uint FILE_CREATED = 0x00000002;
        public const uint FILE_OVERWRITTEN = 0x00000003;
        public const uint FILE_EXISTS = 0x00000004;
        public const uint FILE_DOES_NOT_EXIST = 0x00000005;

        public const uint FILE_ATTRIBUTE_NORMAL = 0x00000080;

        public const uint FILE_SHARE_READ = 0x00000001;
        public const uint FILE_SHARE_WRITE = 0x00000002;
        public const uint FILE_SHARE_DELETE = 0x00000004;

        public const uint FILE_SUPERSEDE = 0x00000000;
        public const uint FILE_OPEN = 0x00000001;
        public const uint FILE_CREATE = 0x00000002;
        public const uint FILE_OPEN_IF = 0x00000003;
        public const uint FILE_OVERWRITE = 0x00000004;
        public const uint FILE_OVERWRITE_IF = 0x00000005;
        public const uint FILE_MAXIMUM_DISPOSITION = 0x00000005;

        public const uint FILE_DIRECTORY_FILE = 0x00000001;
        public const uint FILE_WRITE_THROUGH = 0x00000002;
        public const uint FILE_SEQUENTIAL_ONLY = 0x00000004;
        public const uint FILE_NO_INTERMEDIATE_BUFFERING = 0x00000008;

        public const uint FILE_SYNCHRONOUS_IO_ALERT = 0x00000010;
        public const uint FILE_SYNCHRONOUS_IO_NONALERT = 0x00000020;
        public const uint FILE_NON_DIRECTORY_FILE = 0x00000040;
        public const uint FILE_CREATE_TREE_CONNECTION = 0x00000080;

        public const uint FILE_COMPLETE_IF_OPLOCKED = 0x00000100;
        public const uint FILE_NO_EA_KNOWLEDGE = 0x00000200;
        public const uint FILE_OPEN_REMOTE_INSTANCE = 0x00000400;
        public const uint FILE_RANDOM_ACCESS = 0x00000800;

        public const uint FILE_DELETE_ON_CLOSE = 0x00001000;
        public const uint FILE_OPEN_BY_FILE_ID = 0x00002000;
        public const uint FILE_OPEN_FOR_BACKUP_INTENT = 0x00004000;
        public const uint FILE_NO_COMPRESSION = 0x00008000;



        public const int BreakOnTermination = 0x1D;  // value for BreakOnTermination (flag)
        public const int ProcessBreakOnTermination = 29;  // 设置为关键进程


        /// <summary>
        /// 将进程设置为系统关键状态。<br/>
        /// 这意味着该过程现在对 Windows 的运行"至关重要"，这也意味着在进程终止时，Windows 本身也会终止。
        /// </summary>
        /// <param name="NewValue">当前进程是否关键所需的新设置。</param>
        /// <param name="OldValue">提供要接收旧设置的变量的地址。此参数可以是 false，表示不需要旧设置。</param>
        /// <param name="IsWinLogon">指定是否要求已为当前进程启用系统关键中断。</param>
        /// <returns></returns>
        [DllImport("ntdll.dll")]
        public static extern bool RtlSetProcessIsCritical(bool NewValue, bool OldValue, bool IsWinLogon);
        [DllImport("ntdll.dll")]
        public static extern uint RtlGetLastWin32Error();
        /// <summary>
        /// 返回宽字符串的长度
        /// </summary>
        /// <param name="str">需要测试的字符串</param>
        /// <returns>宽字符串的长度</returns>
        [DllImport("ntdll.dll")]
        public static extern uint wcslen(string str);
        /// <summary>
        /// 求某个角的正切值
        /// </summary>
        /// <param name="x">角的弧度值。</param>
        /// <returns>x 弧度的正切值。</returns>
        [DllImport("ntdll.dll")]
        public static extern double tan(double x);
        /// <summary>
        /// 使用参数列表发送格式化输出到字符串。
        /// </summary>
        /// <param name="str">接收的字符串</param>
        /// <param name="format">格式化字符串</param>
        /// <param name="list">一个表示可变参数列表的对象。</param>
        /// <returns>如果成功，则返回写入的字符总数，否则返回一个负数。</returns>
        [DllImport("ntdll.dll")]
        public static extern int vsprintf(StringBuilder str, string format, params dynamic[] list);
        /// <summary>
        /// 将指定进程设置为关进进程。<br/>
        /// 这意味着该过程现在对 Windows 的运行"至关重要"，这也意味着在进程终止时，Windows 本身也会终止。
        /// </summary>
        /// <param name="hProcess">进程句柄<br/>使用OpenProcess()来获取</param>
        /// <param name="processInformationClass">设置为ProcessBreakOnTermination 或者BreakOnTermination</param>
        /// <param name="processInformation">如果传进来的值为1，则表示要设置为关键进程<br/>否则表示为非关键进程</param>
        /// <param name="processInformationLength">设置为sizeof(int)</param>
        /// <returns></returns>
        [DllImport("ntdll.dll", SetLastError = true)]
        public static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength);

        /// <summary>
        /// 获取csrss.exe的PID
        /// </summary>
        /// <returns>返回csrss.exe的PID</returns>
        [DllImport("ntdll.dll", SetLastError = true)]
        public static extern IntPtr CsrGetProcessId();
        /// <summary>
        /// 向内核调试器发送消息。
        /// </summary>
        /// <param name="Format">指定指向要打印的格式字符串的指针。Format 字符串支持大多数printf样式格式规范字段。但是，Unicode 格式代码 （%C、 %S、 %lc、 %ls、 %wc、 %ws和%wZ）只能与 IRQL = PASSIVE_LEVEL一起使用。DbgPrint例程不支持任何浮点类型（%f、 %e、 %E、 %g 、%G 、%a或%A） 。</param>
        /// <param name="list">参数列表</param>
        /// <returns></returns>
        [DllImport("ntdll.dll")]
        public static extern uint DbgPrint(string Format, params string[] list);
        [DllImport("ntdll.dll")]
        public static extern int NtClose(IntPtr Handle);
        /// <summary>
        /// 创建新文件或目录，或打开现有文件，设备，目录或卷。
        /// </summary>
        /// <param name="FileHandle">如果调用成功，则指向接收文件句柄的变量的指针。</param>
        /// <param name="DesiredAccess">该ACCESS_MASK表达访问的调用者需要对文件或目录的类型值。系统定义的DesiredAccess标志集确定了文件对象的以下特定访问权限。<br/>
        /// DELETE：该文件可以删除。<br/>
        /// FILE_READ_DATA：可以从文件中读取数据。<br/>
        /// FILE_READ_ATTRIBUTES：可以读取稍后描述的FileAttributes标志。<br/>
        /// FILE_READ_EA：可以读取与文件关联的扩展属性。该标志与设备和中间驱动程序无关。<br/>
        /// READ_CONTROL：可以读取与文件关联的访问控制列表（ACL）和所有权信息。<br/>
        /// FILE_WRITE_DATA：数据可以写入文件。<br/>
        /// FILE_WRITE_ATTRIBUTES：可以写入FileAttributes标志。<br/>
        /// FILE_WRITE_EA：可以写入与文件关联的扩展属性（EA）。该标志与设备和中间驱动程序无关。<br/>
        /// FILE_APPEND_DATA：数据可以附加到文件中。<br/>
        /// WRITE_DAC：	可以编写与文件关联的任意访问控制列表（DACL）。<br/>
        /// WRITE_OWNER：可以写入与文件关联的所有权信息。<br/>
        /// SYNCHRONIZE：可以等待 返回的FileHandle与I / O操作的完成同步。如果未为同步I / O打开FileHandle，则忽略此值。<br/>
        /// FILE_EXECUTE：可以使用系统分页I / O将数据从文件读入内存。该标志与设备和中间驱动程序无关。<br/>
        /// 创建或打开FILE_READ_DATA时 FILE_WRITE_DATAFILE_APPEND_DATAFILE_EXECUTE指定FILE_EXECUTE、名称、名称、名称或名称。<br/>
        /// NtCreateFile 的调用者可以指定以下一个或多个组合，对于不表示目录文件的任何文件对象，可能使用位或与上一个"期望访问"标志列表中的其他兼容标志。
        /// FILE_GENERIC_READ：STANDARD_RIGHTS_READ | FILE_READ_DATA | FILE_READ_ATTRIBUTES | FILE_READ_EA | SYNCHRONIZE<br/>
        /// FILE_GENERIC_WRITE：STANDARD_RIGHTS_WRITE | FILE_WRITE_DATA | FILE_WRITE_ATTRIBUTES | FILE_WRITE_EA | FILE_APPEND_DATA | SYNCHRONIZE<br/>
        /// FILE_GENERIC_EXECUTE：STANDARD_RIGHTS_EXECUTE | FILE_READ_ATTRIBUTES | FILE_EXECUTE | SYNCHRONIZE<br/>
        /// 所述FILE_GENERIC_EXECUTE 值是不相关的用于设备和中间层驱动程序。<br/>
        /// STANDARD_RIGHTS_ XXX是预定义的用于强制系统对象安全系统值。<br/>
        /// 若要打开或创建目录文件（也如CreateOptions 参数所示），NtCreateFile的调用者可以指定以下一项或多项操作的组合，可能使用按位或与前面的DesiredAccess标志列表中的一个或多个兼容标志 一起使用。<br/>
        /// FILE_LIST_DIRECTORY：可以列出目录中的文件。<br/>
        /// FILE_TRAVERSE：可以遍历该目录：也就是说，它可以是文件路径名的一部分。
        /// </param>
        /// <param name="ObjectAttributes">
        /// 指向已使用InitializeObjectAttributes初始化的结构的指针 。文件对象的此结构的成员包括以下成员。<br/>
        /// Length：指定提供的ObjectAttributes数据的字节数。此值必须至少为sizeof（OBJECT_ATTRIBUTES）。<br/>
        /// RootDirectory：（可选）指定通过先前调用NtCreateFile获得的目录的句柄 。如果此值为 NULL，则ObjectName成员必须是完全合格的文件规范，其中包括目标文件的完整路径。如果此值为非NULL，则ObjectName成员指定相对于此目录的文件名。<br/>
        /// ObjectName：指向一个缓冲的Unicode字符串，该字符串为要创建或打开的文件命名。该值必须是标准文件规范或设备对象的名称，除非它是相对于RootDirectory指定的目录的文件名。例如，\ Device \ Floppy1 \ myfile.dat或\ ?? \ B：\ myfile.dat可以是完全合格的文件规范，前提是已经加载了软盘驱动程序和上层文件系统。<br/>
        /// Attributes：是一组控制文件对象属性的标志。该值可以为零或 OBJ_CASE_INSENSITIVE，这表示名称查找代码应忽略ObjectName成员的大小写，而不是执行完全匹配搜索。值 OBJ_INHERIT与设备和中间驱动程序无关。<br/>
        /// SecurityDescriptor：（可选）指定要应用于文件的安全描述符。由此类安全描述符指定的ACL仅在文件创建时才应用于文件。如果在创建文件时该值为NULL，则放在文件上的ACL取决于文件系统；大多数文件系统从父目录文件中传播此类ACL的某些部分，并结合调用者的默认ACL。设备和中间驱动程序可以将此成员设置为NULL。<br/>
        /// SecurityQualityOfService：指定服务器应被赋予客户端安全上下文的访问权限。仅当建立与受保护服务器的连接时，此值才为非NULL，从而允许调用方控制调用方安全上下文的哪些部分可用于服务器，以及是否允许服务器模拟调用方。
        /// </param>
        /// <param name="IoStatusBlock">指向变量的指针，该变量接收最终的完成状态和有关所请求操作的信息。从NtCreateFile返回时， Information成员包含以下值之一：<br/>
        /// FILE_CREATED<br/>
        /// FILE_OPENED<br/>
        /// FILE_OVERWRITTEN<br/>
        /// FILE_SUPERSEDED<br/>
        /// FILE_EXISTS<br/>
        /// FILE_DOES_NOT_EXIST<br/>
        /// </param>
        /// <param name="AllocationSize">文件的初始分配大小（以字节为单位）。除非正在创建，覆盖或替换文件，否则非零值无效。</param>
        /// <param name="FileAttributes">文件属性。明确指定的属性仅在创建，替换或在某些情况下被覆盖时才应用。默认情况下，此值为FILE_ATTRIBUTE_NORMAL，可以由Wdm.h和NtDdk.h中定义的一个或多个FILE_ATTRIBUTE_ xxxx标志的ORed组合进行覆盖 。有关可与NtCreateFile一起使用的标志的列表 ，请参见 CreateFile。</param>
        /// <param name="ShareAccess">调用者希望在文件中使用的共享访问类型，可以是零，也可以是以下值之一或组合。<br/>
        /// FILE_SHARE_READ：可以通过其他线程对NtCreateFile的调用来打开该文件以进行读取访问 。<br/>
        /// FILE_SHARE_WRITE：可以通过其他线程对NtCreateFile的调用来打开该文件以进行写访问 。<br/>
        /// FILE_SHARE_DELETE：可以通过其他线程对NtCreateFile的调用来打开该文件以进行删除访问 。
        /// </param>
        /// <param name="CreateDisposition">根据以下文件之一，指定要执行的操作，具体取决于文件是否已存在。<br/>
        /// FILE_SUPERSEDE：如果文件已经存在，请用给定的文件替换它。如果没有，请创建给定的文件。<br/>
        /// FILE_CREATE：如果该文件已经存在，请失败请求，并且不要创建或打开给定的文件。如果没有，请创建给定的文件。<br/>
        /// FILE_OPEN：如果文件已经存在，请打开它，而不要创建一个新文件。如果不是，则使请求失败，并且不创建新文件。<br/>
        /// FILE_OPEN_IF：如果该文件已经存在，请打开它。如果没有，请创建给定的文件。<br/>
        /// FILE_OVERWRITE：如果文件已经存在，请打开并覆盖它。如果不是，则使请求失败。<br/>
        /// FILE_OVERWRITE_IF：如果文件已经存在，请打开并覆盖它。如果没有，请创建给定的文件。<br/>
        /// </param>
        /// <param name="CreateOptions">创建或打开文件时要应用的选项，作为以下标志的兼容组合。<br/>
        /// FILE_DIRECTORY_FILE：正在创建或打开的文件是目录文件。使用此标志， 必须将CreateDisposition参数设置为FILE_CREATE， FILE_OPEN或FILE_OPEN_IF。使用此标志，其他兼容的CreateOptions标志仅包括以下内容： FILE_SYNCHRONOUS_IO_ALERT，FILE_SYNCHRONOUS_IO _NONALERT， FILE_WRITE_THROUGH，FILE_OPEN_FOR_BACKUP_INTENT和 FILE_OPEN_BY_FILE_ID。<br/>
        /// FILE_NON_DIRECTORY_FILE：正在打开的文件不能是目录文件，否则此调用将失败。正在打开的文件对象可以代表数据文件，逻辑，虚拟或物理设备或卷。<br/>
        /// FILE_WRITE_THROUGH：将数据写入文件的应用程序必须在将任何请求的写入操作视为完成之前实际将数据传输到文件中。如果设置了CreateOptions标志FILE_NO_INTERMEDIATE _BUFFERING，则会自动设置此标志 。<br/>
        /// FILE_SEQUENTIAL_ONLY：对文件的所有访问都是顺序的。<br/>
        /// FILE_RANDOM_ACCESS：对文件的访问可以是随机的，因此FSD或系统不应对文件执行顺序的预读操作。<br/>
        /// FILE_NO_INTERMEDIATE_BUFFERING：无法在驱动程序的内部缓冲区中缓存或缓冲文件。该标志是不兼容的 DesiredAccess FILE_APPEND_DATA 标志。<br/>
        /// FILE_SYNCHRONOUS_IO_ALERT：对文件的所有操作都是同步执行的。任何代表呼叫者的等待都可能因警报而提前终止。此标志还使I / O系统维护文件位置上下文。如果设置了此标志，则还必须设置DesiredAccess SYNCHRONIZE标志。<br/>
        /// FILE_SYNCHRONOUS_IO_NONALERT：对文件的所有操作都是同步执行的。在系统中等待同步I / O排队和完成不会受到警报的影响。此标志还使I / O系统维护文件位置上下文。如果设置了此标志，则还必须设置DesiredAccess SYNCHRONIZE标志。<br/>
        /// FILE_CREATE_TREE_CONNECTION：为此文件创建树状连接以便通过网络打开它。设备和中间驱动程序不使用此标志。<br/>
        /// FILE_NO_EA_KNOWLEDGE：如果在打开的现有文件上的扩展属性指示调用方必须理解EA才能正确解释该文件，则此请求将失败，因为调用方不了解如何处理EA。该标志与设备和中间驱动程序无关。<br/>
        /// FILE_OPEN_REPARSE_POINT：打开具有重解析点的文件，并绕过该文件的常规重解析点处理。有关更多信息，请参见“备注”部分。<br/>
        /// FILE_DELETE_ON_CLOSE：当文件的最后一个句柄传递到NtClose时，将其删除。如果设置了此标志，则必须在DesiredAccess参数中设置DELETE标志。<br/>
        /// FILE_OPEN_BY_FILE_ID：由ObjectAttributes参数指定的文件名包括文件的8字节文件参考号。该编号由特定文件系统分配并特定于特定文件系统。如果文件是重新解析点，则文件名还将包括设备的名称。请注意，FAT文件系统不支持此标志。设备和中间驱动程序不使用此标志。<br/>
        /// FILE_OPEN_FOR_BACKUP_INTENT：正在打开文件以进行备份。因此，在根据文件的安全描述符检查DesiredAccess参数之前，系统应检查某些访问权限并授予调用者适当的文件访问权限。设备和中间驱动程序不使用此标志。<br/>
        /// FILE_RESERVE_OPFILTER：此标志允许应用程序请求过滤器机会锁定（oplock），以防止其他应用程序遇到共享冲突。如果已经有打开的句柄，则创建请求将失败，并显示STATUS_OPLOCK_NOT_GRANTED。有关更多信息，请参见“备注”部分。<br/>
        /// FILE_OPEN_REQUIRING_OPLOCK：正在打开文件，并且作为单个原子操作请求文件上的机会锁（oplock）。文件系统在执行创建操作之前会检查oplock，如果结果是要破坏现有的oplock，则创建失败，返回码为STATUS_CANNOT_BREAK_OPLOCK。有关更多信息，请参见“备注”部分。Windows Server 2008，Windows Vista，Windows Server 2003和Windows XP：  不支持此标志。以下文件系统支持此标志：NTFS，FAT和exFAT。<br/>
        /// FILE_COMPLETE_IF_OPLOCKED：如果目标文件被锁定（而不是阻塞调用者的线程），请 立即使用备用成功代码STATUS_OPLOCK_BREAK_IN_PROGRESS完成此操作。如果文件被锁定，则另一个调用者已经可以访问该文件。设备和中间驱动程序不使用此标志。
        /// </param>
        /// <param name="EaBuffer">指向用于传递扩展属性的EA缓冲区的指针。</param>
        /// <param name="EaLength">EA缓冲区的长度。</param>
        /// <returns></returns>
        [DllImport("ntdll.dll")]
        public static extern int NtCreateFile(out IntPtr FileHandle, uint DesiredAccess, ref _OBJECT_ATTRIBUTES ObjectAttributes, out _IO_STATUS_BLOCK IoStatusBlock, uint AllocationSize, uint FileAttributes, uint ShareAccess, uint CreateDisposition, uint CreateOptions, ref IntPtr EaBuffer, uint EaLength);
        [DllImport("ntdll.dll")]
        public static extern int NtDrawText(_UNICODE_STRING UnicodeText);
        [DllImport("ntdll.dll")]
        public static extern int NtDeleteFile(ref _OBJECT_ATTRIBUTES ObjectAttributes);
        [DllImport("ntdll.dll")]
        public static extern bool RtlDosPathNameToNtPathName_U(string path, ref _UNICODE_STRING sTRING,IntPtr a, IntPtr b);
        
        [DllImport("ntdll.dll")]
        public static extern void RtlInitUnicodeString(ref _UNICODE_STRING _UNICODE,string SourceString);
        [DllImport("ntdll.dll")]
        public static extern void NtQueryInformationProcess(IntPtr processHandle,int sourceString,ref int processInformationClass,int processInformationLength,ref uint returnLength);

    }
}
