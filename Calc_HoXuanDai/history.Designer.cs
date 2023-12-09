
namespace Calc_HoXuanDai
{
    partial class history
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
            this.components = new System.ComponentModel.Container();
            this.lHistory = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBackCal = new FontAwesome.Sharp.IconButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tt_BackToCal = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lHistory
            // 
            this.lHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lHistory.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lHistory.Cursor = System.Windows.Forms.Cursors.No;
            this.lHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lHistory.FormattingEnabled = true;
            this.lHistory.ItemHeight = 38;
            this.lHistory.Location = new System.Drawing.Point(12, 86);
            this.lHistory.Name = "lHistory";
            this.lHistory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lHistory.Size = new System.Drawing.Size(385, 498);
            this.lHistory.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(132, 600);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 51);
            this.button1.TabIndex = 1;
            this.button1.Text = "Xóa nhật ký";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.onClick_delHis);
            // 
            // btnBackCal
            // 
            this.btnBackCal.BackColor = System.Drawing.Color.White;
            this.btnBackCal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackCal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackCal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBackCal.IconChar = FontAwesome.Sharp.IconChar.Calculator;
            this.btnBackCal.IconColor = System.Drawing.Color.Black;
            this.btnBackCal.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBackCal.Location = new System.Drawing.Point(12, 12);
            this.btnBackCal.Name = "btnBackCal";
            this.btnBackCal.Size = new System.Drawing.Size(55, 53);
            this.btnBackCal.TabIndex = 2;
            this.btnBackCal.UseVisualStyleBackColor = false;
            this.btnBackCal.Click += new System.EventHandler(this.onClick_BacktoCal);
            // 
            // textBox1
            // 
            this.textBox1.Cursor = System.Windows.Forms.Cursors.No;
            this.textBox1.Font = new System.Drawing.Font("Segoe Script", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(95, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(292, 53);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "History";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tt_BackToCal
            // 
            this.tt_BackToCal.Popup += new System.Windows.Forms.PopupEventHandler(this.tt_BackCal_Popup);
            // 
            // history
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(409, 672);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnBackCal);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lHistory);
            this.Name = "history";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "frmHistory";
            this.Load += new System.EventHandler(this.history_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lHistory;
        private System.Windows.Forms.Button button1;
        private FontAwesome.Sharp.IconButton btnBackCal;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolTip tt_BackToCal;
    }
}