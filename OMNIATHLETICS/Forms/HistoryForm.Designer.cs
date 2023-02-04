namespace OMNIATHLETICS
{
    partial class HistoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewHistory = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.omniCalculationsDBDataSet = new OMNIATHLETICS.OmniCalculationsDBDataSet();
            this.calculationDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.calculationDataTableAdapter = new OMNIATHLETICS.OmniCalculationsDBDataSetTableAdapters.CalculationDataTableAdapter();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calculatorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calculationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.omniCalculationsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calculationDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewHistory
            // 
            this.dataGridViewHistory.AutoGenerateColumns = false;
            this.dataGridViewHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewHistory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(29)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.calculatorDataGridViewTextBoxColumn,
            this.calculationDataGridViewTextBoxColumn,
            this.equationDataGridViewTextBoxColumn,
            this.resultDataGridViewTextBoxColumn});
            this.dataGridViewHistory.DataSource = this.calculationDataBindingSource;
            this.dataGridViewHistory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(29)))));
            this.dataGridViewHistory.Location = new System.Drawing.Point(78, 100);
            this.dataGridViewHistory.Name = "dataGridViewHistory";
            this.dataGridViewHistory.Size = new System.Drawing.Size(799, 555);
            this.dataGridViewHistory.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 22F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(329, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 35);
            this.label1.TabIndex = 14;
            this.label1.Text = "Calculation History";
            // 
            // omniCalculationsDBDataSet
            // 
            this.omniCalculationsDBDataSet.DataSetName = "OmniCalculationsDBDataSet";
            this.omniCalculationsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // calculationDataBindingSource
            // 
            this.calculationDataBindingSource.DataMember = "CalculationData";
            this.calculationDataBindingSource.DataSource = this.omniCalculationsDBDataSet;
            // 
            // calculationDataTableAdapter
            // 
            this.calculationDataTableAdapter.ClearBeforeFill = true;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // calculatorDataGridViewTextBoxColumn
            // 
            this.calculatorDataGridViewTextBoxColumn.DataPropertyName = "Calculator";
            this.calculatorDataGridViewTextBoxColumn.FillWeight = 101.5228F;
            this.calculatorDataGridViewTextBoxColumn.HeaderText = "Calculator";
            this.calculatorDataGridViewTextBoxColumn.Name = "calculatorDataGridViewTextBoxColumn";
            // 
            // calculationDataGridViewTextBoxColumn
            // 
            this.calculationDataGridViewTextBoxColumn.DataPropertyName = "Calculation";
            this.calculationDataGridViewTextBoxColumn.FillWeight = 99.49239F;
            this.calculationDataGridViewTextBoxColumn.HeaderText = "Calculation";
            this.calculationDataGridViewTextBoxColumn.Name = "calculationDataGridViewTextBoxColumn";
            // 
            // equationDataGridViewTextBoxColumn
            // 
            this.equationDataGridViewTextBoxColumn.DataPropertyName = "Equation";
            this.equationDataGridViewTextBoxColumn.FillWeight = 99.49239F;
            this.equationDataGridViewTextBoxColumn.HeaderText = "Equation";
            this.equationDataGridViewTextBoxColumn.Name = "equationDataGridViewTextBoxColumn";
            // 
            // resultDataGridViewTextBoxColumn
            // 
            this.resultDataGridViewTextBoxColumn.DataPropertyName = "Result";
            this.resultDataGridViewTextBoxColumn.FillWeight = 99.49239F;
            this.resultDataGridViewTextBoxColumn.HeaderText = "Result";
            this.resultDataGridViewTextBoxColumn.Name = "resultDataGridViewTextBoxColumn";
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(970, 699);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewHistory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HistoryForm";
            this.Text = "HistoryForm";
            this.Load += new System.EventHandler(this.HistoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.omniCalculationsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calculationDataBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewHistory;
        private System.Windows.Forms.Label label1;
        private OmniCalculationsDBDataSet omniCalculationsDBDataSet;
        private System.Windows.Forms.BindingSource calculationDataBindingSource;
        private OmniCalculationsDBDataSetTableAdapters.CalculationDataTableAdapter calculationDataTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn calculatorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn calculationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn equationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultDataGridViewTextBoxColumn;
    }
}