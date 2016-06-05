using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using NeuralNetwork;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GUI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<double> neuron_values;
        List<double> output_values;
        public MainPage()
        {
            this.InitializeComponent();
           
        }

        private void buttonCalculate_Click(object sender, RoutedEventArgs e)
        {
            List<Neuron> inputs = new List<Neuron>();
            inputs.Add(input1.neuron);
            inputs.Add(input2.neuron);
            List<Neuron> neurons = new List<Neuron>();
            neurons.Add(Neuron1.neuron);
            neurons.Add(Neuron2.neuron);
            neurons.Add(Neuron3.neuron);
            List<Neuron> outputs = new List<Neuron>();
            outputs.Add(output.neuron);

            input1.currentValueString = TextBoxInput1.Text;
            input1.neuron.currentValue = float.Parse(TextBoxInput1.Text);

            input2.currentValueString = textBoxInput2.Text;
            input2.neuron.currentValue = float.Parse(textBoxInput2.Text);
            Random rand = new Random();

            input1.neuron.weights.Add(rand.NextDouble());
            input1.neuron.weights.Add(rand.NextDouble());
            input1.neuron.weights.Add(rand.NextDouble());

            input2.neuron.weights.Add(rand.NextDouble());
            input2.neuron.weights.Add(rand.NextDouble());
            input2.neuron.weights.Add(rand.NextDouble());

            Neuron1.neuron.weights.Add(rand.NextDouble());
            Neuron2.neuron.weights.Add(rand.NextDouble());
            Neuron3.neuron.weights.Add(rand.NextDouble());

            List<double> neuron_values = calculateValue(inputs, neurons);

            List<double> output_values = calculateValue(neurons, outputs);
         }

        public List<double> calculateValue(List<Neuron> inputs, List<Neuron> neurons)
        {
            List<double> returnValue = new List<double>();

            foreach(Neuron neuron in neurons)
            {
                double value = 0;
                int input_counter = 0;
               foreach(Neuron inputNeuron in inputs)
                {
                    value += inputNeuron.currentValue * inputNeuron.weights.ElementAt(input_counter);
                }
                value = sigmoid(value);
                returnValue.Add(value);
                input_counter++;
            }

            return returnValue;
        }
        public double sigmoid(double value)
        {
            return (1 / (1 + Math.Exp(0 - value)));
        }

        public void displayValues(List<Neuron> inputs, List<Neuron> neurons, List<Neuron> outputs)
        {

        }

    }
}
