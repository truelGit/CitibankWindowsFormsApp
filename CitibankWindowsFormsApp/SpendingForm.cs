﻿using System;
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

						var sum = spendingList.Where(s => s.Value < 0).Sum(s => s.Value);
						var cacheBack = spendingList.Where(s => s.Value > 0 && s.Shop != "ПЕРЕВОД ИЗ ДРУГОГО БАНКА").Sum(s => s.Value);

						foreach (DataGridViewColumn column in dataGridView.Columns)
							column.SortMode = DataGridViewColumnSortMode.Automatic;

						lblSpendings.Text = string.Format(Resources.SpendingForm_btnLoad_Click_Итого_затрат___0_, sum);
						lblCashback.Text = string.Format(Resources.SpendingForm_btnLoad_Click_Итого_кешбека__0_, cacheBack);
					}
				}
				catch (SecurityException ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void dataGridView_SelectionChanged(object sender, EventArgs e)
		{
			var selectedSum = dataGridView.SelectedRows
				.Cast<DataGridViewRow>()
				.Select(r => (decimal)r.Cells["Value"].Value)
				.Where(v => v < 0)
				.Sum();

			lblSelectedSpending.Text = string.Format(Resources.SpendingForm_dataGridView_SelectionChanged_Выбрано_затрат__0_, selectedSum);
		}
	}
}
