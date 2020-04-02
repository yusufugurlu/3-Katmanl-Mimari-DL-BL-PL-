# 3-Katmanl-Mimari-DL-BL-PL-
Katmanlı Mimariye Ornek Musterilerin Giris ve Verilerin getirilmesi <br/>
1.Sqli yuklemeden Once scriptdboMusteri.sql sql servera taşıyarak execute ederek bilgisayarınızda eklemiş oluyorsunuz.<br/>
2.DL>clsBaglanti.cs içinde sqlconnectiona sql baglanti yolunu giriniz.<br/>
1-sql servera şifreniz  ile login oluyorsanız<br/>
"Data Source=.;Initial Catalog=dboMusteri;User ID=sa(genellikle sa olur değiştirmediyseniz);Password=şifre" <br/>
2-sql serverda şifresiz ile login oluyorsanız<br/>
Data Source=.;Initial Catalog=dboMusteri;Integrated Security=True<br/>
![Adsız](https://user-images.githubusercontent.com/58319579/78259011-c4c84680-7504-11ea-8e7f-729ec8ee6854.png)
classa ekleyerek çalıştırın :D
1-sql için procedureler<br/>
Verilen musteri id gore adi,soyadi ve email getirir.<br/>
create procedure [dbo].[sp_MusteriGetir](<br/>
@MusteriID int<br/>
)<br/>
as<br/>
begin<br/>
select Adi,Soyadi,Email from tblMusteriler where ID=@MusteriID<br/>
end<br/>
Login ekranı için<br/>
create procedure [dbo].[sp_MusteriLogin](<br/>
@Email nvarchar(50),<br/>
@Sifre nvarchar(50)<br/>
)as<br/>
begin<br/>
declare @Sayac int<br/>
set @Sayac=(select count(*) from tblMusteriler where Email=@Email and Sifre=@Sifre)<br/>
if @Sayac=0<br/>
begin<br/>
select 0<br/>
end<br/>
else<br/>
begin<br/>
select @Sayac<br/>
end<br/>
end <br/>
tablo ise <br/>
![Adsı2](https://user-images.githubusercontent.com/58319579/78260414-9cd9e280-7506-11ea-8b96-4c9333c2fd47.png)
