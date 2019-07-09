using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MPLATFORMLib;

namespace MP_MixerLineProblem
{
    public partial class Form1 : Form
    {
        MMixerClass m_objMixer;
        MElement m_Layer;
        IMColors m_Colors;

        FormPrev formPrev;

        MPreviewClass m_objPreview;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitMixer();
            InitMixerLayer();

            InitPreview();

            formPrev = new FormPrev(m_objPreview);
            formPrev.Show();

        }

        private void InitPreview()
        {
            m_objPreview = new MPreviewClass();

            m_Colors = new CoMColorsClass();
            m_objPreview.PluginsAdd(m_Colors, 0);

            m_objPreview.ObjectStart(m_objMixer);
            LoadProps();
        }

        private void LoadProps()
        {
            m_objPreview.PreviewEnable("", 1, 1);

            m_objPreview.PropsSet("overlay_rms", "true");
            m_objPreview.PropsSet("maintain_ar", "true");
            m_objPreview.PropsSet("preview.crop", "0.0%,0.0%,0.0%,0.0%");
            m_objPreview.PropsSet("preview.background", "#FF0000");
            m_objPreview.PropsSet("preview.drop_frames", "true");
            m_objPreview.PropsSet("deinterlace", "true");
            m_objPreview.PropsSet("preview.downscale", "0");

            LoadColorProps();
        }

        private void LoadColorProps()
        {
            MG_BRIGHT_CONT_PARAM brightContParam;
            int enabled;

            m_Colors.GetBrightContParam(out brightContParam, out enabled);
            brightContParam.dblColorGain = 1.0;

            Thread.Sleep(200);

            m_Colors.SetBrightContParam(ref brightContParam, 1, 0);
        }

        private void InitMixerLayer()
        {
            MElement root;
            m_objMixer.ElementsGetByIndex(0, out root);

            (root as IMElements).ElementsAdd("","video",$"stream_id='Layer_1' h=1 w=1 x=0 y=0 show=1 pos=top-left alpha=1 audio_gain=0",out m_Layer,0); 
        }

        private void InitMixer()
        {
            m_objMixer = new MMixerClass();

            m_objMixer.PropsSet("preview.downscale", "2");           


            m_objMixer.ObjectStart(null);
            m_objMixer.FilePlayStart();

            MItem item;
            m_objMixer.StreamsBackgroundSet(null, "black", "", out item, 0);
            Marshal.ReleaseComObject(item);

            IMElements mySceneConfig;
            m_objMixer.ScenesAdd("", "MyScene",out mySceneConfig);

            m_objMixer.ScenesActiveSet("MyScene", "");

            SetVideoFormat();

        }

        private void SetVideoFormat()
        {
            M_VID_PROPS props;            
            string name;

            m_objMixer.FormatVideoGetByIndex(eMFormatType.eMFT_Input, 6, out props, out name);

            props.eInterlace = eMInterlace.eMI_Progressive;
            props.fccType = eMFCC.eMFCC_ARGB32;

            m_objMixer.FormatVideoSet(eMFormatType.eMFT_Convert, ref props);
        }
    }
}
