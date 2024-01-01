# parallel-processing-mandelbrot.cs

🧧🧧🧧 C#で並列処理でマンデルブロ集合を描画してみる！  

![成果物](./docs/images/fruit.png)  

## 実行方法

DevContainerに入り、以下のコマンドを実行します！  

```shell
dotnet run --project Program --configuration Release
```

M2 Mac(Debian GNU/Linux 11)での実行結果は以下の通りです。  

```result
// * Summary *

BenchmarkDotNet v0.13.11, Debian GNU/Linux 11 (bullseye) (container)
Unknown processor
.NET SDK 6.0.417
  [Host]     : .NET 6.0.25 (6.0.2523.51912), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 6.0.25 (6.0.2523.51912), Arm64 RyuJIT AdvSIMD


| Method       | Mean      | Error    | StdDev   |
|------------- |----------:|---------:|---------:|
| MultiThread  |  65.88 ms | 0.709 ms | 0.663 ms |
| SingleThread | 113.77 ms | 1.440 ms | 1.276 ms |
```

マルチスレッド処理で約2倍の速度で描画できています！  
