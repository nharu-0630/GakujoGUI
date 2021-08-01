
namespace GakujoGUI
{
    partial class FileTextInputBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileTextInputBox));
            this.buttonCancel = new MaterialSkin.Controls.MaterialRaisedButton();
            this.buttonOk = new MaterialSkin.Controls.MaterialRaisedButton();
            this.textBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label = new MaterialSkin.Controls.MaterialLabel();
            this.buttonFile = new MaterialSkin.Controls.MaterialFlatButton();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.AutoSize = true;
            this.buttonCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCancel.Depth = 0;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Icon = null;
            this.buttonCancel.Location = new System.Drawing.Point(315, 202);
            this.buttonCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Primary = true;
            this.buttonCancel.Size = new System.Drawing.Size(73, 36);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "CANCEL";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.AutoSize = true;
            this.buttonOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOk.Depth = 0;
            this.buttonOk.Icon = null;
            this.buttonOk.Location = new System.Drawing.Point(270, 202);
            this.buttonOk.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Primary = true;
            this.buttonOk.Size = new System.Drawing.Size(39, 36);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // textBox
            // 
            this.textBox.Depth = 0;
            this.textBox.Hint = "";
            this.textBox.Location = new System.Drawing.Point(12, 173);
            this.textBox.MaxLength = 32767;
            this.textBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBox.Name = "textBox";
            this.textBox.PasswordChar = '\0';
            this.textBox.SelectedText = "";
            this.textBox.SelectionLength = 0;
            this.textBox.SelectionStart = 0;
            this.textBox.Size = new System.Drawing.Size(376, 23);
            this.textBox.TabIndex = 3;
            this.textBox.TabStop = false;
            this.textBox.UseSystemPasswordChar = false;
            // 
            // label
            // 
            this.label.Depth = 0;
            this.label.Font = new System.Drawing.Font("Roboto", 11F);
            this.label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label.Location = new System.Drawing.Point(12, 76);
            this.label.MouseState = MaterialSkin.MouseState.HOVER;
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(376, 46);
            this.label.TabIndex = 1;
            // 
            // buttonFile
            // 
            this.buttonFile.AllowDrop = true;
            this.buttonFile.AutoSize = true;
            this.buttonFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonFile.Depth = 0;
            this.buttonFile.Icon = null;
            this.buttonFile.Location = new System.Drawing.Point(12, 128);
            this.buttonFile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonFile.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Primary = false;
            this.buttonFile.Size = new System.Drawing.Size(127, 36);
            this.buttonFile.TabIndex = 2;
            this.buttonFile.Text = "DRAG AND DROP";
            this.buttonFile.UseVisualStyleBackColor = true;
            this.buttonFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.buttonFile_DragDrop);
            this.buttonFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.buttonFile_DragEnter);
            // 
            // FileTextInputBox
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.buttonFile);
            this.Controls.Add(this.label);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 250);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 250);
            this.Name = "FileTextInputBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Title";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialRaisedButton buttonCancel;
        private MaterialSkin.Controls.MaterialRaisedButton buttonOk;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBox;
        private MaterialSkin.Controls.MaterialLabel label;
        private MaterialSkin.Controls.MaterialFlatButton buttonFile;
    }
}