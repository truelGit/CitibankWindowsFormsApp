using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Windows.Forms;
using CitibankWindowsFormsApp.Models;

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

						var source = new BindingSource {DataSource = spendingList};
						dataGridView.DataSource = source;

						var sum = spendingList.Where(s => s.Value < 0).Sum(s => s.Value);
						var cacheBack = spendingList.Where(s => s.Value > 0 && s.Shop != "ПЕРЕВОД ИЗ ДРУГОГО БАНКА").Sum(s => s.Value);

						lblSpendings.Text = $"Итого затрат: {sum}";
						lblCashback.Text = $"Итого кешбека {cacheBack}";
					}
				}
				catch (SecurityException ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}
	}
}
