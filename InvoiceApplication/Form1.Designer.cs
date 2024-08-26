namespace InvoiceApplication
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewInvoices;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtPlateNumber;
        private System.Windows.Forms.TextBox txtPaymentType;
        private System.Windows.Forms.Button btnAddInvoice;
        private System.Windows.Forms.Button btnDeleteInvoice;
        private System.Windows.Forms.Button btnPreviewInvoice;
        private System.Windows.Forms.Button btnPrintInvoice;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridViewInvoices = new System.Windows.Forms.DataGridView();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtPlateNumber = new System.Windows.Forms.TextBox();
            this.txtPaymentType = new System.Windows.Forms.TextBox();
            this.btnAddInvoice = new System.Windows.Forms.Button();
            this.btnDeleteInvoice = new System.Windows.Forms.Button();
            this.btnPreviewInvoice = new System.Windows.Forms.Button();
            this.btnPrintInvoice = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInvoices)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewInvoices
            // 
            this.dataGridViewInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInvoices.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewInvoices.Name = "dataGridViewInvoices";
            this.dataGridViewInvoices.Size = new System.Drawing.Size(776, 250);
            this.dataGridViewInvoices.TabIndex = 0;
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Location = new System.Drawing.Point(12, 280);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(100, 20);
            this.txtCustomerID.TabIndex = 1;
            this.txtCustomerID.GotFocus += new System.EventHandler(this.txtCustomerID_GotFocus);
            this.txtCustomerID.LostFocus += new System.EventHandler(this.txtCustomerID_LostFocus);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(118, 280);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(100, 20);
            this.txtCustomerName.TabIndex = 2;
            this.txtCustomerName.GotFocus += new System.EventHandler(this.txtCustomerName_GotFocus);
            this.txtCustomerName.LostFocus += new System.EventHandler(this.txtCustomerName_LostFocus);
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(224, 280);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(100, 20);
            this.txtTotalAmount.TabIndex = 3;
            this.txtTotalAmount.GotFocus += new System.EventHandler(this.txtTotalAmount_GotFocus);
            this.txtTotalAmount.LostFocus += new System.EventHandler(this.txtTotalAmount_LostFocus);
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(330, 280);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(100, 20);
            this.txtTotalPrice.TabIndex = 4;
            this.txtTotalPrice.GotFocus += new System.EventHandler(this.txtTotalPrice_GotFocus);
            this.txtTotalPrice.LostFocus += new System.EventHandler(this.txtTotalPrice_LostFocus);
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(436, 280);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(100, 20);
            this.txtDiscount.TabIndex = 5;
            this.txtDiscount.GotFocus += new System.EventHandler(this.txtDiscount_GotFocus);
            this.txtDiscount.LostFocus += new System.EventHandler(this.txtDiscount_LostFocus);
            // 
            // txtPlateNumber
            // 
            this.txtPlateNumber.Location = new System.Drawing.Point(542, 280);
            this.txtPlateNumber.Name = "txtPlateNumber";
            this.txtPlateNumber.Size = new System.Drawing.Size(100, 20);
            this.txtPlateNumber.TabIndex = 6;
            this.txtPlateNumber.GotFocus += new System.EventHandler(this.txtPlateNumber_GotFocus);
            this.txtPlateNumber.LostFocus += new System.EventHandler(this.txtPlateNumber_LostFocus);
            // 
            // txtPaymentType
            // 
            this.txtPaymentType.Location = new System.Drawing.Point(648, 280);
            this.txtPaymentType.Name = "txtPaymentType";
            this.txtPaymentType.Size = new System.Drawing.Size(100, 20);
            this.txtPaymentType.TabIndex = 7;
            this.txtPaymentType.GotFocus += new System.EventHandler(this.txtPaymentType_GotFocus);
            this.txtPaymentType.LostFocus += new System.EventHandler(this.txtPaymentType_LostFocus);
            // 
            // btnAddInvoice
            // 
            this.btnAddInvoice.Location = new System.Drawing.Point(348, 310);
            this.btnAddInvoice.Name = "btnAddInvoice";
            this.btnAddInvoice.Size = new System.Drawing.Size(100, 23);
            this.btnAddInvoice.TabIndex = 8;
            this.btnAddInvoice.Text = "Add Invoice";
            this.btnAddInvoice.UseVisualStyleBackColor = true;
            this.btnAddInvoice.Click += new System.EventHandler(this.btnAddInvoice_Click);
            // 
            // btnDeleteInvoice
            // 
            this.btnDeleteInvoice.Location = new System.Drawing.Point(348, 340);
            this.btnDeleteInvoice.Name = "btnDeleteInvoice";
            this.btnDeleteInvoice.Size = new System.Drawing.Size(100, 23);
            this.btnDeleteInvoice.TabIndex = 9;
            this.btnDeleteInvoice.Text = "Delete Invoice";
            this.btnDeleteInvoice.UseVisualStyleBackColor = true;
            this.btnDeleteInvoice.Click += new System.EventHandler(this.btnDeleteInvoice_Click);
            // 
            // btnPreviewInvoice
            // 
            this.btnPreviewInvoice.Location = new System.Drawing.Point(348, 370);
            this.btnPreviewInvoice.Name = "btnPreviewInvoice";
            this.btnPreviewInvoice.Size = new System.Drawing.Size(100, 23);
            this.btnPreviewInvoice.TabIndex = 10;
            this.btnPreviewInvoice.Text = "Preview Invoice";
            this.btnPreviewInvoice.UseVisualStyleBackColor = true;
            this.btnPreviewInvoice.Click += new System.EventHandler(this.btnPreviewInvoice_Click);
            // 
            // btnPrintInvoice
            // 
            this.btnPrintInvoice.Location = new System.Drawing.Point(348, 400);
            this.btnPrintInvoice.Name = "btnPrintInvoice";
            this.btnPrintInvoice.Size = new System.Drawing.Size(100, 23);
            this.btnPrintInvoice.TabIndex = 11;
            this.btnPrintInvoice.Text = "Print Invoice";
            this.btnPrintInvoice.UseVisualStyleBackColor = true;
            this.btnPrintInvoice.Click += new System.EventHandler(this.btnPrintInvoice_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPrintInvoice);
            this.Controls.Add(this.btnPreviewInvoice);
            this.Controls.Add(this.btnDeleteInvoice);
            this.Controls.Add(this.btnAddInvoice);
            this.Controls.Add(this.txtPaymentType);
            this.Controls.Add(this.txtPlateNumber);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.txtTotalPrice);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.txtCustomerID);
            this.Controls.Add(this.dataGridViewInvoices);
            this.Name = "Form1";
            this.Text = "Invoice Application";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInvoices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
