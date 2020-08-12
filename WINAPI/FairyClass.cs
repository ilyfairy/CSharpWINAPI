using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WINAPI
{
    public unsafe class FairyClass
    {
        public static Random r = new Random();
        public static string StringReverse(string str)
        {
            StringBuilder newStr = new StringBuilder();
            char[] @char = str.Replace("\0", "").ToArray();
            Array.Reverse(@char);
            newStr.Append(@char);
            return newStr.ToString();
        }
        public static bool SetWindowTitleText(IntPtr hWnd, string str)
        {
            StringBuilder setstr = new StringBuilder(str);
            if (User32.SendMessageW(hWnd, User32.WM_SETTEXT, 0, setstr) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool WindowTextReverse(IntPtr hWnd)
        {
            StringBuilder str = new StringBuilder();
            User32.SendMessageA(User32.GetForegroundWindow(), User32.WM_GETTEXT, 1024, str);
            //Console.WriteLine("{0}", str.ToString());
            char[] newstr = str.ToString().Replace("\0", "").ToArray();
            //Console.WriteLine(new string(newstr));
            Array.Reverse(newstr);

            int result = User32.SendMessageA(hWnd, User32.WM_SETTEXT, 0, newstr);
            if (result != 0)
            {
                return true;
            }
            return false;
        }

        public static List<IntPtr> getChildHwd(IntPtr intptr)
        {
            List<IntPtr> list = new List<IntPtr>();
            IntPtr Zptr = (IntPtr)0;
            int i = 1;
            while ((int)Zptr != 0 || i == 1)
            {
                i++;
                Zptr = User32.FindWindowExA(intptr, Zptr, null, null);
                if ((int)Zptr > 0)
                {
                    list.Add(Zptr);
                    getChildHwd(Zptr);
                }
            }
            return list;
        }
        /// <summary>
        /// 随机抖动窗体
        /// </summary>
        /// <param name="hWnd">需要抖动的窗口句柄</param>
        /// <param name="range">抖动幅度(1~range)</param>
        public static void WindiwJitter(IntPtr hWnd, int range)
        {
            Random r = new Random();
            RECT rect;
            new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    User32.GetWindowRect(hWnd, out rect);
                    User32.MoveWindow(hWnd,
                        rect.left + (r.Next(1, range) * RandMinus()),
                        rect.top + (r.Next(1, range) * RandMinus()),
                        rect.right - rect.left, rect.bottom - rect.top,
                        true);
                    Thread.Sleep(10);
                }
            })).Start();
        }
        public static int RandMinus()
        {
            return r.Next(0, 2) == 0 ? 1 : -1;
        }
        public static void WindowFall(IntPtr hWnd)
        {
            RECT rect = new RECT();
            double pixel = 2;
            double upspeed = 1.01;
            bool isDown = true;
            int ScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            int ScreenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    Thread.Sleep(10);
                    User32.GetWindowRect(hWnd, out rect);
                    rect.top -= 8;
                    rect.bottom -= 8;
                    if (rect.bottom >= ScreenHeight)
                    {
                        if (isDown)
                        {
                            pixel /= 2;
                        }
                        isDown = false;
                    }
                    if (isDown)
                    {
                        User32.MoveWindow(hWnd, rect.left, rect.top + (int)pixel, rect.right - rect.left, rect.bottom - rect.top, true);
                        pixel *= upspeed;
                        upspeed *= 1.001;
                    }
                    else
                    {
                        User32.MoveWindow(hWnd, rect.left, rect.top + -(int)pixel, rect.right - rect.left, rect.bottom - rect.top, true);
                        pixel /= upspeed;
                        if (pixel < 1)
                        {
                            isDown = true;
                        }
                    }
                }
            })).Start();
        }
        public static void WindowFallNoStop(IntPtr hWnd)
        {
            RECT rect = new RECT();
            double pixel = 2;
            double upspeed = 1.01;
            bool isDown = true;
            int ScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            int ScreenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            int L = 3;
            new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    Thread.Sleep(10);
                    User32.GetWindowRect(hWnd, out rect);
                    if (rect.bottom - 10 >= ScreenHeight)
                    {
                        if (isDown)
                        {
                            pixel /= 1;
                        }
                        isDown = false;
                    }
                    if (isDown)
                    {
                        User32.MoveWindow(hWnd, rect.left + L, rect.top + (int)pixel, rect.right - rect.left, rect.bottom - rect.top, true);
                        if (rect.left <= -5)
                        {
                            L = r.Next(1, 5);
                        }
                        if (rect.right >= ScreenWidth + 5)
                        {
                            L = -r.Next(1, 5);
                        }
                        pixel *= upspeed;
                        upspeed *= 1.001;
                    }
                    else
                    {
                        User32.MoveWindow(hWnd, rect.left + L, rect.top + -(int)pixel, rect.right - rect.left, rect.bottom - rect.top, true);
                        if (rect.left <= -5)
                        {
                            L = r.Next(1, 5);
                        }
                        if (rect.right >= ScreenWidth + 5)
                        {
                            L = -r.Next(1, 5);
                        }
                        pixel /= upspeed;
                        if (pixel < 1.5)
                        {
                            isDown = true;
                            upspeed = 1.06;
                        }
                    }
                }
            })).Start();
        }
        public static void WindowStretch(IntPtr hWnd)
        {
            User32.GetWindowRect(hWnd, out RECT rect);
            IntPtr hdc = User32.GetWindowDC(hWnd);
            Console.WriteLine(Gdi32.StretchBlt(hdc, 10, 10, rect.right - 20, rect.bottom - 20, hdc, 0, 0, rect.right, rect.bottom, Gdi32.SRCCOPY));
            User32.ReleaseDC(hWnd, hdc);
        }
    }
}
