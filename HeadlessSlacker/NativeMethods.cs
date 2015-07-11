using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HeadlessSlacker
{
    public static class NativeMethods
    {
        // todo: add wrapper class that doesn't require the first parameter and hide this 
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    }

    [ComImport, Guid("56fdf342-fd6d-11d0-958a-006097c9a090"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ITaskbarList
    {
        /// <summary>
        /// Initializes the taskbar list object. This method must be called before any other ITaskbarList methods can be called.
        /// </summary>
        int HrInit();

        /// <summary>
        /// Adds an item to the taskbar.
        /// </summary>
        /// <param name="hWnd">A handle to the window to be added to the taskbar.</param>
        int AddTab([In] IntPtr hWnd);

        /// <summary>
        /// Deletes an item from the taskbar.
        /// </summary>
        /// <param name="hWnd">A handle to the window to be deleted from the taskbar.</param>
        int DeleteTab([In] IntPtr hWnd);

        /// <summary>
        /// Activates an item on the taskbar. The window is not actually activated; the window's item on the taskbar is merely displayed as active.
        /// </summary>
        /// <param name="hWnd">A handle to the window on the taskbar to be displayed as active.</param>
        int ActivateTab([In] IntPtr hWnd);

        /// <summary>
        /// Marks a taskbar item as active but does not visually activate it.
        /// </summary>
        /// <param name="hWnd">A handle to the window to be marked as active.</param>
        int SetActiveAlt([In] IntPtr hWnd);
    }

    [ComImport]
    [Guid("56fdf344-fd6d-11d0-958a-006097c9a090")]
    public class CoTaskbarList { }
}
