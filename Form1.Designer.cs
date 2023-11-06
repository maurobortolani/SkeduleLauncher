namespace SkeduleLauncher
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            buttonRun = new Button();
            dataGridView1 = new DataGridView();
            Programma = new DataGridViewTextBoxColumn();
            WorkingDirectory = new DataGridViewTextBoxColumn();
            Arguments = new DataGridViewTextBoxColumn();
            Pausa = new DataGridViewTextBoxColumn();
            Enable = new DataGridViewCheckBoxColumn();
            buttonSave = new Button();
            buttonLoad = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // buttonRun
            // 
            buttonRun.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonRun.Location = new Point(924, 415);
            buttonRun.Name = "buttonRun";
            buttonRun.Size = new Size(75, 23);
            buttonRun.TabIndex = 0;
            buttonRun.Text = "Run";
            buttonRun.UseVisualStyleBackColor = true;
            buttonRun.Click += buttonRun_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Programma, WorkingDirectory, Arguments, Pausa, Enable });
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(863, 426);
            dataGridView1.TabIndex = 1;
            // 
            // Programma
            // 
            Programma.HeaderText = "Percorso Assoluto Programma";
            Programma.MinimumWidth = 6;
            Programma.Name = "Programma";
            Programma.Width = 300;
            // 
            // WorkingDirectory
            // 
            WorkingDirectory.HeaderText = "Directory file";
            WorkingDirectory.MinimumWidth = 6;
            WorkingDirectory.Name = "WorkingDirectory";
            WorkingDirectory.Width = 125;
            // 
            // Arguments
            // 
            Arguments.HeaderText = "Nome File";
            Arguments.MinimumWidth = 6;
            Arguments.Name = "Arguments";
            Arguments.Width = 125;
            // 
            // Pausa
            // 
            Pausa.HeaderText = "Pausa a Seguire [s]";
            Pausa.MinimumWidth = 6;
            Pausa.Name = "Pausa";
            Pausa.Width = 125;
            // 
            // Enable
            // 
            Enable.HeaderText = "Enable";
            Enable.MinimumWidth = 6;
            Enable.Name = "Enable";
            Enable.Width = 125;
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSave.Location = new Point(926, 10);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonLoad
            // 
            buttonLoad.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonLoad.Location = new Point(926, 38);
            buttonLoad.Margin = new Padding(3, 2, 3, 2);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(75, 22);
            buttonLoad.TabIndex = 4;
            buttonLoad.Text = "Load";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1011, 450);
            Controls.Add(buttonLoad);
            Controls.Add(buttonSave);
            Controls.Add(dataGridView1);
            Controls.Add(buttonRun);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Skedule Laucher";
            Load += Form1_Load;
            SizeChanged += Form1_SizeChanged;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonRun;
        private DataGridView dataGridView1;
        private Button buttonSave;
        private Button buttonLoad;
        private DataGridViewTextBoxColumn Programma;
        private DataGridViewTextBoxColumn WorkingDirectory;
        private DataGridViewTextBoxColumn Arguments;
        private DataGridViewTextBoxColumn Pausa;
        private DataGridViewCheckBoxColumn Enable;
        private System.Windows.Forms.Timer timer1;
    }
}