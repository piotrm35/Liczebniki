namespace Liczebniki
{
    partial class Liczebniki_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Liczebniki_Form));
            this.Liczba_textBox = new System.Windows.Forms.TextBox();
            this.Liczebnik_richTextBox = new System.Windows.Forms.RichTextBox();
            this.Przepisz_button = new System.Windows.Forms.Button();
            this.About_button = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // Liczba_textBox
            // 
            this.Liczba_textBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Liczba_textBox.Location = new System.Drawing.Point(12, 12);
            this.Liczba_textBox.Name = "Liczba_textBox";
            this.Liczba_textBox.Size = new System.Drawing.Size(264, 26);
            this.Liczba_textBox.TabIndex = 0;
            this.Liczba_textBox.Text = "Wprowadź kwotę...";
            this.Liczba_textBox.TextChanged += new System.EventHandler(this.Liczba_textBox_TextChanged);
            this.Liczba_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Liczba_textBox_KeyPress);
            // 
            // Liczebnik_richTextBox
            // 
            this.Liczebnik_richTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Liczebnik_richTextBox.Location = new System.Drawing.Point(12, 44);
            this.Liczebnik_richTextBox.Name = "Liczebnik_richTextBox";
            this.Liczebnik_richTextBox.Size = new System.Drawing.Size(353, 113);
            this.Liczebnik_richTextBox.TabIndex = 1;
            this.Liczebnik_richTextBox.Text = "... a tutaj przepiszę ją słownie. :)";
            this.Liczebnik_richTextBox.TextChanged += new System.EventHandler(this.Liczebnik_richTextBox_TextChanged);
            // 
            // Przepisz_button
            // 
            this.Przepisz_button.Location = new System.Drawing.Point(282, 10);
            this.Przepisz_button.Name = "Przepisz_button";
            this.Przepisz_button.Size = new System.Drawing.Size(59, 23);
            this.Przepisz_button.TabIndex = 2;
            this.Przepisz_button.Text = "Przepisz";
            this.Przepisz_button.UseVisualStyleBackColor = true;
            this.Przepisz_button.Click += new System.EventHandler(this.Przepisz_button_Click);
            // 
            // About_button
            // 
            this.About_button.Location = new System.Drawing.Point(347, 10);
            this.About_button.Name = "About_button";
            this.About_button.Size = new System.Drawing.Size(18, 23);
            this.About_button.TabIndex = 3;
            this.About_button.Text = "?";
            this.toolTip1.SetToolTip(this.About_button, "O programie.");
            this.About_button.UseVisualStyleBackColor = true;
            this.About_button.Click += new System.EventHandler(this.About_button_Click);
            // 
            // Liczebniki_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 169);
            this.Controls.Add(this.About_button);
            this.Controls.Add(this.Przepisz_button);
            this.Controls.Add(this.Liczebnik_richTextBox);
            this.Controls.Add(this.Liczba_textBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Liczebniki_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liczebniki v. 0.3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Liczba_textBox;
        private System.Windows.Forms.RichTextBox Liczebnik_richTextBox;
        private System.Windows.Forms.Button Przepisz_button;
        private System.Windows.Forms.Button About_button;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

