using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Soroban
{
    public partial class AbacusControl : UserControl
    {
        Ellipse[,] numbers = new Ellipse[7, 5];
        Double[,,] origanalValues = new double[7, 5, 2];
        int counter = 0;


        public AbacusControl()
        {
            InitializeComponent();
            Ellipse[] ones = { one, two, three, four, five };
            Ellipse[] tens = { ten, twenty, thirty, fourty, fifty };
            Ellipse[] hundreds = { hundred, twohundred, threehundred, fourhundred, fivehundred };
            Ellipse[] thousands = { thousend, twothousend, threethousend, fourthousend, fivethousend };
            Ellipse[] tenThousands = { tenthousend, twentythousend, thirtythousend, fourtythousend, fiftythousend };
            Ellipse[] hundredThousands = { hundredthousand, twohundredthousand, threehundredthousand, fourhundredthousand, fivehundredthousend };
            Ellipse[] millions = { million1, twomillion1, threemillion, fourmillion, fivemillion };

            addNum(millions);
            addNum(hundredThousands);
            addNum(tenThousands);
            addNum(thousands);
            addNum(hundreds);
            addNum(tens);
            addNum(ones);

            for (int i = 0; i <= 6; i++)
            {
                for (int j = 0; j <= 4; j++)
                {
                    origanalValues[i, j, 0] = numbers[i, j].RenderTransform.Value.OffsetX;
                    origanalValues[i, j, 1] = numbers[i, j].RenderTransform.Value.OffsetY;
                }
            }


        }

        public void beadUp(int i, int j)
        {
            if (numbers[i, j].RenderTransform == null || !(numbers[i, j].RenderTransform is TranslateTransform))
                numbers[i, j].RenderTransform = new TranslateTransform();

            var transform = (TranslateTransform)numbers[i, j].RenderTransform;
            if (j == 4)
                transform.Y = 0;
            else transform.Y = -100;
        }

        public void beadDown(int i, int j)
        {
            if (numbers[i, j].RenderTransform == null || !(numbers[i, j].RenderTransform is TranslateTransform))
                numbers[i, j].RenderTransform = new TranslateTransform();

            var transform = (TranslateTransform)numbers[i, j].RenderTransform;
            if (j == 4)
                transform.Y = 100;
            else transform.Y = 0;

        }


        


        public void addNum(Ellipse[] arr)
        {
            for (int j = 0; j < 5; j++)
            {
                numbers[counter, j] = arr[j];
            }
            counter++;

        }
    }
}
