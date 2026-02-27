# ArduinoİlkProjem

![C#](https://img.shields.io/badge/C%23-8.0+-239120?logo=c-sharp&logoColor=white)
![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.5-512BD4?logo=dotnet&logoColor=white)
![WinForms](https://img.shields.io/badge/UI-Windows%20Forms-0078D6)
![Lisans](https://img.shields.io/badge/Lisans-MIT-green)

## Neden Bu Proje?
Bu proje, Arduino ile bilgisayar arasında seri port üzerinden güvenilir bir iletişim kurarak LED gibi temel donanım bileşenlerini masaüstü arayüzünden kontrol etmeyi sağlar; donanım-yazılım entegrasyonuna yeni başlayan geliştiriciler için anlaşılır bir WinForms örneği sunduğu için hem eğitimde hem de hızlı prototiplemede değerlidir.

## Mimari / Özellikler
- Windows Forms tabanlı sade bir kontrol paneli ile bağlantı ve LED durumu yönetimi.
- `System.IO.Ports.SerialPort` ile otomatik port listeleme ve seri haberleşme.
- Arduino’dan gelen veri ile UI durumunu anlık güncelleyen olay tabanlı akış (`DataReceived`).
- UI thread güvenliği için `InvokeRequired` kontrolü ile yardımcı işlem metodu.
- Çözüm ve proje dosyaları (`.sln` / `.csproj`) depo içinde hazır; ek bağımlılık dosyası gerektirmez.

## Hızlı Başlangıç
Aşağıdaki komutları **Windows + Visual Studio Build Tools (MSBuild)** ortamında çalıştırın:

```bash
git clone https://github.com/furkanisikay/ArduinoIlkProjem.git
cd ArduinoIlkProjem
msbuild ArduinoIlkProjem.sln /p:Configuration=Release
```

Derleme sonrası uygulama:

```bash
ArduinoIlkProjem\bin\Release\ArduinoIlkProjem.exe
```

## Ortam Kurulumu
1. Windows üzerinde **.NET Framework 4.5 Developer Pack** kurulu olmalıdır.
2. Arduino kartınızı USB ile bağlayın ve doğru COM portunu not edin.
3. Uygulamayı açtıktan sonra port seçip **Bağlan** butonuna tıklayın.
4. Arduino tarafı, uygulamanın gönderdiği `1`/`0` komutlarını işleyecek şekilde seri haberleşme (aynı baud rate) kullanmalıdır.

## Kod Denetimi ve Güvenlik
- Depoda hardcoded şifre, API anahtarı veya yerel kullanıcı yolu (örn. `C:\\Users\\...`) taraması yapılmıştır.
- Tespit edilen kritik bir gizli bilgi bulunmamıştır.
- İleride gizli bilgi eklenmesi gerekirse kaynak koda gömmek yerine ortam değişkeni yaklaşımı tercih edilmelidir.

## Refactoring (Öncelikli 3 Adım)
1. **Seri port işlemlerini servis katmanına ayırın:** `Form1` içindeki bağlantı/aç-kapat/yazma mantığını ayrı bir sınıfa taşıyarak UI ile haberleşme katmanını ayrıştırın.
2. **Durum yönetimini sabit metinlerden çıkarın:** `"Bağlan"`, `"Bağlantıyı Kes"`, `"Çalıştır"` gibi metin bazlı kontroller yerine enum tabanlı bir durum modeli kullanın.
3. **Hata yönetimini iyileştirin:** `throw ex;` yerine `throw;` kullanın; ek olarak seri port açma/kapama işlemleri için kullanıcıya anlamlı mesajlar üretecek `try/catch` akışı planlayın.

## Katkı
Katkı süreçleri için [CONTRIBUTING.md](CONTRIBUTING.md) dosyasına bakın.

## Lisans
Bu proje [MIT Lisansı](LICENSE) ile lisanslanmıştır.
