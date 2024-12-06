namespace GraphApp
{
    partial class Form1
    {
        /// <summary>
        /// Обов'язковий метод для підтримки конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Звільнення ресурсів.
        /// </summary>
        /// <param name="disposing">true, якщо керовані ресурси потрібно звільнити; інакше false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматично створений конструктором форм Windows

        /// <summary>
        /// Метод ініціалізації компонентів.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "Графік функції";
            this.ResumeLayout(false);
        }

        #endregion
    }
} 