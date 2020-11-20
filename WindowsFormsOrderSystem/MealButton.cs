using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsOrderSystem
{
    class MealButton : Button
    {
        private string _imagePath;
        private const string HEADER = "../../..";
        public MealButton()
        {
            BackgroundImageLayout = ImageLayout.Stretch;
            TextAlign = ContentAlignment.BottomRight;
            Dock = DockStyle.Fill;
        }

        public string ImagePath
        {
            get
            {
                return _imagePath;
            }
            set
            {
                _imagePath = value;
                BackgroundImage = Image.FromFile(HEADER + _imagePath);
            }
        }
    }
}
