﻿namespace Patcher
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using Properties;
    using SilDev;
    using SilDev.Forms;
    using SilDev.Investment;
    using SilDev.Media;

    public partial class MainForm : Form
    {
        private int _count;
        private Dictionary<string, Image> _graphics;

        public MainForm()
        {
            InitializeComponent();
            Icon = Resources.VMware;
            SlideText.Left = Width + 10;
        }

        private static string LibDir { get; } = PathEx.Combine(Reg.ReadString(Environment.Is64BitOperatingSystem ? Resources.VMwareRegistryPath64 : Resources.VMwareRegistryPath, Resources.VMwareRegistryKey));

        private static string LibPath { get; set; } = Path.Combine(LibDir, Resources.VMwareCoreLibraryName);

        private static Random RandomDefault { get; } = new RandomInvestor().GetGenerator();

        private void MainForm_Load(object sender, EventArgs e)
        {
            ControlEx.EnableDragMove(HeaderLabel);
            ControlEx.EnableDragMove(DemoBox);
            DemoBox.SetControlStyle((ControlStyles)(0x1 | 0x2 | 0x10 | 0x800 | 0x2000 | 0x20000));
            IrrKlangPlayer.Play(Initializer.TrackPath, true, 25);
            WinApi.NativeHelper.AnimateWindow(Handle, 400, (WinApi.AnimateWindowFlags)(RandomDefault.Next(150) < 50 ? 0x10 : 0x40000 | (RandomDefault.Next(100) < 50 ? 0x8 : 0x4)));
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Opacity <= 0d)
                return;
            e.Cancel = true;
            var timer = new Timer(components)
            {
                Interval = 1,
                Enabled = true
            };
            timer.Tick += (o, args) =>
            {
                if (Opacity > 0d)
                {
                    Opacity -= .025d;
                    return;
                }
                timer.Dispose();
                Application.Exit();
            };
        }

        private void MinBtn_Click(object sender, EventArgs e) =>
            WindowState = FormWindowState.Minimized;

        private void CloseBtn_Click(object sender, EventArgs e) =>
            Application.Exit();

        private void DemoScreen_Tick(object sender, EventArgs e)
        {
            try
            {
                if (_graphics == default(Dictionary<string, Image>))
                    _graphics = Resources.Graphics.DeserializeObject<Dictionary<string, Image>>();
                DemoBox.Image = _graphics[$"{_count}"];
                _count = _count < _graphics.Count - 1 ? _count + 1 : 0;
            }
            catch (Exception ex) when (ex.IsCaught())
            {
                Environment.ExitCode++;
                Environment.Exit(Environment.ExitCode);
            }
        }

        private void WriteCheck()
        {
            if (Elevation.IsAdministrator || Elevation.WritableLocation(LibDir))
                return;
            var result = MessageBoxEx.Show(this, Resources.Msg_WarnWritePermission, Resources.MsgTitle_Warn, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                Elevation.RestartAsAdministrator();
        }

        private bool SetPath()
        {
            if (File.Exists(LibPath))
                return true;
            MessageBoxEx.Show(this, Resources.Msg_InfoSelection, Resources.MsgTitle_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
            using var dialog = new FolderBrowserDialog
            {
                ShowNewFolderButton = false
            };
            dialog.ShowDialog(new Form
            {
                ShowIcon = false,
                TopMost = true
            });
            if (string.IsNullOrWhiteSpace(dialog.SelectedPath))
                return false;
            if (!File.Exists(Path.Combine(dialog.SelectedPath, Resources.VMwareCoreLibraryName)))
            {
                MessageBoxEx.Show(this, Resources.Msg_WarnFileNotFound, Resources.MsgTitle_Warn, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            LibPath = dialog.SelectedPath;
            return File.Exists(LibPath);
        }

        private void PatchBtn_Click(object sender, EventArgs e)
        {
            if (!SetPath())
            {
                MessageBoxEx.Show(this, Resources.Msg_InfoCanceled, Resources.MsgTitle_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            WriteCheck();
            var oldValue = new byte[] { 0x40, 0x26, 0x21, 0x2a, 0x40, 0x2a, 0x40 };
            var newValue = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            var completed = FileEx.BinaryReplace(LibPath, oldValue, newValue);
            switch (completed)
            {
                case false:
                    MessageBoxEx.Show(this, Resources.Msg_WarnFailed, Resources.MsgTitle_Warn, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                default:
                    MessageBoxEx.Show(this, Resources.Msg_InfoCompleted, Resources.MsgTitle_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private void RestoreBtn_Click(object sender, EventArgs e)
        {
            if (!SetPath())
            {
                MessageBoxEx.Show(this, Resources.Msg_InfoCanceled, Resources.MsgTitle_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            WriteCheck();
            if (!File.Exists(LibPath))
                return;
            try
            {
                var backupPath = $"{LibPath}.backup";
                for (var i = 0; i < short.MaxValue; i++)
                {
                    var path = backupPath + i;
                    if (!File.Exists(path))
                        break;
                    if (File.Exists(LibPath))
                        File.Delete(LibPath);
                    File.Move(path, LibPath);
                }
                MessageBoxEx.Show(this, Resources.Msg_InfoCompleted, Resources.MsgTitle_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) when (ex.IsCaught())
            {
                MessageBoxEx.Show(this, Resources.Msg_WarnFailed, Resources.MsgTitle_Warn, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SlideDemo_Tick(object sender, EventArgs e) =>
            SlideText.Left = (int)(SlideText.Left <= SlideText.Width * -1 ? SlideText.Width / 2d + Width / (Math.PI / 1.5d) : SlideText.Left -= 1 * 1);

        private void SlideDemoGlow_Tick(object sender, EventArgs e)
        {
            if (SlideText.ForeColor == Color.DarkGray)
            {
                SlideText.ForeColor = Color.Gainsboro;
                SlideDemoGlow.Interval = RandomDefault.Next(20, 80);
            }
            else
            {
                SlideText.ForeColor = Color.DarkGray;
                SlideDemoGlow.Interval = 100;
            }
        }
    }
}
