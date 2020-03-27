﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class AddNewCarType : Form
    {
        public AddNewCarType()
        {
            InitializeComponent();
        }
        /*
         * When submit button is clicked, the error check is performed to ensure that all fields are filled.
         * If all the fields are filled, the values are added to the database
         */
        private void submitButton_Click(object sender, EventArgs e)
        {
            // Check to ensure all the fields have text
            if (carTypeNameTextBox.Text == "" || dailyFeeTextBox.Text == "" || 
                weeklyFeeTextBox.Text == "" || monthlyFeeTextBox.Text == "" )
            {
                resultLabel.Text = "All fields are required";
                resultLabel.ForeColor = Color.FromArgb(192, 0, 0); // dark red
                resultLabel.Visible = true;
            }
            else
            {
                String carType = carTypeNameTextBox.Text;
                Double dailyFee = Convert.ToDouble(dailyFeeTextBox.Text);
                Double weeklyFee = Convert.ToDouble(weeklyFeeTextBox.Text);
                Double monthlyFee = Convert.ToDouble(monthlyFeeTextBox.Text);

                resultLabel.Text = "Added successfully to the database!";
                resultLabel.ForeColor = Color.FromArgb(0, 192, 0); // Dark Green
                resultLabel.Visible = true;

                // RUN THE QUERY
            }

        }
        /*
         * The function checks if the user entered value is a number (integer, or a float).
         * The digit is not typed in the textbox if the digit is not an integer or a float
         */
        private void checkForANumber(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
