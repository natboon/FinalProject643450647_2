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
    public class Bill
    {
        public void showbill(System.Drawing.Printing.PrintPageEventArgs e, string Booker, string nameRoom, string Quall, string Qudays, string Sumroom)
        {
            e.Graphics.DrawString("ใบเสร็จ", new Font("Microsoft Sans Serif", 20, FontStyle.Underline), Brushes.Blue, new Point(370, 100));
            e.Graphics.DrawString("____________________________________________________", new Font("Microsoft Sans Serif", 16, FontStyle.Underline), Brushes.Black, new Point(75, 150));
            e.Graphics.DrawString("ชื่อ-นามสกุลผู้จอง:  " + Booker, new Font("Microsoft Sans Serif", 16, FontStyle.Underline), Brushes.Black, new Point(100, 200));
            e.Graphics.DrawString("ประเภทห้อง:  " + nameRoom, new Font("Microsoft Sans Serif", 16, FontStyle.Underline), Brushes.Black, new Point(100, 250));
            e.Graphics.DrawString("จำนวนห้อง:  " + Quall, new Font("Microsoft Sans Serif", 16, FontStyle.Underline), Brushes.Black, new Point(100, 300));
            e.Graphics.DrawString("จำนวนวัน:  " + Qudays, new Font("Microsoft Sans Serif", 16, FontStyle.Underline), Brushes.Black, new Point(100, 350));
            e.Graphics.DrawString("ราคาสุทธิ:  " + Sumroom, new Font("Microsoft Sans Serif", 16, FontStyle.Underline), Brushes.Black, new Point(100, 400));
        }
    }
}
