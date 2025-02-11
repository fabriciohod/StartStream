## Stream Launcher

This tool is designed to start and close all the software you use for streaming. To customize it for your setup, simply open the `Programs.yaml` file and add the paths for the software you want to open. For example:

```yaml
programs:
  - name: OBS Studio
    path: "C:\\Program Files\\obs-studio\\bin\\64bit\\obs64.exe"
    runAsAdmin: true

  - name: Streamer.bot
    path: "E:\\Streamer.bot-x64-0.2.6\\Streamer.bot.exe"
    runAsAdmin: false
```
>[!NOTE]
>If needed, you can add the `launchOptions` field to run a program with initialization options.
>A useful example of this is configuring the browser to open a specific page, such as the Twitch dashboard or YouTube.
```yaml
programs:
  - name: OBS Studio
    path: "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe"
    launchOptions: "https://www.youtube.com/"
    runAsAdmin: false
```
### PT-BR

Fiz essa ferramenta para abrir e fechar todos os programas que uso para as minhas lives. Para personalizar para você, é só abrir o arquivo `Programs.yaml` e adicionar o caminho do executável do programa que você quer abrir. Por exemplo:

```yaml
programs:
  - name: OBS Studio
    path: "C:\\Program Files\\obs-studio\\bin\\64bit\\obs64.exe"
    runAsAdmin: true

  - name: Streamer.bot
    path: "E:\\Streamer.bot-x64-0.2.6\\Streamer.bot.exe"
    runAsAdmin: false
```

>[!NOTE]
> Caso necessário, você pode adicionar o campo `launchOptions` para executar um programa com opções de inicialização.
> Um exemplo útil disso é configurar o navegador para abrir uma página específica, como o dashboard da Twitch ou o YouTube.
```yaml
programs:
  - name: OBS Studio
    path: "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe"
    launchOptions: "https://www.youtube.com/"
    runAsAdmin: false
```

# [Download](https://github.com/CoffeSan/StartStream/releases/download/1.1.0/Start-Stream-1.1.0.zip)
