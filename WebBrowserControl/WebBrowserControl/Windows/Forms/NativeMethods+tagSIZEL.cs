using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Pajocomo.Windows.Forms
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// Defines the width and height of a rectangle.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public sealed class tagSIZEL
        {
            /// <summary>
            /// Specifies the rectangle's width. The units depend on which function uses this structure.
            /// </summary>
            public int cx;

            /// <summary>
            /// Specifies the rectangle's height. The units depend on which function uses this structure.
            /// </summary>
            public int cy;

            /// <summary>
            /// Initializes a new instance of the <see cref="tagSIZEL"/> class.
            /// </summary>
            public tagSIZEL()
            {
            }
        }
    }
}
