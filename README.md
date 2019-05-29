# Applicant Assessment Test 1
Bilgisayar ve kullanıcı arasında oynanan bir sayı tahmin oyunudur.
## Kurulum

1. Programı oluşturan kod sayfaları klasör olarak bilgisayara indirilir veya kurulur. Bunun için 'releases' sayfasından projenin ilk versiyonunu bilgisayaranıza indirmeniz yeterlidir.
2. Klasörün içindeki *TestProject.exe* dosyasının çalıştırılması halinde program kullanılmak için çalışmaya başlar. *(...\TestProject\TestProject\bin\Debug\TestProject.exe)*
> Programın kurulumunda herhangi bir veritabanı kullanımı gerekmemektedir.

## Kullanım Kılavuzu

![image1](https://i.ibb.co/rtQLpy6/fig1.png)
###### *Figür 1*

* Program çalıştırıldıktan sonra ilk olarak "Anasayfa" penceresi açılır *(Figür 1)*. Burada kullanıcıya iki seçenek sunulur. "**Bir Sayı Tut**" yazılı buton kullanıcıyı kullanıcının içinden bir sayı tuttuğu ve bilgisayarın bu sayıyı tahmin etmeye çalıştığı diğer bir pencereye yönlendirir. "**Sayıyı Tahmin Et**" yazılı buton ise bilgisayarın bir sayı tuttuğu ve kullanıcının bunu bilmeye çalıştığı bir pencereye yönlendirir.

![image1](https://i.ibb.co/pyxhSSC/fig2.png)
###### *Figür 2*

1. Kullanıcı "**Bir Sayı Tut**" yazılı butona basarsa bu oyuna ait pencere açılır *(Figür 2)*. 
* Bu pencerede orta kısımda makinenin kullanıcının tahminini bilmeye yönelik 4 basamaklı sayı tahmini çıkar. Eğer bu sayının içinde rakam değeri ve basamak değeri doğru olarak tahmin edilmiş sayı varsa (ama sayı tamamen doğru tahmin edilmemişse) kullanıcı bunu "Hayır" butonun yanındaki (+) işaretinin yanına yazmalıdır ve hangi basamağın doğru seçildiğine kutucuklardan tik atmalıdır.
* Eğer makinenin rakam değeri olarak doğru ama basamak olarak yanlış bildiği sayı değerini de (-) işaretinin yanına yazılmalıdır.
* Eğer herhangi bir rakam ve basamak değeri doğru bilinememişse (+) ve (-) değerleri 0 olarak bırakılmalıdır.
* (+) ve (-) değerler tam ve doğru olarak girildikten sonra "Hayır" butonuna basılarak makinenin yeni bir tahmin yapması beklenir.
* Eğer makine sayıyı doğru bilirse "Evet" butonuna basılır ve "Oyun bitti!" mesajı görülür.
* Sol sağ üstteki ev resmi bulunan buton ise "Ansayfa" için bir geri dönüş butonudur.

![image1](https://i.ibb.co/R4twG3Z/fig3.png)
###### *Figür 3*

2. Kullanıcı "**Sayıyı Tahmin Et**" yazılı butona basarsa bu oyuna ait pencere açılır *(Figür 3)*. 
* Bu pencerede orta kısımda kullanıcının makinenin tahminini bilmeye yönelik 4 basamaklı sayı girilmesi gereken alan çıkar. Kullanıcı 4 basamaklı sayı tahminini yazdıktan sonra "Gönder" butonuna basarak bilgisayardan dönüt bekler.
* Eğer kullanıcının girdiği sayı değeri içinde hem rakam hem basamak değeri doğru olan varsa (+) işaretinin yanında kaç tane olduğu sayı olarak yazacaktır. 
* Eğer kullanıcının girdiği sayı değeri içinde rakam değeri doğru ama basamak değeri yanlış olan varsa (-) işaretinin yanında kaç tane olduğu sayı olarak yazacaktır. 
* Kullanıcı yeni bir tahmin yaparken önceki tahmini silip yenisi yazmalıdır.
* Eğer (+) işaretinin yanında "4" yazarsa 4 basamağın da doğru bilindiği-*sayının doğru tahmin edildiği*- anlamına gelir ve "Oyun bitti!" mesajı çıkar, oyun biter.
* Sol sağ üstteki ev resmi bulunan buton ise "Ansayfa" için bir geri dönüş butonudur.
