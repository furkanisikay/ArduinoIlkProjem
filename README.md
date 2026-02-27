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

## Katkı
Katkı süreçleri için [CONTRIBUTING.md](CONTRIBUTING.md) dosyasına bakın.

## Lisans
Bu proje [MIT Lisansı](LICENSE) ile lisanslanmıştır.
