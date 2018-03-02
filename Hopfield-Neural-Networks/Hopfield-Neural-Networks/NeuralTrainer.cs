using HopfieldNeuralNetworks.Controls;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace HopfieldNeuralNetworks
{
    public class NeuralTrainer
    {
        static int _patternCount = 36;

        static int _patternDimension;
        static string _charmapPath;
        static int _charCellWidth, _charCellHeight;

        public NeuralTrainer(int patternDimension)
        {
            _patternDimension = patternDimension;
            _charmapPath = Path.Combine(System.Windows.Forms.Application.StartupPath, "Assets", "charmap.png");
            _charCellWidth = 78;
            _charCellHeight = 83;
        }
        
        public NeuralTrainer(int patternDimension, string charmapPath, int charCellWidth, int charCellHeight)
        {
            _patternDimension = patternDimension;
            _charmapPath = charmapPath;
            _charCellWidth = charCellWidth;
            _charCellHeight = charCellHeight;
        }

        public async Task<int> Train(NeuralNetwork neuralNetwork)
        {
            await Task.Factory.StartNew(() =>
            {
                neuralNetwork.Clear();

                using (Bitmap charmapBitmap = new Bitmap(_charmapPath))
                {
                    int row = 0, column = 0, x = 0, y = 0;

                    for (int i = 0; i < _patternCount; i++)
                    {
                        column = i % 10;
                        row = i / 10;

                        x = column * _charCellWidth + ((_charCellWidth - _patternDimension) / 2);
                        y = row * _charCellHeight + ((_charCellHeight - _patternDimension) / 2);

                        Bitmap charPattern = charmapBitmap.Clone(new Rectangle(x, y, _patternDimension, _patternDimension), System.Drawing.Imaging.PixelFormat.Format1bppIndexed);

                        int[,] pixels = charPattern.GetPixelArray();

                        charPattern.Dispose();

                        Neuron[] pattern = new Neuron[_patternDimension * _patternDimension];

                        int n = 0;
                        foreach (int pixel in pixels)
                        {
                            pattern[n] = new Neuron(pixel == PixelPictureBox.WhiteColor ? NeuronStates.AlongField : NeuronStates.AgainstField);
                            n++;
                        }

                        neuralNetwork.AddPattern(pattern);
                    }
                }
            });

            return _patternCount;
        }

        public async Task<Bitmap> GetRandomPattern()
        {

            Bitmap randomPattern = await Task.Factory.StartNew(() =>
            {
                using (Bitmap charmapBitmap = new Bitmap(_charmapPath))
                {
                    int i = new Random().Next(0, _patternCount);
                    int column = i % 10;
                    int row = i / 10;

                    int x = column * _charCellWidth + ((_charCellWidth - _patternDimension) / 2);
                    int y = row * _charCellHeight + ((_charCellHeight - _patternDimension) / 2);

                    randomPattern = charmapBitmap.Clone(new Rectangle(x, y, _patternDimension, _patternDimension), System.Drawing.Imaging.PixelFormat.Format1bppIndexed);
                    return randomPattern;
                }
            });

            return randomPattern;
        }
    }
}
