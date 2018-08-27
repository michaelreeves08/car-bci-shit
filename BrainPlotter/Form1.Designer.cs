namespace BrainPlotter
{
	partial class Form1
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.fullAverageLabel = new System.Windows.Forms.Label();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.sampleLabel = new System.Windows.Forms.Label();
			this.clickCheck = new System.Windows.Forms.CheckBox();
			this.checkCom = new System.Windows.Forms.CheckBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// chart1
			// 
			chartArea2.AxisX.Maximum = 500D;
			chartArea2.AxisY.Maximum = 200D;
			chartArea2.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea2);
			this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
			legend2.Name = "Legend1";
			this.chart1.Legends.Add(legend2);
			this.chart1.Location = new System.Drawing.Point(3, 3);
			this.chart1.Name = "chart1";
			series2.ChartArea = "ChartArea1";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series2.Legend = "Legend1";
			series2.Name = "Raw";
			this.chart1.Series.Add(series2);
			this.chart1.Size = new System.Drawing.Size(1484, 514);
			this.chart1.TabIndex = 0;
			this.chart1.Text = "chart1";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.chart1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1490, 651);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// fullAverageLabel
			// 
			this.fullAverageLabel.AutoSize = true;
			this.fullAverageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fullAverageLabel.Location = new System.Drawing.Point(3, 0);
			this.fullAverageLabel.Name = "fullAverageLabel";
			this.fullAverageLabel.Size = new System.Drawing.Size(226, 29);
			this.fullAverageLabel.TabIndex = 3;
			this.fullAverageLabel.Text = "Full Focus Average:";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.fullAverageLabel);
			this.flowLayoutPanel1.Controls.Add(this.sampleLabel);
			this.flowLayoutPanel1.Controls.Add(this.checkCom);
			this.flowLayoutPanel1.Controls.Add(this.clickCheck);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 654);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(1490, 170);
			this.flowLayoutPanel1.TabIndex = 4;
			// 
			// sampleLabel
			// 
			this.sampleLabel.AutoSize = true;
			this.sampleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sampleLabel.Location = new System.Drawing.Point(3, 29);
			this.sampleLabel.Name = "sampleLabel";
			this.sampleLabel.Size = new System.Drawing.Size(266, 29);
			this.sampleLabel.TabIndex = 5;
			this.sampleLabel.Text = "Sample Buffer Average:";
			// 
			// clickCheck
			// 
			this.clickCheck.AutoSize = true;
			this.clickCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.clickCheck.Location = new System.Drawing.Point(3, 95);
			this.clickCheck.Name = "clickCheck";
			this.clickCheck.Size = new System.Drawing.Size(157, 28);
			this.clickCheck.TabIndex = 4;
			this.clickCheck.Text = "Click on Focus";
			this.clickCheck.UseVisualStyleBackColor = true;
			// 
			// checkCom
			// 
			this.checkCom.AutoSize = true;
			this.checkCom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkCom.Location = new System.Drawing.Point(3, 61);
			this.checkCom.Name = "checkCom";
			this.checkCom.Size = new System.Drawing.Size(209, 28);
			this.checkCom.TabIndex = 6;
			this.checkCom.Text = "Serial Com on Focus";
			this.checkCom.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(3, 523);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(1484, 125);
			this.textBox1.TabIndex = 1;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1490, 824);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label fullAverageLabel;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.CheckBox clickCheck;
		private System.Windows.Forms.Label sampleLabel;
		private System.Windows.Forms.CheckBox checkCom;
		private System.Windows.Forms.TextBox textBox1;
	}
}

