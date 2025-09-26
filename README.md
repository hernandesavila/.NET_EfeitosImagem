# 🎨 EfeitosImagem

EfeitosImagem é um aplicativo **Windows Forms** escrito em **C#** no **.NET Framework 4.7.2** para capturar vídeo da webcam e aplicar efeitos visuais em tempo real como Cinza, Sépia, Preto e Branco, Desfoque Gaussiano, Negativo, Pixelizar e espelhamentos.

A interface exibe o fluxo ao vivo da câmera, permite escolher o filtro desejado, definir o tipo de espelhamento e visualizar instantaneamente o resultado.

---

## 🛠️ Tecnologias Utilizadas

<p align="center">
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dot-net/dot-net-original.svg" alt=".NET" width="30" height="30"/>
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" alt="C#" width="30" height="30"/>
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/vscode/vscode-original.svg" alt="Visual Studio" width="30" height="30"/>
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/windows8/windows8-original.svg" alt="Windows" width="30" height="30"/>
</p>

- **C# (.NET Framework 4.7.2)** – linguagem e plataforma alvo
- **Windows Forms** – interface gráfica e ciclo de vida do formulário
- **AForge.NET** – captura de vídeo e acesso à webcam
- **Visual Studio** – ambiente de desenvolvimento recomendado
- **Windows** – sistema operacional suportado (DirectShow)

---

## 📂 Estrutura do Projeto

- `EfeitosImagem.sln` – solução do Visual Studio
- `EfeitosImagem/EfeitosImagem.csproj` – projeto principal Windows Forms
- `EfeitosImagem/Principal.cs` – lógica da tela, captura da webcam e seleção de efeitos
- `EfeitosImagem/Class/ImageHandler.cs` – filtros de imagem, espelhamento e manipulação de bitmaps
- `EfeitosImagem/packages.config` – dependências NuGet (AForge)

---

## ✅ Pré-requisitos

- Windows com **.NET Framework 4.7.2+** instalado
- **Visual Studio 2017** (ou superior compatível com .NET Framework 4.7.2)
- Webcam compatível com **DirectShow**
- Permissão para acessar dispositivos de vídeo e executar aplicativos Windows Forms

---

## ⚙️ Configuração

1. **Restaure os pacotes NuGet**
   - Abra a solução no Visual Studio e permita a restauração automática dos pacotes AForge.NET ou use `Tools > NuGet Package Manager > Restore Packages`.
2. **Conecte a webcam**
   - Certifique-se de que o dispositivo esteja configurado no Windows antes de iniciar o aplicativo.
3. **Opções de espelhamento**
   - Utilize os botões de rádio (Nenhum, Horizontal, Vertical) para ajustar o sentido da imagem conforme necessário.

---

## 🛠️ Compilação

1. Abra `EfeitosImagem.sln` no **Visual Studio**.
2. Selecione a configuração (`Debug` ou `Release`).
3. Compile o projeto `EfeitosImagem` (`Build > Build EfeitosImagem`).
4. Os binários serão gerados em `EfeitosImagem\EfeitosImagem\bin\<Configuration>`.

---

## ▶️ Execução

1. Execute o aplicativo pelo Visual Studio ou abra o executável na pasta de saída.
2. Aguarde a inicialização da webcam (a primeira fonte encontrada é selecionada automaticamente).
3. Escolha um efeito na lista (`Normal`, `Cinza`, `Desfoque Gaussiano`, `Negativo`, `Pixelizar`, `Preto e Branco`, `Sepia`).
4. Defina o espelhamento desejado (Nenhum, Horizontal ou Vertical).
5. Observe a imagem processada em tempo real e ajuste os filtros conforme necessário.

---

## 🔎 Funcionamento

- O formulário principal captura os quadros da webcam com `VideoCaptureDevice`, atualizando a interface em cada evento `NewFrame`.
- A classe `ImageHandler` concentra os filtros de bitmap (negativo, preto e branco, sépia, cinza, pixelização e desfoque gaussiano) e as transformações de espelhamento horizontal/vertical.
- A seleção de efeitos é controlada por uma `ComboBox`, enquanto o espelhamento é definido por botões de rádio.
- Ao fechar a aplicação, a captura de vídeo é finalizada chamando `SignalToStop` para liberar o dispositivo.

---

## 📌 Observações

- Ajuste o índice da webcam se houver mais de um dispositivo conectado.
- Os filtros manipulam diretamente os bytes dos bitmaps; experimente variar o tamanho do bloco de pixelização ou kernel do desfoque para personalizar o resultado.
- Considere tratar cenários sem webcam disponível exibindo mensagens amigáveis ao usuário.

---

## 📄 Licença

Este projeto está licenciado sob a [MIT License](LICENSE).
