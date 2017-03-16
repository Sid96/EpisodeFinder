namespace ShowAlerts
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.showNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prevDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prevEpisodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nextDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nextEpisodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.showDBDataSet = new ShowAlerts.ShowDBDataSet();
            this.tableTableAdapter = new ShowAlerts.ShowDBDataSetTableAdapters.TableTableAdapter();
            this.Back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.showNameDataGridViewTextBoxColumn,
            this.prevDateDataGridViewTextBoxColumn,
            this.prevEpisodeDataGridViewTextBoxColumn,
            this.nextDateDataGridViewTextBoxColumn,
            this.nextEpisodeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tableBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(8, 8);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(592, 175);
            this.dataGridView1.TabIndex = 0;
            // 
            // showNameDataGridViewTextBoxColumn
            // 
            this.showNameDataGridViewTextBoxColumn.DataPropertyName = "ShowName";
            this.showNameDataGridViewTextBoxColumn.HeaderText = "ShowName";
            this.showNameDataGridViewTextBoxColumn.Name = "showNameDataGridViewTextBoxColumn";
            // 
            // prevDateDataGridViewTextBoxColumn
            // 
            this.prevDateDataGridViewTextBoxColumn.DataPropertyName = "PrevDate";
            this.prevDateDataGridViewTextBoxColumn.HeaderText = "PrevDate";
            this.prevDateDataGridViewTextBoxColumn.Name = "prevDateDataGridViewTextBoxColumn";
            // 
            // prevEpisodeDataGridViewTextBoxColumn
            // 
            this.prevEpisodeDataGridViewTextBoxColumn.DataPropertyName = "PrevEpisode";
            this.prevEpisodeDataGridViewTextBoxColumn.HeaderText = "PrevEpisode";
            this.prevEpisodeDataGridViewTextBoxColumn.Name = "prevEpisodeDataGridViewTextBoxColumn";
            // 
            // nextDateDataGridViewTextBoxColumn
            // 
            this.nextDateDataGridViewTextBoxColumn.DataPropertyName = "NextDate";
            this.nextDateDataGridViewTextBoxColumn.HeaderText = "NextDate";
            this.nextDateDataGridViewTextBoxColumn.Name = "nextDateDataGridViewTextBoxColumn";
            // 
            // nextEpisodeDataGridViewTextBoxColumn
            // 
            this.nextEpisodeDataGridViewTextBoxColumn.DataPropertyName = "NextEpisode";
            this.nextEpisodeDataGridViewTextBoxColumn.HeaderText = "NextEpisode";
            this.nextEpisodeDataGridViewTextBoxColumn.Name = "nextEpisodeDataGridViewTextBoxColumn";
            // 
            // tableBindingSource
            // 
            this.tableBindingSource.DataMember = "Table";
            this.tableBindingSource.DataSource = this.showDBDataSet;
            // 
            // showDBDataSet
            // 
            this.showDBDataSet.DataSetName = "ShowDBDataSet";
            this.showDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableTableAdapter
            // 
            this.tableTableAdapter.ClearBeforeFill = true;
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(12, 188);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(75, 23);
            this.Back.TabIndex = 1;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 217);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "View TV Shows";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showDBDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private ShowDBDataSet showDBDataSet;
        private System.Windows.Forms.BindingSource tableBindingSource;
        private ShowDBDataSetTableAdapters.TableTableAdapter tableTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn showNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prevDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prevEpisodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nextDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nextEpisodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button Back;
    }
}

