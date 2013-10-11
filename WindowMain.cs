using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Tao.OpenGl;

namespace GraalLevelViewer
{
    public partial class WindowMain : Form
    {
        public LevelViewer levelViewer;
        public bool done = false;
        private string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public string chosenTileset;
        public string chosenFile;

        public WindowMain()
        {
            InitializeComponent();

            levelViewer = new LevelViewer();
            levelViewer.Name = "LevelViewer";
            levelViewer.Parent = LevelViewerPanel;
            levelViewer.parentWindow = this;
            levelViewer.SetBounds(0, 0, 64 * 16, 64 * 16);

            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(WindowMain_DragEnter);
            this.DragDrop += new DragEventHandler(WindowMain_DragDrop);
        }

        public void Setup()
        {
            //Create sub-folders if they don't exist
            string folderPath_Tilesets = currentDirectory + "tilesets";
            string folderPath_Images = currentDirectory + "images";

            if (!Directory.Exists(folderPath_Tilesets))
            {
                Console.WriteLine("Tileset folder does not exist. Will create new folder {0}", folderPath_Tilesets);
                Directory.CreateDirectory(folderPath_Tilesets);
            }

            if (!Directory.Exists(folderPath_Images))
            {
                Console.WriteLine("Images folder does not exist. Will create new folder {0}", folderPath_Images);
                Directory.CreateDirectory(folderPath_Images);
            }

            //Check if any tilesets are in the tileset folder
            string[] tilesets = Directory.GetFiles(folderPath_Tilesets);

            if (tilesets.Length <= 0)
            {
                Console.WriteLine("No tilesets are saved under {0}", folderPath_Tilesets);
                MessageBox.Show("Couldn't find any tileset images saved in the tileset sub-folder!");
            }
            else
            {
                for (int i = 0; i < tilesets.Length; i++)
                {
                    string tilesetName = Path.GetFileName(tilesets[i]);
                    LevelViewerTilesetList.Items.Add(tilesetName);
                }

                LevelViewerTilesetList.SelectedIndex = 0;
            }
        }

        public void Generate()
        {
            //If no file has been chosen, prompt the user to choose one
            if (chosenFile == "" || chosenFile == null)
            {
                Console.WriteLine("Couldn't generate: No file has been chosen. Will open file browser dialog...");
                LevelViewerBrowseButton_Click(this, System.EventArgs.Empty);
            }

            chosenTileset = LevelViewerTilesetList.SelectedItem.ToString();

            //Remove all controls from the panel
            int remCount = 0;
            foreach (Control control in levelViewer.Controls.OfType<Control>())
            {
                levelViewer.Controls.Remove(control);
                remCount++;
            }

            Bitmap levelBitmap = new Bitmap(64 * 16, 64 * 16);
            Graphics g = levelViewer.CreateGraphics();

            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);
            Gl.glEnableClientState(Gl.GL_TEXTURE_COORD_ARRAY);

            using (StreamReader sr = new StreamReader(chosenFile))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    if (line.StartsWith("BOARD"))
                    {
                        string lineTilesBasecode = line.Substring(line.Length, 128);
                        string[] Base64TileChunks = StringToChunks(lineTilesBasecode, 2);

                        for (int i = 0; i < Base64TileChunks.Length; i++)
                        {
                            int tileID = Base64ToTile(Base64TileChunks[i]);
                            int[] tilePosition = TileToImage(tileID);

                            Image tilesetImage = Image.FromFile(chosenTileset);
                            Rectangle tile = new Rectangle(16 * (i % 16), 16 * (i / 16), 16, 16);
                            Rectangle container = new Rectangle(tilePosition[0], tilePosition[1], 16, 16);
                            g.DrawImage(tilesetImage, container, tile, GraphicsUnit.Pixel);
                            
                        }
                    }
                }
            }
        }

        private string[] StringToChunks(string str, int chunksize)
        {
            List<string> list = new List<string>();

            for (int i = 0; i < str.Length; i += chunksize)
            {
                if (i + chunksize > str.Length) chunksize = str.Length - i;
                list.Add(str.Substring(i, chunksize));
            }

            string[] result = list.ToArray();
            return result;
        }

        private int Base64ToTile(string t)
        {
            string base64 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
            return base64.IndexOf(t.Substring(0, 1)) * 64 + base64.IndexOf(t.Substring(1, 1));
        }

        private int[] TileToImage(int t)
        {
            decimal dec1 = t % 16;
            decimal dec2 = t / 512;
            decimal dec3 = t / 16;

            int px = ((int)Math.Ceiling(dec1) * 16) + ((int)Math.Ceiling(dec2) * 256);
            int py = ((int)Math.Ceiling(dec3) * 16) % 512;

            int[] result = {px, py};
            return result;
        }

        private void closing(object sender, FormClosingEventArgs e)
        {
            done = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Generate();
        }

        private void WindowMain_DragEnter(object sender, DragEventArgs e)
        {
            Console.WriteLine("Enter");
        }

        private void WindowMain_DragDrop(object sender, DragEventArgs e)
        {
            Console.WriteLine("Drop");
        }

        private void LevelViewerBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Graal Level | *.nw";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine("Chose level file ({0}) will now attempt to generate", openFileDialog.FileName);
                chosenFile = openFileDialog.FileName;
                Generate();
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
