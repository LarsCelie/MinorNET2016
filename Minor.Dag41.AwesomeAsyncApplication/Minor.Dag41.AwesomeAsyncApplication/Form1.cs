using InfoSupport.Threading.MathLib;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minor.Dag41.AwesomeAsyncApplication
{
    public partial class Form1 : Form
    {
        private ConcurrentBag<int> squares;
        private object lockList = new object();
        public Form1()
        {
            InitializeComponent();

        }

        private void btnSumOfSquares_Click(object sender, EventArgs e)
        {
            squares = new ConcurrentBag<int>();
            SlowMath math = new SlowMath();

            var input1 = int.Parse(txtInput1.Text);
            math.BeginSquare(input1, SquareReceived, math);

            var input2 = int.Parse(txtInput2.Text);
            math.BeginSquare(input2, SquareReceived, math);

            var input3 = int.Parse(txtInput3.Text);
            math.BeginSquare(input3, SquareReceived, math);
        }

        private void SquareReceived(IAsyncResult ar)
        {
            SlowMath math = (SlowMath) ar.AsyncState;

            lock (lockList)
            {
                
                int uitvoer = math.EndSquare(ar);
                squares.Add(uitvoer);
            }

            if (squares.Count == 3)
            {
                var executeOnMain = (MethodInvoker)(() =>
                {
                    txtOutput.Text = squares.Sum().ToString();
                });
                Invoke(executeOnMain);
            }
        }
    }
}
