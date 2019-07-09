using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MPLATFORMLib;

namespace MP_MixerLineProblem
{
    public partial class FormPrev : Form
    {
        IMPreview _m_objPrev;
        public FormPrev()
        {
            InitializeComponent();
        }

        public FormPrev(IMPreview m_objPrev)
        {
            _m_objPrev = m_objPrev;
            InitializeComponent();
        }

        private void FormPrev_Load(object sender, EventArgs e)
        {
            Width = 642;
            Height = 357;
            Visible = true;
            _m_objPrev.PreviewWindowSet("", panel1.Handle.ToInt32());
        }
    }
}
