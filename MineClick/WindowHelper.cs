using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace MineClick
{
    public class Window
    {
        [DllImport("user32")]
        private static extern Int32 SendMessage(int hWnd, int Msg, int wParam, [MarshalAs(UnmanagedType.LPStr)] string lParam);

        [DllImport("user32")]
        private static extern Int32 SendMessage(int hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow(int hWnd, int nCmdShow);

        public const int WM_COMMAND = 0x111;
        public const int WM_LBUTTONDOWN = 0x201;
        public const int WM_LBUTTONUP = 0x202;
        public const int WM_LBUTTONDBLCLK = 0x203;
        public const int WM_RBUTTONDOWN = 0x204;
        public const int WM_RBUTTONUP = 0x205;
        public const int WM_RBUTTONDBLCLK = 0x206;
        public const int WM_KEYDOWN = 0x100;
        public const int WM_KEYUP = 0x101;

        private const int SW_MAXIMIZE = 3;
        private const int SW_MINIMIZE = 6;

        public string Title;
        public string Class;
        public int Handle;

        public void SendMessage(int Msg, int wParam, int lParam)
        {
            SendMessage(Handle, Msg, wParam, lParam);
        }

        public void Minimize()
        {
            ShowWindow(Handle, SW_MINIMIZE);
        }

        public void Maximize()
        {
            ShowWindow(Handle, SW_MAXIMIZE);
        }
    }

    public class WindowHelper
    {
        [DllImport("user32")]
        private static extern int GetWindow(int hwnd, int wCmd);

        [DllImport("user32")]
        private static extern int GetDesktopWindow();

        [DllImport("user32", EntryPoint = "GetWindowLongA")]
        private static extern int GetWindowLong(int hwnd, int nIndex);

        [DllImport("user32")]
        private static extern int GetParent(int hwnd);

        [DllImport("user32", EntryPoint = "GetClassNameA")]
        private static extern int GetClassName(
          int hWnd, [Out] StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32", EntryPoint = "GetWindowTextA")]
        private static extern int GetWindowText(
          int hWnd, [Out] StringBuilder lpString, int nMaxCount);

        private const int GWL_ID = (-12);
        private const int GW_HWNDNEXT = 2;
        private const int GW_CHILD = 5;

        public static Window[] Find(int hwndStart, string findText, string findClassName)
        {
            ArrayList windows = DoSearch(hwndStart, findText, findClassName);
            return (Window[])windows.ToArray(typeof(Window));
        }

        private static ArrayList DoSearch(int hwndStart, string findText, string findClassName)
        {

            ArrayList list = new ArrayList();

            if (hwndStart == 0)
                hwndStart = GetDesktopWindow();

            int hwnd = GetWindow(hwndStart, GW_CHILD);

            while (hwnd != 0)
            {
                list.AddRange(DoSearch(hwnd, findText, findClassName));

                StringBuilder text = new StringBuilder(255);
                int rtn = GetWindowText(hwnd, text, 255);
                string windowText = text.ToString();
                windowText = windowText.Substring(0, rtn);

                StringBuilder cls = new StringBuilder(255);
                rtn = GetClassName(hwnd, cls, 255);
                string className = cls.ToString();
                className = className.Substring(0, rtn);

                if (GetParent(hwnd) != 0)
                    rtn = GetWindowLong(hwnd, GWL_ID);

                if (windowText.Length > 0 && windowText.StartsWith(findText) &&
                  (className.Length == 0 || className.StartsWith(findClassName)))
                {
                    Window currentWindow = new Window();

                    currentWindow.Title = windowText;
                    currentWindow.Class = className;
                    currentWindow.Handle = hwnd;

                    list.Add(currentWindow);
                }

                hwnd = GetWindow(hwnd, GW_HWNDNEXT);

            }
            return list;
        }
    }
}