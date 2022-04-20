using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject643450647_2
{
    public partial class MainPage : Form
    {
        private string nameRoom = "";
        public DateTime Today { get; private set; }
        public MainPage()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV (*.csv) | *.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] readAllLine = File.ReadAllLines(openFileDialog.FileName);

                string readAllText = File.ReadAllText(openFileDialog.FileName);
                for (int i = 0; i < readAllLine.Length; i++)
                {
                    string allDATARAW = readAllLine[i];
                    string[] allDATASplited = allDATARAW.Split(',');
                    this.dataGridView1.Rows.Add(allDATASplited[0], allDATASplited[1], allDATASplited[2], allDATASplited[3], allDATASplited[4]);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV (*.csv) | *.csv";
                bool fileError = false;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!fileError)
                    {
                        int columnCount = dataGridView1.Columns.Count;
                        string[] outputCSV = new string[dataGridView1.Rows.Count + 1];
                        for (int i = 1; (i - 1) < dataGridView1.Rows.Count; i++)
                        {
                            for (int j = 0; j < columnCount; j++)
                            {
                                if(j == 4)
                                {
                                    outputCSV[i] += dataGridView1.Rows[i - 1].Cells[j].Value.ToString();
                                    break;
                                }
                                outputCSV[i] += dataGridView1.Rows[i - 1].Cells[j].Value.ToString() + ",";
                            }
                            string logFile = saveFileDialog.FileName;
                            string path = Path.Combine(Environment.CurrentDirectory, @"\", logFile);
                            StreamWriter sw = File.AppendText(path);
                            sw.WriteLine(outputCSV[i]);
                            sw.Close();
                        }
                    }
                }
            }
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            textBoxQudays.Text = (dateTimePickerOut.Value - dateTimePickerIn.Value).TotalDays.ToString("#");

            int standard = 2500, superior = 3000, deluxe = 3500, suite = 4000, alltotal;
            int room1 = 0, room2 = 0, room3 = 0, room4 = 0;
            int total1 = 0,total2 = 0, total3 = 0, total4 = 0;
            int days;
            bool QudayCheck;
            QudayCheck = int.TryParse(textBoxQudays.Text, out days);

            if (QudayCheck == true)
            {
                if (checkBoxStandard.Checked == true)
                {
                    nameRoom += " ห้องสเเตนดาร์ด Standard ";
                    room1 = int.Parse(textBoxQuroom1.Text);
                    total1 = (room1 * standard) * days;
                }
                if (checkBoxSuperior.Checked == true)
                {
                    nameRoom += " ห้องซูพีเรีย Superior ";
                    room2 = int.Parse(textBoxQuroom2.Text);
                    total2 = (room2 * superior) * days;
                }
                if (checkBoxDeluxe.Checked == true)
                {
                    nameRoom += " ห้องดีลักซ์ Deluxe ";
                    room3 = int.Parse(textBoxQuroom3.Text);
                    total3 = (room3 * deluxe) * days;
                }
                if (checkBoxSuite.Checked == true)
                {
                    nameRoom += " ห้องสวีท Suite ";
                    room4 = int.Parse(textBoxQuroom4.Text);
                    total4 = (room4 * suite) * days;
                }
                alltotal = total1 + total2 + total3 + total4;
                int allroom = room1 + room2 + room3 + room4;
                textBoxSumroom.Text = alltotal.ToString();
                textBoxQuall.Text = allroom.ToString();
            }
            else if(QudayCheck == false)
            {
                MessageBox.Show("Error");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bill bill = new Bill();
            bill.showbill(e, textBoxBooker.Text, nameRoom, textBoxQuall.Text, textBoxQudays.Text, textBoxSumroom.Text);
        }

        private void buttonBill_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxBooker.Clear();
            dateTimePickerIn.Format = DateTimePickerFormat.Short;
            dateTimePickerOut.Format = DateTimePickerFormat.Short;
            DateTime today = DateTime.Now;
            textBoxQudays.Clear();
            textBoxQuall.Clear();
            textBoxQuroom1.Clear();
            textBoxQuroom2.Clear();
            textBoxQuroom3.Clear();
            textBoxQuroom4.Clear();
            textBoxSumroom.Clear();
            nameRoom = "";
            checkBoxStandard.Checked = false;
            checkBoxSuperior.Checked = false;
            checkBoxDeluxe.Checked = false;
            checkBoxSuite.Checked = false;
        }

        private void button1savedata_Click(object sender, EventArgs e)
        {
            string Booker = textBoxBooker.Text;
            string Days = textBoxQudays.Text;
            string Qudays = textBoxQuall.Text;
            string Sumroom = textBoxSumroom.Text;

            int n = dataGridView1.Rows.Add();

            dataGridView1.Rows[n].Cells[0].Value = Booker;
            dataGridView1.Rows[n].Cells[1].Value = nameRoom;
            dataGridView1.Rows[n].Cells[2].Value = Qudays;
            dataGridView1.Rows[n].Cells[3].Value = Days;
            dataGridView1.Rows[n].Cells[4].Value = Sumroom;
            nameRoom = "";
        }
    }
}
