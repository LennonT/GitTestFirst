using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransformResCheck.Model;

namespace PackageConfigCheck
{
    public partial class PackageCheck : Form
    {
        public PackageCheck()
        {
            InitializeComponent();
        }

        private void ChooseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = "E:\\";
            fileDialog.RestoreDirectory = true;


            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.File.Copy(fileDialog.FileName, PathAndName.Path+"test.zip");
            }

        }
    }
}
