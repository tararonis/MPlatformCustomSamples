using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using MPLATFORMLib;

namespace MP_CororConvertinWithMatrixTransformation
{
    public partial class Form1 : Form
    {
        MPlaylistClass m_objMPLaylist;
        string filePath = String.Empty;
        MFFactoryClass m_objMFFactory;
        string[] predifinedMatrixes = { "Custom", "BT2020_BT709", "BT709_BT2020", "RGB_YUV_601", "RGB_YUV_709", "RGB_YUV_2020", "YUV_RGB_601", "YUV_RGB_709", "YUV_RGB_2020", "Full_To_16_235", "Full_From_16_235" };
        string[] colors = { "Red", "Green", "Blue" };
        string matrix = String.Empty;
        bool gpu_p = false;
        private static System.Timers.Timer aTimer;

        string updatedColor = String.Empty;
        bool canUpdate = false;

        public Form1()
        {
            InitializeComponent();
            aTimer = new System.Timers.Timer(100);
            aTimer.Elapsed += ATimer_Elapsed;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var m in predifinedMatrixes)
            {
                PredifinedMatrix_txb.Items.Add(m);
            }
            PredifinedMatrix_txb.SelectedIndex = 0;

            foreach (var c in colors)
            {
                ColorLevel_cmb.Items.Add(c);
            }
            ColorLevel_cmb.SelectedIndex = 0;
            m_objMPLaylist = new MPlaylistClass();

            InitMatrix();
        }

        private void GpuPipilineOn_btn_Click(object sender, EventArgs e)
        {
            if (!gpu_p)
            {
                m_objMFFactory = new MFFactoryClass();
                m_objMFFactory.PropsSet("gpu_pipeline", "true");

                gpu_p = true;
                GpuPipilineOn_btn.Text = "GPU PIPELINE = ON";
                GpuPipilineOn_btn.BackColor = Color.Green;

                Reset_btn.Enabled = true;
                PredifinedMatrix_txb.Enabled = true;
                ColorLevel_cmb.Enabled = true;
                R_trb.Enabled = true;
                G_trb.Enabled = true;
                B_trb.Enabled = true;
                Level_trb.Enabled = true;

                m_objMPLaylist.FilePosGet(out double position);
                m_objMPLaylist.FilePlayStop(0);
                Marshal.ReleaseComObject(m_objMPLaylist);

                m_objMPLaylist = new MPlaylistClass();

                m_objMPLaylist.PreviewWindowSet("", panelPr.Handle.ToInt32());
                m_objMPLaylist.PreviewEnable("", 1, 1);

                if (filePath.Length > 1)
                {
                    index = -1;

                    m_objMPLaylist.PlaylistAdd(null, filePath, "", ref index, out item);
                    m_objMPLaylist.FilePosSet(position, 0);
                    m_objMPLaylist.FilePlayStart();
                }
            }
        }

        int index = -1;
        MItem item;
        private void OpenFile_btn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileNames.Length != 0)
            {
                filePath = openFileDialog1.FileNames[0].ToString();
                m_objMPLaylist.PlaylistAdd(null, filePath, "", ref index, out item);
            }
            m_objMPLaylist.PreviewWindowSet("", panelPr.Handle.ToInt32());
            m_objMPLaylist.PreviewEnable("", 1, 1);
            m_objMPLaylist.FilePlayStart();
        }

        private void PredifinedMatrix_txb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selected = (string)comboBox.SelectedItem;

            SetMatrix(selected);
        }

        private void SetColorConvertion_btn_Click(object sender, EventArgs e)
        {
            SetMatrix(matrix);
        }

        double[] redColorValues = { 1, 0, 0 };
        double[] greenColorValues = { 0, 1, 0 };
        double[] blueColorValues = { 0, 0, 1 };
        double[] colorLevelValues = { 0, 0, 0 };

        void InitMatrix()
        {
            matrix = String.Empty;
            foreach (var v in redColorValues)
                matrix += v.ToString(CultureInfo.InvariantCulture) + ",";
            matrix += colorLevelValues[0].ToString(CultureInfo.InvariantCulture) + ",";
            foreach (var v in greenColorValues)
                matrix += v.ToString(CultureInfo.InvariantCulture) + ",";
            matrix += colorLevelValues[1].ToString(CultureInfo.InvariantCulture) + ",";
            foreach (var v in blueColorValues)
                matrix += v.ToString(CultureInfo.InvariantCulture) + ",";
            matrix += colorLevelValues[2].ToString(CultureInfo.InvariantCulture);
            Debug.WriteLine(matrix);
            SetMatrix(matrix);

        }
        void UpdateValue(double value, int trackBar = 4)
        {
            if (updatedColor == "Red")
            {
                if (trackBar != 4)
                    redColorValues[trackBar] = value;
                if (trackBar == 4)
                    colorLevelValues[0] = value;
            }
            if (updatedColor == "Green")
            {
                if (trackBar != 4)
                    greenColorValues[trackBar] = value;
                if (trackBar == 4)
                    colorLevelValues[1] = value;
            }
            if (updatedColor == "Blue")
            {
                if (trackBar != 4)
                    blueColorValues[trackBar] = value;
                if (trackBar == 4)
                    colorLevelValues[2] = value;
            }

            InitMatrix();
        }

        void SetMatrix(string value)
        {
            if (canUpdate)
            {
                if (m_objMPLaylist != null)
                    m_objMPLaylist.PropsSet("object::gpu.rgb_transform_matrix", value);
                Debug.WriteLine("We are setting matix with value: " + value + "\n");
                CurrentMatrix_txb.Text = value;
                canUpdate = true;
            }

        }

        private void ATimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            canUpdate = true;
        }
        private void R_trb_Scroll(object sender, EventArgs e)
        {
            TrackBar trackBar = (TrackBar)sender;
            double selected = (double)trackBar.Value / 100;
            RedChannel_txb.Text = selected.ToString(CultureInfo.InvariantCulture);
            UpdateValue(selected, 0);
        }

        private void G_trb_Scroll(object sender, EventArgs e)
        {
            TrackBar trackBar = (TrackBar)sender;
            double selected = (double)trackBar.Value / 100;
            GreenChannel_txb.Text = selected.ToString(CultureInfo.InvariantCulture);
            UpdateValue(selected, 1);
        }

        private void B_trb_Scroll(object sender, EventArgs e)
        {
            TrackBar trackBar = (TrackBar)sender;
            double selected = (double)trackBar.Value / 100;
            BlueChannel_txb.Text = selected.ToString(CultureInfo.InvariantCulture);
            UpdateValue(selected, 2);
        }

        private void Level_trb_Scroll(object sender, EventArgs e)
        {
            TrackBar trackBar = (TrackBar)sender;
            double selected = (double)trackBar.Value / 100;
            ConstantChannel_txb.Text = selected.ToString(CultureInfo.InvariantCulture);
            UpdateValue(selected);
        }

        private void ColorLevel_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selected = (string)comboBox.SelectedItem;

            updatedColor = selected;

            if (selected == "Red")
            {
                ChangeTextBoxValues(redColorValues);
                ConstantChannel_txb.Text = colorLevelValues[0].ToString();
                Level_trb.Value = (int)(colorLevelValues[0] * 100);
            }

            if (selected == "Green")
            {
                ChangeTextBoxValues(greenColorValues);
                ConstantChannel_txb.Text = colorLevelValues[1].ToString();
                Level_trb.Value = (int)(colorLevelValues[1] * 100);
            }

            if (selected == "Blue")
            {
                ChangeTextBoxValues(blueColorValues);
                ConstantChannel_txb.Text = colorLevelValues[2].ToString();
                Level_trb.Value = (int)(colorLevelValues[2] * 100);
            }

        }

        void ChangeTextBoxValues(double[] array)
        {
            RedChannel_txb.Text = array[0].ToString();
            R_trb.Value = (int)(array[0] * 100);
            GreenChannel_txb.Text = array[1].ToString();
            G_trb.Value = (int)(array[1] * 100);
            BlueChannel_txb.Text = array[2].ToString();
            B_trb.Value = (int)(array[2] * 100);
        }

        private void Reset_btn_Click(object sender, EventArgs e)
        {
            SetMatrix("1,0,0,0,0,1,0,0,0,0,1,0");
            // reset sliders

        }
    }
}
