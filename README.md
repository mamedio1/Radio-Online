# 🎵 Radio Player Online

Aplicativo desktop para Windows desenvolvido em **Visual Basic .NET (Windows Forms / .NET 8)** para reprodução de estações de rádio online via streaming com **analisador de espectro em tempo real (FFT)**, criado para fins de estudo.

> 🌐 Versão web relacionada: [radio-online-ten.vercel.app](https://radio-online-ten.vercel.app)

---

## ✨ Funcionalidades

- **Reprodução de Rádios Online com 1 clique**
  - Streaming de áudio direto pela internet utilizando `MediaFoundationReader` e `WaveOutEvent` da biblioteca **NAudio**.
  - **5 emissoras pré-configuradas:**
    - **Antena 1**
    - **Rádio 80FM**
    - **Paranoia**
    - **Saudade FM**
    - **Nostalgia**

- **Analisador de Espectro em Tempo Real (`SPECTRUM ANALYZER`)**
  - Visualizador gráfico com **64 barras de frequência** desenhadas em GDI+ (com *Double Buffering* e taxa de atualização de ~20 FPS via `TimerSpectrum` a cada 50 ms).
  - Processamento de áudio via **Transformada Rápida de Fourier (FFT)** com janela de **1024 amostras** (`SampleAggregator` + `NAudio.Dsp.FastFourierTransform`).
  - Indicadores de pico (*peak hold*) com decaimento suave e gradiente de cores dinâmico (azul → ciano → verde → rosa/vermelho).

- **Controles de Reprodução e Interface**
  - Controle de **Volume (0% a 100%)** em tempo real usando `VolumeSampleProvider` (padrão inicial em 50%).
  - Botão **⏹ PARAR** para interromper o stream e liberar os recursos de áudio.
  - Barra de status indicando conexão, emissora em reprodução ou falhas de rede com janela de erro detalhada.
  - Tela **ℹ SOBRE** com informações do autor e botão **✖ SAIR** com diálogo de confirmação.

---

## 🛠️ Tecnologias Utilizadas

- **Linguagem:** Visual Basic .NET (VB.NET)
- **Framework / UI:** .NET 8.0 (`net8.0-windows`) — Windows Forms
- **Áudio e Processamento Digital de Sinais (DSP):** [NAudio 2.2.1](https://github.com/naudio/NAudio)
  - `NAudio.Wave.MediaFoundationReader`
  - `NAudio.Wave.WaveOutEvent`
  - `NAudio.Wave.SampleProviders.VolumeSampleProvider`
  - `NAudio.Dsp.FastFourierTransform`
- **Gráficos:** `System.Drawing` / `System.Drawing.Drawing2D`

---

## 📋 Pré-requisitos

- **Sistema Operacional:** Windows 10 ou Windows 11 (necessário para Windows Forms e codecs do Windows Media Foundation).
- **SDK / Runtime:** [.NET 8.0 SDK / Desktop Runtime (`net8.0-windows`)](https://dotnet.microsoft.com/) ou **Visual Studio 2022** (v17.14+).
- **Conexão com a internet** para reprodução dos streams das rádios.

---

## 📂 Estrutura do Projeto

```text
Radio-Online/
├── RadioPlayer.sln                       # Solução do Visual Studio
└── RadioPlayer/
    ├── RadioPlayer.vbproj                # Configuração do projeto (.NET 8 Windows Forms + NAudio)
    ├── FormRadio.vb                      # Lógica do player, streams, volume e Spectrum Analyzer (FFT)
    ├── FormRadio.Designer.vb             # Layout da interface principal
    ├── SampleAggregator.vb               # Agregador de amostras para cálculo de FFT (1024 pontos)
    ├── FormSobre.vb                      # Janela modal "Sobre o Autor"
    ├── FormSobre.Designer.vb             # Estrutura base da janela "Sobre"
    ├── ApplicationEvents.vb              # Eventos do ciclo de vida da aplicação VB.NET
    ├── ondas-de-radio.ico / .png         # Ícone da aplicação
    ├── Resources/
    │   └── Robson.JPG                    # Foto exibida na tela "Sobre"
    └── My Project/                       # Configurações e recursos do projeto
```

---

## 🚀 Como Executar

1. Clone o repositório:
   ```bash
   git clone https://github.com/mamedio1/Radio-Online.git
   ```
2. Entre na pasta do projeto e execute ou compile pelo **.NET CLI**:
   ```bash
   cd Radio-Online
   dotnet run --project RadioPlayer/RadioPlayer.vbproj
   ```
   Ou abra o arquivo `RadioPlayer.sln` no **Visual Studio 2022** e pressione **F5**.

---

## 📻 Estações Configuradas (`FormRadio.vb`)

| Estação | Protocolo / Origem configurada |
|---|---|
| **Antena 1** | HTTPS (`antenaone.crossradio.com.br`) |
| **Rádio 80FM** | HTTPS (`live1.livemus.com.br`) |
| **Paranoia** | HTTPS (`servidor34.brlogic.com`) |
| **Saudade FM** | HTTPS (`playerservices.streamtheworld.com`) |
| **Nostalgia** | HTTP (`172.82.160.250:8083`) |

> *Obs.:* A disponibilidade de cada emissora depende de o servidor de streaming estar online no momento da execução.

---

## 👤 Autor

**Robson Mamedio Araujo**  
Tecnólogo em Telecomunicações e Eletrônica — Águas Claras, DF  
- GitHub: [@mamedio1](https://github.com/mamedio1)
- E-mail: `mamedio1@gmail.com`
