using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Windows.Forms;


namespace Varbotdefteri
{
    public partial class Form1 : Form
    {
        List<string> nots = new List<string>();
        string not;
        int selectedIndex;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listyukle();
        }

        private void notyaz_TextChanged(object sender, EventArgs e)
        {
            not = notyaz.Text;
        }

        private void notekle_Click(object sender, EventArgs e)
        {

            notekleme();
        }

        private void notsil_Click(object sender, EventArgs e)
        {
            notsilme();
        }

        private void notlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex = notlar.SelectedIndex;

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            listkaydet();
        }

        private void alldelete_Click(object sender, EventArgs e)
        {
            hepsinisil();
        }

        void listkaydet()
        {
            string kaydedilecekMetin = string.Join("|", nots);
            Varnotdefteri.Properties.Settings.Default.Notlar = kaydedilecekMetin;
            Varnotdefteri.Properties.Settings.Default.Save();
        }
        void listyukle()
        {
            string kaydedilenMetin = Varnotdefteri.Properties.Settings.Default.Notlar;
            if (!string.IsNullOrEmpty(kaydedilenMetin))
            {
                string[] notDizisi = kaydedilenMetin.Split('|');
                nots = new List<string>(notDizisi);
                notlar.Items.AddRange(notDizisi);
            }
        }
        void notsilme()
        {
            try
            {
                int index = int.Parse(not);
                nots.RemoveAt(index);
                notlar.Items.RemoveAt(index);
            }
            catch
            {
                try
                {
                    int sel = notlar.SelectedIndex;
                    if (sel >= 0 && sel < nots.Count)
                    {
                        nots.RemoveAt(sel - 1);
                        notlar.Items.RemoveAt(sel);
                        return;
                    }
                }
                catch
                {
                    if (nots.Contains(notyaz.Text))
                        nots.Remove(notyaz.Text);
                    notlar.Items.Remove(notyaz.Text);

                }

            }

        }
        void notekleme()
        {
            nots.Add(notyaz.Text);
            notlar.Items.Add(notyaz.Text);
        }
        void notdegistir()
        {
            if (selectedIndex >= 0 && selectedIndex < nots.Count)
            {
                nots[selectedIndex] = notyaz.Text;
                notlar.Items[selectedIndex] = notyaz.Text;
            }
            else
            {
                MessageBox.Show("Lütfen deðiþtirmek istediðiniz notu seçin. en son satýr deðiþtirelemez", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void hepsinisil()
        {
            DialogResult silmekontrol = MessageBox.Show("Tüm notlar silinecek, emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (silmekontrol == DialogResult.Yes)
            {
                nots.Clear();
                notlar.Items.Clear();
            }
            else
            { }
        }


        private void dosyakaydet()
        {
            // 1. SaveFileDialog ayarlarýný yap
            saveFileDialog1.Filter = "Metin Dosyasý (*.txt)|*.txt|Tüm Dosyalar (*.*)|*.*";
            saveFileDialog1.Title = "Notlarý Metin Dosyasý Olarak Kaydet";
            saveFileDialog1.FileName = "notlarim.txt"; // Varsayýlan dosya adý

            // 2. Diyaloðu göster ve Tamam'a basýp basmadýðýný kontrol et
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // 3. Kullanýcýnýn seçtiði dosya yolunu al
                string dosyaYolu = saveFileDialog1.FileName;

                try
                {
                    // 4. ListBox'taki (veya 'nots' listendeki) tüm öðeleri dosyaya yaz
                    // (Senin kodunda 'nots' adýnda bir List<string> vardý, onu kullanmak en temizidir)
                    File.WriteAllLines(dosyaYolu, nots);

                    // Alternatif: Doðrudan ListBox'tan almak istersen:
                    // List<string> satirlar = new List<string>();
                    // foreach (var item in notlar.Items)
                    // {
                    //     satirlar.Add(item.ToString());
                    // }
                    // File.WriteAllLines(dosyaYolu, satirlar);

                    MessageBox.Show("Notlar baþarýyla metin dosyasýna kaydedildi!", "Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dosya kaydedilirken bir hata oluþtu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Dosyadanyukle()
        {
            // 1. OpenFileDialog ayarlarýný yap
            openFileDialog1.Filter = "Metin Dosyasý (*.txt)|*.txt";
            openFileDialog1.Title = "Metin Dosyasýndan Not Yükle";

            // 2. Diyaloðu göster ve Tamam'a basýp basmadýðýný kontrol et
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // 3. Kullanýcýnýn seçtiði dosya yolunu al
                string dosyaYolu = openFileDialog1.FileName;

                try
                {
                    // 4. Dosyadaki tüm satýrlarý oku
                    string[] yuklenenSatirlar = File.ReadAllLines(dosyaYolu);

                    // 5. Mevcut listeleri temizle (öncekiler kaybolsun)
                    nots.Clear();
                    notlar.Items.Clear();

                    // 6. Okunan satýrlarý hem 'nots' listesine hem de 'notlar' ListBox'ýna ekle
                    nots.AddRange(yuklenenSatirlar);
                    notlar.Items.AddRange(yuklenenSatirlar);

                    MessageBox.Show("Notlar baþarýyla yüklendi.", "Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dosya okunurken bir hata oluþtu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void degistir_Click(object sender, EventArgs e)
        {
            notdegistir();
        }

        private void notlar_DoubleClick(object sender, EventArgs e)
        {
            DialogResult secim = MessageBox.Show("Notlarý txt olarak kaydetmek için Evet'e, notlarý yüklemek için Hayýr'a basýn", "Seçim", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (secim == DialogResult.Yes)
            {
                dosyakaydet();
            }
            else if (secim == DialogResult.No)
            {
                Dosyadanyukle();
            }
            else
            { }
        }
    }
}
