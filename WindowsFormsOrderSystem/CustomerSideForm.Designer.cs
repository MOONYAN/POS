namespace WindowsFormsOrderSystem
{
    partial class CustomerSideForm
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
            this._mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this._groupBox = new System.Windows.Forms.GroupBox();
            this._categoryTabControl = new System.Windows.Forms.TabControl();
            this._tabPage = new System.Windows.Forms.TabPage();
            this._mealTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._costLabel = new System.Windows.Forms.Label();
            this._pageTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._pageLabel = new System.Windows.Forms.Label();
            this._lastPageButton = new System.Windows.Forms.Button();
            this._nextPageButton = new System.Windows.Forms.Button();
            this._richTextBox = new System.Windows.Forms.RichTextBox();
            this._delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this._name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._quantity = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
            this._total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._mainTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this._groupBox.SuspendLayout();
            this._categoryTabControl.SuspendLayout();
            this._tabPage.SuspendLayout();
            this._pageTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mainTableLayoutPanel
            // 
            this._mainTableLayoutPanel.ColumnCount = 2;
            this._mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._mainTableLayoutPanel.Controls.Add(this._dataGridView, 1, 0);
            this._mainTableLayoutPanel.Controls.Add(this._groupBox, 0, 0);
            this._mainTableLayoutPanel.Controls.Add(this._costLabel, 1, 1);
            this._mainTableLayoutPanel.Controls.Add(this._pageTableLayoutPanel, 0, 1);
            this._mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this._mainTableLayoutPanel.Name = "_mainTableLayoutPanel";
            this._mainTableLayoutPanel.RowCount = 2;
            this._mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this._mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._mainTableLayoutPanel.Size = new System.Drawing.Size(767, 469);
            this._mainTableLayoutPanel.TabIndex = 0;
            // 
            // _dataGridView
            // 
            this._dataGridView.AccessibleName = "DataGridView";
            this._dataGridView.AllowUserToAddRows = false;
            this._dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._delete,
            this._name,
            this._category,
            this._price,
            this._quantity,
            this._total});
            this._dataGridView.Cursor = System.Windows.Forms.Cursors.Default;
            this._dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGridView.EnableHeadersVisualStyles = false;
            this._dataGridView.Location = new System.Drawing.Point(386, 3);
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.RowHeadersVisible = false;
            this._dataGridView.RowTemplate.Height = 24;
            this._dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dataGridView.Size = new System.Drawing.Size(378, 322);
            this._dataGridView.TabIndex = 6;
            this._dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickDataGridViewCellContent);
            // 
            // _groupBox
            // 
            this._groupBox.Controls.Add(this._categoryTabControl);
            this._groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._groupBox.Location = new System.Drawing.Point(3, 3);
            this._groupBox.Name = "_groupBox";
            this._groupBox.Size = new System.Drawing.Size(377, 322);
            this._groupBox.TabIndex = 4;
            this._groupBox.TabStop = false;
            this._groupBox.Text = "Meals";
            // 
            // _categoryTabControl
            // 
            this._categoryTabControl.Controls.Add(this._tabPage);
            this._categoryTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._categoryTabControl.Location = new System.Drawing.Point(3, 18);
            this._categoryTabControl.Name = "_categoryTabControl";
            this._categoryTabControl.SelectedIndex = 0;
            this._categoryTabControl.Size = new System.Drawing.Size(371, 301);
            this._categoryTabControl.TabIndex = 0;
            this._categoryTabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.SelectTabControl);
            // 
            // _tabPage
            // 
            this._tabPage.Controls.Add(this._mealTableLayoutPanel);
            this._tabPage.Location = new System.Drawing.Point(4, 22);
            this._tabPage.Name = "_tabPage";
            this._tabPage.Padding = new System.Windows.Forms.Padding(3);
            this._tabPage.Size = new System.Drawing.Size(363, 275);
            this._tabPage.TabIndex = 0;
            this._tabPage.Text = "tabPage1";
            this._tabPage.UseVisualStyleBackColor = true;
            // 
            // _mealTableLayoutPanel
            // 
            this._mealTableLayoutPanel.ColumnCount = 3;
            this._mealTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._mealTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._mealTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._mealTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mealTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this._mealTableLayoutPanel.Name = "_mealTableLayoutPanel";
            this._mealTableLayoutPanel.RowCount = 3;
            this._mealTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._mealTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._mealTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._mealTableLayoutPanel.Size = new System.Drawing.Size(357, 269);
            this._mealTableLayoutPanel.TabIndex = 1;
            // 
            // _costLabel
            // 
            this._costLabel.AccessibleName = "CostLabel";
            this._costLabel.AutoSize = true;
            this._costLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._costLabel.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._costLabel.ForeColor = System.Drawing.Color.Red;
            this._costLabel.Location = new System.Drawing.Point(386, 445);
            this._costLabel.Name = "_costLabel";
            this._costLabel.Size = new System.Drawing.Size(378, 24);
            this._costLabel.TabIndex = 8;
            this._costLabel.Text = "Total：";
            // 
            // _pageTableLayoutPanel
            // 
            this._pageTableLayoutPanel.ColumnCount = 3;
            this._pageTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._pageTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._pageTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._pageTableLayoutPanel.Controls.Add(this._pageLabel, 0, 1);
            this._pageTableLayoutPanel.Controls.Add(this._lastPageButton, 1, 1);
            this._pageTableLayoutPanel.Controls.Add(this._nextPageButton, 2, 1);
            this._pageTableLayoutPanel.Controls.Add(this._richTextBox, 0, 0);
            this._pageTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pageTableLayoutPanel.Location = new System.Drawing.Point(3, 331);
            this._pageTableLayoutPanel.Name = "_pageTableLayoutPanel";
            this._pageTableLayoutPanel.RowCount = 2;
            this._pageTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this._pageTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._pageTableLayoutPanel.Size = new System.Drawing.Size(377, 135);
            this._pageTableLayoutPanel.TabIndex = 9;
            // 
            // _pageLabel
            // 
            this._pageLabel.AutoSize = true;
            this._pageLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._pageLabel.ForeColor = System.Drawing.Color.Blue;
            this._pageLabel.Location = new System.Drawing.Point(3, 123);
            this._pageLabel.Name = "_pageLabel";
            this._pageLabel.Size = new System.Drawing.Size(119, 12);
            this._pageLabel.TabIndex = 8;
            this._pageLabel.Text = "label1";
            // 
            // _lastPageButton
            // 
            this._lastPageButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lastPageButton.Location = new System.Drawing.Point(128, 111);
            this._lastPageButton.Name = "_lastPageButton";
            this._lastPageButton.Size = new System.Drawing.Size(119, 21);
            this._lastPageButton.TabIndex = 9;
            this._lastPageButton.Text = "LastPage";
            this._lastPageButton.UseVisualStyleBackColor = true;
            this._lastPageButton.Click += new System.EventHandler(this.ClickLastPageButton);
            // 
            // _nextPageButton
            // 
            this._nextPageButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._nextPageButton.Location = new System.Drawing.Point(253, 111);
            this._nextPageButton.Name = "_nextPageButton";
            this._nextPageButton.Size = new System.Drawing.Size(121, 21);
            this._nextPageButton.TabIndex = 10;
            this._nextPageButton.Text = "NextPage";
            this._nextPageButton.UseVisualStyleBackColor = true;
            this._nextPageButton.Click += new System.EventHandler(this.ClickNextPageButton);
            // 
            // _richTextBox
            // 
            this._pageTableLayoutPanel.SetColumnSpan(this._richTextBox, 3);
            this._richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._richTextBox.Location = new System.Drawing.Point(3, 3);
            this._richTextBox.Name = "_richTextBox";
            this._richTextBox.ReadOnly = true;
            this._richTextBox.Size = new System.Drawing.Size(371, 102);
            this._richTextBox.TabIndex = 11;
            this._richTextBox.Text = "";
            // 
            // _delete
            // 
            this._delete.DataPropertyName = "Delete";
            this._delete.HeaderText = "Delete";
            this._delete.Name = "_delete";
            this._delete.ReadOnly = true;
            this._delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._delete.Text = "X";
            // 
            // _name
            // 
            this._name.DataPropertyName = "Name";
            this._name.HeaderText = "Name";
            this._name.Name = "_name";
            this._name.ReadOnly = true;
            this._name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _category
            // 
            this._category.DataPropertyName = "Category";
            this._category.HeaderText = "Category";
            this._category.Name = "_category";
            this._category.ReadOnly = true;
            this._category.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _price
            // 
            this._price.DataPropertyName = "Price";
            this._price.HeaderText = "Unit Price";
            this._price.Name = "_price";
            this._price.ReadOnly = true;
            this._price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _quantity
            // 
            this._quantity.DataPropertyName = "Quantity";
            this._quantity.HeaderText = "Quantity";
            this._quantity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._quantity.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this._quantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._quantity.Name = "_quantity";
            this._quantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // _total
            // 
            this._total.DataPropertyName = "Subtotal";
            this._total.HeaderText = "Subtotal";
            this._total.Name = "_total";
            this._total.ReadOnly = true;
            this._total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CustomerSideForm
            // 
            this.AccessibleName = "CustomerSideForm";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 469);
            this.Controls.Add(this._mainTableLayoutPanel);
            this.Name = "CustomerSideForm";
            this.Text = "CustomerSideForm";
            this.Load += new System.EventHandler(this.LoadCustomerSideForm);
            this._mainTableLayoutPanel.ResumeLayout(false);
            this._mainTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            this._groupBox.ResumeLayout(false);
            this._categoryTabControl.ResumeLayout(false);
            this._tabPage.ResumeLayout(false);
            this._pageTableLayoutPanel.ResumeLayout(false);
            this._pageTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _mainTableLayoutPanel;
        private System.Windows.Forms.DataGridView _dataGridView;
        private System.Windows.Forms.Label _costLabel;
        private System.Windows.Forms.GroupBox _groupBox;
        private System.Windows.Forms.TableLayoutPanel _pageTableLayoutPanel;
        private System.Windows.Forms.Label _pageLabel;
        private System.Windows.Forms.Button _lastPageButton;
        private System.Windows.Forms.Button _nextPageButton;
        private System.Windows.Forms.RichTextBox _richTextBox;
        private System.Windows.Forms.TabControl _categoryTabControl;
        private System.Windows.Forms.TabPage _tabPage;
        private System.Windows.Forms.TableLayoutPanel _mealTableLayoutPanel;
        private System.Windows.Forms.DataGridViewButtonColumn _delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn _name;
        private System.Windows.Forms.DataGridViewTextBoxColumn _category;
        private System.Windows.Forms.DataGridViewTextBoxColumn _price;
        private DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn _quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn _total;

    }
}