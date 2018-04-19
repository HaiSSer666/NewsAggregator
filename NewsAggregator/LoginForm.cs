﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsAggregator
{
    public partial class LoginForm : Form
    {
        private LoginManager loginManager = LoginManager.Instance;
        public MainForm mainForm = new MainForm();

        public LoginForm()
        {
            InitializeComponent();
            MessageBox.Show("You are not authorised user, Please enter a valid PIN from the generated link.");
        }

        private void ClickLoginButton(object sender, EventArgs e)
        {
            try
            {
                loginManager.LoginWithPIN(textfieldPIN.Text);
                MessageBox.Show("Hello. " + loginManager.userName + "! Now you can use app.");
                this.Hide();
                mainForm.Show();
            }
            catch (System.NullReferenceException ex)
            {
                MessageBox.Show("Error is occured. There might be internet connection lost.\n Try to authenticate one more time.");
                textfieldPIN.Clear();
            }
            catch (Tweetinvi.Exceptions.TwitterNullCredentialsException ex)
            {
                MessageBox.Show("Error is occured. You have entered the wrong PIN.\n Try to authenticate one more time. ");
                textfieldPIN.Clear();
                textfieldPIN.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oops something went wrong.\n Try to authenticate one more time.");
                textfieldPIN.Clear();
                textfieldPIN.Enabled = true;
            }
        }

        private void TextfieldPIN_Changed(object sender, EventArgs e)
        {
            UpdateButtonLogin();
        }

        private void UpdateButtonLogin()
        {
            loginButton.Enabled = textfieldPIN.Text.Trim() != string.Empty;
        }
    }
}
