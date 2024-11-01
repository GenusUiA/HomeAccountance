using System;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Course_project_HOME_ACCOUNTANCE
{
    public partial class Reports : Form
    {
        private DataGridView reportDataGridView;

        // ...

        private void DownloadPdfButton_Click(object sender, EventArgs e)
        {
            // Create a PDF document using iTextSharp
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("report.pdf", FileMode.Create));
            document.Open();

            // Add content to the PDF document
            PdfPTable table = new PdfPTable(reportDataGridView.Columns.Count);
            for (int i = 0; i < reportDataGridView.Columns.Count; i++)
            {
                table.AddCell(new Phrase(reportDataGridView.Columns[i].HeaderText));
            }

            for (int i = 0; i < reportDataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < reportDataGridView.Columns.Count; j++)
                {
                    table.AddCell(new Phrase(reportDataGridView.Rows[i].Cells[j].Value.ToString()));
                }
            }

            document.Add(table);
            document.Close();

            MessageBox.Show("PDF report generated successfully.");
        }
    }
}