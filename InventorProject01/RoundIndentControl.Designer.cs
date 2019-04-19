namespace InventorProject01
{
    partial class RoundIndentControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.roundDim = new System.Windows.Forms.GroupBox();
            this.roundIndentWidth_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.roundIndentLength_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.errorProvider_round = new System.Windows.Forms.ErrorProvider(this.components);
            this.roundDim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roundIndentWidth_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundIndentLength_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_round)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "T/I";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "B/O";
            // 
            // roundDim
            // 
            this.roundDim.Controls.Add(this.roundIndentWidth_numericUpDown);
            this.roundDim.Controls.Add(this.roundIndentLength_numericUpDown);
            this.roundDim.Controls.Add(this.label1);
            this.roundDim.Controls.Add(this.label2);
            this.roundDim.Location = new System.Drawing.Point(0, 0);
            this.roundDim.Name = "roundDim";
            this.roundDim.Size = new System.Drawing.Size(255, 60);
            this.roundDim.TabIndex = 5;
            this.roundDim.TabStop = false;
            this.roundDim.Text = "Round";
            // 
            // roundIndentWidth_numericUpDown
            // 
            this.roundIndentWidth_numericUpDown.DecimalPlaces = 2;
            this.roundIndentWidth_numericUpDown.Location = new System.Drawing.Point(140, 32);
            this.roundIndentWidth_numericUpDown.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.roundIndentWidth_numericUpDown.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.roundIndentWidth_numericUpDown.Name = "roundIndentWidth_numericUpDown";
            this.roundIndentWidth_numericUpDown.Size = new System.Drawing.Size(75, 20);
            this.roundIndentWidth_numericUpDown.TabIndex = 18;
            this.roundIndentWidth_numericUpDown.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // roundIndentLength_numericUpDown
            // 
            this.roundIndentLength_numericUpDown.DecimalPlaces = 2;
            this.roundIndentLength_numericUpDown.Location = new System.Drawing.Point(6, 32);
            this.roundIndentLength_numericUpDown.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.roundIndentLength_numericUpDown.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.roundIndentLength_numericUpDown.Name = "roundIndentLength_numericUpDown";
            this.roundIndentLength_numericUpDown.Size = new System.Drawing.Size(75, 20);
            this.roundIndentLength_numericUpDown.TabIndex = 17;
            this.roundIndentLength_numericUpDown.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // errorProvider_round
            // 
            this.errorProvider_round.ContainerControl = this;
            // 
            // RoundIndentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.roundDim);
            this.Name = "RoundIndentControl";
            this.Size = new System.Drawing.Size(303, 102);
            this.roundDim.ResumeLayout(false);
            this.roundDim.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roundIndentWidth_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundIndentLength_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_round)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox roundDim;
        public System.Windows.Forms.NumericUpDown roundIndentWidth_numericUpDown;
        public System.Windows.Forms.NumericUpDown roundIndentLength_numericUpDown;
        private System.Windows.Forms.ErrorProvider errorProvider_round;
    }
}
