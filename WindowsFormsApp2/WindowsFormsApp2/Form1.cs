using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        HashSet<Point> mayınlar = new HashSet<Point>();
        HashSet<Point> bosAlanlar = new HashSet<Point>();
        Random rastgele = new Random();
        int mayınYok= 0;
        int toplamMayın = 80;
        int yerleştirilenMayın = 0;
        int mayınKoy = 0;
        int ilkTıklama = 0;
        bool renk = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            butonlarıEkle();
        }

        public void butonlarıEkle()
        {
            for (int x = 0; x < panel1.Width; x += 25)
            {
                renk = !renk;
                for (int y = 0; y < panel1.Height; y += 25)
                {
                    yeniButon(new Point(x, y), renk);
                    renk = !renk;
                }
            }
            toplamMayınLabel.Text = ("Toplam Mayın: " + yerleştirilenMayın.ToString());
        }

        public void yeniButon(Point konum, bool rengi)
        {
            Button btn = new Button();
            btn.Name = "mayın" + konum.X + konum.Y;
            btn.Size = new Size(25, 25);
            btn.Location = (konum);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            if (renk) btn.BackColor = Color.FromArgb(95,170,20);
            else btn.BackColor = Color.YellowGreen;
            btn.Cursor = Cursors.Hand;

            mayınKoy = rastgele.Next(0, 100);
            if (yerleştirilenMayın < toplamMayın && mayınKoy < 14)
            {
                // Butonların rastgele olarak Tag değerini değiştirerek mayınları yerleştirmiş oluyoruz 
                btn.Tag = true;
                yerleştirilenMayın++;
                mayınlar.Add(btn.Location);
            }
            else btn.Tag = false;
            btn.Click += new EventHandler(btnTıkla);
            btn.MouseDown += new MouseEventHandler(btnSağTıkla);
            panel1.Controls.Add(btn);
        }
        void btnTıkla(object sender, EventArgs e)
        {
            mayınYok++;
            kalanHamleLabel.Text = ("Kalan Hücre: " + (400-yerleştirilenMayın-mayınYok).ToString());
            if (mayınYok == 400-yerleştirilenMayın)
            {
                MessageBox.Show("Oyunu Kazandınız", "Oyun Bitti!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                YenidenBaslat();
                return;
            }
            Button btn = (sender as Button);
            if (ilkTıklama == 0) // ilk tıklamada mayına denk gelmesi durumunda oradaki mayın silinir
            {
                if ((bool)btn.Tag)
                {
                    yerleştirilenMayın--;
                    toplamMayınLabel.Text = ("Toplam Mayın: " + yerleştirilenMayın.ToString());
                    btn.Tag = false;
                }
            }
            if ((bool)btn.Tag)
            {
                MayınlarıGöster();
                MessageBox.Show("Oyunu Kaybettiniz", "Oyun Bitti!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                YenidenBaslat();
            }
            else
            {
                btn.BackColor = Color.FromArgb(180, 180, 180);
                int etrafMayınSayısı = etrafındakiMayınlar(btn.Location);
                if (etrafMayınSayısı != 0) btn.Text = etrafMayınSayısı.ToString();
                btn.Enabled = false;
            }    
        }
        void btnSağTıkla(object sender, MouseEventArgs e)
        {
            Button btn = (sender as Button);

            if (e.Button == MouseButtons.Right)
            {
                if (btn.Text.Equals("X")) btn.Text = "";
                else btn.Text = "X";
            }
            
        }
        void MayınlarıGöster()
        {
            foreach (Point konum in mayınlar)
            {
                Button btn = panel1.Controls.OfType<Button>().FirstOrDefault(b => b.Location == konum);
                btn.Text = "X";
            }
        }

        public int etrafındakiMayınlar (Point konum)
        {
            if (bosAlanlar.Contains(konum)) return 0;

            bosAlanlar.Add(konum);

            int etraftakiMayın = 0;

            int[] komsuX = {-25, 0 , 25};
            int[] komsuY = { -25, 0, 25 };

            foreach (int komsununX in komsuX)
            {
                foreach (int komsununY in komsuY)
                {
                    if (komsununX == 0 && komsununY == 0) continue;

                    Point komsuKonum = new Point(konum.X + komsununX, konum.Y + komsununY);

                    // panel1 içerisindeki butonların konumlarını komsuKonum ile karşılaştırır
                    // ve eşleşen durum olursa o konumdaki butonu döndürür
                    Button komsuButon = panel1.Controls.OfType<Button>().FirstOrDefault(b => b.Location == komsuKonum);

                    if (komsuButon != null && (bool)komsuButon.Tag) etraftakiMayın++;

                }
            }
            if(etraftakiMayın == 0)
            {
                ilkTıklama++;
                foreach (int komsununX in komsuX)
                {
                    foreach (int komsununY in komsuY)
                    {
                        if (komsununX == 0 && komsununY == 0) continue;

                        Point komsuKonum = new Point(konum.X + komsununX, konum.Y + komsununY);

                        Button komsuButon = panel1.Controls.OfType<Button>().FirstOrDefault(b => b.Location == komsuKonum);

                        if (komsuButon != null && !bosAlanlar.Contains(komsuKonum)) komsuButon.PerformClick();

                    }
                }
            }
            return etraftakiMayın;
        }
        public void YenidenBaslat()
        {
            mayınYok = 0;
            yerleştirilenMayın = 0;
            ilkTıklama = 0;
            mayınlar.Clear();
            bosAlanlar.Clear();
            panel1.Controls.Clear();
            butonlarıEkle();
            kalanHamleLabel.Text = ("Kalan Hücre: " + (400 - yerleştirilenMayın - mayınYok).ToString());
        }
    }
}
