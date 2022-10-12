using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UmowyMJ
{
    class ToolStripColors : ToolStripProfessionalRenderer
    {
        public ToolStripColors() : base(new MyColors()) { }
    }

    class MyColors : ProfessionalColorTable
    {

        public override Color MenuItemSelectedGradientBegin
        {
            get { return Color.FromArgb(225, 90, 23); }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get { return Color.FromArgb(225, 90, 23); }
        }

        public override Color MenuItemBorder
        {
            get { return Color.Empty; }
        }

        public override Color MenuItemSelected
        {
            get { return Color.FromArgb(243, 245, 247); }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get { return Color.FromArgb(225, 90, 23); }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get { return Color.FromArgb(225, 90, 23); }
        }

        public override Color MenuBorder
        {
            get { return Color.Empty; }
        }

    }
}
