using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
namespace TestProject
{
    /// <summary>
    /// Interaction logic for WindowPredictNumber.xaml
    /// </summary>
    public partial class WindowUserPredict : Window
    {
        int[] machinePickedNumber;
        public WindowUserPredict()
        {
            InitializeComponent();
            MachineRandomNumber();
        }

        #region Textbox'un sadece sayisal degerleri kabul etmesi icin
        private void NumericInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValid(((TextBox)sender).Text + e.Text);
        }
        public static bool IsValid(string my_str)
        {
            int i;
            return int.TryParse(my_str, out i) && i >=0  && i <= 9999;
        }
        #endregion

        public void MachineRandomNumber() {
            machinePickedNumber = new int[4]; //Makinenin sectigi sayi
           
            Random randomGenerate = new Random();
            int randomNumber = randomGenerate.Next(1000, 10000); //4 basamakli random bir sayi uretiyor bu sayi makinenin sectigi sayi olarak daha sonra atanacak

            //random elde ettigimiz sayiyi basamaklarina ayirip hangi basamakta hangi rakamlar var makinenin sectigi sayiya atiyoruz.
            for (int i = 0; i < 4; i++)
            {
                machinePickedNumber[i] = randomNumber % 10;
                randomNumber = randomNumber / 10;
            }

        }

        //main function
        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            int i;

            int plus_digit = 0; //Dogru bilinen digit
            int minus_digit = 0; //Rakam olarak dogru ama basamak olarak yanlis olan digit
            int userPredictionNumber; //Kullanicinin tahmini
            int[] tempDigit = new int[4]; //Kullanicinin tahmini olan sayiyi basamaklara bolup makinenin sectigi sayi ile karsilastirirken kullanilacak

            int x = 0;
            while (x < 4) //Kullanici makinenin tahmin ettigi sayiyi bulana kadar devam edecek
            {
                x++; //4 basamaga da bakmasi icin var, sadece sayac gorevi goruyor
                plus_digit = 0;
                minus_digit = 0;

                userPredictionNumber = 0; //Kullanicinin girdigi tahmini sayi
                try
                {
                    userPredictionNumber = Convert.ToInt16(txtbxUserPrediction.Text.ToString());
                }
                catch (Exception)
                {
                    //Textboxtan okunan degeri stringe cevirirken bir hata oldu!
                }

                //Kullanicinin tahmini olan sayiyi basamaklarina bol ve digitValue icine kaydet daha sonra karsilastirma icin kullanilacak
                for (i = 0; i < 4; i++)
                {
                    tempDigit[i] = userPredictionNumber % 10;

                    userPredictionNumber = userPredictionNumber / 10;

                    bool digitValue = false; //digitin rakam degeri


                    //Kullanicinin girdigi sayinin bir basamagi icin makinenin tahmin ettigi sayinin tum(dort) basamagina da bakar

                    for (int m = 0; m < 4; m++)
                    {
                        if (tempDigit[i] == machinePickedNumber[m])
                        {
                            digitValue = true; //Elementler ayni rakam degerine sahip
                            break; //Rakamlarin basamaklarini kontrol etmek icin cik
                        }
                    }

                    if (digitValue == true)
                    {
                        if (tempDigit[i] == machinePickedNumber[i])
                        {
                            plus_digit++;  //Rakam degerleri esit olan digitlerin basamaklari da ayni ise plus_digit'i arttir
                        }
                        else
                        {
                            minus_digit++; //Rakam degerleri esit fakat basamaklari farkli olan digit varsa minus_digit'i arttir
                        }
                    }

                }

                //Sonuc kismi icin + ve - olan degerlerin yazdirilmasi
                txtb_plus.Text = plus_digit.ToString();
                txtb_minus.Text = minus_digit.ToString();

                if (plus_digit == 4)
                {
                    MessageBox.Show("Oyun bitti!");
                }
            }
        }

        private void BtnHomepage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }
    }
}
