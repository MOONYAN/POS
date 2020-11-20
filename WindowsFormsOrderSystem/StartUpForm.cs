using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsOrderSystem
{
    public partial class StartUpForm : Form
    {
        Model _model;
        public StartUpForm()
        {
            InitializeComponent();
            _model = new Model();
        }

        //handler click exit button
        private void ClickExitButton(object sender, EventArgs e)
        {
            Close();
        }

        //handler close server(frontend button)
        private void CloseRestaurantSideForm(object sender, FormClosedEventArgs e)
        {
            _restaurantButton.Enabled = true;
        }

        //handler close host(frontend button)
        private void CloseCustomerSideForm(object sender, FormClosedEventArgs e)
        {
            _customerButton.Enabled = true;
        }

        //handler click customer(frontend button)
        private void ClickCustomerButton(object sender, EventArgs e)
        {
            Form customerSideForm = new CustomerSideForm(_model);
            customerSideForm.FormClosed += CloseCustomerSideForm;
            customerSideForm.Show();
            _customerButton.Enabled = false;
        }

        //handler click Restaurant(backend button)
        private void ClickRestaurantButton(object sender, EventArgs e)
        {
            Form restaurantSideForm = new RestaurantSideForm(_model);
            restaurantSideForm.FormClosed += CloseRestaurantSideForm;
            restaurantSideForm.Show();
            _restaurantButton.Enabled = false;
        }
    }
}