using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemPR4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int counter = 0;
            int curPage=1;

            Font myFont = new Font("Arial", 14, FontStyle.Regular, GraphicsUnit.Pixel);

            string curLine;

            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            float yPos = 0;

            int nPages;
            int nLines;
            int i;

            nLines = (int)(e.MarginBounds.Height / myFont.GetHeight(e.Graphics));

            nPages = (richTextBox1.Lines.Length - 1) / nLines + 1;

            i = 0;

            while ((i < nLines) && (counter < richTextBox1.Lines.Length))
            {
                curLine = richTextBox1.Lines[counter];

                yPos = topMargin + i * myFont.GetHeight(e.Graphics);

                e.Graphics.DrawString(curLine, myFont, Brushes.Blue, leftMargin, yPos, new StringFormat());

                counter++;
                i++;
            }
            e.HasMorePages = false;

            if (curPage < nPages)
            {
                curPage++;
                e.HasMorePages = true;
            }
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //if (printDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    printDocument1.Print();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pageSetupDialog1.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
