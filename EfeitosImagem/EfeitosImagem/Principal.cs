using AForge.Video;
using AForge.Video.DirectShow;
using EfeitosImagem.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EfeitosImagem
{
    public partial class Principal : Form
    {
        VideoCaptureDevice videoSource;
        ImageHandler ImageHandler;
        String selecteEffect;
        ImageHandler.MirrorType enuMirrorType;

        public Principal()
        {
            InitializeComponent();

            cboEffect.Text = "Normal";
            rdbMirrorNone.Checked = true;

            FilterInfoCollection videosources = new AForge.Video.DirectShow.FilterInfoCollection(AForge.Video.DirectShow.FilterCategory.VideoInputDevice);

            if (videosources != null)
            {
                try
                {
                    videoSource = new VideoCaptureDevice(videosources[0].MonikerString);
                    videoSource.NewFrame += videoSource_NewFrame;

                    videoSource.VideoResolution = videoSource.VideoCapabilities[videoSource.VideoCapabilities.Count() - 1];
                    videoSource.Start();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            ImageHandler = new ImageHandler((Bitmap)eventArgs.Frame.Clone(), enuMirrorType);

            switch (selecteEffect)
            {
                case "Cinza":
                    picImageOutput.Image = ImageHandler.ApplayGreyScale();
                    break;
                case "Desfoque Gaussiano":
                    picImageOutput.Image = ImageHandler.ApplayGaussianBlur();
                    break;
                case "Negativo":
                    picImageOutput.Image = ImageHandler.ApplayNegative();
                    break;
                case "Pixelizar":
                    picImageOutput.Image = ImageHandler.ApplayPixelize();
                    break;
                case "Preto e Branco":
                    picImageOutput.Image = ImageHandler.ApplayBlackAndWhite();
                    break;
                case "Sepia":
                    picImageOutput.Image = ImageHandler.ApplaySepia();
                    break;
                default:
                    if(rdbMirrorHorizontal.Checked)
                        picImageOutput.Image = ImageHandler.ApplayFlipHorizontal();
                    else if(rdbMirrorVertical.Checked)
                        picImageOutput.Image = ImageHandler.ApplayFlipVertical();
                    else
                        picImageOutput.Image = ImageHandler.Image;

                    break;
            }
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                videoSource.NewFrame -= videoSource_NewFrame;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }

        protected override void OnClosed(EventArgs e)
        {
            try
            {
                base.OnClosed(e);

                if (videoSource != null && videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboEffect_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selecteEffect = cboEffect.Items[cboEffect.SelectedIndex].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbMirrorNone_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMirrorHorizontal.Checked)
                enuMirrorType = ImageHandler.MirrorType.None;
        }

        private void rdbMirrorHorizontal_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMirrorHorizontal.Checked)
                enuMirrorType = ImageHandler.MirrorType.Horizontal;
        }

        private void rdbMirrorVertical_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMirrorVertical.Checked)
                enuMirrorType = ImageHandler.MirrorType.Vertical;
        }
    }
}
