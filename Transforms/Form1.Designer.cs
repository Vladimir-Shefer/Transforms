namespace Transforms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_COM_port = new System.Windows.Forms.ComboBox();
            this.comboBox_COM_speed = new System.Windows.Forms.ComboBox();
            this.Find_COM_button = new System.Windows.Forms.Button();
            this.fixate_COM_Name_and_Speed = new System.Windows.Forms.Button();
            this.Open_Serial_Port_button = new System.Windows.Forms.Button();
            this.Close_Serial_Port_button = new System.Windows.Forms.Button();
            this.avg_richTextBox_1 = new System.Windows.Forms.RichTextBox();
            this.avg_richTextBox_2 = new System.Windows.Forms.RichTextBox();
            this.avg_richTextBox_3 = new System.Windows.Forms.RichTextBox();
            this.avg_richTextBox_4 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Send_Data_button = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel_with_fields1 = new Transforms.Panel_with_fields();
            this.data_Carrier_Container1 = new Transforms.Data_Carrier_Container();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM порт";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Скорость";
            // 
            // comboBox_COM_port
            // 
            this.comboBox_COM_port.FormattingEnabled = true;
            this.comboBox_COM_port.Location = new System.Drawing.Point(39, 46);
            this.comboBox_COM_port.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_COM_port.Name = "comboBox_COM_port";
            this.comboBox_COM_port.Size = new System.Drawing.Size(133, 23);
            this.comboBox_COM_port.TabIndex = 2;
            // 
            // comboBox_COM_speed
            // 
            this.comboBox_COM_speed.FormattingEnabled = true;
            this.comboBox_COM_speed.Location = new System.Drawing.Point(39, 142);
            this.comboBox_COM_speed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_COM_speed.Name = "comboBox_COM_speed";
            this.comboBox_COM_speed.Size = new System.Drawing.Size(133, 23);
            this.comboBox_COM_speed.TabIndex = 3;
            this.comboBox_COM_speed.Text = "115200";
            // 
            // Find_COM_button
            // 
            this.Find_COM_button.Location = new System.Drawing.Point(207, 46);
            this.Find_COM_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Find_COM_button.Name = "Find_COM_button";
            this.Find_COM_button.Size = new System.Drawing.Size(134, 43);
            this.Find_COM_button.TabIndex = 4;
            this.Find_COM_button.Text = "Найти доступные COM";
            this.Find_COM_button.UseVisualStyleBackColor = true;
            this.Find_COM_button.Click += new System.EventHandler(this.Find_COM_button_Click);
            // 
            // fixate_COM_Name_and_Speed
            // 
            this.fixate_COM_Name_and_Speed.Location = new System.Drawing.Point(207, 141);
            this.fixate_COM_Name_and_Speed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fixate_COM_Name_and_Speed.Name = "fixate_COM_Name_and_Speed";
            this.fixate_COM_Name_and_Speed.Size = new System.Drawing.Size(134, 46);
            this.fixate_COM_Name_and_Speed.TabIndex = 5;
            this.fixate_COM_Name_and_Speed.Text = "Задать порт и скорость";
            this.fixate_COM_Name_and_Speed.UseVisualStyleBackColor = true;
            this.fixate_COM_Name_and_Speed.Click += new System.EventHandler(this.fixate_COM_Name_and_Speed_Click);
            // 
            // Open_Serial_Port_button
            // 
            this.Open_Serial_Port_button.Location = new System.Drawing.Point(45, 228);
            this.Open_Serial_Port_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Open_Serial_Port_button.Name = "Open_Serial_Port_button";
            this.Open_Serial_Port_button.Size = new System.Drawing.Size(82, 70);
            this.Open_Serial_Port_button.TabIndex = 6;
            this.Open_Serial_Port_button.Text = "открыть порт";
            this.Open_Serial_Port_button.UseVisualStyleBackColor = true;
            this.Open_Serial_Port_button.Click += new System.EventHandler(this.Open_Serial_Port_button_Click);
            // 
            // Close_Serial_Port_button
            // 
            this.Close_Serial_Port_button.Location = new System.Drawing.Point(164, 228);
            this.Close_Serial_Port_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Close_Serial_Port_button.Name = "Close_Serial_Port_button";
            this.Close_Serial_Port_button.Size = new System.Drawing.Size(82, 70);
            this.Close_Serial_Port_button.TabIndex = 7;
            this.Close_Serial_Port_button.Text = "закрыть порт";
            this.Close_Serial_Port_button.UseVisualStyleBackColor = true;
            this.Close_Serial_Port_button.Click += new System.EventHandler(this.Close_Serial_Port_button_Click);
            // 
            // avg_richTextBox_1
            // 
            this.avg_richTextBox_1.Location = new System.Drawing.Point(388, 24);
            this.avg_richTextBox_1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.avg_richTextBox_1.Name = "avg_richTextBox_1";
            this.avg_richTextBox_1.Size = new System.Drawing.Size(110, 125);
            this.avg_richTextBox_1.TabIndex = 8;
            this.avg_richTextBox_1.Text = "";
            // 
            // avg_richTextBox_2
            // 
            this.avg_richTextBox_2.Location = new System.Drawing.Point(551, 24);
            this.avg_richTextBox_2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.avg_richTextBox_2.Name = "avg_richTextBox_2";
            this.avg_richTextBox_2.Size = new System.Drawing.Size(110, 125);
            this.avg_richTextBox_2.TabIndex = 9;
            this.avg_richTextBox_2.Text = "";
            // 
            // avg_richTextBox_3
            // 
            this.avg_richTextBox_3.Location = new System.Drawing.Point(388, 192);
            this.avg_richTextBox_3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.avg_richTextBox_3.Name = "avg_richTextBox_3";
            this.avg_richTextBox_3.Size = new System.Drawing.Size(110, 125);
            this.avg_richTextBox_3.TabIndex = 10;
            this.avg_richTextBox_3.Text = "";
            // 
            // avg_richTextBox_4
            // 
            this.avg_richTextBox_4.Location = new System.Drawing.Point(551, 192);
            this.avg_richTextBox_4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.avg_richTextBox_4.Name = "avg_richTextBox_4";
            this.avg_richTextBox_4.Size = new System.Drawing.Size(110, 125);
            this.avg_richTextBox_4.TabIndex = 11;
            this.avg_richTextBox_4.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(354, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(354, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(518, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(518, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "4";
            // 
            // Send_Data_button
            // 
            this.Send_Data_button.Location = new System.Drawing.Point(774, 229);
            this.Send_Data_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Send_Data_button.Name = "Send_Data_button";
            this.Send_Data_button.Size = new System.Drawing.Size(82, 69);
            this.Send_Data_button.TabIndex = 16;
            this.Send_Data_button.Text = "отправить данные";
            this.Send_Data_button.UseVisualStyleBackColor = true;
            this.Send_Data_button.Click += new System.EventHandler(this.Send_Data_button_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(761, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(572, 181);
            this.panel1.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(963, 229);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 22);
            this.button1.TabIndex = 18;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel_with_fields1
            // 
            this.panel_with_fields1.Location = new System.Drawing.Point(508, 405);
            this.panel_with_fields1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_with_fields1.Name = "panel_with_fields1";
            this.panel_with_fields1.Size = new System.Drawing.Size(678, 99);
            this.panel_with_fields1.TabIndex = 19;
            // 
            // data_Carrier_Container1
            // 
            this.data_Carrier_Container1.BackColor = System.Drawing.Color.Transparent;
            this.data_Carrier_Container1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("data_Carrier_Container1.BackgroundImage")));
            this.data_Carrier_Container1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.data_Carrier_Container1.Location = new System.Drawing.Point(96, 405);
            this.data_Carrier_Container1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.data_Carrier_Container1.Name = "data_Carrier_Container1";
            this.data_Carrier_Container1.Size = new System.Drawing.Size(206, 40);
            this.data_Carrier_Container1.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Transforms.Properties.Resources.сук;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1344, 564);
            this.Controls.Add(this.data_Carrier_Container1);
            this.Controls.Add(this.panel_with_fields1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Send_Data_button);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.avg_richTextBox_4);
            this.Controls.Add(this.avg_richTextBox_3);
            this.Controls.Add(this.avg_richTextBox_2);
            this.Controls.Add(this.avg_richTextBox_1);
            this.Controls.Add(this.Close_Serial_Port_button);
            this.Controls.Add(this.Open_Serial_Port_button);
            this.Controls.Add(this.fixate_COM_Name_and_Speed);
            this.Controls.Add(this.Find_COM_button);
            this.Controls.Add(this.comboBox_COM_speed);
            this.Controls.Add(this.comboBox_COM_port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox comboBox_COM_port;
        private ComboBox comboBox_COM_speed;
        private Button Find_COM_button;
        private Button fixate_COM_Name_and_Speed;
        private Button Open_Serial_Port_button;
        private Button Close_Serial_Port_button;
        private RichTextBox avg_richTextBox_1;
        private RichTextBox avg_richTextBox_2;
        private RichTextBox avg_richTextBox_3;
        private RichTextBox avg_richTextBox_4;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button Send_Data_button;
        private Panel panel1;
        private Button button1;
        private Panel_with_fields panel_with_fields1;
        private Data_Carrier_Container data_Carrier_Container1;
    }
}