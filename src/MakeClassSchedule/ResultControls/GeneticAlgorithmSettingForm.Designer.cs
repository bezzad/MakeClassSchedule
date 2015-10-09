namespace MakeClassSchedule.ResultControls
{
    partial class GeneticAlgorithmSettingForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grbDSP = new System.Windows.Forms.GroupBox();
            this.numNumberOfCrossoverPoints = new System.Windows.Forms.NumericUpDown();
            this.numMutationProbability = new System.Windows.Forms.NumericUpDown();
            this.numCrossoverProbability = new System.Windows.Forms.NumericUpDown();
            this.numMutationSize = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grbGAP = new System.Windows.Forms.GroupBox();
            this.numNumberOfChromosomes = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numTrackBest = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numReplaceByGeneration = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDefault = new System.Windows.Forms.Button();
            this.grbDSP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberOfCrossoverPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMutationProbability)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCrossoverProbability)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMutationSize)).BeginInit();
            this.grbGAP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberOfChromosomes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTrackBest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReplaceByGeneration)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnSave.Location = new System.Drawing.Point(65, 305);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnCancel.Location = new System.Drawing.Point(285, 305);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grbDSP
            // 
            this.grbDSP.Controls.Add(this.numNumberOfCrossoverPoints);
            this.grbDSP.Controls.Add(this.numMutationProbability);
            this.grbDSP.Controls.Add(this.numCrossoverProbability);
            this.grbDSP.Controls.Add(this.numMutationSize);
            this.grbDSP.Controls.Add(this.label4);
            this.grbDSP.Controls.Add(this.label3);
            this.grbDSP.Controls.Add(this.label2);
            this.grbDSP.Controls.Add(this.label1);
            this.grbDSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.grbDSP.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.grbDSP.Location = new System.Drawing.Point(12, 12);
            this.grbDSP.Name = "grbDSP";
            this.grbDSP.Size = new System.Drawing.Size(400, 146);
            this.grbDSP.TabIndex = 0;
            this.grbDSP.TabStop = false;
            this.grbDSP.Text = "Define Schedule Prototype";
            // 
            // numNumberOfCrossoverPoints
            // 
            this.numNumberOfCrossoverPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.numNumberOfCrossoverPoints.Location = new System.Drawing.Point(239, 27);
            this.numNumberOfCrossoverPoints.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numNumberOfCrossoverPoints.Name = "numNumberOfCrossoverPoints";
            this.numNumberOfCrossoverPoints.Size = new System.Drawing.Size(110, 20);
            this.numNumberOfCrossoverPoints.TabIndex = 0;
            this.numNumberOfCrossoverPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numNumberOfCrossoverPoints.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numMutationProbability
            // 
            this.numMutationProbability.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.numMutationProbability.Location = new System.Drawing.Point(239, 108);
            this.numMutationProbability.Name = "numMutationProbability";
            this.numMutationProbability.Size = new System.Drawing.Size(110, 20);
            this.numMutationProbability.TabIndex = 3;
            this.numMutationProbability.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numCrossoverProbability
            // 
            this.numCrossoverProbability.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.numCrossoverProbability.Location = new System.Drawing.Point(239, 81);
            this.numCrossoverProbability.Name = "numCrossoverProbability";
            this.numCrossoverProbability.Size = new System.Drawing.Size(110, 20);
            this.numCrossoverProbability.TabIndex = 2;
            this.numCrossoverProbability.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numMutationSize
            // 
            this.numMutationSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.numMutationSize.Location = new System.Drawing.Point(239, 54);
            this.numMutationSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numMutationSize.Name = "numMutationSize";
            this.numMutationSize.Size = new System.Drawing.Size(110, 20);
            this.numMutationSize.TabIndex = 1;
            this.numMutationSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numMutationSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(51, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mutation Probability:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(51, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Crossover Probability:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(51, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mutation Size:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(51, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of Crossover Points:";
            // 
            // grbGAP
            // 
            this.grbGAP.Controls.Add(this.numNumberOfChromosomes);
            this.grbGAP.Controls.Add(this.label5);
            this.grbGAP.Controls.Add(this.numTrackBest);
            this.grbGAP.Controls.Add(this.label6);
            this.grbGAP.Controls.Add(this.numReplaceByGeneration);
            this.grbGAP.Controls.Add(this.label7);
            this.grbGAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.grbGAP.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.grbGAP.Location = new System.Drawing.Point(12, 164);
            this.grbGAP.Name = "grbGAP";
            this.grbGAP.Size = new System.Drawing.Size(400, 126);
            this.grbGAP.TabIndex = 1;
            this.grbGAP.TabStop = false;
            this.grbGAP.Text = "Genetic Algorithm Parameters";
            // 
            // numNumberOfChromosomes
            // 
            this.numNumberOfChromosomes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.numNumberOfChromosomes.Location = new System.Drawing.Point(249, 31);
            this.numNumberOfChromosomes.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numNumberOfChromosomes.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numNumberOfChromosomes.Name = "numNumberOfChromosomes";
            this.numNumberOfChromosomes.Size = new System.Drawing.Size(110, 20);
            this.numNumberOfChromosomes.TabIndex = 1;
            this.numNumberOfChromosomes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numNumberOfChromosomes.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numNumberOfChromosomes.ValueChanged += new System.EventHandler(this.numNumberOfChromosomes_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(41, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Number of Chromosomes:";
            // 
            // numTrackBest
            // 
            this.numTrackBest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.numTrackBest.Location = new System.Drawing.Point(249, 85);
            this.numTrackBest.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numTrackBest.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTrackBest.Name = "numTrackBest";
            this.numTrackBest.Size = new System.Drawing.Size(110, 20);
            this.numTrackBest.TabIndex = 3;
            this.numTrackBest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numTrackBest.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTrackBest.ValueChanged += new System.EventHandler(this.numTrackBest_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(41, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Replace by Generation:";
            // 
            // numReplaceByGeneration
            // 
            this.numReplaceByGeneration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.numReplaceByGeneration.Location = new System.Drawing.Point(249, 58);
            this.numReplaceByGeneration.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numReplaceByGeneration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numReplaceByGeneration.Name = "numReplaceByGeneration";
            this.numReplaceByGeneration.Size = new System.Drawing.Size(110, 20);
            this.numReplaceByGeneration.TabIndex = 2;
            this.numReplaceByGeneration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numReplaceByGeneration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numReplaceByGeneration.ValueChanged += new System.EventHandler(this.numReplaceByGeneration_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(41, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(183, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Number of Track Best Chromosomes:";
            // 
            // btnDefault
            // 
            this.btnDefault.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDefault.Location = new System.Drawing.Point(175, 306);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(75, 25);
            this.btnDefault.TabIndex = 5;
            this.btnDefault.Text = "&Default";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // GeneticAlgorithmSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(424, 342);
            this.ControlBox = false;
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.grbGAP);
            this.Controls.Add(this.grbDSP);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GeneticAlgorithmSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Genetic Algorithm Setting (GAS)";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.GeneticAlgorithmSettingForm_Load);
            this.grbDSP.ResumeLayout(false);
            this.grbDSP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberOfCrossoverPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMutationProbability)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCrossoverProbability)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMutationSize)).EndInit();
            this.grbGAP.ResumeLayout(false);
            this.grbGAP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberOfChromosomes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTrackBest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReplaceByGeneration)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grbDSP;
        private System.Windows.Forms.GroupBox grbGAP;
        private System.Windows.Forms.NumericUpDown numNumberOfCrossoverPoints;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numMutationSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numCrossoverProbability;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numMutationProbability;
        private System.Windows.Forms.NumericUpDown numNumberOfChromosomes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numTrackBest;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numReplaceByGeneration;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDefault;
    }
}