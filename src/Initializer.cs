namespace Patcher
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using Properties;

    internal static class Initializer
    {
        private static string AssemblyDir { get; } = Path.Combine(Path.GetTempPath(), $"patcher-{Resources.AssemblyGuid}");

        private static string LocalPath { get; } = new Uri(Assembly.GetEntryAssembly()?.CodeBase ?? throw new NullReferenceException()).LocalPath;

        private static string LocalDir { get; } = Path.GetDirectoryName(LocalPath)?.TrimEnd(Path.DirectorySeparatorChar);

        internal static string TrackPath { get; } = Path.Combine(AssemblyDir, "music", Resources.TrackName);

        internal static void Initialize(byte[] resData)
        {
            try
            {
                if (!LocalDir.Equals(AssemblyDir, StringComparison.OrdinalIgnoreCase))
                {
                    var path = $"{AssemblyDir}.zip";
                    if (string.IsNullOrEmpty(path))
                        throw new NullReferenceException();
                    var dir = AssemblyDir;
                    if (string.IsNullOrEmpty(dir))
                        throw new NullReferenceException();
                    if (File.Exists(path))
                        File.Delete(path);
                    using (var ms = new MemoryStream(resData))
                    {
                        var data = ms.ToArray().Reverse().ToArray();
                        using var fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                        fs.Write(data, 0, data.Length);
                    }
                    Unzip(path, dir);
                    path = Path.Combine(AssemblyDir, Resources.AssemblyName);
                    if (File.Exists(path))
                        File.Delete(path);
                    File.Copy(LocalPath, path);
                }
            }
            catch (Exception ex)
            {
                Environment.ExitCode++;
                MessageBox.Show(ex.Message, Resources.MsgTitle_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            var core = Path.Combine(LocalDir, "x86", Resources.CoreLibraryName);
            if (!File.Exists(core))
            {
                try
                {
                    using var process = new Process
                    {
                        StartInfo =
                        {
                            FileName = Path.Combine(AssemblyDir, Resources.AssemblyName),
                            WorkingDirectory = AssemblyDir
                        }
                    };
                    process.Start();
                }
                catch (Exception ex)
                {
                    Environment.ExitCode++;
                    MessageBox.Show(ex.Message, Resources.MsgTitle_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Environment.Exit(Environment.ExitCode);
            }
            try
            {
                var path = Environment.GetEnvironmentVariable("ComSpec");
                if (string.IsNullOrEmpty(path))
                    throw new ArgumentNullException(nameof(path));
                var psi = new ProcessStartInfo
                {
                    Arguments = string.Format(Resources.DelayedRmDir, AssemblyDir),
                    CreateNoWindow = true,
                    FileName = path,
                    WindowStyle = ProcessWindowStyle.Hidden
                };
                AppDomain.CurrentDomain.ProcessExit += (sender, args) =>
                {
                    using var process = new Process
                    {
                        StartInfo = psi
                    };
                    process.Start();
                };
            }
            catch (Exception ex)
            {
                Environment.ExitCode++;
                MessageBox.Show(ex.Message, Resources.MsgTitle_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void Unzip(string srcPath, string destDir)
        {
            try
            {
                var src = srcPath;
                if (string.IsNullOrEmpty(src))
                    throw new ArgumentNullException(nameof(srcPath));
                if (!File.Exists(src))
                    throw new FileNotFoundException();
                var dest = destDir;
                if (string.IsNullOrEmpty(dest))
                    throw new ArgumentNullException(nameof(destDir));
                using (var archive = ZipFile.OpenRead(src))
                    foreach (var ent in archive.Entries)
                        try
                        {
                            if (!Path.HasExtension(ent.FullName))
                                continue;
                            var entPath = ent.FullName;
                            entPath = Path.Combine(AssemblyDir, entPath);
                            if (File.Exists(entPath))
                                File.Delete(entPath);
                            var entDir = Path.GetDirectoryName(entPath);
                            if (string.IsNullOrEmpty(entDir))
                                continue;
                            if (!Directory.Exists(entDir))
                            {
                                if (File.Exists(entDir))
                                    File.Delete(entDir);
                                Directory.CreateDirectory(entDir);
                            }
                            ent.ExtractToFile(entPath, true);
                        }
                        catch (Exception ex)
                        {
                            Environment.ExitCode++;
                            MessageBox.Show(ex.Message, Resources.MsgTitle_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                File.Delete(src);
            }
            catch (Exception ex)
            {
                Environment.ExitCode++;
                MessageBox.Show(ex.Message, Resources.MsgTitle_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
