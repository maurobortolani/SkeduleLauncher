using System.Diagnostics;
using System.Text.Json;

namespace SkeduleLauncher
{
    public partial class Form1 : Form
    {
        public int indexSequence = 0;
        class ProgramToRun
        {
            public string programma;
            public string workingDirectory;
            public string argomento;
            public int secondi;
            public bool enable;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            swichStato();
        }

        private void swichStato()
        {
            if (timer1.Enabled == false)
            {
                indexSequence = 0;
                runNext();
                popolaLista();
                buttonRun.Text = "Stop";
                buttonRun.BackColor = Color.Red;
                //timer1.Enabled = true;
            }
            else
            {
                indexSequence = 0;
                timer1.Enabled = false;
                buttonRun.Text = "Run";
                buttonRun.BackColor = Color.White;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void popolaLista()
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog windows = new SaveFileDialog();
            windows.Filter = "xml files |*.xml";
            windows.FilterIndex = 2;
            windows.RestoreDirectory = true;

            if (windows.ShowDialog() == DialogResult.OK)
            {
                string Stringa = "";
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    ProgramToRun item = new ProgramToRun();
                    item.programma = dataGridView1.Rows[i].Cells["Programma"].Value.ToString();
                    item.workingDirectory = dataGridView1.Rows[i].Cells["WorkingDirectory"].Value.ToString();
                    item.argomento = "\"" + dataGridView1.Rows[i].Cells["Arguments"].Value.ToString() + "\"";
                    item.secondi = Convert.ToInt32(dataGridView1.Rows[i].Cells["Pausa"].Value);
                    item.enable = Convert.ToBoolean(dataGridView1.Rows[i].Cells["Enable"].Value);

                    Stringa += item.programma + "|" +
                                        item.workingDirectory + "|" +
                                        item.argomento + "|" +
                                        item.secondi + "|" +
                                        item.enable + "§";
                }
                File.WriteAllText(windows.FileName, Stringa);
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string Stringa = File.ReadAllText(fileDialog.FileName);
                string[] righe = Stringa.Split('§');

                foreach (string r in righe)
                {
                    try
                    {
                        string[] campi = r.Split('|');
                        campi[2] = campi[2].Trim(new Char[] { '"' });
                        dataGridView1.Rows.Add(campi);
                    }
                    catch { }
                }
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            resize();
        }
        public void resize()
        {
            dataGridView1.Size = new Size(
                this.Width - 150,
                this.Height - 100);
            dataGridView1.Columns[0].Width = (int)(dataGridView1.Width * 0.25);
            dataGridView1.Columns[1].Width = (int)(dataGridView1.Width * 0.25);
            dataGridView1.Columns[2].Width = (int)(dataGridView1.Width * 0.25);
            dataGridView1.Columns[3].Width = (int)(dataGridView1.Width * 0.1);
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            resize();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            runNext();
        }

        private void resetSequence()
        {   
            swichStato();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void runNext()
        {
            if (indexSequence < dataGridView1.RowCount)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[indexSequence].Cells["Enable"].Value) == true)
                {
                    try
                    {
                        var p = new Process
                        {
                            StartInfo =
                            {
                                FileName = dataGridView1.Rows[indexSequence].Cells["Programma"].Value.ToString(),
                                WorkingDirectory = dataGridView1.Rows[indexSequence].Cells["WorkingDirectory"].Value.ToString(),
                                Arguments = "\"" + dataGridView1.Rows[indexSequence].Cells["Arguments"].Value.ToString() + "\""
                            }
                        };
                        p.Start();
                        dataGridView1.Rows[indexSequence].DefaultCellStyle.BackColor = Color.Green;
                        timer1.Interval = Convert.ToInt32(dataGridView1.Rows[indexSequence].Cells["Pausa"].Value) * 1000;    
                        timer1.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                indexSequence++;
            }
            else
            {
                resetSequence();
            }
        }
    }
}