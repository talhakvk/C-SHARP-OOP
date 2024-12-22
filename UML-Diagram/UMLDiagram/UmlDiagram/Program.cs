using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmlDiagram
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    // ------------------- Diagram 1: Araç Kiralama Sistemi -------------------

    // Müşteriyi temsil eden sınıf
    class Customer
    {
        public int Id { get; set; } // Müşteriye ait benzersiz ID
        public string Name { get; set; } // Müşterinin adı
        public string Contact { get; set; } // İletişim bilgileri
        public string Address { get; set; } // Müşterinin adresi
        public int Payment { get; set; } // Ödeme bilgileri

        public void Update()
        {
            // Müşteri bilgilerini güncelleme yöntemi
        }
    }

    // Aracı temsil eden sınıf
    class Car
    {
        public int Id { get; set; } // Araca ait benzersiz ID
        public int Details { get; set; } // Araç detayları (ör. model, yıl)
        public string OrderType { get; set; } // Sipariş türü (ör. kiralama türü)

        public void ProcessDebit()
        {
            // Araç için borç işlemlerini gerçekleştiren yöntem
        }
    }

    // Kiralama sahibini temsil eden sınıf
    class RentingOwner
    {
        public int Id { get; set; } // Sahibine ait benzersiz ID
        public string Name { get; set; } // Sahibinin adı
        public int Age { get; set; } // Sahibinin yaşı
        public string ContactNum { get; set; } // Sahibinin iletişim numarası
        public string Username { get; set; } // Giriş kullanıcı adı
        public string Password { get; set; } // Giriş şifresi

        public void VerifyAccount()
        {
            // Hesap bilgilerini doğrulama yöntemi
        }
    }

    // İşlemi temsil eden sınıf
    class Transaction
    {
        public int Id { get; set; } // İşleme ait benzersiz ID
        public string Name { get; set; } // İşleme bağlı isim
        public string Date { get; set; } // İşlem tarihi
        public string Address { get; set; } // İşlemle ilgili adres

        public void Update()
        {
            // İşlem bilgilerini güncelleme yöntemi
        }
    }

    // Rezervasyonu temsil eden sınıf
    class Reservation
    {
        public int Id { get; set; } // Rezervasyona ait benzersiz ID
        public string Details { get; set; } // Rezervasyon detayları
        public string List { get; set; } // Rezerve edilen öğelerin listesi

        public void Confirmation()
        {
            // Rezervasyonu onaylama yöntemi
        }
    }

    // Ödeme bilgilerini temsil eden sınıf
    class Payment
    {
        public int Id { get; set; } // Ödemeye ait benzersiz ID
        public int CardNumber { get; set; } // Kredi kartı numarası
        public string Amount { get; set; } // Ödeme tutarı

        public void Add()
        {
            // Ödeme ekleme yöntemi
        }

        public void Update()
        {
            // Ödeme bilgilerini güncelleme yöntemi
        }
    }

    // Kiralamaları temsil eden sınıf
    class Rentals
    {
        public int Id { get; set; } // Kiralamaya ait benzersiz ID
        public string Names { get; set; } // Kiralanan öğelerin isimleri
        public string Price { get; set; } // Kiralama fiyatı

        public void Add()
        {
            // Kiralama ekleme yöntemi
        }

        public void Update()
        {
            // Kiralama bilgilerini güncelleme yöntemi
        }
    }

    // ------------------- Diagram 2: Evcil Hayvan Sistemi -------------------

    // Tanımlanabilir nesneleri temsil eden arayüz
    interface Identifiable
    {
        string Id { get; } // Benzersiz kimlik
    }

    // Deneyimli sahipler için arayüz
    interface Experienced
    {
        void GainExperience(); // Deneyim kazanma yöntemi
    }

    // Sahibi temsil eden sınıf
    class Owner : Experienced
    {
        public string Name { get; set; } // Sahibinin adı

        public void GainExperience()
        {
            // Deneyim kazanma işlemini gerçekleştirme
        }
    }

    // Hayvanı temsil eden sınıf
    class Animal
    {
        public string Type { get; set; } // Hayvan türü
        public string Breed { get; set; } // Hayvanın cinsi
        public bool Carnivore { get; set; } // Hayvanın etçil olup olmadığını belirtir
    }

    // Aşıyı temsil eden sınıf
    class Vaccine
    {
        public string Name { get; set; } // Aşı adı
        public string Type { get; set; } // Aşı türü
    }

    // Evcil hayvan bilgilerini temsil eden sınıf
    class PetInformation
    {
        public List<string> Traits { get; set; } // Özelliklerin listesi
        public List<Vaccine> Vaccines { get; set; } // Aşıların listesi
    }

    // Evcil hayvanı temsil eden sınıf
    class Pet : Identifiable
    {
        public string Id { get; } // Evcil hayvana ait benzersiz kimlik
        public string Name { get; set; } // Evcil hayvanın adı
        public int Age { get; set; } // Evcil hayvanın yaşı
        public Owner Owner { get; set; } // Evcil hayvanın sahibi
        public Animal Type { get; set; } // Hayvan türü
        public PetInformation PetInfo { get; set; } // Evcil hayvan bilgileri

        public bool IsHerbivore()
        {
            // Hayvanın otçul olup olmadığını belirler
            return !Type.Carnivore;
        }

        public void Feed()
        {
            // Evcil hayvanı besleme yöntemi
        }
    }

    // ------------------- Diagram 3: Üniversite Sistemi -------------------

    // Kişiyi temsil eden sınıf
    class Person
    {
        public string Name { get; set; } // Kişinin adı
        public string PhoneNumber { get; set; } // Telefon numarası
        public string EmailAddress { get; set; } // E-posta adresi

        public void PurchaseParkingPass()
        {
            // Otopark geçiş kartı satın alma yöntemi
        }
    }

    // Adresi temsil eden sınıf
    class Address
    {
        public string Street { get; set; } // Sokak adresi
        public string City { get; set; } // Şehir
        public string State { get; set; } // Eyalet
        public int PostalCode { get; set; } // Posta kodu
        public string Country { get; set; } // Ülke

        public bool Validate()
        {
            // Adres bilgilerini doğrular
            return true;
        }

        public string OutputAsLabel()
        {
            // Adresi etiket olarak çıktı verir
            return $"{Street}, {City}, {State}, {PostalCode}, {Country}";
        }
    }

    // Öğrenciyi temsil eden sınıf (Person sınıfından türetilmiştir)
    class Student : Person
    {
        public int StudentNumber { get; set; } // Öğrenci numarası
        public int AverageMark { get; set; } // Öğrencinin not ortalaması

        public bool IsEligibleToEnroll(string course)
        {
            // Öğrencinin bir derse kayıt olmaya uygun olup olmadığını kontrol eder
            return AverageMark >= 50;
        }

        public int GetSeminarsTaken()
        {
            // Alınan seminerlerin sayısını döndürür
            return 5;
        }
    }

    // Profesörü temsil eden sınıf (Person sınıfından türetilmiştir)
    class Professor : Person
    {
        public int Salary { get; set; } // Profesörün maaşı
        public int StaffNumber { get; set; } // Personel numarası
        public int YearsOfService { get; set; } // Hizmet yılı
        public int NumberOfClasses { get; set; } // Verilen ders sayısı
    }

}
