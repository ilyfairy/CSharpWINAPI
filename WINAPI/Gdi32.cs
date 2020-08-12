using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WINAPI
{
    public static class Gdi32
    {

        //BitBil
        public const uint SRCCOPY = 0x00CC0020;
        public const uint SRCPAINT = 0x00EE0086;
        public const uint SRCAND = 0x008800C6;
        public const uint SRCINVERT = 0x00660046;
        public const uint SRCERASE = 0x00440328;
        public const uint NOTSRCCOPY = 0x00330008;
        public const uint NOTSRCERASE = 0x001100A6;
        public const uint MERGECOPY = 0x00C000CA;
        public const uint MERGEPAINT = 0x00BB0226;
        public const uint PATCOPY = 0x00F00021;
        public const uint PATPAINT = 0x00FB0A09;
        public const uint PATINVERT = 0x005A0049;
        public const uint DSTINVERT = 0x00550009;
        public const uint BLACKNESS = 0x00000042;
        public const uint WHITENESS = 0x00FF0062;
        public const uint NOMIRRORBITMAP = 0x80000000;
        public const uint CAPTUREBLT = 0x40000000;







        /// <summary>
        /// SetPixel函数将指定坐标处的像素设置为指定颜色。
        /// </summary>
        /// <param name="hdc">设备上下文的句柄。</param>
        /// <param name="x">要设置的点的 x 坐标（以逻辑单位为单位）。</param>
        /// <param name="y">要设置的点的 y 坐标（以逻辑单位为单位）。</param>
        /// <param name="color">用于绘制点的颜色。若要创建RGB颜色值，请使用RGB()。</param>
        /// <returns>如果函数成功，则返回值是函数将像素设置到的 RGB 值，如果函数失败，返回值为 -1。</returns>
        [DllImport("Gdi32.dll")]
        public static extern int SetPixel(IntPtr hdc, int x, int y, int color);
        /// <summary>
        /// 将颜色rgb转换为rgb
        /// </summary>
        /// <param name="r">红色的强度。</param>
        /// <param name="g">绿色的强度。</param>
        /// <param name="b">蓝色的强度。</param>
        /// <returns>返回颜色值</returns>
        public static int RGB(int r, int g, int b)
        {
            return r | g << 8 | b << 16;
        }
        /// <summary>
        /// 该函数绘制一个矩形，可以用当前的画笔画矩形轮廓，用当前画刷进行填充。
        /// </summary>
        /// <param name="hdc">设备环境句柄。</param>
        /// <param name="nLeftRect">指定矩形左上角的逻辑X坐标。</param>
        /// <param name="nTopRect">指定矩形左上角的逻辑Y坐标。</param>
        /// <param name="nRightRect">指定矩形右下角的逻辑X坐标。</param>
        /// <param name="nBottomRect">指定矩形右下角的逻辑Y坐标。</param>
        /// <returns>如果函数调用成功，返回值非零，否则返回值为0。</returns>
        [DllImport("Gdi32.dll")]
        public static extern int Rectangle(IntPtr hdc,int nLeftRect, int nTopRect,int nRightRect,int nBottomRect);
        /// <summary>
        /// 将指定设备上下文的文本颜色设置为指定的颜色。
        /// </summary>
        /// <param name="hdc">设备上下文的句柄。</param>
        /// <param name="color">文本的颜色。请使用RGB()</param>
        /// <returns>如果函数成功，返回值是上一文本颜色的颜色参考<br/>
        /// 如果函数失败，则返回值0xFFFFFFFF</returns>
        [DllImport("Gdi32.dll")]
        public static extern int SetTextColor(IntPtr hdc, int color);
        /// <summary>
        /// 将指定设备上下文的背景颜色设置为指定的颜色。
        /// </summary>
        /// <param name="hdc">设备上下文的句柄。</param>
        /// <param name="color">背景颜色。请使用RGB()</param>
        /// <returns>如果函数成功，返回值是上一文本颜色的颜色参考<br/>
        /// 如果函数失败，则返回值0xFFFFFFFF</returns>
        [DllImport("Gdi32.dll")]
        public static extern int SetBkMode(IntPtr hdc, int color);
        /// <summary>
        /// 对指定的源设备环境区域中的像素进行位块（bit_block）转换，以传送到目标设备环境。
        /// </summary>
        /// <param name="hdc">目标设备上下文的句柄。</param>
        /// <param name="x">目标矩形左上角的 x 坐标（逻辑单位）。</param>
        /// <param name="y">目标矩形左上角的 y 坐标（逻辑单位）。</param>
        /// <param name="cx">源矩形和目标矩形的宽度（以逻辑单位为单位）。</param>
        /// <param name="cy">源和目标矩形的高度（以逻辑单位为单位）。</param>
        /// <param name="hdcSrc">源设备上下文的句柄。</param>
        /// <param name="x1">源矩形左上角的 x 坐标（逻辑单位）。</param>
        /// <param name="y1">源矩形左上角的 y 坐标（逻辑单位）。</param>
        /// <param name="rop">栅格操作代码。这些代码定义如何将源矩形的颜色数据与目标矩形的颜色数据相结合，以实现最终颜色。<br/>
        /// BLACKNESS：使用物理调色板中与索引 0 关联的颜色填充目标矩形。（对于默认物理调色板，此颜色为黑色。<br/>
        /// CAPTUREBLT：包括在生成的图像中，在窗口顶部分层的任何窗口。默认情况下，图像仅包含您的窗口。请注意，这通常不能用于打印设备上下文。<br/>
        /// DSTINVERT：表示使目标矩形区域颜色取反。<br/>
        /// MERGECOPY：表示使用布尔型的AND（与）操作符将源矩形区域的颜色与特定模式组合一起。<br/>
        /// MERGEPAINT：通过使用布尔型的OR（或）操作符将反向的源矩形区域的颜色与目标矩形区域的颜色合并。<br/>
        /// NOMIRRORBITMAP：防止对位图进行镜像。<br/>
        /// NOTSRCCOPY：将源矩形区域颜色取反，于拷贝到目标矩形区域。<br/>
        /// NOTSRCERASE：使用布尔类型的OR（或）操作符组合源和目标矩形区域的颜色值，然后将合成的颜色取反。<br/>
        /// PATCOPY：将特定的模式拷贝到目标位图上。<br/>
        /// PATINVERT：通过使用XOR（异或）操作符将源和目标矩形区域内的颜色合并。<br/>
        /// PATPAINT：通过使用布尔OR（或）操作符将源矩形区域取反后的颜色值与特定模式的颜色合并。然后使用OR（或）操作符将该操作的结果与目标矩形区域内的颜色合并。<br/>
        /// SRCAND：通过使用AND（与）操作符来将源和目标矩形区域内的颜色合并。<br/>
        /// SRCCOPY：将源矩形区域直接拷贝到目标矩形区域。<br/>
        /// SRCERASE：通过使用AND（与）操作符将目标矩形区域颜色取反后与源矩形区域的颜色值合并。<br/>
        /// SRCINVERT通过使用布尔型的XOR（异或）操作符将源和目标矩形区域的颜色合并。<br/>
        /// SRCPAINT：通过使用布尔型的OR（或）操作符将源和目标矩形区域的颜色合并。<br/>
        /// WHITENESS：使用与物理调色板中索引1有关的颜色填充目标矩形区域。（对于缺省物理调色板来说，这个颜色就是白色）。
        /// </param>
        /// <returns>如果函数成功，则返回值为非零。<br/>
        /// 如果函数失败，则返回值为零。</returns>
        [DllImport("Gdi32.dll")]
        public static extern bool BitBlt(IntPtr hdc, int x, int y, int cx, int cy, IntPtr hdcSrc, int x1, int y1, uint rop);
        /// <summary>
        /// 从源矩形中复制一个位图到目标矩形，必要时按目标设备设置的模式进行图像的拉伸或压缩。
        /// </summary>
        /// <param name="hdcDest">目标设备上下文的句柄。</param>
        /// <param name="xDest">目标矩形左上角的 x 坐标（逻辑单位）。</param>
        /// <param name="yDest">目标矩形左上角的 y 坐标（逻辑单位）。</param>
        /// <param name="wDest">源矩形和目标矩形的宽度（以逻辑单位为单位）。</param>
        /// <param name="hDest">源和目标矩形的高度（以逻辑单位为单位）。</param>
        /// <param name="hdcSrc">源设备上下文的句柄。</param>
        /// <param name="wSrc">源矩形左上角的 x 坐标（逻辑单位）。</param>
        /// <param name="hSrc">源矩形左上角的 y 坐标（逻辑单位）。</param>
        /// <param name="rop">栅格操作代码。这些代码定义如何将源矩形的颜色数据与目标矩形的颜色数据相结合，以实现最终颜色。<br/>
        /// BLACKNESS：使用物理调色板中与索引 0 关联的颜色填充目标矩形。（对于默认物理调色板，此颜色为黑色。<br/>
        /// CAPTUREBLT：包括在生成的图像中，在窗口顶部分层的任何窗口。默认情况下，图像仅包含您的窗口。请注意，这通常不能用于打印设备上下文。<br/>
        /// DSTINVERT：表示使目标矩形区域颜色取反。<br/>
        /// MERGECOPY：表示使用布尔型的AND（与）操作符将源矩形区域的颜色与特定模式组合一起。<br/>
        /// MERGEPAINT：通过使用布尔型的OR（或）操作符将反向的源矩形区域的颜色与目标矩形区域的颜色合并。<br/>
        /// NOMIRRORBITMAP：防止对位图进行镜像。<br/>
        /// NOTSRCCOPY：将源矩形区域颜色取反，于拷贝到目标矩形区域。<br/>
        /// NOTSRCERASE：使用布尔类型的OR（或）操作符组合源和目标矩形区域的颜色值，然后将合成的颜色取反。<br/>
        /// PATCOPY：将特定的模式拷贝到目标位图上。<br/>
        /// PATINVERT：通过使用XOR（异或）操作符将源和目标矩形区域内的颜色合并。<br/>
        /// PATPAINT：通过使用布尔OR（或）操作符将源矩形区域取反后的颜色值与特定模式的颜色合并。然后使用OR（或）操作符将该操作的结果与目标矩形区域内的颜色合并。<br/>
        /// SRCAND：通过使用AND（与）操作符来将源和目标矩形区域内的颜色合并。<br/>
        /// SRCCOPY：将源矩形区域直接拷贝到目标矩形区域。<br/>
        /// SRCERASE：通过使用AND（与）操作符将目标矩形区域颜色取反后与源矩形区域的颜色值合并。<br/>
        /// SRCINVERT通过使用布尔型的XOR（异或）操作符将源和目标矩形区域的颜色合并。<br/>
        /// SRCPAINT：通过使用布尔型的OR（或）操作符将源和目标矩形区域的颜色合并。<br/>
        /// WHITENESS：使用与物理调色板中索引1有关的颜色填充目标矩形区域。（对于缺省物理调色板来说，这个颜色就是白色）。
        /// </param>
        /// <returns>如果函数成功，则返回值为非零。<br/>
        /// 如果函数失败，则返回值为零。</returns>
        [DllImport("Gdi32.dll")]
        public static extern bool StretchBlt(IntPtr hdcDest, int xDest, int yDest, int wDest, int hDest, IntPtr hdcSrc, int xSrc, int ySrc, int wSrc, int hSrc, uint rop);
    }
}
