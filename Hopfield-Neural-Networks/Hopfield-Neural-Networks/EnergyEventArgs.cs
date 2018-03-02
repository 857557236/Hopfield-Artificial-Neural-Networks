using System;

namespace HopfieldNeuralNetworks
{
    public class EnergyEventArgs : EventArgs
    {
        private double _energy;
        private int _neuronIndex;
        
        public EnergyEventArgs(double Energy, int NeuronIndex)
        {
            _energy = Energy;
            _neuronIndex = NeuronIndex;
        }

        public double Energy
        {
            get {
                return _energy;
            }
        }

        public int NeuronIndex
        {
            get {
                return _neuronIndex;
            }
        }
    }
}
