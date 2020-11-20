namespace WindowsFormsOrderSystem
{
    partial class StartUpForm
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
            this._tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._customerButton = new System.Windows.Forms.Button();
            this._restaurantButton = new System.Windows.Forms.Button();
            this._exitButton = new System.Windows.Forms.Button();
            this._tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tableLayoutPanel
            // 
            this._tableLayoutPanel.ColumnCount = 4;
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tableLayoutPanel.Controls.Add(this._customerButton, 0, 0);
            this._tableLayoutPanel.Controls.Add(this._restaurantButton, 2, 0);
            this._tableLayoutPanel.Controls.Add(this._exitButton, 3, 1);
            this._tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this._tableLayoutPanel.Name = "_tableLayoutPanel";
            this._tableLayoutPanel.RowCount = 2;
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel.Size = new System.Drawing.Size(554, 142);
            this._tableLayoutPanel.TabIndex = 0;
            // 
            // _customerButton
            // 
            this._customerButton.AccessibleName = "CustomerSideFormButton";
            this._tableLayoutPanel.SetColumnSpan(this._customerButton, 2);
            this._customerButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._customerButton.Location = new System.Drawing.Point(3, 3);
            this._customerButton.Name = "_customerButton";
            this._customerButton.Size = new System.Drawing.Size(270, 65);
            this._customerButton.TabIndex = 0;
            this._customerButton.Text = "Frontend(customer)";
            this._customerButton.UseVisualStyleBackColor = true;
            this._customerButton.Click += new System.EventHandler(this.ClickCustomerButton);
            // 
            // _restaurantButton
            // 
            this._restaurantButton.AccessibleName = "RestaurantSideFormButton";
            this._tableLayoutPanel.SetColumnSpan(this._restaurantButton, 2);
            this._restaurantButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._restaurantButton.Location = new System.Drawing.Point(279, 3);
            this._restaurantButton.Name = "_restaurantButton";
            this._restaurantButton.Size = new System.Drawing.Size(272, 65);
            this._restaurantButton.TabIndex = 1;
            this._restaurantButton.Text = "Backend(restaurant)";
            this._restaurantButton.UseVisualStyleBackColor = true;
            this._restaurantButton.Click += new System.EventHandler(this.ClickRestaurantButton);
            // 
            // _exitButton
            // 
            this._exitButton.AccessibleName = "ExitButton";
            this._exitButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._exitButton.Location = new System.Drawing.Point(417, 74);
            this._exitButton.Name = "_exitButton";
            this._exitButton.Size = new System.Drawing.Size(134, 65);
            this._exitButton.TabIndex = 2;
            this._exitButton.Text = "Exit";
            this._exitButton.UseVisualStyleBackColor = true;
            this._exitButton.Click += new System.EventHandler(this.ClickExitButton);
            // 
            // StartUpForm
            // 
            this.AccessibleName = "StartUpForm";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 142);
            this.Controls.Add(this._tableLayoutPanel);
            this.Name = "StartUpForm";
            this.Text = "StartUpForm";
            this._tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel;
        private System.Windows.Forms.Button _customerButton;
        private System.Windows.Forms.Button _restaurantButton;
        private System.Windows.Forms.Button _exitButton;
    }
}