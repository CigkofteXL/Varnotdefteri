namespace Varbotdefteri
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
            notekle = new Button();
            notsil = new Button();
            notyaz = new TextBox();
            notlar = new ListBox();
            alldelete = new Button();
            SuspendLayout();
            // 
            // notekle
            // 
            notekle.Anchor = AnchorStyles.Top;
            notekle.BackColor = Color.Transparent;
            notekle.ForeColor = Color.Black;
            notekle.Location = new Point(695, 157);
            notekle.Name = "notekle";
            notekle.Size = new Size(75, 23);
            notekle.TabIndex = 1;
            notekle.Text = "ekle";
            notekle.UseVisualStyleBackColor = false;
            notekle.Click += notekle_Click;
            // 
            // notsil
            // 
            notsil.Anchor = AnchorStyles.Top;
            notsil.BackColor = Color.Transparent;
            notsil.ForeColor = Color.Black;
            notsil.Location = new Point(776, 157);
            notsil.Name = "notsil";
            notsil.Size = new Size(75, 23);
            notsil.TabIndex = 2;
            notsil.Text = "sil";
            notsil.UseVisualStyleBackColor = false;
            notsil.Click += notsil_Click;
            // 
            // notyaz
            // 
            notyaz.Anchor = AnchorStyles.Top;
            notyaz.ForeColor = SystemColors.WindowText;
            notyaz.Location = new Point(442, 158);
            notyaz.Name = "notyaz";
            notyaz.Size = new Size(171, 23);
            notyaz.TabIndex = 3;
            notyaz.TextChanged += notyaz_TextChanged;
            // 
            // notlar
            // 
            notlar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            notlar.BackColor = SystemColors.InfoText;
            notlar.ForeColor = SystemColors.Window;
            notlar.FormattingEnabled = true;
            notlar.ItemHeight = 15;
            notlar.Items.AddRange(new object[] { "notların burada gözükür bu notu silip başlığı kendin atmak istersen yeni bir not ekleyip 0 sil yaparak başlık ayarlayabilirsin" });
            notlar.Location = new Point(152, 257);
            notlar.Name = "notlar";
            notlar.Size = new Size(944, 499);
            notlar.TabIndex = 5;
            notlar.SelectedIndexChanged += notlar_SelectedIndexChanged;
            // 
            // alldelete
            // 
            alldelete.Anchor = AnchorStyles.Top;
            alldelete.BackColor = Color.Transparent;
            alldelete.ForeColor = Color.Black;
            alldelete.Location = new Point(857, 158);
            alldelete.Name = "alldelete";
            alldelete.Size = new Size(83, 24);
            alldelete.TabIndex = 6;
            alldelete.Text = "hepsini sil";
            alldelete.UseVisualStyleBackColor = false;
            alldelete.Click += alldelete_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1229, 798);
            Controls.Add(notyaz);
            Controls.Add(notekle);
            Controls.Add(notsil);
            Controls.Add(alldelete);
            Controls.Add(notlar);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Varnotdefteri";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            Enter += Form1_Enter;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button notekle;
        private Button notsil;
        private TextBox notyaz;
        private ListBox notlar;
        private Button alldelete;
    }
}
