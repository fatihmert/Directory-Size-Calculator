using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Directory_Size_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void getDrivers()
        {
            string[] drives = Environment.GetLogicalDrives();

            foreach (string drive in drives)
            {
                DriveInfo di = new DriveInfo(drive);
                int driveImage;

                switch (di.DriveType)
                {
                    case DriveType.CDRom:
                        driveImage = 3;
                        break;
                    case DriveType.Network:
                        driveImage = 6;
                        break;
                    case DriveType.NoRootDirectory:
                        driveImage = 8;
                        break;
                    case DriveType.Unknown:
                        driveImage = 8;
                        break;
                    default:
                        driveImage = 2;
                        break;
                }

                TreeNode node = new TreeNode(drive.Substring(0, 1), driveImage, driveImage);
                node.Tag = drive;

                if (di.IsReady == true)
                    node.Nodes.Add("...");

                foldersView.Nodes.Add(node);
            }
        }

        private void createDirTree_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.getDrivers();
        }

        private long calcFolderSize(string p)
        {
            string[] files = Directory.GetFiles(p);
            string[] subdirectories = Directory.GetDirectories(p);

            long size = files.Sum(x => new FileInfo(x).Length);
            foreach (string s in subdirectories)
                size += calcFolderSize(s);

            return size;
        }

        public enum SizeUnits
        {
            Byte, KB, MB, GB, TB, PB, EB, ZB, YB
        }

        public static string ToSize(Int64 value, SizeUnits unit)
        {
            return String.Format(
                "<{0} {1}>", 
                (value / (double)Math.Pow(1024, (Int64)unit)).ToString("0.00"),
                Enum.GetName(typeof(SizeUnits), unit)
            );
        }

        private void foldersView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {
                if (e.Node.Nodes[0].Text == "..." && e.Node.Nodes[0].Tag == null)
                {
                    e.Node.Nodes.Clear();

                    string[] dirs = Directory.GetDirectories(e.Node.Tag.ToString());

                    foreach (string dir in dirs)
                    {
                        DirectoryInfo di = new DirectoryInfo(dir);

                        var calcSize = ToSize(calcFolderSize(dir), SizeUnits.GB);

                        TreeNode node = new TreeNode(String.Format("{0} {1}", di.Name, calcSize), 0, 1);

                        try
                        {
                            node.Tag = dir;

                            if (di.GetDirectories().Count() > 0)
                                node.Nodes.Add(null, "...", 0, 0);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "DirectoryLister",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            e.Node.Nodes.Add(node);
                        }
                    }
                }
            }
        }

        private void foldersView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string fullPath = e.Node.Tag.ToString();
            currentPath.Text = fullPath;

            filesView.Items.Clear();
            filesView.Refresh();

            string[] filePaths = Directory.GetFiles(String.Format(@"{0}", fullPath));
            foreach(string filePath in filePaths)
            {
                var calcSize = ToSize(new FileInfo(filePath).Length, SizeUnits.GB);
                filesView.Items.Add(
                    String.Format("{0} {1}", Path.GetFileName(filePath), calcSize)
                );
            }
        }
    }
}
