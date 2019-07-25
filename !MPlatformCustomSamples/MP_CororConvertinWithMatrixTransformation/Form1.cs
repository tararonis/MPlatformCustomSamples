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
        MFFactoryClass m_objMFFactory; //need to set GPU_PIPELINE
        bool gpu_p = false;

        MFileClass m_objMFile; //Object for Playback
        string filePath = String.Empty;        
        
        Dictionary<string, double[]> Matrixes = new Dictionary<string, double[]>(); //Container for all Predifined matrixes
        string[] colors = { "Red", "Green", "Blue" }; //Color Channels

        string matrix = String.Empty; // The value that we are setting with PropsSet method
        double[] customMatrix = new double[12];   

        string updatedColor = String.Empty;

        public Form1()
        {
            InitializeComponent();
            InitMarrixes();
        }
        void InitMarrixes()
        {
            Matrixes.Add("Default", new double[] {
                1, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 1, 0 });
            Matrixes.Add("Grayscale", new double[] {
                1, 0, 0, 0,
                1, 0, 0, 0,
                1, 0, 0, 0 });
            Matrixes.Add("ReverseColors", new double[] {
                1.5,1.5,1.5,-1,
                1.5,1.5,1.5,1,
                1.5,1.5,1.5,-1 });
            Matrixes.Add("BT2020_BT709", new double[] {
                1.6605, -0.5876, -0.0728,    0.0,
                -0.1246,  1.1329, -0.0083,   0.0,
                -0.0182, -0.1006,  1.1187,   0.0 });
            Matrixes.Add("BT709_BT2020", new double[] {
                0.627,     0.329,     0.0433,    0.0,
                0.0691,    0.92,      0.0113,    0.0,
                0.0164,    0.088,     0.896,     0.0});
            Matrixes.Add("RGB_YUV_601", new double[] {
                0.257,  0.504,  0.098, 0.0625,
                -0.148, -0.291,  0.439, 0.500,
                0.439, -0.368, -0.071, 0.500});
            Matrixes.Add("RGB_YUV_709", new double[] {
                0.183,  0.614,  0.062, 0.0625,
                -0.101, -0.338,  0.439, 0.500,
                0.439, -0.399, -0.040, 0.500});
            Matrixes.Add("RGB_YUV_2020", new double[] {
                0.225613,  0.582282,  0.050928, 0.062745,
                -0.119918, -0.309494,  0.429412, 0.500,
                0.429412, -0.394875, -0.034537, 0.500});
            Matrixes.Add("RGB_YUV_2020_Limited", new double[] {
                0.2627,  0.6780,  0.0593,  0.0,
                -0.139630, -0.360370,  0.5, 0.500,
                0.5, -0.459786, -0.040214, 0.500 });
            Matrixes.Add("YUV_RGB_601", new double[] {
                1.164,  0.000,  1.596, -0.87075,
                1.164, -0.813, -0.391,  0.52925,
                1.164,  2.018,  0.000, -1.08175 });
            Matrixes.Add("YUV_RGB_709", new double[] {
                1.164,  0.000,  1.793, -0.96925,
                1.164, -0.213, -0.534,  0.30075,
                1.164,  2.115,  0.000, -1.13025 });
            Matrixes.Add("YUV_RGB_2020", new double[] {
                1.164384,0.000000,1.717000,-0.931559,
                1.164384,-0.191603,-0.665274,0.355379,
                1.164384,2.190671,0.000000,-1.168395});
            Matrixes.Add("YUV_RGB_2020_Limited", new double[] {
                1.0, 0.0, 1.474600,  -0.737300,
                1.0, -0.164553, -0.571353, 0.367953,
                1.0,  1.881400,  0.0, -0.940700 });
            Matrixes.Add("Full_To_16_235", new double[] {
                0.856305, 0.0, 0.0, 0.0625,
                0.0, 0.856305,  0.0, 0.0625,
                0.0, 0.0, 0.856305, 0.0625});
            Matrixes.Add("Full_from_16_235", new double[] {
                1.167808, 0.0, 0.0, -0.0729880,
                0.0, 1.167808, 0.0, -0.0729880,
                0.0, 0.0, 1.167808, -0.0729880 });
            Matrixes.Add("Custom", new double[] {
                1, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 1, 0 });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Filing the comboboxes with Matrixes and ColorChannels 
            foreach (var m in Matrixes)
            {
                PredifinedMatrix_txb.Items.Add(m.Key);
            }
            PredifinedMatrix_txb.SelectedIndex = Matrixes.Count-1;

            foreach (var c in colors)
            {
                ColorLevel_cmb.Items.Add(c);
            }
            ColorLevel_cmb.SelectedIndex = 0;

            m_objMFile = new MFileClass();

        }

        //This feature is working only with GPU_PIPELINE.
        private void GpuPipilineOn_btn_Click(object sender, EventArgs e)
        {
            TurnOnGPU_Pipeline();
        }

        void TurnOnGPU_Pipeline()
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
                Red_trb.Enabled = true;
                Green_trb.Enabled = true;
                Blue_trb.Enabled = true;
                Constant_trb.Enabled = true;
                RedChannel_txb.Enabled = true;
                GreenChannel_txb.Enabled = true;
                BlueChannel_txb.Enabled = true;
                ConstantChannel_txb.Enabled = true;

                //When we turn on the gpu_pipeline we need to recreate objects.
                //To continue playback from same position we take current and save it
                m_objMFile.FilePosGet(out double position);
                m_objMFile.FilePlayStop(0);

                Marshal.ReleaseComObject(m_objMFile);

                m_objMFile = new MFileClass();

                m_objMFile.PreviewWindowSet("", panelPr.Handle.ToInt32());
                m_objMFile.PreviewEnable("", 1, 1);

                if (filePath.Length > 1)
                {
                    m_objMFile.FileNameSet(filePath, "loop=true");
                    m_objMFile.FilePosSet(position, 0);
                    m_objMFile.FilePlayStart();
                }
                PredifinedMatrix_txb.SelectedIndex = 0;
            }
        }


        private void OpenFile_btn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileNames.Length != 0)
            {
                filePath = openFileDialog1.FileNames[0].ToString();
                m_objMFile.FileNameSet(filePath, "loop=true");
            }
            m_objMFile.PreviewWindowSet("", panelPr.Handle.ToInt32());
            m_objMFile.PreviewEnable("", 1, 1);
            m_objMFile.FilePlayStart();
        }

        //Select the matrix from the ComboBox
        private void PredifinedMatrix_txb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gpu_p)
            {
                ComboBox comboBox = (ComboBox)sender;
                string selected = (string)comboBox.SelectedItem;
                SetMatrix(Matrixes[selected]);
            }
        }

        void SetMatrix(double[] value)
        {
            matrix = null;
            for (int i = 0; i < customMatrix.Length; i++)
            {
                customMatrix[i] = value[i];
                matrix += value[i].ToString(CultureInfo.InvariantCulture) + ",";
            }
            if (m_objMFile != null)
                m_objMFile.PropsSet("object::gpu.rgb_transform_matrix", matrix);

            Debug.WriteLine("We are setting matix with value: " + matrix + "\n");

            CurrentMatrix_txb.Text = matrix;
            UpdateVisualData(ColorLevel_cmb.SelectedItem.ToString());
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
            UpdateValue(selected, 3);
        }
        void UpdateValue(double value, int trackBar)
        {
            
            if (updatedColor == "Red")
            {
                customMatrix[trackBar] = value;
            }
            if (updatedColor == "Green")
            {
                customMatrix[trackBar +4] = value;
            }
            if (updatedColor == "Blue")
            {
                customMatrix[trackBar+8] = value;
            }

            Matrixes["Custom"] = customMatrix;

            PredifinedMatrix_txb.SelectedIndex = Matrixes.Count - 1;

            SetMatrix(Matrixes["Custom"]);
        }

        private void ColorLevel_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selected = (string)comboBox.SelectedItem;

            updatedColor = selected;

            UpdateVisualData(updatedColor);

        }
        void UpdateVisualData(string curColor)
        {
            if (curColor == "Red")
            {
                ChangeTextBoxesAndTrackbarsValues(customMatrix[0], customMatrix[1], customMatrix[2], customMatrix[3]);
            }

            if (curColor == "Green")
            {
                ChangeTextBoxesAndTrackbarsValues(customMatrix[4], customMatrix[5], customMatrix[6], customMatrix[7]);
            }

            if (curColor == "Blue")
            {
                ChangeTextBoxesAndTrackbarsValues(customMatrix[8], customMatrix[9], customMatrix[10], customMatrix[11]);
            }
        }

        void ChangeTextBoxesAndTrackbarsValues(double red, double green, double blue, double constant)
        {
            if (red > 0)
                RedChannel_txb.Text = "+" + (red * 100).ToString();

            else if (red == 0)
                RedChannel_txb.Text = (red * 100).ToString();

            else if (red < 0)
                RedChannel_txb.Text = (red * 100).ToString();

            Red_trb.Value = (int)(red * 100);

            if (green > 0)            
                GreenChannel_txb.Text = "+" + (green * 100).ToString();                
            
            else if (green == 0)
                GreenChannel_txb.Text = (green * 100).ToString();

            if (green < 0)
                GreenChannel_txb.Text = (green * 100).ToString();

            Green_trb.Value = (int)(green * 100);

            if (blue > 0)            
                BlueChannel_txb.Text ="+" + (blue * 100).ToString();                
            
            else if (blue == 0)
                BlueChannel_txb.Text = (blue * 100).ToString();

            if (blue < 0)
                BlueChannel_txb.Text = (blue * 100).ToString();

            Blue_trb.Value = (int)(blue * 100);

            if (constant > 0)
                ConstantChannel_txb.Text = "+" + (constant * 100).ToString();

            else if (constant == 0)
                ConstantChannel_txb.Text = (constant * 100).ToString();

            else if (constant < 0)
                ConstantChannel_txb.Text = (constant * 100).ToString();

            Constant_trb.Value = (int)(constant * 100);
        }

        private void Reset_btn_Click(object sender, EventArgs e)
        {
            PredifinedMatrix_txb.SelectedIndex = 0;
        }

       
    }
}
