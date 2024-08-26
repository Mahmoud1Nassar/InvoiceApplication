using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace InvoiceApplication
{
    public partial class Form1 : Form
    {
        private DatabaseSetup dbSetup;

        public Form1()
        {
            InitializeComponent();
            dbSetup = new DatabaseSetup();
            dbSetup.CreateDatabase();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set initial placeholder text
            SetPlaceholders();
            LoadInvoices();
        }

        private void SetPlaceholders()
        {
            SetPlaceholder(txtCustomerID, "Customer ID");
            SetPlaceholder(txtCustomerName, "Customer Name");
            SetPlaceholder(txtTotalAmount, "Total Amount");
            SetPlaceholder(txtTotalPrice, "Total Price");
            SetPlaceholder(txtDiscount, "Discount");
            SetPlaceholder(txtPlateNumber, "Plate Number");
            SetPlaceholder(txtPaymentType, "Payment Type");
        }

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;
        }

        private void RemovePlaceholder(TextBox textBox, string placeholder)
        {
            if (textBox.Text == placeholder)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }

        private void LoadInvoices()
        {
            using (SQLiteConnection conn = dbSetup.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Invoices";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridViewInvoices.DataSource = dt;
            }
        }

        private void btnAddInvoice_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = dbSetup.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO Invoices 
                                (CustomerID, CustomerName, TotalAmount, TotalPrice, Discount, Date, Time, PlateNumber, PaymentType) 
                                VALUES 
                                (@CustomerID, @CustomerName, @TotalAmount, @TotalPrice, @Discount, @Date, @Time, @PlateNumber, @PaymentType)";

                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerID", txtCustomerID.Text);
                cmd.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                cmd.Parameters.AddWithValue("@TotalAmount", Convert.ToDouble(txtTotalAmount.Text));
                cmd.Parameters.AddWithValue("@TotalPrice", Convert.ToDouble(txtTotalPrice.Text));
                cmd.Parameters.AddWithValue("@Discount", Convert.ToDouble(txtDiscount.Text));
                cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Time", DateTime.Now.ToString("HH:mm:ss"));
                cmd.Parameters.AddWithValue("@PlateNumber", txtPlateNumber.Text);
                cmd.Parameters.AddWithValue("@PaymentType", txtPaymentType.Text);

                cmd.ExecuteNonQuery();

                LoadInvoices(); // Refresh the DataGridView
            }
        }

        private void btnDeleteInvoice_Click(object sender, EventArgs e)
        {
            if (dataGridViewInvoices.SelectedRows.Count > 0)
            {
                int invoiceID = Convert.ToInt32(dataGridViewInvoices.SelectedRows[0].Cells["InvoiceID"].Value);

                using (SQLiteConnection conn = dbSetup.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM Invoices WHERE InvoiceID = @InvoiceID";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@InvoiceID", invoiceID);
                    cmd.ExecuteNonQuery();
                }

                LoadInvoices(); // Refresh the DataGridView
            }
            else
            {
                MessageBox.Show("Please select an invoice to delete.");
            }
        }

        private void btnPreviewInvoice_Click(object sender, EventArgs e)
        {
            if (dataGridViewInvoices.SelectedRows.Count > 0)
            {
                int invoiceID = Convert.ToInt32(dataGridViewInvoices.SelectedRows[0].Cells["InvoiceID"].Value);

                PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
                printPreviewDialog.Document = CreatePrintDocument(invoiceID);
                printPreviewDialog.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select an invoice to preview.");
            }
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            if (dataGridViewInvoices.SelectedRows.Count > 0)
            {
                int invoiceID = Convert.ToInt32(dataGridViewInvoices.SelectedRows[0].Cells["InvoiceID"].Value);

                PrintDialog printDialog = new PrintDialog();
                var printDocument = CreatePrintDocument(invoiceID);

                printDialog.Document = printDocument;
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
            else
            {
                MessageBox.Show("Please select an invoice to print.");
            }
        }

        private System.Drawing.Printing.PrintDocument CreatePrintDocument(int invoiceID)
        {
            var printDocument = new System.Drawing.Printing.PrintDocument();
            printDocument.PrintPage += (sender, e) => PrintInvoice(e, invoiceID);
            return printDocument;
        }

        private void PrintInvoice(System.Drawing.Printing.PrintPageEventArgs e, int invoiceID)
        {
            using (SQLiteConnection conn = dbSetup.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Invoices WHERE InvoiceID = @InvoiceID";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@InvoiceID", invoiceID);
                SQLiteDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string customerName = reader["CustomerName"].ToString();
                    string totalAmount = reader["TotalAmount"].ToString();
                    string totalPrice = reader["TotalPrice"].ToString();
                    string discount = reader["Discount"].ToString();
                    string date = reader["Date"].ToString();
                    string time = reader["Time"].ToString();
                    string plateNumber = reader["PlateNumber"].ToString();
                    string paymentType = reader["PaymentType"].ToString();

                    e.Graphics.DrawString("Invoice", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(100, 100));
                    e.Graphics.DrawString($"Customer Name: {customerName}", new Font("Arial", 12), Brushes.Black, new PointF(100, 150));
                    e.Graphics.DrawString($"Total Amount: {totalAmount}", new Font("Arial", 12), Brushes.Black, new PointF(100, 180));
                    e.Graphics.DrawString($"Total Price: {totalPrice}", new Font("Arial", 12), Brushes.Black, new PointF(100, 210));
                    e.Graphics.DrawString($"Discount: {discount}", new Font("Arial", 12), Brushes.Black, new PointF(100, 240));
                    e.Graphics.DrawString($"Date: {date}", new Font("Arial", 12), Brushes.Black, new PointF(100, 270));
                    e.Graphics.DrawString($"Time: {time}", new Font("Arial", 12), Brushes.Black, new PointF(100, 300));
                    e.Graphics.DrawString($"Plate Number: {plateNumber}", new Font("Arial", 12), Brushes.Black, new PointF(100, 330));
                    e.Graphics.DrawString($"Payment Type: {paymentType}", new Font("Arial", 12), Brushes.Black, new PointF(100, 360));
                }
            }
        }

        private void txtCustomerID_GotFocus(object sender, EventArgs e)
        {
            RemovePlaceholder(txtCustomerID, "Customer ID");
        }

        private void txtCustomerID_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerID.Text))
            {
                SetPlaceholder(txtCustomerID, "Customer ID");
            }
        }

        private void txtCustomerName_GotFocus(object sender, EventArgs e)
        {
            RemovePlaceholder(txtCustomerName, "Customer Name");
        }

        private void txtCustomerName_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                SetPlaceholder(txtCustomerName, "Customer Name");
            }
        }

        private void txtTotalAmount_GotFocus(object sender, EventArgs e)
        {
            RemovePlaceholder(txtTotalAmount, "Total Amount");
        }

        private void txtTotalAmount_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTotalAmount.Text))
            {
                SetPlaceholder(txtTotalAmount, "Total Amount");
            }
        }

        private void txtTotalPrice_GotFocus(object sender, EventArgs e)
        {
            RemovePlaceholder(txtTotalPrice, "Total Price");
        }

        private void txtTotalPrice_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTotalPrice.Text))
            {
                SetPlaceholder(txtTotalPrice, "Total Price");
            }
        }

        private void txtDiscount_GotFocus(object sender, EventArgs e)
        {
            RemovePlaceholder(txtDiscount, "Discount");
        }

        private void txtDiscount_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDiscount.Text))
            {
                SetPlaceholder(txtDiscount, "Discount");
            }
        }

        private void txtPlateNumber_GotFocus(object sender, EventArgs e)
        {
            RemovePlaceholder(txtPlateNumber, "Plate Number");
        }

        private void txtPlateNumber_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPlateNumber.Text))
            {
                SetPlaceholder(txtPlateNumber, "Plate Number");
            }
        }

        private void txtPaymentType_GotFocus(object sender, EventArgs e)
        {
            RemovePlaceholder(txtPaymentType, "Payment Type");
        }

        private void txtPaymentType_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPaymentType.Text))
            {
                SetPlaceholder(txtPaymentType, "Payment Type");
            }
        }
    }
}
