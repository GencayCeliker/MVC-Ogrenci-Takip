# 🎓 MVC Öğrenci Takip

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=dotnet&logoColor=white)
![ASP.NET MVC 5](https://img.shields.io/badge/ASP.NET%20MVC-5.2-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-LINQ-6C1D5F?style=for-the-badge)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)

Öğrenci, ders, kulüp, not ve ürün kayıtlarının **ASP.NET MVC 5** ile yönetildiği web uygulaması. Veri erişimi Entity Framework ve **LINQ** sorgularıyla yapılır.

> Web Programlama dersinde MVC yapısını (Model–View–Controller), Razor görünümlerini ve LINQ ile CRUD işlemlerini öğrenmek için geliştirdim.

---

## 🚀 Özellikler

| Modül | İşlemler |
| --- | --- |
| **Öğrenciler** | Listele, yeni öğrenci, güncelle, sil (aktif/pasif durum) |
| **Dersler** | Listele, ders ekle, güncelle, sil |
| **Kulüpler** | Listele, yeni kulüp, güncelle, sil |
| **Notlar** | Not girişi ve silme |
| **Ürünler** | Listele, yeni ürün, güncelle, sil |

- Öğrenci, ders ve kulüp silme işlemleri kaydı tamamen silmek yerine **durum alanını pasif yapar** (soft delete) ve listeler yalnızca aktif kayıtları gösterir. Not ve ürün silme kalıcıdır.
- Bootstrap 5 ile ortak `_Layout` ve tablo tabanlı listeler

## 🗄️ Veritabanı (`DBLINQSORGULAR25B`)

5 tablo: `TBLOGRENCİ`, `TBLDERS`, `TBLKULUP`, `TBLNOTLAR`, `TBLURUN`

---

## ⚙️ Kurulum

**Gereksinimler:** Visual Studio 2022/2026 (*ASP.NET ve web geliştirme*) · SQL Server (Express yeterli) · SQL Server Management Studio (SSMS) 22

1. **İndirin**
   ```bash
   git clone https://github.com/GencayCeliker/MVC-Ogrenci-Takip.git
   ```
2. **Veritabanını kurun (SSMS 22):** `Veri Tabanı/DBLINQSORGULAR25B.sql` dosyasını açıp **Execute (F5)**'e basın.
3. **Bağlantıyı kontrol edin:** `MVCOgrenciTakip25/Web.config` içinde `data source=.\SQLEXPRESS` kullanılır.
4. **Çalıştırın:** `MVCOgrenciTakip25.sln` dosyasını açın; NuGet paketleri otomatik yüklenir; **F5** ile IIS Express'te başlatın.
