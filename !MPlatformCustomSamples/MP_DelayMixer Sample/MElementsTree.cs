using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MPLATFORMLib;

namespace MixerSample
{
    public partial class MElementsTree : TreeView
    {
        IMElements m_pElementsRoot;

        public MElementsTree()
        {
            InitializeComponent();
        }

        public Object SetControlledObject(Object pObject)
        {
            Object pOld = (Object)m_pElementsRoot;
            try
            {
                m_pElementsRoot = (IMElements)pObject;

                UpdateTree(false);
            }
            catch (System.Exception) { }

            return pOld;
        }

        public void UpdateTree( bool bKeepSel)
        {
            MElement pSel = GetSelectedElement();
            Nodes.Clear();

            UpdateTree_R(Nodes, m_pElementsRoot);

            if (pSel != null && bKeepSel )
                SetSelectedElement(pSel);

            ExpandAll();
        }

        public MElement SelectedElement
        {
            get
            {
                return GetSelectedElement();
            }
            set
            {
                SetSelectedElement(value);
            }
        }
        private double m_dblTimeForChange = 2.0;
        public double TimeForChange
        {
            get { return m_dblTimeForChange; }
            set { m_dblTimeForChange = value; }
        }

        MElement GetSelectedElement()
        {
            if (SelectedNode != null)
            {
                return ((MElement)SelectedNode.Tag);
            }

            return null;
        }

        public bool SetSelectedElement(MElement pSel)
        {
            return SetSelectedElement_R(Nodes, pSel);
        }

        bool SetSelectedElement_R(TreeNodeCollection tvNodes, MElement pSel)
        {
            for (int i = 0; i < tvNodes.Count; i++)
            {
                if (tvNodes[i].Tag.Equals(pSel))
                {
                    SelectedNode = tvNodes[i];
                    return true;
                }

                if (SetSelectedElement_R(tvNodes[i].Nodes, pSel))
                    return true;
            }

            return false;
        }


        void UpdateTree_R(TreeNodeCollection tvNodes, IMElements pNode)
        {
            bool bFocused = Focused;
            int nCount = 0;
            pNode.ElementsGetCount(out nCount);
            for (int i = 0; i < nCount; i++)
            {
                MElement pChildNode;
                pNode.ElementsGetByIndex(i, out pChildNode);

                string sType;
                pChildNode.ElementTypeGet(out sType);

                string strID;
                int bHaveID = 0;
                pChildNode.AttributesHave("id", out bHaveID, out strID);
                if (bHaveID != 0 )
                    sType = sType + " [" + strID + "]";

                string strShow;
                int bHaveShow = 0;
                pChildNode.AttributesHave("show", out bHaveShow, out strShow);

                TreeNode tvNode = tvNodes.Add(sType );
                tvNode.Tag = pChildNode;

                if (bHaveShow == 0 || strShow == "1" || strShow == "true")
                    tvNode.Checked = true;
                else
                    tvNode.Checked = false;
                
                UpdateTree_R(tvNode.Nodes, (IMElements)pChildNode);
            }

            if (bFocused)
                Focus();
        }

        private void MElementsTree_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MElement pSelElement = SelectedElement;
            if (pSelElement != null)
            {
                int bHave = 0;
                string sSelected;
                pSelElement.AttributesHave("selected", out bHave, out sSelected);
                if( bHave == 0 || sSelected != "true" )
                    pSelElement.ElementReorder(1000); // Move to top
                // Note: 
                // ElementInvoke("select", "true", m_dblTimeForChange); - > select element (by default - full screen)
                // ElementInvoke("select", "false", m_dblTimeForChange); - > unselect element (restore original)
                // ElementInvoke("select", "", m_dblTimeForChange) -> chnage selected <-> normal state
                pSelElement.ElementInvoke("select", "", m_dblTimeForChange);
            }
        }

        private void MElementsTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            MElement pSelElement = (MElement)e.Node.Tag;
            if (pSelElement != null )
            {
                if (e.Node.Checked)
                {
                    // Show item
                    pSelElement.ElementBoolSet("show", 1, m_dblTimeForChange);
                }
                else
                {
                    // Hide item
                    pSelElement.ElementBoolSet("show", 0, m_dblTimeForChange);
                }
            }
        }

    }
}
