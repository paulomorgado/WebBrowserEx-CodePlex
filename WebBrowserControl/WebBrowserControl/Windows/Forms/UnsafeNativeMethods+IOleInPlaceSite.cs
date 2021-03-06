using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Pajocomo.Windows.Forms
{
    public static partial class UnsafeNativeMethods
    {
        /// <summary>
        /// 
        /// </summary>
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00000119-0000-0000-C000-000000000046")]
        public interface IOleInPlaceSite //: IOleWindow
        {
            #region IOleWindow

            /// <summary>
            /// Gets a window handle.
            /// </summary>
            /// <returns>Pointer to where to return the window handle.</returns>
            IntPtr GetWindow();

            /// <summary>
            /// Controls enabling of context-sensitive help.
            /// </summary>
            /// <param name="fEnterMode">Indicator of whether the control is entering context-sensitive help mode (<see langword="true"/>) or leaving it (<see langword="false"/>).</param>
            void ContextSensitiveHelp(
                [In, MarshalAs(UnmanagedType.Bool)] bool fEnterMode);

            #endregion

            /// <summary>
            /// Determines whether or not the container can activate the object in place.
            /// </summary>
            void CanInPlaceActivate();

            /// <summary>
            /// Notifies the container that one of its objects is being activated in place.
            /// </summary>
            void OnInPlaceActivate();

            /// <summary>
            /// Notifies the container that the object is about to be activated in place and that the object is going to replace the container's main menu with an in-place composite menu.
            /// </summary>
            void OnUIActivate();

            /// <summary>
            /// Enables the in-place object to retrieve the window interfaces that form the window object hierarchy, and the position in the parent window where the object's in-place activation window should be placed.
            /// </summary>
            /// <param name="ppFrame">Address of IOleInPlaceFrame* pointer variable that receives the interface pointer to the frame. If an error occurs, the implementation must set *ppFrame to <see langword="null"/>.</param>
            /// <param name="ppDoc">Address of IOleInPlaceUIWindow* pointer variable that receives the interface pointer to the document window. If the document window is the same as the frame window, *ppDoc is set to <see langword="null"/>. In this case, the object can only use *ppFrame or border negotiation. If an error is returned, the implementation must set *ppDoc to <see langword="null"/>.</param>
            /// <param name="lprcPosRect">Pointer to the rectangle containing the position of the in-place object in the client coordinates of its parent window. If an error is returned, this parameter must be set to <see langword="null"/>.</param>
            /// <param name="lprcClipRect">Pointer to the outer rectangle containing the in-place object's position rectangle (PosRect). This rectangle is relative to the client area of the object's parent window. If an error is returned, this parameter must be set to <see langword="null"/>.</param>
            /// <param name="lpFrameInfo">Pointer to an OLEINPLACEFRAMEINFO structure the container is to fill in with appropriate data. If an error is returned, this parameter must be set to <see langword="null"/>.</param>
            void GetWindowContext(
                [MarshalAs(UnmanagedType.Interface)] out UnsafeNativeMethods.IOleInPlaceFrame ppFrame, 
                [MarshalAs(UnmanagedType.Interface)] out UnsafeNativeMethods.IOleInPlaceUIWindow ppDoc, 
                [Out] NativeMethods._RECT lprcPosRect, 
                [Out] NativeMethods._RECT lprcClipRect, 
                [In, Out] NativeMethods.tagOIFI lpFrameInfo);

            /// <summary>
            /// Tells the container to scroll the view of the object by a specified number of pixels.
            /// </summary>
            /// <param name="scrollExtant">Number of pixels by which to scroll in the X and Y directions.</param>
            /// <returns><see langword="false"/> if the method successfully executed the view scroll instruction.</returns>
            [return: MarshalAs(UnmanagedType.I4)]
            bool Scroll(NativeMethods.tagSIZE scrollExtant);

            /// <summary>
            /// Notifies the container on deactivation that it should reinstall its user interface and take focus, and whether or not the object has an undoable state.
            /// </summary>
            /// <param name="fUndoable"></param>
            void OnUIDeactivate(
                [In, MarshalAs(UnmanagedType.Bool)] bool fUndoable);

            /// <summary>
            /// Notifies the container that the object is no longer active in place.
            /// </summary>
            void OnInPlaceDeactivate();

            /// <summary>
            /// Tells the container that the object no longer has any undo state and that the container should not call <see cref="M:IOleInPlaceObject.ReActivateAndUndo"/>.
            /// </summary>
            void DiscardUndoState();

            /// <summary>
            /// Causes the container to end the in-place session, deactivate the object, and revert to its own saved undo state.
            /// </summary>
            void DeactivateAndUndo();

            /// <summary>
            /// Indicates the object's extents have changed.
            /// </summary>
            /// <param name="lprcPosRect">Pointer to the rectangle containing the position of the in-place object in the client coordinates of its parent window.</param>
            void OnPosRectChange(
                [In] NativeMethods._RECT lprcPosRect);
        }
    }
}
