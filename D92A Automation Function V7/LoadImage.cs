using DirectShowLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D92A_Automation_Function_V7
{
    public partial class LoadImage : Form
    {
        private Actions actions;
        Rectangle Rect;
        private System.Drawing.Point LocationXY;
        private System.Drawing.Point LocationX1Y1;
        private bool IsMouseDown = false;
        private bool IsCapture;
        private string _path = @"./system";
        private OpenCvSharp.VideoCapture capture;
        private int indexDriver = -1;
        public LoadImage(Actions action,int indexDriver)
        {
            InitializeComponent();
            this.actions = action;
            this.indexDriver = indexDriver;
        }


        private void LoadImage_Load(object sender, EventArgs e)
        {
            btnConnect();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            using (Bitmap bitmap = new Bitmap(pictureBoxCamera.Image))
            {
                using (Bitmap bmp = new Bitmap(Rect.Width, Rect.Height))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.DrawImage(bitmap, 0, 0, Rect, GraphicsUnit.Pixel);
                    }
                    // Set path
                    string path = @"./system/temp/";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string filename = $"{path}{Guid.NewGuid()}.jpg";                    
                    // Save image
                    bmp.Save(filename, ImageFormat.Jpeg);             
                    this.actions.SetImage(filename);
                }
            }
            this.Close();
        }

        private void pictureBoxCamera_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;
            LocationXY = e.Location;
        }

        private void pictureBoxCamera_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown)
            {
                LocationX1Y1 = e.Location;
                Refresh();
            }
        }

        private void pictureBoxCamera_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsMouseDown)
            {
                LocationX1Y1 = e.Location;
                Refresh();
                IsMouseDown = false;
            }

        }

        private void pictureBoxCamera_Paint(object sender, PaintEventArgs e)
        {
            if (Rect != null && IsCapture)
            {
                e.Graphics.DrawRectangle(Pens.Red, GetRect());
            }
        }

        private Rectangle GetRect()
        {
            Rect = new Rectangle();
            Rect.X = Math.Min(LocationXY.X, LocationX1Y1.X);
            Rect.Y = Math.Min(LocationXY.Y, LocationX1Y1.Y);
            Rect.Width = Math.Abs(LocationXY.X - LocationX1Y1.X);
            Rect.Height = Math.Abs(LocationXY.Y - LocationX1Y1.Y);
            return Rect;
        }

        private void btnConnect()
        {
            try
            {
                if (capture != null)
                {
                    timerVideo.Stop();
                    capture.Dispose();
                }

                capture = new OpenCvSharp.VideoCapture(indexDriver);
                capture.FrameWidth = 1280;
                capture.FrameHeight = 720;
                capture.Fps = 30;
                capture.Open(indexDriver);
                if (capture.IsOpened())
                {
                    timerVideo.Start();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void timerVideo_Tick(object sender, EventArgs e)
        {
            try
            {
                if (capture != null)
                {
                    if (capture.IsOpened())
                    {
                        using (var frame = capture.RetrieveMat())
                        {
                            if (!frame.Empty())
                            {
                                pictureBoxCamera.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame);
                            }
                        }
                        IsCapture = true;
                    }
                    else
                    {
                        timerVideo.Stop();
                        IsCapture = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void LoadImage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (capture != null)
            {
                capture.Dispose();
                timerVideo.Stop();
            }
        }
    }
}
