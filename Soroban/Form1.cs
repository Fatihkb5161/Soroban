using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soroban
{
    public partial class Form1 : Form
    {
        int num1, num2;
        public List<int> number1 = new List<int>();
        public List<int> number2 = new List<int>();
        int[,] number1arr = new int[7, 2];
        int[,] number2arr = new int[7, 2];
        int[,] toplamarr = new int[7, 2];
        public Form1()
        {
            InitializeComponent();
        }

        private void number()
        {
            number1.Clear();
            number2.Clear();
            num1 = Convert.ToInt32(textBox1.Text);
            num2 = Convert.ToInt32(textBox2.Text);
            int division1, division2;



            for (int i = 1000000; i >= 1; i /= 10)
            {
                division1 = num1 / i;
                number1.Add(division1);
                num1 = num1 % i;

                division2 = num2 / i;
                number2.Add(division2);
                num2 = num2 % i;
            }

            
            int counter1 = 0;

            foreach(int num in number1)
            {
                int new_num_division1 = num / 5;
                int new_num_remainder1 = num % 5;
                number1arr[counter1, 0] = new_num_division1;
                number1arr[counter1, 1] = new_num_remainder1;
                counter1++;
            }

            int counter2 = 0;
            foreach (int num in number2)
            {

                int new_num_division2 = num / 5;
                int new_num_remainder2 = num % 5;
                number2arr[counter2, 0] = new_num_division2;
                number2arr[counter2, 1] = new_num_remainder2;
                counter2++;
            }
            
        }


         
        private async void toplaBtn_Click(object sender, EventArgs e)
        {
            userControl21.clear();
            number1.Clear();
            number2.Clear();
            number();
            userControl21.moveCircle(number1arr);
            await Task.Delay(10000);
            toplam();
        }


        private async void toplam()
        {
            //number();
            for (int i = 0; i <= 6; i++)
            {
                int notAdded0 = toplamarr[i, 0];
                int notAdded1 = toplamarr[i, 1];
                toplamarr[i, 0] = number1arr[i, 0] + number2arr[i, 0];
                toplamarr[i, 1] = number1arr[i, 1] + number2arr[i, 1];

                

                try
                {
                    if (toplamarr[i, 0] == 1)
                    {
                        await Task.Delay(500);
                        userControl21.circleDown(i, 4);
                    }
                    if (toplamarr[i, 0] > 1)
                    {
                        toplamarr[i, 0] = 0;
                        await Task.Delay(500);
                        userControl21.circleUp(i, 4);
                        rec(toplamarr, i);
                    }

                    if (toplamarr[i, 1] > 4)
                    {
                        if (toplamarr[i, 0] < 1)
                        {
                            toplamarr[i, 0] += 1;
                            await Task.Delay(500);
                            userControl21.circleDown(i, 4);
                            int remainder = toplamarr[i, 1] %= 5;
                            for (int j = 3; j >= remainder; j--)
                            {
                                await Task.Delay(500);
                                userControl21.circleDown(i, j);
                            }
                        }
                        else
                        {
                            toplamarr[i, 0] = 0;
                            await Task.Delay(500);
                            userControl21.circleUp(i, 4);
                            toplamarr[i, 1] %= 5;
                            for (int j = 0; j <= 3; j++)
                            {
                                if(j <= toplamarr[i, 1] - 1)
                                {
                                    await Task.Delay(500);
                                    userControl21.circleUp(i, j);
                                }
                            }
                            for (int j = 3; j >= 0; j--)
                            {
                                if (j > toplamarr[i, 1] - 1)
                                {
                                    await Task.Delay(500);
                                    userControl21.circleDown(i, j);
                                }
                            }
                            rec(toplamarr, i);
                        }
                    }
                    else
                    {
                        for(int l = 0; l <= toplamarr[i, 1] - 1; l++)
                        {
                            if (l <= toplamarr[i, 1] - 1)
                            {
                                await Task.Delay(500);
                                userControl21.circleUp(i, l);
                            }
                        }

                        for (int l = toplamarr[i, 1] - 1; l >= 0; l--)
                        {
                            if (l > toplamarr[i, 1] - 1)
                            {
                                await Task.Delay(500);
                                userControl21.circleDown(i, l);
                            }
                        }

                    }
                    
                }
                catch { }
                
            }
        }


        private async Task rec(int[,] arr, int i)
        {
            if (arr[i - 1, 1] < 4)
            {
                arr[i - 1, 1] += 1;
                for (int k = 0; k <= 3; k++)
                {
                    if (k < toplamarr[i - 1, 1])
                    {
                        await Task.Delay(500);
                        userControl21.circleUp(i - 1, k);
                    }

                }
                for (int k = 3; k >=0; k--)
                {
                    if (k >= toplamarr[i - 1, 1])
                    {
                        await Task.Delay(500);
                        userControl21.circleDown(i - 1, k);
                    }
                }


            }
            else
            {
                if (arr[i - 1, 0] < 1)
                {
                    arr[i - 1, 0] += 1;
                    await Task.Delay(500);
                    userControl21.circleDown(i - 1, 4);
                    arr[i - 1, 1] = 0;
                    for (int j = 3; j >= 0; j--)
                    {
                        await Task.Delay(500);
                        userControl21.circleDown(i, j);
                    }
                    for (int j = 3; j >= 0; j--)
                    {
                        await Task.Delay(500);
                        userControl21.circleDown(i - 1, j);
                    }

                }
                else
                {
                    arr[i - 1, 0] = 0;
                    await Task.Delay(500);
                    userControl21.circleUp(i - 1, 4);
                    arr[i - 1, 1] = 0;
                    for (int j = 3; j >= 0; j--)
                    {
                        await Task.Delay(500);
                        userControl21.circleDown(i, j);
                    }
                    for (int j = 3; j >= 0; j--)
                    {
                        await Task.Delay(500);
                        userControl21.circleDown(i - 1, j);
                    }
                    rec(arr, i - 1);
                }
            }

        }
            

        
    }
}
