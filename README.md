# Literate

.NET 9.0 Console Application

## 概要

シンプルなC#コンソールアプリケーションです。

## 必要環境

- .NET 9.0 SDK
- WiX Toolset 3.11 (インストーラービルド用)

## ビルド・実行

```bash
# アプリケーションのビルド
dotnet build

# アプリケーションの実行
dotnet run --project literate

# インストーラーのビルド（WiX Toolset必要）
dotnet build literate.Installer
```

## プロジェクト構成

- `literate/` - メインアプリケーション
- `literate.Installer/` - WiXインストーラープロジェクト

## インストーラー

WiX Toolset 3.11を使用してWindowsインストーラー(.msi)を生成できます。

1. [WiX Toolset](https://wixtoolset.org/releases/)をダウンロード・インストール
2. `dotnet build literate.Installer`でインストーラーをビルド
3. `literate.Installer\bin\Debug\LiterateInstaller.msi`が生成されます