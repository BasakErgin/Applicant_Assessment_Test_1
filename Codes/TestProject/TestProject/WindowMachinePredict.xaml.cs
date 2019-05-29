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
    /// Interaction logic for WindowPickNumber.xaml
    /// </summary>
    public partial class WindowMachinePredict : Window
    {
        int[] machinePickedNumber;
        public WindowMachinePredict()
        {
            InitializeComponent();
            MachineRandomNumber(); //Makine ilk olarak random bir tahmin yapiyor
            txtbx_plus.Text = "0";
            txtbx_minus.Text = "0";
        }

        #region Textbox'un sadece sayisal degerleri kabul etmesi icin
        private void NumericInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValid(((TextBox)sender).Text + e.Text);
        }
        public static bool IsValid(string my_str)
        {
            int i;
            return int.TryParse(my_str, out i) && i >= 0 && i <= 9999;
        }
        #endregion

        public void MachineRandomNumber()
        {
            machinePickedNumber = new int[4]; //Makinenin sectigi sayi

            Random randomGenerate = new Random();
            int randomNumber = randomGenerate.Next(1000, 10000); //4 basamakli random bir sayi uretiyor bu sayi makinenin sectigi sayi olarak daha sonra atanacak

            txtbxMachinePrediction.Text = randomNumber.ToString();

        }

        //main function
        private void BtnNo_Click(object sender, RoutedEventArgs e)
        {
            int temp_plus_digit = Convert.ToInt16(txtbx_plus.Text.ToString()); //Dogru bilinen digit
            int temp_minus_digit = Convert.ToInt16(txtbx_minus.Text.ToString()); //Rakam olarak dogru ama basamak olarak yanlis olan digit
            int thousands = 10, hundreds = 10, tens = 10, units = 10; //Checkboxlardan gelen dogru bilinen basamak degerini kaydetmek icin
            int machinePredictionNumber = Convert.ToInt16(txtbxMachinePrediction.Text.ToString()); //Makinenin tahmini
            int[] tempArray = new int[4]; //Makinenin tahmini olan sayiyi basamaklara bolup karsilastirirma icin kullanilacak
            int[] tempArray2 = new int[4]; //Basamak degisimi icin
            int[] newRandomMachineNumber = new int[4]; //Dogru bilinen basamak ve rakamlardan sonra bu kriterlere gore makinenin tahmin edecegi yeni sayi


            for (int i = 0; i < 4; i++)
            {
                tempArray[i] = machinePredictionNumber % 10;

                machinePredictionNumber = machinePredictionNumber / 10;
            }

            //Hicbir rakam ve basamak degeri dogru tahmin edilememisse
            if (temp_plus_digit == 0 && temp_minus_digit == 0)
            {
                MachineRandomNumber();
            }
            //Dogru basamak ve rakam degeri (+) tahmin edilmisse
            else if (temp_plus_digit > 0 && temp_plus_digit < 4)
            {

                #region Dogru bilinen rakamlari ve basamaklari tempArray'e aktarma
                if (chbx_thousands.IsChecked == true)
                {
                    thousands = tempArray[3]; //Dogru bilinen binler basamagindaki rakami tutar
                }
                if (chbx_hundreds.IsChecked == true)
                {
                    hundreds = tempArray[2]; //Dogru bilinen yuzler basamagindaki rakami tutar
                }
                if (chbx_tens.IsChecked == true)
                {
                    tens = tempArray[1]; //Dogru bilinen onlar basamagindaki rakami tutar
                }
                if (chbx_units.IsChecked == true)
                {
                    units = tempArray[0]; //Dogru bilinen birler basamagindaki rakami tutar
                }
                #endregion
                #region Yeni bir random sayi uretmeden once bilinen rakamlari sayida sabitlemek icin arraye aktarma
                if (thousands != 10) {
                    newRandomMachineNumber[3] = thousands;
                }
                if (hundreds != 10)
                {
                    newRandomMachineNumber[2] = hundreds;
                }
                if (tens != 10)
                {
                    newRandomMachineNumber[1] = tens;
                }
                if (units != 10)
                {
                    newRandomMachineNumber[0] = units;
                }
                #endregion
                //Sadece (+) olan degerler varsa
                if (temp_minus_digit == 0)
                {
                    #region Yeni random sayiyi uretip textboxa yazdirma
                    Random randomGenerate = new Random();
                    if (thousands == 10)
                    {

                        int randomNumber = randomGenerate.Next(1, 9); //İlk basamak 0 olamayacagi icin 1 ve 9 arasi random bir sayi atiyor yeni tahmini icin
                        newRandomMachineNumber[3] = randomNumber;
                    }
                    if (hundreds == 10)
                    {
                        int randomNumber = randomGenerate.Next(0, 9); //İlk basamak 0 olamayacagi icin 1 ve 9 arasi random bir sayi atiyor yeni tahmini icin
                        newRandomMachineNumber[2] = randomNumber;
                    }
                    if (tens == 10)
                    {
                        int randomNumber = randomGenerate.Next(0, 9); //İlk basamak 0 olamayacagi icin 1 ve 9 arasi random bir sayi atiyor yeni tahmini icin
                        newRandomMachineNumber[1] = randomNumber;
                    }
                    if (units == 10)
                    {
                        int randomNumber = randomGenerate.Next(0, 9); //İlk basamak 0 olamayacagi icin 1 ve 9 arasi random bir sayi atiyor yeni tahmini icin
                        newRandomMachineNumber[0] = randomNumber;
                    }


                    //Olusan yeni sayiyi yazdirma
                    txtbxMachinePrediction.Text = newRandomMachineNumber[3].ToString() + newRandomMachineNumber[2].ToString() + newRandomMachineNumber[1].ToString()
                           + newRandomMachineNumber[0].ToString();
                    #endregion
                }
                //(+) degerler yaninda basamaklari farkli olan rakamlar varsa (-)
                else
                {
                    //Default degerler
                    for (int c = 0; c < 4; c++) {
                        tempArray2[c] = 10;
                    }

                    int count = 0;
                    //Dogru bilinemeyen sayilarin arraydaki yerini tutuyor
                    for (int y = 0; y < 4; y++) {

                        if (newRandomMachineNumber[y] != tempArray[y])
                        {
                            tempArray2[count] = y;
                            count++;
                        }

                    }
                 
                    //Rakam dogru ama basamak degeri farkli olan sayilari bulmak icin swap edilip bu sekilde tekrar sorulur
                    int temp = tempArray[tempArray2[0]];
                    tempArray[tempArray2[0]] = tempArray[tempArray2[1]];
                    tempArray[tempArray2[1]] = temp;
                    //Olusan yeni sayiyi yazdirma
                    txtbxMachinePrediction.Text = tempArray[3].ToString() + tempArray[2].ToString() + tempArray[1].ToString()
                           + tempArray[0].ToString();
                }

            }
            //Sadece rakam degerleri dogru tahmin edilmisse (-)
            else if (temp_minus_digit > 0 && temp_plus_digit ==0) {
                for (int a=0, j=0; a< temp_minus_digit && j<4; a++, j++) {
                    
                    int temp = tempArray[j];
                    tempArray[j] = tempArray[j + 1];
                    tempArray[j + 1] = temp;
                }
                txtbxMachinePrediction.Text = tempArray[3].ToString() + tempArray[2].ToString() + tempArray[1].ToString()
                           + tempArray[0].ToString();
            }   
        }

        

        private void BtnHomepage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }

        private void BtnYes_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Oyun bitti!");
        }
    
    }

      
}
