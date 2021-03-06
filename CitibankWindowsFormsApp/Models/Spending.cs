﻿using System;
using System.Globalization;

namespace CitibankWindowsFormsApp.Models
{
	public class Spending
	{
		public DateTime Date { get; set; }
		public string Shop { get; set; }
		public decimal Value { get; set; }

		public decimal Sum { get; set; }

		public Spending(string line, decimal sum)
		{
			var tokens = line.Replace("\"", string.Empty).Split(',');
			if (tokens.Length == 4)
			{
				Date = DateTime.Parse(tokens[0], new CultureInfo("ru-RU"));
				Shop = tokens[1];
				Value = decimal.Parse(tokens[2], CultureInfo.InvariantCulture);
				Sum = (Value > 0)? sum : Value + sum;
			}
		}
    }
}
