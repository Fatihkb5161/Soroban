using Soroban;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        private async Task placeFirstNum(object sender, EventArgs e)
        {
            for (int i = 6; i >= 0; i--)
            {
                for (int j = 0; j < num1.Columns[i].LowerBeads; j++)
                {
                    abacusControl.beadUp(i, j);
                    await Task.Delay(1000);
                }
                if(num1.Columns[i].UpperBead == 1)
                    abacusControl.beadDown(i, 4);
                    await Task.Delay(1000);
            }
            label4.Text = "İşlem: İlk sayı yerleştirildi";

        }

        private async Task sorobanSum(object sender, EventArgs e)
        {
            int carry = 0;
            int result = 0;
            int digit1 = 0;
            int digit2 = 0;
            int dif = 0;

            for (int i = 6; i >= 0; i--) 
            {
                digit1 = num1.Columns[i].LowerBeads + num1.Columns[i].UpperBead * 5;
                digit2 = num2.Columns[i].LowerBeads + num2.Columns[i].UpperBead * 5;
                result = digit1 + digit2 + carry;

                carry = result / 10;
                result %= 10;

                resultSoroban.Columns[i].UpperBead = result / 5;
                resultSoroban.Columns[i].LowerBeads = result % 5;

                // 
                dif = resultSoroban.Columns[i].LowerBeads - num1.Columns[i].LowerBeads;
                if (dif < 0)
                {
                    for (int k = num1.Columns[i].LowerBeads - 1; k >= resultSoroban.Columns[i].LowerBeads; k--)
                    {
                        await Task.Delay(1000);
                        abacusControl.beadDown(i, k);
                    }
                }
                else if (dif > 0)
                {
                    for (int k = num1.Columns[i].LowerBeads; k < resultSoroban.Columns[i].LowerBeads; k++)
                    {
                        await Task.Delay(1000);
                        abacusControl.beadUp(i, k);
                    }

                }


                if (resultSoroban.Columns[i].UpperBead == 1)
                {
                    await Task.Delay(1000);
                    abacusControl.beadDown(i, 4);
                }
                else if (num1.Columns[i].UpperBead == 1 && resultSoroban.Columns[i].UpperBead == 0)
                {
                    await Task.Delay(1000);
                    abacusControl.beadUp(i, 4);
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
        }

        private async Task sorobanSubstract()
        {

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

            await placeFirstNum(sender, e);
            await sorobanSum(sender, e);
        }
    }
}
