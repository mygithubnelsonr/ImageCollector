using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageCollectorSample
{
    public partial class Form1 : Form
    {
        private string _imagePath = "_Images";
        private List<string> avatarNames;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> pathList = new List<string>();
            pathList.Add(Path.Combine(@"\\win2k16dc01\FS012\Country", _imagePath));
            pathList.Add(@"\\win2k16dc01\FS012\Country\Johnny\CD\Alabama\Southern Star");
            pathList.Add(Path.Combine(@"\\win2k16dc01\FS012\Country\Johnny\CD\Alabama\Southern Star", _imagePath));

            avatarNames = new List<string>();
            var collector = new ImageCollector(pathList, textBoxArtist.Text);

            avatarNames = collector.GetImages();

            foreach(var file in avatarNames)
            {
                Debug.Print(file);
            }

            timerImageFlip.Enabled = true;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            timerImageFlip.Enabled = false;
        }

        private void timerImageFlip_Tick(object sender, EventArgs e)
        {
            if( Tag == null || (int)Tag >= avatarNames.Count) Tag = 0;

            int counter = (int)Tag;

            pictureBoxAvatar.ImageLocation = avatarNames[counter];
            pictureBoxAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            Tag = ++counter;
        }

    }
}
