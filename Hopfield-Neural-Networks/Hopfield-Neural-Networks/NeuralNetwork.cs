using System.Threading.Tasks;

namespace HopfieldNeuralNetworks
{
    public delegate void EnergyChangedHandler(object sender, EnergyEventArgs e);

    public class NeuralNetwork
    {
        static Neuron[] _neurons;

        static int _memorySize;
        static int _patternCount;
        static double _energy;
        static int[,] _matrix;

        private static NeuralNetwork _instance = null;

        public static NeuralNetwork GetInstance(int memorySize)
        {
            if (_instance != null)
                return _instance;

            _instance = new NeuralNetwork(memorySize);
            return _instance;
        }

        private NeuralNetwork(int memorySize)
        {
            _memorySize = memorySize;
            _neurons = new Neuron[memorySize];

            for (int i = 0; i < memorySize; i++)
            {
                Neuron neuron = new Neuron();
                neuron.State = 0;
                _neurons[i] = neuron;
            }

            _matrix = new int[memorySize, memorySize];
            _patternCount = 0;

            for (int i = 0; i < memorySize; i++)
                for (int j = 0; j < memorySize; j++)
                    _matrix[i, j] = 0;
        }
        
        public int MemorySize
        {
            get {
                return _memorySize;
            }
        }

        public int PatternCount
        {
            get {
                return _patternCount;
            } 
        }        

        public double Energy
        {
            get {
                return _energy;
            }
        }

        public int[,] Matrix
        {
            get {
                return _matrix;
            }
        }

        public Neuron[] Neurons
        {
            get {
                return _neurons;
            }
        }

        public void AddPattern(Neuron[] pattern)
        {
            Parallel.For(0, _memorySize, (i) =>
            {
                for (int j = 0; j < _memorySize; j++)
                {
                    if (i == j)
                        _matrix[i, j] = 0;
                    else
                        _matrix[i, j] += (pattern[i].State * pattern[j].State);
                }
            });

            _patternCount++;
        }
        
        public void Clear()
        {
            _patternCount = 0;
            _energy = 0;

            Parallel.For(0, _memorySize, (i) =>
            {
                for (int j = 0; j < _memorySize; j++)
                    _matrix[i, j] = 0;
            });     
        }

        private static void CalculateEnergy()
        {
            double tempEnergy = 0;

            Parallel.For(0, _memorySize, (i) =>
            {
                for (int j = 0; j < _memorySize; j++)
                    if (i != j)
                        tempEnergy += _matrix[i, j] * _neurons[i].State * _neurons[j].State;
            });

            _energy = -1 * tempEnergy / 2;
        }

        public async void Run(Neuron[] initialState)
        {
            _neurons = initialState;

            await RunRecursive();

            //CalculateEnergy();             
        }

        static async Task RunRecursive()
        {
            int condition = 0;

            await Task.Factory.StartNew(() =>
            {
                Parallel.For(0, _memorySize, (i) =>
                {
                    int h = 0;

                    for (int j = 0; j < _memorySize; j++)
                        h += _matrix[i, j] * (_neurons[j].State);

                    if (_neurons[i].ChangeState(h))
                    {
                        condition = condition | 1;
                        CalculateEnergy();
                        _instance.OnEnergyChanged(new EnergyEventArgs(_energy, i));
                    }
                });
            });

            if ((condition & 1) == 1)
                await RunRecursive();
        }

        public event EnergyChangedHandler EnergyChanged;
		
        protected virtual void OnEnergyChanged(EnergyEventArgs e)
        {
            EnergyChanged?.Invoke(this, e);
        }
    }
}