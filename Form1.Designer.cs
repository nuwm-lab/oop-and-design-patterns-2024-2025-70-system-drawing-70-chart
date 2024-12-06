namespace WinFormsApp2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button button1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 10); // Координати кнопки
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30); // Розмір кнопки
            this.button1.TabIndex = 0;
            this.button1.Text = "Redraw"; // Текст кнопки
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click); // Прив’язка події

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600); // Розмір форми
            this.Controls.Add(this.button1); // Додавання кнопки до форми
            this.Name = "Form1";
            this.Text = "Graph Drawer";
            this.ResumeLayout(false);
        }
    }
}
