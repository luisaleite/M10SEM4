### Questão
Realize as atividades propostas no tutorial "Criando métricas". Você deverá criar um repositório no github e implementar todas as etapas. Crie um arquivo markdown e registre, em forma de relatório, o seu avanço. Adicione ao relatório prints da execução do seu programa exibindo as saidas do console/terminal.

# Passo 1
- Criação do aplicativo com os comandos:
  ```
  dotnet new console
  dotnet add package System.Diagnostics.DiagnosticSource
  ```
- E adicione esse código em Progrma.cs
  
  ```
  using System;
  using System.Diagnostics.Metrics;
  using System.Threading;

  class Program
  {
      static Meter s_meter = new Meter("HatCo.Store");
      static Counter<int> s_hatsSold = s_meter.CreateCounter<int>("hatco.store.hats_sold");

      static void Main(string[] args)
      {
          Console.WriteLine("Press any key to exit");
          while(!Console.KeyAvailable)
          {
              // Pretend our store has a transaction each second that sells 4 hats
              Thread.Sleep(1000);
              s_hatsSold.Add(4);
          }
      }
  }
  ```

- Coloque esse comando no terminal:
```
dotnet run
```


