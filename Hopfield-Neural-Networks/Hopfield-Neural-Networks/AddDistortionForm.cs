using System;
using System.Windows.Forms;

namespace HopfieldNeuralNetworks
{
    public partial class AddDistortionForm : Form
    {
        public bool _isAdded = false;

        public int _distortionLevel = 10;
        public bool _isNegative = false;

        public AddDistortionForm()
        {
            InitializeComponent();
        }

        private void numericDistorionLevel_ValueChanged(object sender, EventArgs e)
        {
            _distortionLevel = Convert.ToInt32(numericDistorionLevel.Value);
        }

        private void checkBoxNegative_CheckedChanged(object sender, EventArgs e)
        {
            _isNegative = !_isNegative;
        }

        private void buttonAddDistortion_Click(object sender, EventArgs e)
        {
            _isAdded = true;
            numericDistorionLevel_ValueChanged(this, new EventArgs());

            Close();
        }
    }
}
