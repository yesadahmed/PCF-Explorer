
namespace PCf_Explorer_Sol
{
	partial class MyPluginControl
	{
		/// <summary> 
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur de composants

		/// <summary> 
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.toolStripMenu = new System.Windows.Forms.ToolStrip();
			this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.maintbllayout = new System.Windows.Forms.TableLayoutPanel();
			this.listViewPCF = new System.Windows.Forms.ListView();
			this.tableLayoutPanelinner = new System.Windows.Forms.TableLayoutPanel();
			this.chartpie = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.txtsearch = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.listViewDetails = new System.Windows.Forms.ListView();
			this.tsbClose = new System.Windows.Forms.ToolStripButton();
			this.tableLayoutPanelListboxes = new System.Windows.Forms.TableLayoutPanel();
			this.comboBoxtotal = new System.Windows.Forms.ComboBox();
			this.comboBoxcustom = new System.Windows.Forms.ComboBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.toolStripMenu.SuspendLayout();
			this.maintbllayout.SuspendLayout();
			this.tableLayoutPanelinner.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chartpie)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanelListboxes.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripMenu
			// 
			this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1});
			this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
			this.toolStripMenu.Name = "toolStripMenu";
			this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
			this.toolStripMenu.Size = new System.Drawing.Size(2824, 52);
			this.toolStripMenu.TabIndex = 4;
			this.toolStripMenu.Text = "toolStrip1";
			// 
			// tssSeparator1
			// 
			this.tssSeparator1.Name = "tssSeparator1";
			this.tssSeparator1.Size = new System.Drawing.Size(6, 52);
			// 
			// maintbllayout
			// 
			this.maintbllayout.ColumnCount = 4;
			this.maintbllayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.53412F));
			this.maintbllayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.46588F));
			this.maintbllayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 666F));
			this.maintbllayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.maintbllayout.Controls.Add(this.listViewPCF, 0, 1);
			this.maintbllayout.Controls.Add(this.tableLayoutPanelinner, 1, 1);
			this.maintbllayout.Controls.Add(this.tableLayoutPanel1, 0, 0);
			this.maintbllayout.Controls.Add(this.tableLayoutPanelListboxes, 2, 1);
			this.maintbllayout.Controls.Add(this.label2, 2, 0);
			this.maintbllayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.maintbllayout.Location = new System.Drawing.Point(0, 52);
			this.maintbllayout.Name = "maintbllayout";
			this.maintbllayout.RowCount = 2;
			this.maintbllayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
			this.maintbllayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.maintbllayout.Size = new System.Drawing.Size(2824, 1468);
			this.maintbllayout.TabIndex = 5;
			// 
			// listViewPCF
			// 
			this.listViewPCF.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewPCF.HideSelection = false;
			this.listViewPCF.Location = new System.Drawing.Point(3, 67);
			this.listViewPCF.Name = "listViewPCF";
			this.listViewPCF.Size = new System.Drawing.Size(796, 1398);
			this.listViewPCF.TabIndex = 0;
			this.listViewPCF.UseCompatibleStateImageBehavior = false;
			this.listViewPCF.SelectedIndexChanged += new System.EventHandler(this.listViewPCF_SelectedIndexChanged);
			// 
			// tableLayoutPanelinner
			// 
			this.tableLayoutPanelinner.ColumnCount = 2;
			this.tableLayoutPanelinner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.48642F));
			this.tableLayoutPanelinner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.51358F));
			this.tableLayoutPanelinner.Controls.Add(this.chartpie, 1, 0);
			this.tableLayoutPanelinner.Controls.Add(this.chart1, 1, 1);
			this.tableLayoutPanelinner.Controls.Add(this.listViewDetails, 0, 0);
			this.tableLayoutPanelinner.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelinner.Location = new System.Drawing.Point(805, 67);
			this.tableLayoutPanelinner.Name = "tableLayoutPanelinner";
			this.tableLayoutPanelinner.RowCount = 2;
			this.tableLayoutPanelinner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.34319F));
			this.tableLayoutPanelinner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.65681F));
			this.tableLayoutPanelinner.Size = new System.Drawing.Size(1329, 1398);
			this.tableLayoutPanelinner.TabIndex = 1;
			// 
			// chartpie
			// 
			this.chartpie.BackColor = System.Drawing.Color.Transparent;
			chartArea3.Name = "ChartArea1";
			this.chartpie.ChartAreas.Add(chartArea3);
			this.chartpie.Dock = System.Windows.Forms.DockStyle.Fill;
			legend3.Name = "Legend1";
			this.chartpie.Legends.Add(legend3);
			this.chartpie.Location = new System.Drawing.Point(766, 3);
			this.chartpie.Name = "chartpie";
			series3.ChartArea = "ChartArea1";
			series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
			series3.Legend = "Legend1";
			series3.Name = "Series1";
			this.chartpie.Series.Add(series3);
			this.chartpie.Size = new System.Drawing.Size(560, 725);
			this.chartpie.TabIndex = 0;
			this.chartpie.Text = "chart1";
			// 
			// chart1
			// 
			chartArea4.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea4);
			this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
			legend4.Name = "Legend1";
			this.chart1.Legends.Add(legend4);
			this.chart1.Location = new System.Drawing.Point(766, 734);
			this.chart1.Name = "chart1";
			this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
			series4.ChartArea = "ChartArea1";
			series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
			series4.Legend = "Legend1";
			series4.Name = "Series1";
			this.chart1.Series.Add(series4);
			this.chart1.Size = new System.Drawing.Size(560, 661);
			this.chart1.TabIndex = 1;
			this.chart1.Text = "chartinfo";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 534F));
			this.tableLayoutPanel1.Controls.Add(this.txtsearch, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(796, 58);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// txtsearch
			// 
			this.txtsearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtsearch.Location = new System.Drawing.Point(265, 6);
			this.txtsearch.Name = "txtsearch";
			this.txtsearch.Size = new System.Drawing.Size(528, 45);
			this.txtsearch.TabIndex = 0;
			this.txtsearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsearch_KeyDown);
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(251, 58);
			this.label1.TabIndex = 1;
			this.label1.Text = "Search control and press enter:   ";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(2250, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(550, 42);
			this.label2.TabIndex = 3;
			this.label2.Text = "PCF-Explorer (Adnan Samuel)";
			// 
			// listViewDetails
			// 
			this.listViewDetails.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewDetails.HideSelection = false;
			this.listViewDetails.Location = new System.Drawing.Point(3, 3);
			this.listViewDetails.Name = "listViewDetails";
			this.tableLayoutPanelinner.SetRowSpan(this.listViewDetails, 2);
			this.listViewDetails.Size = new System.Drawing.Size(757, 1392);
			this.listViewDetails.TabIndex = 2;
			this.listViewDetails.UseCompatibleStateImageBehavior = false;
			// 
			// tsbClose
			// 
			this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbClose.Name = "tsbClose";
			this.tsbClose.Size = new System.Drawing.Size(211, 45);
			this.tsbClose.Text = "Close this tool";
			this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
			// 
			// tableLayoutPanelListboxes
			// 
			this.tableLayoutPanelListboxes.ColumnCount = 1;
			this.tableLayoutPanelListboxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelListboxes.Controls.Add(this.comboBoxtotal, 0, 0);
			this.tableLayoutPanelListboxes.Controls.Add(this.comboBoxcustom, 0, 2);
			this.tableLayoutPanelListboxes.Controls.Add(this.listBox1, 0, 1);
			this.tableLayoutPanelListboxes.Controls.Add(this.listBox2, 0, 3);
			this.tableLayoutPanelListboxes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelListboxes.Location = new System.Drawing.Point(2140, 67);
			this.tableLayoutPanelListboxes.Name = "tableLayoutPanelListboxes";
			this.tableLayoutPanelListboxes.RowCount = 4;
			this.tableLayoutPanelListboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.976744F));
			this.tableLayoutPanelListboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.02325F));
			this.tableLayoutPanelListboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
			this.tableLayoutPanelListboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 593F));
			this.tableLayoutPanelListboxes.Size = new System.Drawing.Size(660, 1398);
			this.tableLayoutPanelListboxes.TabIndex = 4;
			// 
			// comboBoxtotal
			// 
			this.comboBoxtotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxtotal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxtotal.FormattingEnabled = true;
			this.comboBoxtotal.Items.AddRange(new object[] {
            "Field",
            "Dataset"});
			this.comboBoxtotal.Location = new System.Drawing.Point(3, 5);
			this.comboBoxtotal.Name = "comboBoxtotal";
			this.comboBoxtotal.Size = new System.Drawing.Size(654, 39);
			this.comboBoxtotal.TabIndex = 0;
			this.comboBoxtotal.SelectedIndexChanged += new System.EventHandler(this.comboBoxtotal_SelectedIndexChanged);
			// 
			// comboBoxcustom
			// 
			this.comboBoxcustom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxcustom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxcustom.FormattingEnabled = true;
			this.comboBoxcustom.Items.AddRange(new object[] {
            "Custom",
            "Microsoft"});
			this.comboBoxcustom.Location = new System.Drawing.Point(3, 748);
			this.comboBoxcustom.Name = "comboBoxcustom";
			this.comboBoxcustom.Size = new System.Drawing.Size(654, 39);
			this.comboBoxcustom.TabIndex = 1;
			this.comboBoxcustom.SelectedIndexChanged += new System.EventHandler(this.comboBoxcustom_SelectedIndexChanged);
			// 
			// listBox1
			// 
			this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 31;
			this.listBox1.Location = new System.Drawing.Point(3, 54);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(654, 676);
			this.listBox1.TabIndex = 2;
			// 
			// listBox2
			// 
			this.listBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBox2.FormattingEnabled = true;
			this.listBox2.ItemHeight = 31;
			this.listBox2.Location = new System.Drawing.Point(3, 807);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(654, 588);
			this.listBox2.TabIndex = 3;
			// 
			// MyPluginControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.maintbllayout);
			this.Controls.Add(this.toolStripMenu);
			this.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
			this.Name = "MyPluginControl";
			this.Size = new System.Drawing.Size(2824, 1520);
			this.Load += new System.EventHandler(this.MyPluginControl_Load);
			this.toolStripMenu.ResumeLayout(false);
			this.toolStripMenu.PerformLayout();
			this.maintbllayout.ResumeLayout(false);
			this.maintbllayout.PerformLayout();
			this.tableLayoutPanelinner.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chartpie)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanelListboxes.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ToolStrip toolStripMenu;
		private System.Windows.Forms.ToolStripSeparator tssSeparator1;
		private System.Windows.Forms.TableLayoutPanel maintbllayout;
		private System.Windows.Forms.ListView listViewPCF;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelinner;
		private System.Windows.Forms.DataVisualization.Charting.Chart chartpie;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TextBox txtsearch;
		private System.Windows.Forms.ListView listViewDetails;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolStripButton tsbClose;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelListboxes;
		private System.Windows.Forms.ComboBox comboBoxtotal;
		private System.Windows.Forms.ComboBox comboBoxcustom;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ListBox listBox2;
	}
}
