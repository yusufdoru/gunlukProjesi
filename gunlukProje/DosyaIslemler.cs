using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;


namespace gunlukProje
{
    public class DosyaIslemler : IDisposable
    {
        private static DosyaIslemler _instance;
        private static object _lockObject = new object();
        public static DosyaIslemler getInstance()
        {
                if(_instance == null)
                {
                    lock (_lockObject) if(_instance == null)
                            _instance = new DosyaIslemler();
                }
                return _instance; 
        }
        private DosyaIslemler() // Yapıcı metodumuz
        {
        }
        #region Özellikler
        public string DosyaAdi { get; set; }
        public bool dosyaVarmi { get; set; }
        #endregion
        #region Metodlar
        public string dosyaMetinDondur() 
        {
            return Decode(File.ReadAllText(DosyaAdi)); // Belirtilen dosyanın içindeki metni string olarak döndürür.
        }

        public void dosyaKaydet(string dosyaMetin) 
        {
            File.WriteAllText(DosyaAdi, Encode(dosyaMetin)); // Dosya içine metin yazar ve kaydeder.
        }
        public void dosyaFormatla(DateTime zaman) 
        {
            
            string format = string.Format("{0}.txt", zaman.ToShortDateString().Replace('.', '-'));
            DosyaAdi = Environment.CurrentDirectory + "\\yazilar\\" + format;
            dosyaVarmi = dosyaKontrol();
        }
        public bool dosyaKontrol() 
        {
            return File.Exists(DosyaAdi); // Dosya'nın var olup, olmadığını kontrol eder.
        }
        public void dosyaSil() 
        {
            File.Delete(DosyaAdi); // Dosyayı siler.
        }
        public static string Encode(string toEncode)
        {
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
            return System.Convert.ToBase64String(toEncodeAsBytes);
        }
        public static string Decode(string encodedData)
        {

            byte[] encodedDataAsBytes = System.Convert.FromBase64String(encodedData);
            return System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
      
        #endregion
    }
	
}