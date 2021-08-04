
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
			this.toolStripMenu = new System.Windows.Forms.ToolStrip();
			this.tsbClose = new System.Windows.Forms.ToolStripButton();
			this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbSample = new System.Windows.Forms.ToolStripButton();
			this.maintbllayout = new System.Windows.Forms.TableLayoutPanel();
			this.listViewPCF = new System.Windows.Forms.ListView();
			this.toolStripMenu.SuspendLayout();
			this.maintbllayout.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripMenu
			// 
			this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1,
            this.tsbSample});
			this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
			this.toolStripMenu.Name = "toolStripMenu";
			this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
			this.toolStripMenu.Size = new System.Drawing.Size(2824, 52);
			this.toolStripMenu.TabIndex = 4;
			this.toolStripMenu.Text = "toolStrip1";
			// 
			// tsbClose
			// 
			this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbClose.Name = "tsbClose";
			this.tsbClose.Size = new System.Drawing.Size(211, 45);
			this.tsbClose.Text = "Close this tool";
			this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
			// 
			// tssSeparator1
			// 
			this.tssSeparator1.Name = "tssSeparator1";
			this.tssSeparator1.Size = new System.Drawing.Size(6, 52);
			// 
			// tsbSample
			// 
			this.tsbSample.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbSample.Name = "tsbSample";
			this.tsbSample.Size = new System.Drawing.Size(110, 45);
			this.tsbSample.Text = "Try me";
			this.tsbSample.Click += new System.EventHandler(this.tsbSample_Click);
			// 
			// maintbllayout
			// 
			this.maintbllayout.ColumnCount = 2;
			this.maintbllayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.31445F));
			this.maintbllayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.68555F));
			this.maintbllayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.maintbllayout.Controls.Add(this.listViewPCF, 0, 0);
			this.maintbllayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.maintbllayout.Location = new System.Drawing.Point(0, 52);
			this.maintbllayout.Name = "maintbllayout";
			this.maintbllayout.RowCount = 2;
			this.maintbllayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.75477F));
			this.maintbllayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.245232F));
			this.maintbllayout.Size = new System.Drawing.Size(2824, 1468);
			this.maintbllayout.TabIndex = 5;
			// 
			// listViewPCF
			// 
			this.listViewPCF.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewPCF.HideSelection = false;
			this.listViewPCF.Location = new System.Drawing.Point(3, 3);
			this.listViewPCF.Name = "listViewPCF";
			this.listViewPCF.Size = new System.Drawing.Size(1076, 1384);
			this.listViewPCF.TabIndex = 0;
			this.listViewPCF.UseCompatibleStateImageBehavior = false;
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
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ToolStrip toolStripMenu;
		private System.Windows.Forms.ToolStripButton tsbClose;
		private System.Windows.Forms.ToolStripButton tsbSample;
		private System.Windows.Forms.ToolStripSeparator tssSeparator1;
		private System.Windows.Forms.TableLayoutPanel maintbllayout;
		private System.Windows.Forms.ListView listViewPCF;
	}
}
