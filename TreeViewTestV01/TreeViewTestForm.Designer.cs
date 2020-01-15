namespace TreeViewTestV01
{
    partial class TreeViewTestForm
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
            this.treeView = new System.Windows.Forms.TreeView();
            this.addSubjectButton = new System.Windows.Forms.Button();
            this.addDivisionNodeButton = new System.Windows.Forms.Button();
            this.saveTreeButton = new System.Windows.Forms.Button();
            this.loadTreeButton = new System.Windows.Forms.Button();
            this.nodeTextValue = new System.Windows.Forms.TextBox();
            this.getNodeNamesButton = new System.Windows.Forms.Button();
            this.getTreeViewDictionaryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(12, 12);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(448, 395);
            this.treeView.TabIndex = 0;
            // 
            // addSubjectButton
            // 
            this.addSubjectButton.Location = new System.Drawing.Point(490, 114);
            this.addSubjectButton.Name = "addSubjectButton";
            this.addSubjectButton.Size = new System.Drawing.Size(162, 23);
            this.addSubjectButton.TabIndex = 1;
            this.addSubjectButton.Text = "Add Subject Node";
            this.addSubjectButton.UseVisualStyleBackColor = true;
            this.addSubjectButton.Click += new System.EventHandler(this.addSubjectButton_Click);
            // 
            // addDivisionNodeButton
            // 
            this.addDivisionNodeButton.Location = new System.Drawing.Point(490, 171);
            this.addDivisionNodeButton.Name = "addDivisionNodeButton";
            this.addDivisionNodeButton.Size = new System.Drawing.Size(162, 23);
            this.addDivisionNodeButton.TabIndex = 2;
            this.addDivisionNodeButton.Text = "Add Division Node";
            this.addDivisionNodeButton.UseVisualStyleBackColor = true;
            this.addDivisionNodeButton.Click += new System.EventHandler(this.addDivisionNodeButton_Click);
            // 
            // saveTreeButton
            // 
            this.saveTreeButton.Location = new System.Drawing.Point(490, 231);
            this.saveTreeButton.Name = "saveTreeButton";
            this.saveTreeButton.Size = new System.Drawing.Size(162, 23);
            this.saveTreeButton.TabIndex = 3;
            this.saveTreeButton.Text = "Save Tree";
            this.saveTreeButton.UseVisualStyleBackColor = true;
            this.saveTreeButton.Click += new System.EventHandler(this.saveTreeButton_Click);
            // 
            // loadTreeButton
            // 
            this.loadTreeButton.Location = new System.Drawing.Point(490, 296);
            this.loadTreeButton.Name = "loadTreeButton";
            this.loadTreeButton.Size = new System.Drawing.Size(162, 23);
            this.loadTreeButton.TabIndex = 4;
            this.loadTreeButton.Text = "Load Tree";
            this.loadTreeButton.UseVisualStyleBackColor = true;
            this.loadTreeButton.Click += new System.EventHandler(this.loadTreeButton_Click);
            // 
            // nodeTextValue
            // 
            this.nodeTextValue.Location = new System.Drawing.Point(490, 64);
            this.nodeTextValue.Name = "nodeTextValue";
            this.nodeTextValue.Size = new System.Drawing.Size(192, 22);
            this.nodeTextValue.TabIndex = 5;
            // 
            // getNodeNamesButton
            // 
            this.getNodeNamesButton.Location = new System.Drawing.Point(490, 348);
            this.getNodeNamesButton.Name = "getNodeNamesButton";
            this.getNodeNamesButton.Size = new System.Drawing.Size(162, 23);
            this.getNodeNamesButton.TabIndex = 6;
            this.getNodeNamesButton.Text = "Get Node Text";
            this.getNodeNamesButton.UseVisualStyleBackColor = true;
            this.getNodeNamesButton.Click += new System.EventHandler(this.getNodeNamesButton_Click);
            // 
            // getTreeViewDictionaryButton
            // 
            this.getTreeViewDictionaryButton.Location = new System.Drawing.Point(490, 395);
            this.getTreeViewDictionaryButton.Name = "getTreeViewDictionaryButton";
            this.getTreeViewDictionaryButton.Size = new System.Drawing.Size(162, 23);
            this.getTreeViewDictionaryButton.TabIndex = 7;
            this.getTreeViewDictionaryButton.Text = "Get Tree View Dictioanry";
            this.getTreeViewDictionaryButton.UseVisualStyleBackColor = true;
            this.getTreeViewDictionaryButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // TreeViewTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.getTreeViewDictionaryButton);
            this.Controls.Add(this.getNodeNamesButton);
            this.Controls.Add(this.nodeTextValue);
            this.Controls.Add(this.loadTreeButton);
            this.Controls.Add(this.saveTreeButton);
            this.Controls.Add(this.addDivisionNodeButton);
            this.Controls.Add(this.addSubjectButton);
            this.Controls.Add(this.treeView);
            this.Name = "TreeViewTestForm";
            this.Text = "TreeViewTestForm";
            this.Load += new System.EventHandler(this.TreeViewTestForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Button addSubjectButton;
        private System.Windows.Forms.Button addDivisionNodeButton;
        private System.Windows.Forms.Button saveTreeButton;
        private System.Windows.Forms.Button loadTreeButton;
        private System.Windows.Forms.TextBox nodeTextValue;
        private System.Windows.Forms.Button getNodeNamesButton;
        private System.Windows.Forms.Button getTreeViewDictionaryButton;
    }
}