namespace HangmanGame
{
    partial class Form1
    {
        // Bileşenlerin alan tanımları
        private DevExpress.XtraEditors.LabelControl labelHangman; // Hangman görüntüsü için
        private DevExpress.XtraEditors.LabelControl labelKelimeDurumu; // Kelimenin durumu için
        private DevExpress.XtraEditors.SimpleButton buttonTahminEt; // Tahmin butonu
        private DevExpress.XtraEditors.TextEdit textBoxHarf; // Harf giriş kutusu

        // Bileşenlerin form üzerinde yerleştirilmesi ve özelliklerinin ayarlanması
        private void InitializeComponent()
        {
            this.labelHangman = new DevExpress.XtraEditors.LabelControl();
            this.labelKelimeDurumu = new DevExpress.XtraEditors.LabelControl();
            this.buttonTahminEt = new DevExpress.XtraEditors.SimpleButton();
            this.textBoxHarf = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxHarf.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelHangman
            // 
            this.labelHangman.Appearance.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.labelHangman.Appearance.Options.UseFont = true;
            this.labelHangman.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelHangman.Location = new System.Drawing.Point(12, 12);
            this.labelHangman.Name = "labelHangman";
            this.labelHangman.Size = new System.Drawing.Size(300, 100);
            this.labelHangman.TabIndex = 0;
            this.labelHangman.Text = "Adam Asmaca";
            // 
            // labelKelimeDurumu
            // 
            this.labelKelimeDurumu.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.labelKelimeDurumu.Appearance.Options.UseFont = true;
            this.labelKelimeDurumu.Location = new System.Drawing.Point(12, 150);
            this.labelKelimeDurumu.Name = "labelKelimeDurumu";
            this.labelKelimeDurumu.Size = new System.Drawing.Size(126, 28);
            this.labelKelimeDurumu.TabIndex = 1;
            this.labelKelimeDurumu.Text = "_ _ _ _ _ _";
            // 
            // buttonTahminEt
            // 
            this.buttonTahminEt.Location = new System.Drawing.Point(80, 200);
            this.buttonTahminEt.Name = "buttonTahminEt";
            this.buttonTahminEt.Size = new System.Drawing.Size(100, 23);
            this.buttonTahminEt.TabIndex = 3;
            this.buttonTahminEt.Text = "Tahmin Et";
            this.buttonTahminEt.Click += new System.EventHandler(this.buttonTahminEt_Click);
            // 
            // textBoxHarf
            // 
            this.textBoxHarf.Location = new System.Drawing.Point(12, 200);
            this.textBoxHarf.Name = "textBoxHarf";
            this.textBoxHarf.Size = new System.Drawing.Size(50, 22);
            this.textBoxHarf.TabIndex = 2;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.buttonTahminEt);
            this.Controls.Add(this.textBoxHarf);
            this.Controls.Add(this.labelKelimeDurumu);
            this.Controls.Add(this.labelHangman);
            this.Name = "Form1";
            this.Text = "Adam Asmaca Oyunu";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textBoxHarf.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
