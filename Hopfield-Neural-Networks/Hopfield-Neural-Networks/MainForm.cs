using HopfieldNeuralNetworks.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HopfieldNeuralNetworks
{
    public partial class MainForm : Form
    {
        public static int PatternDimension = 40;

        static NeuralNetwork _neuralNetwork;

        static Bitmap _neuralNetworkState;

        static bool _drawingEnabled = true;

        Point? _drawingCursorPoint;
        Point _drawingLastPoint;
        GraphicsPath _currentPath;
        List<GraphicsPath> _drawingGraphPaths = new List<GraphicsPath>();

        bool _patternDrawn = false;

        delegate void SetTextCallback(Label label, string text);

        private void SetText(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                Invoke(d, new object[] { label, text });
            }
            else
            {
                label.Text = text;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            InitializeDrawing();
            InitializeNeuralNetwork();
        }

        void InitializeDrawing()
        {
            pixelPictureBox.MouseDown += new MouseEventHandler(pixelPictureBox_MouseDown);
            pixelPictureBox.MouseMove += new MouseEventHandler(pixelPictureBox_MouseMove);
            pixelPictureBox.MouseLeave += new EventHandler(pixelPictureBox_MouseLeave);
            pixelPictureBox.Paint += new PaintEventHandler(pixelPictureBox_Paint);
        }
        
        async void InitializeNeuralNetwork()
        {
            progressBar.Style = ProgressBarStyle.Marquee;

            _neuralNetwork = NeuralNetwork.GetInstance(PatternDimension * PatternDimension);
            Debug.WriteLine("Neural Network created.");
            toolStripStatusLabel.Text = "Neural Network created.";

            NeuralTrainer neuralTrainer = new NeuralTrainer(PatternDimension);
            int trainResult = await neuralTrainer.Train(_neuralNetwork);
            Debug.WriteLine(string.Format("Neural Network trained with {0} patterns.", trainResult));
            toolStripStatusLabel.Text = string.Format("Neural Network trained with {0} patterns.", trainResult);

            progressBar.Style = ProgressBarStyle.Continuous;
            buttonRun.Enabled = true;

            labelNeuronCount.Text = "Neuron Count:" + _neuralNetwork.MemorySize;
            labelPatternCount.Text = "Pattern Count: " + trainResult;

            _neuralNetwork.EnergyChanged += new EnergyChangedHandler(neuralNetwork_EnergyChanged);
        }

        async Task RunNeuralNetwork()
        {
            Neuron[] initialState = new Neuron[_neuralNetwork.MemorySize];

            for (int i = 0; i < PatternDimension; i++)
                for (int j = 0; j < PatternDimension; j++)
                {
                    initialState[i * PatternDimension + j] = new Neuron(pixelPictureBox.pixels[i, j] == PixelPictureBox.WhiteColor ? NeuronStates.AlongField : NeuronStates.AgainstField);
                }

            progressBar.Style = ProgressBarStyle.Marquee;
            buttonRun.Enabled = false;

            await _neuralNetwork.Run(initialState);

            progressBar.Style = ProgressBarStyle.Continuous;
            buttonRun.Enabled = true;
        }

        private void neuralNetwork_EnergyChanged(object sender, EnergyEventArgs e)
        {
            SetText(labelEnergy, "Energy: " + e.Energy);

            int i = e.NeuronIndex / PatternDimension;
            int j = e.NeuronIndex % PatternDimension;

            pixelPictureBox.InversePixel(i, j);
            pixelPictureBox.Invalidate();
        }

        void pixelPictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (!_drawingEnabled)
                return;
            foreach (GraphicsPath graphPath in _drawingGraphPaths)
            {
                Pen pen = new Pen(Color.Black, 6);
                e.Graphics.DrawPath(pen, graphPath);
            }

            if (_drawingCursorPoint.HasValue)
            {
                e.Graphics.DrawLine(Pens.LightBlue, new Point(_drawingCursorPoint.Value.X, 0), new Point(_drawingCursorPoint.Value.X, pixelPictureBox.Height));
                e.Graphics.DrawLine(Pens.LightBlue, new Point(0, _drawingCursorPoint.Value.Y), new Point(pixelPictureBox.Width, _drawingCursorPoint.Value.Y));
            }
            else
            {
                _neuralNetworkState = new Bitmap(pixelPictureBox.Width, pixelPictureBox.Height, e.Graphics);
            }
        }

        void pixelPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_drawingEnabled)
                return;

            if (e.Button == MouseButtons.Left)
            {
                _drawingLastPoint = new Point(e.X, e.Y);
                _currentPath = new GraphicsPath();
                _drawingGraphPaths.Add(_currentPath);

                _patternDrawn = true;
            }
        }

        void pixelPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_drawingEnabled)
                return;

            _drawingCursorPoint = new Point(e.X, e.Y);

            if (e.Button == MouseButtons.Left)
            {
                Point newPoint = new Point(e.X, e.Y);
                _currentPath.AddLine(_drawingLastPoint, newPoint);
                _drawingLastPoint = newPoint;
            }

            pixelPictureBox.Refresh();
        }

        void pixelPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (!_drawingEnabled)
                return;

            _drawingCursorPoint = null;

            pixelPictureBox.Refresh();
        }

        void buttonAddDistortion_Click(object sender, EventArgs e)
        {
            AddDistortionForm addDistortionForm = new AddDistortionForm();
            addDistortionForm.ShowDialog();

            if (!addDistortionForm._isAdded)
                return;

            Bitmap pattern = new Bitmap(pixelPictureBox.Width, pixelPictureBox.Height);
            pixelPictureBox.DrawToBitmap(pattern, pixelPictureBox.ClientRectangle);

            _drawingGraphPaths.Clear();

            pixelPictureBox.Image = pattern;

            Random random = new Random();
            int p = 0;
            int k = 0;
            if (addDistortionForm._isNegative)
            {
                int n = 0;
                int m = 0;
                while (n != pixelPictureBox.Width)
                {
                    while (m != pixelPictureBox.Height)
                    {
                        pixelPictureBox.InversePixel(n, m);
                        m++;
                    }

                    m = 0;
                    n++;
                }
            }

            double realDistortionLevel = addDistortionForm._distortionLevel * Math.Pow(pixelPictureBox.Width, 2) / 100;

            for (int i = 0; i < realDistortionLevel; i++)
            {
                p = random.Next(pixelPictureBox.Width);
                k = random.Next(pixelPictureBox.Height);
                pixelPictureBox.InversePixel(k, p);
            }

            pixelPictureBox.Invalidate();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            _drawingGraphPaths.Clear();

            pixelPictureBox.Refresh();

            _patternDrawn = false;
        }

        async void buttonRun_Click(object sender, EventArgs e)
        {
            if (!_patternDrawn)
            {
                MessageBox.Show("Please draw a letter first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Bitmap pattern = new Bitmap(pixelPictureBox.Width, pixelPictureBox.Height);
            pixelPictureBox.DrawToBitmap(pattern, pixelPictureBox.ClientRectangle);

            pattern = pattern.ResizeBitmap(PatternDimension, PatternDimension);

            _drawingGraphPaths.Clear();

            pixelPictureBox.Image = pattern;

            await RunNeuralNetwork();
        }
    }
}
