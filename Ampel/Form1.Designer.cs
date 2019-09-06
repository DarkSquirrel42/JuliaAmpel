namespace Ampel
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ampelControl1 = new Ampel.AmpelControl();
            this.ampelControl2 = new Ampel.AmpelControl();
            this.fußgängerAmpelComponent1 = new Ampel.FußgängerAmpel.FußgängerAmpelComponent(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ampelControl1
            // 
            this.ampelControl1.AmpelBild = Ampel.AmpelBildEnum.Aus;
            this.ampelControl1.AutoSize = true;
            this.ampelControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ampelControl1.Location = new System.Drawing.Point(60, 55);
            this.ampelControl1.Name = "ampelControl1";
            this.ampelControl1.Size = new System.Drawing.Size(30, 90);
            this.ampelControl1.TabIndex = 0;
            // 
            // ampelControl2
            // 
            this.ampelControl2.AmpelBild = Ampel.AmpelBildEnum.Aus;
            this.ampelControl2.AutoSize = true;
            this.ampelControl2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ampelControl2.Location = new System.Drawing.Point(197, 55);
            this.ampelControl2.Name = "ampelControl2";
            this.ampelControl2.Size = new System.Drawing.Size(30, 90);
            this.ampelControl2.TabIndex = 1;
            // 
            // fußgängerAmpelComponent1
            // 
            this.fußgängerAmpelComponent1.AutoAmpel = this.ampelControl1;
            this.fußgängerAmpelComponent1.FußgängerAmpel = this.ampelControl2;
            this.fußgängerAmpelComponent1.Knopf = this.button1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(178, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(702, 388);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ampelControl2);
            this.Controls.Add(this.ampelControl1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AmpelControl ampelControl1;
        private AmpelControl ampelControl2;
        private FußgängerAmpel.FußgängerAmpelComponent fußgängerAmpelComponent1;
        private System.Windows.Forms.Button button1;
    }
}

