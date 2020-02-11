namespace CitibankWindowsFormsApp
{
	partial class SpendingForm
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
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblSelectedSpending = new System.Windows.Forms.Label();
			this.lblCashback = new System.Windows.Forms.Label();
			this.lblSpendings = new System.Windows.Forms.Label();
			this.btnLoad = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridView
			// 
			this.dataGridView.AllowUserToOrderColumns = true;
			this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView.Location = new System.Drawing.Point(0, 31);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.ReadOnly = true;
			this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView.Size = new System.Drawing.Size(800, 419);
			this.dataGridView.TabIndex = 0;
			this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblSelectedSpending);
			this.panel1.Controls.Add(this.lblCashback);
			this.panel1.Controls.Add(this.lblSpendings);
			this.panel1.Controls.Add(this.btnLoad);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(800, 31);
			this.panel1.TabIndex = 1;
			// 
			// lblSelectedSpending
			// 
			this.lblSelectedSpending.AutoSize = true;
			this.lblSelectedSpending.Location = new System.Drawing.Point(410, 9);
			this.lblSelectedSpending.Name = "lblSelectedSpending";
			this.lblSelectedSpending.Size = new System.Drawing.Size(89, 13);
			this.lblSelectedSpending.TabIndex = 3;
			this.lblSelectedSpending.Text = "Выбрано затрат";
			// 
			// lblCashback
			// 
			this.lblCashback.AutoSize = true;
			this.lblCashback.Location = new System.Drawing.Point(244, 9);
			this.lblCashback.Name = "lblCashback";
			this.lblCashback.Size = new System.Drawing.Size(84, 13);
			this.lblCashback.TabIndex = 2;
			this.lblCashback.Text = "Итого кешбека";
			// 
			// lblSpendings
			// 
			this.lblSpendings.AutoSize = true;
			this.lblSpendings.Location = new System.Drawing.Point(94, 9);
			this.lblSpendings.Name = "lblSpendings";
			this.lblSpendings.Size = new System.Drawing.Size(74, 13);
			this.lblSpendings.TabIndex = 1;
			this.lblSpendings.Text = "Итого затрат";
			// 
			// btnLoad
			// 
			this.btnLoad.Location = new System.Drawing.Point(13, 4);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(75, 23);
			this.btnLoad.TabIndex = 0;
			this.btnLoad.Text = "Load";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// SpendingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.dataGridView);
			this.Controls.Add(this.panel1);
			this.Name = "SpendingForm";
			this.Text = "Анализ трат Ситибанк";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.Label lblSpendings;
		private System.Windows.Forms.Label lblCashback;
		private System.Windows.Forms.Label lblSelectedSpending;
	}
}

