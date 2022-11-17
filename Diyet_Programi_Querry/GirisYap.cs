﻿using DataAccess.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diyet_Programi_Querry
{
    public partial class GirisYap : Form
    {
        public GirisYap()
        {
            InitializeComponent();
        }
        DietQueryDBContext db;
        public static int gelenID;
        private void btnGirisYap_Click_1(object sender, EventArgs e)
        {
             db = new DietQueryDBContext();
            KullaniciBilgisi kullaniciAdi = db.KullaniciBilgisis.Where(x => x.KullaniciAd == textBox1.Text).FirstOrDefault();
            KullaniciBilgisi kullaniciSifre = db.KullaniciBilgisis.Where(x => x.Sifre == textBox2.Text).FirstOrDefault();
            int hak = 3;
            do
            {



                if (kullaniciAdi == null || kullaniciSifre == null)
                {
                    hak--;
                    if (hak == 0)
                    {
                        MessageBox.Show("Girişiniz Bloke Olmuştur.");
                        btnGirisYap.Enabled = false;
                        break;
                    }



                    MessageBox.Show($"Giriş Başarısız. Tekrar Giriniz. {hak} Adet Giriş Hakkınız Kalmıştır.");
                }
                else
                {
                    MessageBox.Show("Giriş Başarılıdır.");
                    AnasayfaForm anasayfaForm = new AnasayfaForm();
                    anasayfaForm.Show();
                    this.Close();
                    break;
                }
            } while (true);

            gelenID = kullaniciAdi.ID;
        }

        private void btnGeri_Click_1(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }
    }
}

