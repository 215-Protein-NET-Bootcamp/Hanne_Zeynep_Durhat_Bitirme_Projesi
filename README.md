# Patika Protein Bootcamp Bitirme Projesi

### Projede Kullanılan Nuget Kütüphaneleri
ORM Kütüphanesi olarak **Dapper**


Şifre hashlemek için **BCrypt.Net**
******
### Proje Açıklamaları
* Projede 5 adet katman bulunmaktadır.
* Üye Kayıt ve Üye Girişi için User classı, ortak repository ve service kullanıldı.
* ORM kütüphenesi olarak dapper tercih edildi.
* Database tercihi olarak PostgreSql seçildi.
* Database içerisinde 3 tane tablo oluşturuldu. (users, category, product)
* Http metot işlemleri için Swagger tercih edildi.

*******
### Proje Ayağa Kaldırlması

İlk olarak modellerimizi oluşturduk ve validate işlemleri gerçekleştirildi. Repository ve service kısımları yapıldı. Daha sonra startup.cs de repository ve serviceleri

service.AddSingleton<>() içerisine yazdık. Buraya yazmazsak proje ayağa kalkmazdı. Controllerlar ile Http metot işlemleri gerçekleştirildi.

*******
### Swagger Göreselleri


![SwaggerTum](https://user-images.githubusercontent.com/83821699/185810542-c87fa457-796b-4ffc-8da0-2f7e1db5c8aa.PNG)



![signup swagger](https://user-images.githubusercontent.com/83821699/185810740-3e680ef8-e526-4739-af00-bba925326bd9.PNG)


![login swagger](https://user-images.githubusercontent.com/83821699/185810810-32e4433f-ef4c-4d5d-b7a9-87ae48cf4554.PNG)


![category swagger](https://user-images.githubusercontent.com/83821699/185810822-dc2a40b7-4da8-427c-b0ed-46ee06600bce.PNG)
 
 
![database tablo](https://user-images.githubusercontent.com/83821699/185811946-6146108a-f642-433b-8a1b-ddf1e8a8a18a.PNG)

*****

### PostgreSql Görselleri

![database user](https://user-images.githubusercontent.com/83821699/185810860-f2db9153-1570-4753-92f2-98544553cd5d.PNG)


![category database](https://user-images.githubusercontent.com/83821699/185811386-e95c3a30-e752-4a91-82a0-eafa11b19556.PNG)


