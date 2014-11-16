using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace gunlukProje
{
	public partial class MainWindow : Window
	{
        #region Tanımlar
		DosyaIslemler dosyaIslemler;
        #endregion
        #region Metodlar

        public MainWindow()
		{
			this.InitializeComponent();
            dosyaIslemler = DosyaIslemler.getInstance(); // DosyaIslemleri sınıfından nesne oluşturduk.
		}

		private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
            
            dosyaKontrol(takvim1.DisplayDate); // Bugünün tarihini dosyaKontrol metoduna gönderdik.
		}

        private void takvim1_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {

            dosyaKontrol(takvim1.SelectedDates[0]); // Seçilen DateTime nesnesini dosyaKontrol metoduna gönderdik.
        }

        private void btnYeni_Click(object sender, RoutedEventArgs e)
        {
            txtMetin.Text = ""; // Yeni günlük oluşturacağı için metin alanımızı temizledik.
            txtMetin.IsReadOnly = false; // Metin alanımızı düzenleme özelliğini aktif hale getirdik.
            txtMetin.Foreground = new SolidColorBrush(Colors.Green); // Dolgu rengini yeşil yaptık.
            btnYeni.Visibility = System.Windows.Visibility.Collapsed; // Oluştur butonunu gizledik.
            btnSil.Visibility = System.Windows.Visibility.Collapsed;  // Sil butonunu gizledik.
            btnKaydet.Visibility = System.Windows.Visibility.Visible; // Kaydet butonunu gösterdik.
        }

        private void btnKaydet_Click(object sender, RoutedEventArgs e)
        {
           
            if (!(txtMetin.Text == "")) // Eğer metin alanımız boş değilse kaydetsin
            {
                dosyaIslemler.dosyaKaydet(txtMetin.Text);
                txtMetin.Foreground = new SolidColorBrush(Colors.Blue);
                txtMetin.IsReadOnly = true;
                btnKaydet.Visibility = System.Windows.Visibility.Collapsed;
                btnDuzenle.Visibility = System.Windows.Visibility.Visible;
                btnSil.Visibility = System.Windows.Visibility.Visible;
            }
            else // Yoksa mesaj versin dedik.
            {
                MessageBox.Show("Lütfen metin alanını doldurunuz!");
            }
            
            
        }

        private void btnDuzenle_Click(object sender, RoutedEventArgs e)
        {
            txtMetin.IsReadOnly = false; 
            /* Düzenle butonumuza bastığımızda metin alanımızın sadece okunabilir
             * özelliğini deaktif ettik
             */
            btnKaydet.Visibility = System.Windows.Visibility.Visible; // Kaydet butonunu gösterdik.
            btnDuzenle.Visibility = System.Windows.Visibility.Collapsed;// Düzenle butonunu gizledik.
            btnSil.Visibility = System.Windows.Visibility.Collapsed;// Sil butonunu gizledik.

        }

        private void btnSil_Click(object sender, RoutedEventArgs e)
        {
            /* Burada herhangi bir hata verince hata mesajını mesaj olarak göstermek için
                 Exception yapısını kullandık.(try-catch)
            */
            try
            {
                dosyaIslemler.dosyaSil(); // Seçili günlüğü siler.
                if (takvim1.SelectedDates.Count > 0)
                {
                    dosyaKontrol(takvim1.SelectedDates[0]); // GünlükKontrol metodu çağırılır çünkü
                    //günlük silindikten sonra metin alanı boş kalır bazı ayarlamalar
                    //(Günlük bulunamadı gibi)
                    //için tekrar metod çağırılır.
                }
                else
                {
                    dosyaKontrol(takvim1.DisplayDate);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Eğer bi hata ile karşılaşılırsa mesaj verilir.

            }
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            dosyaIslemler.Dispose();
        }

        private void dosyaKontrol(DateTime dt)
        {
            dosyaIslemler.dosyaFormatla(dt); // Günlük dosya adı formatlanır ve var mı yok mu kontrol edilir.
            if (dosyaIslemler.dosyaVarmi) // Eğer seçili tarih de günlük varsa metin döndürülür.
            {
                txtMetin.Foreground = new SolidColorBrush(Colors.Blue);
                txtMetin.IsReadOnly = true;
                txtMetin.Text = dosyaIslemler.dosyaMetinDondur();
                btnYeni.Visibility = System.Windows.Visibility.Collapsed;
                btnKaydet.Visibility = System.Windows.Visibility.Collapsed;
                btnDuzenle.Visibility = System.Windows.Visibility.Visible;
                btnSil.Visibility = System.Windows.Visibility.Visible;

            }
            else // Yoksa 'Günlük bulunamadı' yazılır.
            {
                txtMetin.IsReadOnly = true;
                txtMetin.Foreground = new SolidColorBrush(Colors.Red);
                txtMetin.Text = "Günlük bulunamadı.";
                btnYeni.Visibility = System.Windows.Visibility.Visible;
                btnKaydet.Visibility = System.Windows.Visibility.Collapsed;
                btnDuzenle.Visibility = System.Windows.Visibility.Collapsed;
                btnSil.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("www.yusufdoru.com" + Environment.NewLine + "doru@yusufdoru.com");            
        }
        #endregion

        

     
    }
}