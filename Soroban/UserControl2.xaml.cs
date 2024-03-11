using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
    /// <summary>
    /// UserControl2.xaml etkileşim mantığı
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        List<Ellipse> ones1;
        List<Ellipse> tens1;
        List<Ellipse> hundreds1;
        List<Ellipse> thousands1;
        List<Ellipse> tenThousands1;
        List<Ellipse> hundredThousands1;
        List<Ellipse> millions1;
        Ellipse[,] numbers = new Ellipse[7,5];
        Double[,,] origanalValues = new double[7,5,2]; 
        int counter = 0;


        public UserControl2()
        {
            InitializeComponent();
            Ellipse[] ones = {one, two, three, four, five};
            Ellipse[] tens = {ten, twenty, thirty, fourty, fifty};
            Ellipse[] hundreds = { hundred, twohundred, threehundred, fourhundred, fivehundred};
            Ellipse[] thousands = {thousend, twothousend, threethousend, fourthousend, fivethousend};
            Ellipse[] tenThousands = {tenthousend, twentythousend, thirtythousend, fourtythousend, fiftythousend};
            Ellipse[] hundredThousands = {hundredthousand, twohundredthousand, threehundredthousand, fourhundredthousand, fivehundredthousend};
            Ellipse[] millions = {million1, twomillion1, threemillion, fourmillion, fivemillion};

            addNum(millions);
            addNum(hundredThousands);
            addNum(tenThousands);
            addNum(thousands);
            addNum(hundreds);
            addNum(tens);
            addNum(ones);

            for(int i = 0; i <=6; i++)
            {
                for(int j = 0; j <=4; j++)
                {
                    origanalValues[i, j, 0] = numbers[i, j].RenderTransform.Value.OffsetX;
                    origanalValues[i, j, 1] = numbers[i, j].RenderTransform.Value.OffsetY;
                }
            }
            
            
        }

        public void circleDown(int i, int j)
        {
            TranslateTransform move;
            if (j == 4)
            {
                 move = new TranslateTransform(0, 100);
            }
            else
            {
                 move = new TranslateTransform(0, 0);
            }
            
            numbers[i, j].RenderTransform = move;
        }

        public void circleUp(int i, int j)
        {

            TranslateTransform move;
            if (j == 4)
            {
                move = new TranslateTransform(0, 0);
            }
            else
            {
                move = new TranslateTransform(0, -100);
            }

            numbers[i, j].RenderTransform = move;
        }

        public async Task moveCircle(int[,] arr)
        {
            for(int i = 0; i < arr.Length / 2; i++)
            {
                
                if (arr[i, 0] != 0)
                {
                    await Task.Delay(500);
                    circleDown(i, 4);
                }
                if (arr[i, 1] != 0)
                {
                    for (int j = 0; j < arr[i, 1]; j++)
                    {
                        await Task.Delay(500);
                        circleUp(i, j);
                    }
                }
            }
        }

        public void clear()
        {
            for(int i = 6; i>= 0; i--)
            {
                for(int j = 4; j>= 0; j--)
                {
                    TranslateTransform resetTranslate= new TranslateTransform(origanalValues[i, j, 0], origanalValues[i, j, 0]);
                    numbers[i, j].RenderTransform = resetTranslate;
                }
            }
           //TranslateTransform resetTranslate = new TranslateTransform(origanalValues[i, j, 0], origanalValues[i, j, 0]);
           //numbers[i, j].RenderTransform = resetTranslate;
        }

        public int[,] add(int[,] arr1, int[,] arr2)
        {
            int[,] toplam = new int[7, 2];

            for(int i = 0; i <= 6; i++)
            {
                for(int j = 0; j <=1; j++)
                {
                    toplam[i, j] = arr1[i, j] + arr2[i, j];
                    Console.WriteLine($"arr1{i}:{j}: {arr1[i, j]}");
                    Console.WriteLine($"arr2{i}:{j}: {arr2[i, j]}");
                    Console.WriteLine($"toplam{i}:{j}: {toplam[i, j]}");
                }
            }

            //for (int i = 6; i >= 0; i--)
            //{
            //    if(toplam[i, 0] >= 5)
            //    {
            //        toplam[i, 0] %= 5;
            //        toplam[i, 1]++;
            //    }
            //
            //    if (toplam[i, 1] > 1)
            //    {
            //        toplam[i, 1] = 0;
            //        toplam[i + 1, 0]++;
            //    }
            //
            //}
            return toplam;
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
