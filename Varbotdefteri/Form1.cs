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
            nots.Add(notyaz.Text);
            notlar.Items.Add(notyaz.Text);
        }

        private void notsil_Click(object sender, EventArgs e)
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

        private void notlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex = notlar.SelectedIndex;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            listkaydet();
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

        private void notyaz_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Enter(object sender, EventArgs e)
        {
            nots.Add(notyaz.Text);
            notlar.Items.Add(notyaz.Text);
        }

        private void alldelete_Click(object sender, EventArgs e)
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
    }
}
