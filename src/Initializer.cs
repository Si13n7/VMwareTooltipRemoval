namespace Patcher
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Reflection;
    using Properties;

    internal static class Initializer
    {
        private static readonly string AssemblyDir = Path.Combine(Path.GetTempPath(), $"patcher-{Resources.AssemblyGuid}");
        private static string LocalPath => new Uri(Assembly.GetEntryAssembly().CodeBase).LocalPath;
        private static string LocalDir => Path.GetDirectoryName(LocalPath)?.TrimEnd(Path.DirectorySeparatorChar);
        internal static string TrackPath => Path.Combine(AssemblyDir, "music", Resources.TrackName);

        internal static void Initialize(byte[] resData)
        {
            try
            {
                if (!LocalPath.Equals(AssemblyDir))
                {
                    var path = $"{AssemblyDir}.zip";
                    if (string.IsNullOrEmpty(path))
                        throw new ArgumentNullException(nameof(path));
                    var dir = AssemblyDir;
                    if (string.IsNullOrEmpty(dir))
                        throw new ArgumentNullException(nameof(dir));
                    if (File.Exists(path))
                        File.Delete(path);
                    using (var ms = new MemoryStream(resData))
                    {
                        var data = ms.ToArray();
                        data = data.Reverse().ToArray();
                        using (var fs = new FileStream(path, FileMode.CreateNew, FileAccess.Write))
                            fs.Write(data, 0, data.Length);
                    }
                    Unzip(path, dir);
                    File.Copy(LocalPath, Path.Combine(AssemblyDir, Resources.AssemblyName));
                }
            }
#if DEBUG
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
            }
#else
            catch
            {
                // ignored
            }
#endif
            var core = Path.Combine(LocalDir, "x86", Resources.CoreLibraryName);
            if (!File.Exists(core))
            {
                try
                {
                    using (var p = new Process())
                    {
                        p.StartInfo.FileName = Path.Combine(AssemblyDir, Resources.AssemblyName);
                        p.StartInfo.WorkingDirectory = AssemblyDir;
                        p.Start();
                    }
                }
#if DEBUG
                catch (Exception ex)
                {
                    Debug.Write(ex.ToString());
                }
#else
                catch
                {
                    // ignored
                }
#endif
                Environment.ExitCode = 0;
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
                AppDomain.CurrentDomain.ProcessExit += (s, e) =>
                {
                    using (var p = new Process { StartInfo = psi })
                        p.Start();
                };
            }
#if DEBUG
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
            }
#else
            catch
            {
                // ignored
            }
#endif
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
#if DEBUG
                        catch (Exception ex)
                        {
                            Debug.Write(ex.ToString());
                        }
#else
                        catch
                        {
                            // ignored
                        }
#endif
                File.Delete(src);
            }
#if DEBUG
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
            }
#else
            catch
            {
                // ignored
            }
#endif
        }
    }
}
