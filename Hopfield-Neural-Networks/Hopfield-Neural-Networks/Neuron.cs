using System;

namespace HopfieldNeuralNetworks
{
    public class Neuron
    {
        private int _state;

        public Neuron()
        {
            switch (new Random().Next(2))
            {
                case 0: _state = NeuronStates.AlongField; break;
                case 1: _state = NeuronStates.AgainstField; break;
            }
        }

        public Neuron(int neuronState)
        {
            _state = neuronState;
        }

        public int State
        {
            get {
                return _state;
            }
            set {
                _state = value;
            }
        }

        public bool ChangeState(double field)
        {
            if (field * _state < 0)
            {
                _state = -_state;
                return true;
            }

            return false;
        }
    }
}
