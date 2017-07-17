namespace Patcher
{
    using System;
    using System.Threading;
    using System.Windows.Forms;
    using Properties;

    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            using (new Mutex(true, Resources.AssemblyGuid, out bool newInstance))
            {
                if (!newInstance)
                    return;
                Initializer.Initialize(Resources.Data);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
}
