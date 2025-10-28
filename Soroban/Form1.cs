using Soroban;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace Soraban
{
    public partial class Form1 : Form
    {
        SorobanNumber num1 = new SorobanNumber(); // sayi1 int -> SorobanNumber
        SorobanNumber num2 = new SorobanNumber(); // sayi2 int -> SorobanNumber
        SorobanNumber resultSoroban = new SorobanNumber(); // işlemlerden elde edilen sonucun depolanması
        
        public Form1()
        {
            InitializeComponent();
        }
        private void numCheck(object sender, System.EventArgs e)
        {
            num1 = SorobanNumber.FromInt(int.Parse(sayiTextBox1.Text));
            num2 = SorobanNumber.FromInt(int.Parse(sayiTextBox2.Text));

            string message1 = "";
            string message2 = "";

            for (int i = 0; i < 7; i++)
            {
                message1 += num1.Columns[i].UpperBead.ToString();
                message2 += num2.Columns[i].UpperBead.ToString();
            }
            message1 += "\n";
            message2 += "\n";
            for (int i = 0; i < 7; i++)
            {
                message1 += num1.Columns[i].LowerBeads.ToString();
                message2 += num2.Columns[i].LowerBeads.ToString();
            }

            MessageBox.Show($"SorabanNumber1: \n{message1}\n\nSorabanNumber2: \n{message2}");

        }


        /// <summary>
        /// Sayılar soldan sağa olacak şekilde yerleştirilir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        /// 

        int GetValue(BeadColumn c) => c.UpperBead * 5 + c.LowerBeads;
        private  async Task placeFirstNum(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                if (num1.Columns[i].UpperBead == 1)
                    await abacusControl.beadDown(i, 4);
                for (int j = 0; j < num1.Columns[i].LowerBeads; j++)
                {
                    await abacusControl.beadUp(i, j);
                }
            }
            label4.Text = "İşlem: İlk sayı yerleştirildi";

        }

        private async Task  sorobanSum(object sender, EventArgs e)
        {
            int carry = 0;
            int result = 0;
            int digit1 = 0;
            int digit2 = 0;
            int dif = 0;
            int beforeResult = 0;


            for (int i = 0; i < 7; i++) 
            {
                digit1 = GetValue(num1.Columns[i]);
                digit2 = GetValue(num2.Columns[i]);
                result = digit1 + digit2;
                int b = 1; /// Basamaklarda geriye gitmek için kullanılacak yani sola
               
                carry = result / 10;
                result %= 10;

                resultSoroban.Columns[i].UpperBead = result / 5;
                resultSoroban.Columns[i].LowerBeads = result % 5;


                if (resultSoroban.Columns[i].UpperBead == 1)
                {
                    await abacusControl.beadDown(i, 4);
                }
                else if (num1.Columns[i].UpperBead == 1 && resultSoroban.Columns[i].UpperBead == 0)
                {
                    await abacusControl.beadUp(i, 4);
                }

                // 
                dif = resultSoroban.Columns[i].LowerBeads - num1.Columns[i].LowerBeads;
                if (dif < 0)
                {
                    for (int k = num1.Columns[i].LowerBeads - 1; k >= resultSoroban.Columns[i].LowerBeads; k--)
                    {
                        await abacusControl.beadDown(i, k);
                    }
                }
                else if (dif > 0)
                {
                    for (int k = num1.Columns[i].LowerBeads; k < resultSoroban.Columns[i].LowerBeads; k++)
                    {
                        await abacusControl.beadUp(i, k);
                    }

                }


                

                if (carry == 1)
                {
                    beforeResult = GetValue(resultSoroban.Columns[i - 1]);

                    if (beforeResult + 1 == 10)
                    {
                        while (GetValue(resultSoroban.Columns[i - b]) + 1 == 10)
                        {
                            await abacusControl.beadUp(i - b, 4);
                            for (int k = 3; k >= 0; k--)
                            {
                                await abacusControl.beadDown(i - b, k);
                            }

                            resultSoroban.Columns[i - b].UpperBead = 0;
                            resultSoroban.Columns[i - b].LowerBeads = 0;
                            b++;
                        }
                        beforeResult = GetValue(resultSoroban.Columns[i - b]);
                    }

                    if (beforeResult + 1 != 5)
                        await abacusControl.beadUp(i - b, resultSoroban.Columns[i - b].LowerBeads++);

                    else if (beforeResult + 1 == 5)
                    {
                        for (int k = 4; k >= 0; k--)
                        {
                            await abacusControl.beadDown(i - b, k);
                        }
                        resultSoroban.Columns[i - b].LowerBeads = 0;
                        resultSoroban.Columns[i - b].UpperBead = 1;
                    }

                }

                

                

            }
            string message1 = "Result:\n";
            int total = 0;

            for (int i = 0; i < 7; i++)
            {
                message1 += resultSoroban.Columns[i].UpperBead.ToString();
            }
            message1 += "\n";
            for (int i = 0; i < 7; i++)
            {
                message1 += resultSoroban.Columns[i].LowerBeads.ToString();
            }
            label3.Text = message1;

            label4.Text = "İşlem: Toplama işlemi tamamlandı!";
        }

        private bool subsRecursive(int index)
        {
            int digit1 = 0;

            digit1 = num1.Columns[index].UpperBead * 5 + num1.Columns[index].LowerBeads;

            if (digit1 > 0)
                return true;
            else { 
                if (subsRecursive(index - 1))
                {
                    num1.Columns[index].UpperBead = 1;
                    num1.Columns[index].LowerBeads = 4;
                }
                else
                {
                   
                }
            }

            return true;
        }
        private async Task sorobanSubstract()
        {
            int barrow = 0;
            int result = 0;
            int digit1 = 0;
            int digit2 = 0;
            int dif = 0;
            int placeValue = 10; /// Bir sonraki basamağın ondalık değeri

            for (int i = 6; i >= 0; i--)
            {
                digit1 = num1.Columns[i].UpperBead * 5 + num1.Columns[i].LowerBeads;
                digit2 = num2.Columns[i].UpperBead * 5 + num2.Columns[i].LowerBeads;

                if (digit1 - digit2 < 0)
                {
                    if (subsRecursive(i - 1))
                    {
                        digit1 += 10;
                        barrow = -1;
                    }
                    else
                    {
                        subsRecursive(i - 2);
                    }


                }

            }
        }

        private async Task sorobanMultiply()
        {

        }

        private async Task sorobanDivide()
        {

        }

        private async void sumBtn_Click(object sender, EventArgs e)
        {
            num1 = SorobanNumber.FromInt(int.Parse(sayiTextBox1.Text));
            num2 = SorobanNumber.FromInt(int.Parse(sayiTextBox2.Text));

            if (int.Parse(sayiTextBox1.Text) + int.Parse(sayiTextBox2.Text) > 9999999)
            {
                MessageBox.Show("Girdiğiniz sayının toplam değeri 9999999 değerinden daha büyük olamaz lütfen kontrol edip yeni sayı giriniz!");
            }
            else
            {
                await placeFirstNum(sender, e);
                await sorobanSum(sender, e);
            }

                

            // num1 = resultSoroban; Kontrol edilecek
        }

        private void subsBtn_Click(object sender, EventArgs e)
        {
            num1 = SorobanNumber.FromInt(int.Parse(sayiTextBox1.Text));
            num2 = SorobanNumber.FromInt(int.Parse(sayiTextBox2.Text));
        }
    }
}
