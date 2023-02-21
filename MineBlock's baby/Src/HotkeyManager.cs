using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NLMMB.Src
{
    public sealed class HotkeyManager : IDisposable
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private class Window : NativeWindow, IDisposable
        {
            private readonly static int WM_HOTKEY = 0x0312;

            public Window()
            {
                CreateHandle(new CreateParams());
            }

            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);

                if (m.Msg == WM_HOTKEY)
                {
                    Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                    ModKeys modifier = (ModKeys)((int)m.LParam & 0xFFFF);

                    KeyPressed?.Invoke(this, new KeyPressedEventArgs(modifier, key));
                }
            }
 
            public event EventHandler<KeyPressedEventArgs> KeyPressed;

            #region IDisposable Members

            public void Dispose()
            {
                DestroyHandle();
            }
            #endregion
        }

        readonly private Window _window = new Window();
        private int _currentId;

        public HotkeyManager()
        {
            _window.KeyPressed += delegate (object HotkeySender, KeyPressedEventArgs args)
            {
                KeyPressed?.Invoke(this, args);
            };
        }

        public void RegisterHotKey(ModKeys modifier, Keys key)
        {
            try
            {
                _currentId++;

                if (!RegisterHotKey(_window.Handle, _currentId, (uint)modifier, (uint)key))
                    throw new InvalidOperationException();
            }
            catch (Exception)
            {
                
            }
        }
        public static event EventHandler<KeyPressedEventArgs> KeyPressed;

        #region IDisposable Members

        public void Dispose()
        {
            for (int i = _currentId; i > 0; i--)
            {
                UnregisterHotKey(_window.Handle, i);
            }

            _window.Dispose();
        }
        #endregion
    }

    public class KeyPressedEventArgs : EventArgs
    {
        private readonly ModKeys _modifier;
        private readonly Keys _key;

        internal KeyPressedEventArgs(ModKeys modifier, Keys key)
        {
            _modifier = modifier;
            _key = key;
        }

        public ModKeys Modifier
        {
            get { return _modifier; }
        }

        public Keys Key
        {
            get { return _key; }
        }
    }

    [Flags]
    public enum ModKeys : uint
    {
        None = 0,
        Alt = 1,
        Control = 2,
        Shift = 4,
        Win = 8
    }
}