using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Windows.Forms;
using CitibankWindowsFormsApp.Models;
using CitibankWindowsFormsApp.Properties;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace CitibankWindowsFormsApp
{
	public partial class SpendingForm : Form
	{
		private readonly OpenFileDialog _openFileDialog;

		public SpendingForm()
		{
			InitializeComponent();
			_openFileDialog = new OpenFileDialog();
		}

		private void btnLoad_Click(object sender, EventArgs e)
		{
			if (_openFileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					var spendingList = new List<Spending>();
					decimal prevSum = 0;

					using (var streamReader = new StreamReader(_openFileDialog.FileName))
					{
						string line;
						while ((line = streamReader.ReadLine()) != null)
						{
							var spending = new Spending(line, prevSum);
							if(spending.Value <0 )
								prevSum += spending.Value;
							spendingList.Add(spending);
						}

						dataGridView.DataSource = new SortableBindingList<Spending>(spendingList);

						foreach (DataGridViewColumn column in dataGridView.Columns)
							column.SortMode = DataGridViewColumnSortMode.Automatic;

						dataGridView_OnLoad(lblSpendings,
							spendingList, 
							s => s.Value < 0, 
							Resources.SpendingForm_btnLoad_Click_Итого_затрат___0_);

						dataGridView_OnLoad(lblCashback,
							spendingList,
							s => s.Value > 0 && s.Shop != "ПЕРЕВОД ИЗ ДРУГОГО БАНКА",
							Resources.SpendingForm_btnLoad_Click_Итого_кешбека__0_);
					}
				}
				catch (SecurityException ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void dataGridView_OnLoad(Label label, List<Spending> spendingList, Func<Spending, bool> func, string format)
		{
			var sum = spendingList.Where(func).Sum(s => s.Value);
			label.Text = string.Format(format, sum);
		}

		private void dataGridView_SelectionChanged(object sender, EventArgs e)
		{
			updateLabelsOnSelection(lblSelectedCashback, v => v < 0, Resources.SpendingForm_dataGridView_SelectionChanged_Выбрано_затрат__0_);
			updateLabelsOnSelection(lblSelectedCashback, v => v > 0, Resources.SpendingForm_dataGridView_SelectionChanged_Выбрано_кешбека);
		}

		private void updateLabelsOnSelection(Label label, Func<decimal, bool> func, string format)
		{
			var sum = dataGridView.SelectedRows
				.Cast<DataGridViewRow>()
				.Select(r => (decimal)r.Cells["Value"].Value)
				.Where(func)
				.Sum();

			label.Text = string.Format(format, sum);
		}
	}
}
