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
    class Winmm
    {

        /// <summary>
        /// 该PlaySound功能播放由给定的文件名，资源或系统事件指定声音。
        /// </summary>
        /// <param name="pszSound">指定要播放的声音的字符串。最大长度（包括空终止符）为 256 个字符。如果此参数为NULL，则停止当前播放的任何波形声音。</param>
        /// <param name="hmod">（SND_ALIAS、SND_FILENAME和SND_RESOURCE）中的三个标志确定该名称是解释为系统事件、文件名还是资源标识符的别名。 <br/>如果未指定这些标志，PlaySound将搜索注册表或 WIN。与指定声音名称的关联中的 INI 文件。<br/>如果找到关联，则播放声音事件。如果在注册表中找不到关联，则该名称将解释为文件名。</param>
        /// <param name="fdwSound">标志播放声音。定义以下值。<br/>
        /// SND_APPLICATION：pszSound参数是注册表中特定于应用程序的别名。您可以将此标志与SND_ALIAS或SND_ALIAS_ID标记组合，以指定应用程序定义的声音别名。<br/>
        /// SND_ALIAS：pszSound参数是注册表或 WIN 中的系统事件别名。INI 文件。请勿与SND_FILENAME或SND_RESOURCE。<br/>
        /// SND_ALIAS_ID：pszSound参数是系统事件别名的预定义标识符。请参阅备注。<br/>
        /// SND_ASYNC：声音以异步方式播放，播放声音在开始声音后立即返回。要终止异步播放的波形声音，请调用PlaySound，将 pszSound设置为NULL。<br/>
        /// SND_FILENAME：pszSound参数是一个文件名。如果找不到该文件，则函数将播放默认声音，除非SND_NODEFAULT标记。<br/>
        /// SND_LOOP：声音反复播放，直到播放声音再次调用与pszSound参数设置为NULL。如果设置了此标志，则还必须设置SND_ASYNC标志。<br/>
        /// SND_MEMORY：pszSound参数指向内存中加载的声音。<br/>
        /// SND_NODEFAULT：未使用默认声音事件。如果找不到声音，PlaySound 将静默返回，而不播放默认声音。<br/>
        /// SND_NOSTOP：指定的声音事件将生成给已在同一进程中播放的另一个声音事件。如果由于生成该声音所需的资源忙于播放另一个声音而无法播放声音，则函数将立即返回FALSE，而不播放请求的声音。<br/>
        /// SND_NOWAIT：不支持。<br/>
        /// SND_PURGE：不支持。<br/>
        /// SND_RESOURCE：pszSound 参数是资源标识符;hmod必须标识包含资源的实例。<br/>
        /// SND_SENTRY：注意需要 Windows Vista 或更晚。如果设置了此标志，则该函数将在播放声音时触发 SoundSentry 事件。 SoundSentry 是一种辅助功能，它使计算机在播放声音时显示视觉提示。如果用户未启用 SoundSentry，则不显示视觉提示。<br/>
        /// SND_SYNC：声音同步播放，播放声音在声音事件完成后返回。这是默认行为。<br/>
        /// SND_SYSTEM：注意需要 Windows Vista 或更晚。如果设置了此标志，则声音将分配给音频会话以接收系统通知声音。系统音量控制程序 （SndVol） 显示一个音量滑块，用于控制系统通知声音。设置此标志将声音置于该音量滑块的控制之下
        /// </param>
        /// <returns>如果成功，则返回TRUE，否则返回FALSE。</returns>
        [DllImport("Winmm.dll")]
        public static extern bool PlaySound(string pszSound,IntPtr hmod,uint fdwSound);
        /// <summary>
        /// 发送一个命令串到MCI设备。命令字符串中指定了发送命令的设备。
        /// </summary>
        /// <param name="lpszCommand">指向以空字符结尾的字符串，该字符串指定MCI命令字符串。</param>
        /// <param name="lpszReturnString">指向接收返回信息的缓冲区的指针。如果不需要返回信息，则此参数可以为NULL。</param>
        /// <param name="cchReturn">指定的返回缓冲区的大小（以字符为单位）。</param>
        /// <param name="hwndCallback">如果在命令字符串中指定了“ notify”标志，则处理到回调窗口。</param>
        /// <returns>如果成功则返回零，否则返回错误。<br/>返回的uint值的低位字包含错误返回值。如果错误是特定于设备的，则返回值的高位字是驱动程序标识符；否则，高阶字为零。</returns>
        [DllImport("Winmm.dll")]
        public static extern uint mciSendString(string lpszCommand,string lpszReturnString,uint cchReturn,IntPtr hwndCallback);
        /// <summary>
        /// 所述mciExecute功能将命令发送到一个MCI设备。命令字符串中指定了发送命令的设备。<br/>
        /// 该函数是mciSendString函数的简化版本。它不占用返回信息的缓冲区，并且在发生错误时会显示一个消息框。
        /// </summary>
        /// <param name="pszCommand">指向以空值结尾的字符串的指针，该字符串指定MCI命令字符串。</param>
        /// <returns>如果成功则返回TRUE，否则返回FALSE。</returns>
        [DllImport("Winmm.dll")]
        public static extern bool mciExecute(string pszCommand); 

    }
}
