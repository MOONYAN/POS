namespace WindowsFormsOrderSystem
{
    partial class RestaurantSideForm
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
            this._tabControl = new System.Windows.Forms.TabControl();
            this._mealTabPage = new System.Windows.Forms.TabPage();
            this._mealTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._mealListBox = new System.Windows.Forms.ListBox();
            this._addMealModeButton = new System.Windows.Forms.Button();
            this._deleteMealButton = new System.Windows.Forms.Button();
            this._mealGroupBox = new System.Windows.Forms.GroupBox();
            this._mealManagerTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._mealCategoryNameLabel = new System.Windows.Forms.Label();
            this._mealUnitLabel = new System.Windows.Forms.Label();
            this._mealNameTextBox = new System.Windows.Forms.TextBox();
            this._mealAddSaveButton = new System.Windows.Forms.Button();
            this._mealNameLabel = new System.Windows.Forms.Label();
            this._mealPriceLabel = new System.Windows.Forms.Label();
            this._mealPriceTextBox = new System.Windows.Forms.TextBox();
            this._mealCategoryComboBox = new System.Windows.Forms.ComboBox();
            this._mealPathLabel = new System.Windows.Forms.Label();
            this._mealPathTextBox = new System.Windows.Forms.TextBox();
            this._browseButton = new System.Windows.Forms.Button();
            this._mealDescriptionLabel = new System.Windows.Forms.Label();
            this._mealDescriptionTextBox = new System.Windows.Forms.TextBox();
            this._categoryTabPage = new System.Windows.Forms.TabPage();
            this._categoryManagerTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._addCategoryModeButton = new System.Windows.Forms.Button();
            this._deleteCategoryButton = new System.Windows.Forms.Button();
            this._categoryListBox = new System.Windows.Forms.ListBox();
            this._categoryGroupBox = new System.Windows.Forms.GroupBox();
            this._categoryTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._categoryUsedMealListBox = new System.Windows.Forms.ListBox();
            this._categoryNameLabel = new System.Windows.Forms.Label();
            this._usedMealLabel = new System.Windows.Forms.Label();
            this._categoryNameTextBox = new System.Windows.Forms.TextBox();
            this._categoryAddSaveButton = new System.Windows.Forms.Button();
            this._openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._tabControl.SuspendLayout();
            this._mealTabPage.SuspendLayout();
            this._mealTableLayoutPanel.SuspendLayout();
            this._mealGroupBox.SuspendLayout();
            this._mealManagerTableLayoutPanel.SuspendLayout();
            this._categoryTabPage.SuspendLayout();
            this._categoryManagerTableLayoutPanel.SuspendLayout();
            this._categoryGroupBox.SuspendLayout();
            this._categoryTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tabControl
            // 
            this._tabControl.Controls.Add(this._mealTabPage);
            this._tabControl.Controls.Add(this._categoryTabPage);
            this._tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabControl.Location = new System.Drawing.Point(0, 0);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(759, 471);
            this._tabControl.TabIndex = 0;
            // 
            // _mealTabPage
            // 
            this._mealTabPage.AccessibleName = "MealTabPage";
            this._mealTabPage.Controls.Add(this._mealTableLayoutPanel);
            this._mealTabPage.Location = new System.Drawing.Point(4, 22);
            this._mealTabPage.Name = "_mealTabPage";
            this._mealTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._mealTabPage.Size = new System.Drawing.Size(751, 445);
            this._mealTabPage.TabIndex = 0;
            this._mealTabPage.Text = "Meal Manager";
            this._mealTabPage.UseVisualStyleBackColor = true;
            // 
            // _mealTableLayoutPanel
            // 
            this._mealTableLayoutPanel.ColumnCount = 3;
            this._mealTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._mealTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._mealTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this._mealTableLayoutPanel.Controls.Add(this._mealListBox, 0, 0);
            this._mealTableLayoutPanel.Controls.Add(this._addMealModeButton, 0, 1);
            this._mealTableLayoutPanel.Controls.Add(this._deleteMealButton, 1, 1);
            this._mealTableLayoutPanel.Controls.Add(this._mealGroupBox, 2, 0);
            this._mealTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mealTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this._mealTableLayoutPanel.Name = "_mealTableLayoutPanel";
            this._mealTableLayoutPanel.RowCount = 2;
            this._mealTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this._mealTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._mealTableLayoutPanel.Size = new System.Drawing.Size(745, 439);
            this._mealTableLayoutPanel.TabIndex = 0;
            // 
            // _mealListBox
            // 
            this._mealListBox.AccessibleName = "MealListBox";
            this._mealTableLayoutPanel.SetColumnSpan(this._mealListBox, 2);
            this._mealListBox.DisplayMember = "Name";
            this._mealListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mealListBox.FormattingEnabled = true;
            this._mealListBox.ItemHeight = 12;
            this._mealListBox.Location = new System.Drawing.Point(3, 3);
            this._mealListBox.Name = "_mealListBox";
            this._mealListBox.Size = new System.Drawing.Size(292, 389);
            this._mealListBox.TabIndex = 0;
            this._mealListBox.SelectedValueChanged += new System.EventHandler(this.ChangeMealListBoxSelectValue);
            // 
            // _addMealModeButton
            // 
            this._addMealModeButton.AccessibleName = "AddNewMealButton";
            this._addMealModeButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._addMealModeButton.Location = new System.Drawing.Point(3, 398);
            this._addMealModeButton.Name = "_addMealModeButton";
            this._addMealModeButton.Size = new System.Drawing.Size(143, 38);
            this._addMealModeButton.TabIndex = 1;
            this._addMealModeButton.Text = "Add New Meal";
            this._addMealModeButton.UseVisualStyleBackColor = true;
            this._addMealModeButton.Click += new System.EventHandler(this.ClickAddMealMode);
            // 
            // _deleteMealButton
            // 
            this._deleteMealButton.AccessibleName = "DeleteSelectedMealButton";
            this._deleteMealButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._deleteMealButton.Location = new System.Drawing.Point(152, 398);
            this._deleteMealButton.Name = "_deleteMealButton";
            this._deleteMealButton.Size = new System.Drawing.Size(143, 38);
            this._deleteMealButton.TabIndex = 2;
            this._deleteMealButton.Text = "Delete Selected Meal";
            this._deleteMealButton.UseVisualStyleBackColor = true;
            this._deleteMealButton.Click += new System.EventHandler(this.ClickDeleteMealButton);
            // 
            // _mealGroupBox
            // 
            this._mealGroupBox.Controls.Add(this._mealManagerTableLayoutPanel);
            this._mealGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mealGroupBox.Location = new System.Drawing.Point(301, 3);
            this._mealGroupBox.Name = "_mealGroupBox";
            this._mealTableLayoutPanel.SetRowSpan(this._mealGroupBox, 2);
            this._mealGroupBox.Size = new System.Drawing.Size(441, 433);
            this._mealGroupBox.TabIndex = 3;
            this._mealGroupBox.TabStop = false;
            this._mealGroupBox.Text = "Edit Meal";
            // 
            // _mealManagerTableLayoutPanel
            // 
            this._mealManagerTableLayoutPanel.ColumnCount = 5;
            this._mealManagerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._mealManagerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._mealManagerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._mealManagerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._mealManagerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._mealManagerTableLayoutPanel.Controls.Add(this._mealCategoryNameLabel, 3, 1);
            this._mealManagerTableLayoutPanel.Controls.Add(this._mealUnitLabel, 2, 1);
            this._mealManagerTableLayoutPanel.Controls.Add(this._mealNameTextBox, 2, 0);
            this._mealManagerTableLayoutPanel.Controls.Add(this._mealAddSaveButton, 4, 5);
            this._mealManagerTableLayoutPanel.Controls.Add(this._mealNameLabel, 0, 0);
            this._mealManagerTableLayoutPanel.Controls.Add(this._mealPriceLabel, 0, 1);
            this._mealManagerTableLayoutPanel.Controls.Add(this._mealPriceTextBox, 1, 1);
            this._mealManagerTableLayoutPanel.Controls.Add(this._mealCategoryComboBox, 4, 1);
            this._mealManagerTableLayoutPanel.Controls.Add(this._mealPathLabel, 0, 2);
            this._mealManagerTableLayoutPanel.Controls.Add(this._mealPathTextBox, 2, 2);
            this._mealManagerTableLayoutPanel.Controls.Add(this._browseButton, 4, 2);
            this._mealManagerTableLayoutPanel.Controls.Add(this._mealDescriptionLabel, 0, 3);
            this._mealManagerTableLayoutPanel.Controls.Add(this._mealDescriptionTextBox, 0, 4);
            this._mealManagerTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mealManagerTableLayoutPanel.Location = new System.Drawing.Point(3, 18);
            this._mealManagerTableLayoutPanel.Name = "_mealManagerTableLayoutPanel";
            this._mealManagerTableLayoutPanel.RowCount = 6;
            this._mealManagerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._mealManagerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._mealManagerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._mealManagerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._mealManagerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._mealManagerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._mealManagerTableLayoutPanel.Size = new System.Drawing.Size(435, 412);
            this._mealManagerTableLayoutPanel.TabIndex = 0;
            // 
            // _mealCategoryNameLabel
            // 
            this._mealCategoryNameLabel.AutoSize = true;
            this._mealCategoryNameLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._mealCategoryNameLabel.Location = new System.Drawing.Point(220, 70);
            this._mealCategoryNameLabel.Name = "_mealCategoryNameLabel";
            this._mealCategoryNameLabel.Size = new System.Drawing.Size(102, 12);
            this._mealCategoryNameLabel.TabIndex = 9;
            this._mealCategoryNameLabel.Text = "Meal Category(*)";
            // 
            // _mealUnitLabel
            // 
            this._mealUnitLabel.AutoSize = true;
            this._mealUnitLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._mealUnitLabel.Location = new System.Drawing.Point(177, 70);
            this._mealUnitLabel.Name = "_mealUnitLabel";
            this._mealUnitLabel.Size = new System.Drawing.Size(37, 12);
            this._mealUnitLabel.TabIndex = 7;
            this._mealUnitLabel.Text = "NTD";
            // 
            // _mealNameTextBox
            // 
            this._mealNameTextBox.AccessibleName = "MealNameTextBox";
            this._mealManagerTableLayoutPanel.SetColumnSpan(this._mealNameTextBox, 3);
            this._mealNameTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._mealNameTextBox.Location = new System.Drawing.Point(177, 16);
            this._mealNameTextBox.Name = "_mealNameTextBox";
            this._mealNameTextBox.Size = new System.Drawing.Size(255, 22);
            this._mealNameTextBox.TabIndex = 6;
            // 
            // _mealAddSaveButton
            // 
            this._mealAddSaveButton.AccessibleName = "TriggerMealButton";
            this._mealAddSaveButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._mealAddSaveButton.Location = new System.Drawing.Point(328, 386);
            this._mealAddSaveButton.Name = "_mealAddSaveButton";
            this._mealAddSaveButton.Size = new System.Drawing.Size(104, 23);
            this._mealAddSaveButton.TabIndex = 0;
            this._mealAddSaveButton.Text = "Save";
            this._mealAddSaveButton.UseVisualStyleBackColor = true;
            this._mealAddSaveButton.Click += new System.EventHandler(this.ClickMealAddSaveButton);
            // 
            // _mealNameLabel
            // 
            this._mealNameLabel.AutoSize = true;
            this._mealManagerTableLayoutPanel.SetColumnSpan(this._mealNameLabel, 2);
            this._mealNameLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._mealNameLabel.Location = new System.Drawing.Point(3, 29);
            this._mealNameLabel.Name = "_mealNameLabel";
            this._mealNameLabel.Size = new System.Drawing.Size(168, 12);
            this._mealNameLabel.TabIndex = 1;
            this._mealNameLabel.Text = "Meal Name(*)";
            // 
            // _mealPriceLabel
            // 
            this._mealPriceLabel.AutoSize = true;
            this._mealPriceLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._mealPriceLabel.Location = new System.Drawing.Point(3, 70);
            this._mealPriceLabel.Name = "_mealPriceLabel";
            this._mealPriceLabel.Size = new System.Drawing.Size(81, 12);
            this._mealPriceLabel.TabIndex = 3;
            this._mealPriceLabel.Text = "Meal Price(*)";
            // 
            // _mealPriceTextBox
            // 
            this._mealPriceTextBox.AccessibleName = "MealPriceTextBox";
            this._mealPriceTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._mealPriceTextBox.Location = new System.Drawing.Point(90, 57);
            this._mealPriceTextBox.Name = "_mealPriceTextBox";
            this._mealPriceTextBox.Size = new System.Drawing.Size(81, 22);
            this._mealPriceTextBox.TabIndex = 4;
            // 
            // _mealCategoryComboBox
            // 
            this._mealCategoryComboBox.AccessibleName = "MealCategoryComboBox";
            this._mealCategoryComboBox.DisplayMember = "Name";
            this._mealCategoryComboBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._mealCategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._mealCategoryComboBox.FormattingEnabled = true;
            this._mealCategoryComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._mealCategoryComboBox.Location = new System.Drawing.Point(328, 59);
            this._mealCategoryComboBox.Name = "_mealCategoryComboBox";
            this._mealCategoryComboBox.Size = new System.Drawing.Size(104, 20);
            this._mealCategoryComboBox.TabIndex = 10;
            // 
            // _mealPathLabel
            // 
            this._mealPathLabel.AutoSize = true;
            this._mealManagerTableLayoutPanel.SetColumnSpan(this._mealPathLabel, 2);
            this._mealPathLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this._mealPathLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._mealPathLabel.Location = new System.Drawing.Point(3, 111);
            this._mealPathLabel.Name = "_mealPathLabel";
            this._mealPathLabel.Size = new System.Drawing.Size(168, 12);
            this._mealPathLabel.TabIndex = 11;
            this._mealPathLabel.Text = "Meal Image Ralative Path(*)";
            // 
            // _mealPathTextBox
            // 
            this._mealPathTextBox.AccessibleName = "MealPathTextBox";
            this._mealManagerTableLayoutPanel.SetColumnSpan(this._mealPathTextBox, 2);
            this._mealPathTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._mealPathTextBox.Location = new System.Drawing.Point(177, 98);
            this._mealPathTextBox.Name = "_mealPathTextBox";
            this._mealPathTextBox.ReadOnly = true;
            this._mealPathTextBox.Size = new System.Drawing.Size(145, 22);
            this._mealPathTextBox.TabIndex = 12;
            // 
            // _browseButton
            // 
            this._browseButton.AccessibleName = "BrowseButton";
            this._browseButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._browseButton.Location = new System.Drawing.Point(328, 97);
            this._browseButton.Name = "_browseButton";
            this._browseButton.Size = new System.Drawing.Size(104, 23);
            this._browseButton.TabIndex = 13;
            this._browseButton.Text = "Browse";
            this._browseButton.UseVisualStyleBackColor = true;
            this._browseButton.Click += new System.EventHandler(this.ClickBrowseButton);
            // 
            // _mealDescriptionLabel
            // 
            this._mealDescriptionLabel.AutoSize = true;
            this._mealManagerTableLayoutPanel.SetColumnSpan(this._mealDescriptionLabel, 2);
            this._mealDescriptionLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._mealDescriptionLabel.Location = new System.Drawing.Point(3, 152);
            this._mealDescriptionLabel.Name = "_mealDescriptionLabel";
            this._mealDescriptionLabel.Size = new System.Drawing.Size(168, 12);
            this._mealDescriptionLabel.TabIndex = 14;
            this._mealDescriptionLabel.Text = "Meal Description";
            // 
            // _mealDescriptionTextBox
            // 
            this._mealDescriptionTextBox.AccessibleName = "MealDescriptionTextBox";
            this._mealManagerTableLayoutPanel.SetColumnSpan(this._mealDescriptionTextBox, 5);
            this._mealDescriptionTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mealDescriptionTextBox.Location = new System.Drawing.Point(3, 167);
            this._mealDescriptionTextBox.Multiline = true;
            this._mealDescriptionTextBox.Name = "_mealDescriptionTextBox";
            this._mealDescriptionTextBox.Size = new System.Drawing.Size(429, 200);
            this._mealDescriptionTextBox.TabIndex = 15;
            // 
            // _categoryTabPage
            // 
            this._categoryTabPage.AccessibleName = "CategoryTabPage";
            this._categoryTabPage.Controls.Add(this._categoryManagerTableLayoutPanel);
            this._categoryTabPage.Location = new System.Drawing.Point(4, 22);
            this._categoryTabPage.Name = "_categoryTabPage";
            this._categoryTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._categoryTabPage.Size = new System.Drawing.Size(751, 445);
            this._categoryTabPage.TabIndex = 1;
            this._categoryTabPage.Text = "Category  Manager";
            this._categoryTabPage.UseVisualStyleBackColor = true;
            // 
            // _categoryManagerTableLayoutPanel
            // 
            this._categoryManagerTableLayoutPanel.ColumnCount = 3;
            this._categoryManagerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._categoryManagerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._categoryManagerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._categoryManagerTableLayoutPanel.Controls.Add(this._addCategoryModeButton, 0, 1);
            this._categoryManagerTableLayoutPanel.Controls.Add(this._deleteCategoryButton, 1, 1);
            this._categoryManagerTableLayoutPanel.Controls.Add(this._categoryListBox, 0, 0);
            this._categoryManagerTableLayoutPanel.Controls.Add(this._categoryGroupBox, 2, 0);
            this._categoryManagerTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._categoryManagerTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this._categoryManagerTableLayoutPanel.Name = "_categoryManagerTableLayoutPanel";
            this._categoryManagerTableLayoutPanel.RowCount = 2;
            this._categoryManagerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this._categoryManagerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._categoryManagerTableLayoutPanel.Size = new System.Drawing.Size(745, 439);
            this._categoryManagerTableLayoutPanel.TabIndex = 0;
            // 
            // _addCategoryModeButton
            // 
            this._addCategoryModeButton.AccessibleName = "AddNewCategoryButton";
            this._addCategoryModeButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._addCategoryModeButton.Location = new System.Drawing.Point(3, 413);
            this._addCategoryModeButton.Name = "_addCategoryModeButton";
            this._addCategoryModeButton.Size = new System.Drawing.Size(180, 23);
            this._addCategoryModeButton.TabIndex = 0;
            this._addCategoryModeButton.Text = "Add New Category";
            this._addCategoryModeButton.UseVisualStyleBackColor = true;
            this._addCategoryModeButton.Click += new System.EventHandler(this.ClickAddCategoryMode);
            // 
            // _deleteCategoryButton
            // 
            this._deleteCategoryButton.AccessibleName = "DeleteSelectedCategoryButton";
            this._deleteCategoryButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._deleteCategoryButton.Location = new System.Drawing.Point(189, 413);
            this._deleteCategoryButton.Name = "_deleteCategoryButton";
            this._deleteCategoryButton.Size = new System.Drawing.Size(180, 23);
            this._deleteCategoryButton.TabIndex = 1;
            this._deleteCategoryButton.Text = "Delete Selected Category";
            this._deleteCategoryButton.UseVisualStyleBackColor = true;
            this._deleteCategoryButton.Click += new System.EventHandler(this.ClickDeleteCategoryButton);
            // 
            // _categoryListBox
            // 
            this._categoryListBox.AccessibleName = "CategoryListBox";
            this._categoryManagerTableLayoutPanel.SetColumnSpan(this._categoryListBox, 2);
            this._categoryListBox.DisplayMember = "Name";
            this._categoryListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._categoryListBox.FormattingEnabled = true;
            this._categoryListBox.ItemHeight = 12;
            this._categoryListBox.Location = new System.Drawing.Point(3, 3);
            this._categoryListBox.Name = "_categoryListBox";
            this._categoryListBox.Size = new System.Drawing.Size(366, 389);
            this._categoryListBox.TabIndex = 2;
            this._categoryListBox.SelectedValueChanged += new System.EventHandler(this.ChangeCategoryListBoxSelectValue);
            // 
            // _categoryGroupBox
            // 
            this._categoryGroupBox.Controls.Add(this._categoryTableLayoutPanel);
            this._categoryGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._categoryGroupBox.Location = new System.Drawing.Point(375, 3);
            this._categoryGroupBox.Name = "_categoryGroupBox";
            this._categoryManagerTableLayoutPanel.SetRowSpan(this._categoryGroupBox, 2);
            this._categoryGroupBox.Size = new System.Drawing.Size(367, 433);
            this._categoryGroupBox.TabIndex = 3;
            this._categoryGroupBox.TabStop = false;
            this._categoryGroupBox.Text = "Edit Category";
            // 
            // _categoryTableLayoutPanel
            // 
            this._categoryTableLayoutPanel.ColumnCount = 2;
            this._categoryTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._categoryTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._categoryTableLayoutPanel.Controls.Add(this._categoryUsedMealListBox, 0, 2);
            this._categoryTableLayoutPanel.Controls.Add(this._categoryNameLabel, 0, 0);
            this._categoryTableLayoutPanel.Controls.Add(this._usedMealLabel, 0, 1);
            this._categoryTableLayoutPanel.Controls.Add(this._categoryNameTextBox, 1, 0);
            this._categoryTableLayoutPanel.Controls.Add(this._categoryAddSaveButton, 1, 3);
            this._categoryTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._categoryTableLayoutPanel.Location = new System.Drawing.Point(3, 18);
            this._categoryTableLayoutPanel.Name = "_categoryTableLayoutPanel";
            this._categoryTableLayoutPanel.RowCount = 4;
            this._categoryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._categoryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._categoryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this._categoryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._categoryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._categoryTableLayoutPanel.Size = new System.Drawing.Size(361, 412);
            this._categoryTableLayoutPanel.TabIndex = 0;
            // 
            // _categoryUsedMealListBox
            // 
            this._categoryTableLayoutPanel.SetColumnSpan(this._categoryUsedMealListBox, 2);
            this._categoryUsedMealListBox.DisplayMember = "Name";
            this._categoryUsedMealListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._categoryUsedMealListBox.FormattingEnabled = true;
            this._categoryUsedMealListBox.ItemHeight = 12;
            this._categoryUsedMealListBox.Location = new System.Drawing.Point(3, 85);
            this._categoryUsedMealListBox.Name = "_categoryUsedMealListBox";
            this._categoryUsedMealListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this._categoryUsedMealListBox.Size = new System.Drawing.Size(355, 282);
            this._categoryUsedMealListBox.TabIndex = 1;
            // 
            // _categoryNameLabel
            // 
            this._categoryNameLabel.AutoSize = true;
            this._categoryNameLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._categoryNameLabel.Location = new System.Drawing.Point(3, 29);
            this._categoryNameLabel.Name = "_categoryNameLabel";
            this._categoryNameLabel.Size = new System.Drawing.Size(174, 12);
            this._categoryNameLabel.TabIndex = 2;
            this._categoryNameLabel.Text = "Category Name(*)";
            // 
            // _usedMealLabel
            // 
            this._usedMealLabel.AutoSize = true;
            this._usedMealLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._usedMealLabel.Location = new System.Drawing.Point(3, 70);
            this._usedMealLabel.Name = "_usedMealLabel";
            this._usedMealLabel.Size = new System.Drawing.Size(174, 12);
            this._usedMealLabel.TabIndex = 3;
            this._usedMealLabel.Text = "Meal(s) Using this Category";
            // 
            // _categoryNameTextBox
            // 
            this._categoryNameTextBox.AccessibleName = "CategoryNameTextBox";
            this._categoryNameTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._categoryNameTextBox.Location = new System.Drawing.Point(183, 16);
            this._categoryNameTextBox.Name = "_categoryNameTextBox";
            this._categoryNameTextBox.Size = new System.Drawing.Size(175, 22);
            this._categoryNameTextBox.TabIndex = 4;
            // 
            // _categoryAddSaveButton
            // 
            this._categoryAddSaveButton.AccessibleName = "TriggerCategoryButton";
            this._categoryAddSaveButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._categoryAddSaveButton.Location = new System.Drawing.Point(183, 386);
            this._categoryAddSaveButton.Name = "_categoryAddSaveButton";
            this._categoryAddSaveButton.Size = new System.Drawing.Size(175, 23);
            this._categoryAddSaveButton.TabIndex = 0;
            this._categoryAddSaveButton.Text = "Save";
            this._categoryAddSaveButton.UseVisualStyleBackColor = true;
            this._categoryAddSaveButton.Click += new System.EventHandler(this.ClickCategoryAddSaveButton);
            // 
            // _openFileDialog
            // 
            this._openFileDialog.FileName = "image\\No Image.jpg";
            this._openFileDialog.Filter = "Image|*.png;*.jpg;*.jpeg";
            this._openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.NotifyFileOK);
            // 
            // RestaurantSideForm
            // 
            this.AccessibleName = "RestaurantSideForm";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 471);
            this.Controls.Add(this._tabControl);
            this.Name = "RestaurantSideForm";
            this.Text = "RestaurantSideForm";
            this.Load += new System.EventHandler(this.LoadRestaurantSideForm);
            this._tabControl.ResumeLayout(false);
            this._mealTabPage.ResumeLayout(false);
            this._mealTableLayoutPanel.ResumeLayout(false);
            this._mealGroupBox.ResumeLayout(false);
            this._mealManagerTableLayoutPanel.ResumeLayout(false);
            this._mealManagerTableLayoutPanel.PerformLayout();
            this._categoryTabPage.ResumeLayout(false);
            this._categoryManagerTableLayoutPanel.ResumeLayout(false);
            this._categoryGroupBox.ResumeLayout(false);
            this._categoryTableLayoutPanel.ResumeLayout(false);
            this._categoryTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _tabControl;
        private System.Windows.Forms.TabPage _mealTabPage;
        private System.Windows.Forms.TabPage _categoryTabPage;
        private System.Windows.Forms.TableLayoutPanel _mealTableLayoutPanel;
        private System.Windows.Forms.ListBox _mealListBox;
        private System.Windows.Forms.Button _addMealModeButton;
        private System.Windows.Forms.Button _deleteMealButton;
        private System.Windows.Forms.GroupBox _mealGroupBox;
        private System.Windows.Forms.TableLayoutPanel _mealManagerTableLayoutPanel;
        private System.Windows.Forms.Button _mealAddSaveButton;
        private System.Windows.Forms.Label _mealNameLabel;
        private System.Windows.Forms.Label _mealPriceLabel;
        private System.Windows.Forms.TextBox _mealPriceTextBox;
        private System.Windows.Forms.Label _mealCategoryNameLabel;
        private System.Windows.Forms.Label _mealUnitLabel;
        private System.Windows.Forms.TextBox _mealNameTextBox;
        private System.Windows.Forms.ComboBox _mealCategoryComboBox;
        private System.Windows.Forms.Label _mealPathLabel;
        private System.Windows.Forms.TextBox _mealPathTextBox;
        private System.Windows.Forms.Button _browseButton;
        private System.Windows.Forms.Label _mealDescriptionLabel;
        private System.Windows.Forms.TextBox _mealDescriptionTextBox;
        private System.Windows.Forms.TableLayoutPanel _categoryManagerTableLayoutPanel;
        private System.Windows.Forms.Button _addCategoryModeButton;
        private System.Windows.Forms.Button _deleteCategoryButton;
        private System.Windows.Forms.ListBox _categoryListBox;
        private System.Windows.Forms.GroupBox _categoryGroupBox;
        private System.Windows.Forms.TableLayoutPanel _categoryTableLayoutPanel;
        private System.Windows.Forms.Button _categoryAddSaveButton;
        private System.Windows.Forms.ListBox _categoryUsedMealListBox;
        private System.Windows.Forms.Label _categoryNameLabel;
        private System.Windows.Forms.Label _usedMealLabel;
        private System.Windows.Forms.TextBox _categoryNameTextBox;
        private System.Windows.Forms.OpenFileDialog _openFileDialog;

    }
}