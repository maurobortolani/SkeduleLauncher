using System.Diagnostics;
using System.Text.Json;

namespace SkeduleLauncher
{
    public partial class Form1 : Form
    {
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
            popolaLista();
        }

        private void popolaLista()
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells["Enable"].Value) == true)
                {
                    try
                    {
                        var p = new Process
                        {
                            StartInfo =
                            {
                                FileName = dataGridView1.Rows[i].Cells["Programma"].Value.ToString(),
                                WorkingDirectory = dataGridView1.Rows[i].Cells["WorkingDirectory"].Value.ToString(),
                                Arguments = "\"" + dataGridView1.Rows[i].Cells["Arguments"].Value.ToString() + "\""
                            }
                        };
                        p.Start();
                        System.Threading.Thread.Sleep(Convert.ToInt32(dataGridView1.Rows[i].Cells["Pausa"].Value) * 1000);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
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
    }
}