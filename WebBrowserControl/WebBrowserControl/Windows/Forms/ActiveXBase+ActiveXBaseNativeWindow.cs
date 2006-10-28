using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Pajocomo.Windows.Forms
{
    public abstract partial class ActiveXBase<TActiveX>
    {
        private class ActiveXBaseNativeWindow : NativeWindow
        {
            private ActiveXBase<TActiveX> activeXBase;

            private ActiveXBaseNativeWindow()
            {
            }

            public ActiveXBaseNativeWindow(ActiveXBase<TActiveX> activeX)
            {
                this.activeXBase = activeX;
            }

            private unsafe void WmWindowPosChanging(ref Message m)
            {
                NativeMethods.WINDOWPOS* windowposPtr1 = (NativeMethods.WINDOWPOS*)m.LParam;
                windowposPtr1->x = 0;
                windowposPtr1->y = 0;
                Size newSize = this.activeXBase.activeXBaseChangingSize;
                if (newSize.Width == -1)
                {
                    windowposPtr1->cx = this.activeXBase.Width;
                    windowposPtr1->cy = this.activeXBase.Height;
                }
                else
                {
                    windowposPtr1->cx = newSize.Width;
                    windowposPtr1->cy = newSize.Height;
                }
                m.Result = IntPtr.Zero;
            }

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == 70)
                {
                    this.WmWindowPosChanging(ref m);
                }
                else
                {
                    base.WndProc(ref m);
                }
            }
        }
    }
}
