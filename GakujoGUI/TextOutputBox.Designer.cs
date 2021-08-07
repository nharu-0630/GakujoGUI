
namespace GakujoGUI
{
    partial class TextOutputBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextOutputBox));
            this.label = new MaterialSkin.Controls.MaterialLabel();
            this.buttonOk = new MaterialSkin.Controls.MaterialRaisedButton();
            this.buttonYes = new MaterialSkin.Controls.MaterialRaisedButton();
            this.buttonNo = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.BackColor = System.Drawing.Color.Transparent;
            this.label.Depth = 0;
            this.label.Font = new System.Drawing.Font("Roboto", 11F);
            this.label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label.Location = new System.Drawing.Point(12, 76);
            this.label.MouseState = MaterialSkin.MouseState.HOVER;
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(376, 123);
            this.label.TabIndex = 1;
            // 
            // buttonOk
            // 
            this.buttonOk.AutoSize = true;
            this.buttonOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOk.Depth = 0;
            this.buttonOk.Icon = null;
            this.buttonOk.Location = new System.Drawing.Point(349, 202);
            this.buttonOk.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Primary = true;
            this.buttonOk.Size = new System.Drawing.Size(39, 36);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Visible = false;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonYes
            // 
            this.buttonYes.AutoSize = true;
            this.buttonYes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonYes.Depth = 0;
            this.buttonYes.Icon = null;
            this.buttonYes.Location = new System.Drawing.Point(298, 202);
            this.buttonYes.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.Primary = true;
            this.buttonYes.Size = new System.Drawing.Size(45, 36);
            this.buttonYes.TabIndex = 2;
            this.buttonYes.Text = "YES";
            this.buttonYes.UseVisualStyleBackColor = true;
            this.buttonYes.Visible = false;
            this.buttonYes.Click += new System.EventHandler(this.buttonYes_Click);
            // 
            // buttonNo
            // 
            this.buttonNo.AutoSize = true;
            this.buttonNo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonNo.Depth = 0;
            this.buttonNo.Icon = null;
            this.buttonNo.Location = new System.Drawing.Point(349, 202);
            this.buttonNo.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.Primary = true;
            this.buttonNo.Size = new System.Drawing.Size(40, 36);
            this.buttonNo.TabIndex = 3;
            this.buttonNo.Text = "NO";
            this.buttonNo.UseVisualStyleBackColor = true;
            this.buttonNo.Visible = false;
            this.buttonNo.Click += new System.EventHandler(this.buttonNo_Click);
            // 
            // TextOutputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.buttonNo);
            this.Controls.Add(this.buttonYes);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 250);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 250);
            this.Name = "TextOutputBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Title";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel label;
        private MaterialSkin.Controls.MaterialRaisedButton buttonOk;
        private MaterialSkin.Controls.MaterialRaisedButton buttonYes;
        private MaterialSkin.Controls.MaterialRaisedButton buttonNo;
    }
}