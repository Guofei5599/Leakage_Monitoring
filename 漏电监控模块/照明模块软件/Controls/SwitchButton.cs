using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 照明模块软件
{
    public class SwitchButton:Button
    {
        public bool flag = false;
        public SwitchButton()
        {
            this.Size = new Size(30,70);
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackgroundImageLayout = ImageLayout.Zoom;
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.BackColor = Color.Transparent;
            ButtonDisplay();
            this.Click += new EventHandler(button_Click);
        }

        private void button_Click(object sender, EventArgs e)
        {
            flag = !flag;
            ButtonDisplay();
        }

        public void ButtonDisplay()
        {
            if (!flag)
                this.BackgroundImage = Properties.Resources.关;
            else
                this.BackgroundImage = Properties.Resources.开;
        }
        public void ButtonDisplay(bool b)
        {
            flag = b;
            if (!flag)
                this.BackgroundImage = Properties.Resources.关;
            else
                this.BackgroundImage = Properties.Resources.开;
        }
    }
}
