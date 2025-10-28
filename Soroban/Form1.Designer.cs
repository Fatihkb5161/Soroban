using Soroban;
namespace Soraban
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Soroban.AbacusControl abacusControl;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.sayiTextBox1 = new System.Windows.Forms.TextBox();
            this.sayiTextBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sumBtn = new System.Windows.Forms.Button();
            this.subsBtn = new System.Windows.Forms.Button();
            this.mulBtn = new System.Windows.Forms.Button();
            this.divBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.abacusControl = new Soroban.AbacusControl();
            this.SuspendLayout();
            // 
            // sayiTextBox1
            // 
            this.sayiTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sayiTextBox1.Location = new System.Drawing.Point(239, 65);
            this.sayiTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sayiTextBox1.Name = "sayiTextBox1";
            this.sayiTextBox1.Size = new System.Drawing.Size(100, 30);
            this.sayiTextBox1.TabIndex = 0;
            this.sayiTextBox1.Text = "0";
            // 
            // sayiTextBox2
            // 
            this.sayiTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sayiTextBox2.Location = new System.Drawing.Point(239, 112);
            this.sayiTextBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sayiTextBox2.Name = "sayiTextBox2";
            this.sayiTextBox2.Size = new System.Drawing.Size(100, 30);
            this.sayiTextBox2.TabIndex = 1;
            this.sayiTextBox2.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(75, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sayı 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(75, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sayı 2:";
            // 
            // sumBtn
            // 
            this.sumBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sumBtn.Location = new System.Drawing.Point(71, 179);
            this.sumBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sumBtn.Name = "sumBtn";
            this.sumBtn.Size = new System.Drawing.Size(91, 33);
            this.sumBtn.TabIndex = 4;
            this.sumBtn.Text = "+";
            this.sumBtn.UseVisualStyleBackColor = true;
            this.sumBtn.Click += new System.EventHandler(this.sumBtn_Click);
            // 
            // subsBtn
            // 
            this.subsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.subsBtn.Location = new System.Drawing.Point(248, 179);
            this.subsBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.subsBtn.Name = "subsBtn";
            this.subsBtn.Size = new System.Drawing.Size(91, 33);
            this.subsBtn.TabIndex = 11;
            this.subsBtn.Text = "-";
            this.subsBtn.UseVisualStyleBackColor = true;
            this.subsBtn.Click += new System.EventHandler(this.subsBtn_Click);
            // 
            // mulBtn
            // 
            this.mulBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mulBtn.Location = new System.Drawing.Point(71, 246);
            this.mulBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mulBtn.Name = "mulBtn";
            this.mulBtn.Size = new System.Drawing.Size(91, 33);
            this.mulBtn.TabIndex = 12;
            this.mulBtn.Text = "*";
            this.mulBtn.UseVisualStyleBackColor = true;
            // 
            // divBtn
            // 
            this.divBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.divBtn.Location = new System.Drawing.Point(248, 246);
            this.divBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.divBtn.Name = "divBtn";
            this.divBtn.Size = new System.Drawing.Size(91, 33);
            this.divBtn.TabIndex = 13;
            this.divBtn.Text = "/";
            this.divBtn.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(75, 336);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 29);
            this.label3.TabIndex = 14;
            this.label3.Text = "Result:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(568, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 29);
            this.label4.TabIndex = 15;
            this.label4.Text = "İşlem: ";
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(514, 68);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(441, 375);
            this.elementHost1.TabIndex = 10;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.abacusControl;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 497);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.divBtn);
            this.Controls.Add(this.mulBtn);
            this.Controls.Add(this.subsBtn);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.sumBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sayiTextBox2);
            this.Controls.Add(this.sayiTextBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sayiTextBox1;
        private System.Windows.Forms.TextBox sayiTextBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button sumBtn;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.Button showNumber;
        private System.Windows.Forms.Button subsBtn;
        private System.Windows.Forms.Button mulBtn;
        private System.Windows.Forms.Button divBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

