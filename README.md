# JournalApp

Cross-platform setup and run guide for the Avalonia desktop app in this repository.

## Tech Stack

- .NET SDK: 9.0
- UI: Avalonia 11
- Solution file: `JournalApp.sln`
- Startup project: `JournalApp.Presentation/JournalApp.Presentation.csproj`

## Prerequisites

### Windows

1. Install .NET 9 SDK.
2. Install Visual Studio Code.
3. Install the C# extension in VS Code (`ms-dotnettools.csharp`).

### macOS

1. Install .NET 9 SDK.
2. Install Visual Studio Code.
3. Install the C# extension in VS Code (`ms-dotnettools.csharp`).

## Clone and Open

```bash
git clone <your-repo-url>
cd JournalApp
code .
```

## Restore and Build

Run from the repository root (the folder that contains `JournalApp.sln`):

```bash
dotnet restore JournalApp.sln
dotnet build JournalApp.sln
```

## Run the App

Run the Avalonia startup project:

```bash
dotnet run --project JournalApp.Presentation/JournalApp.Presentation.csproj
```

## Run with Hot Reload

```bash
dotnet watch --project JournalApp.Presentation/JournalApp.Presentation.csproj run
```

## Run and Debug in VS Code

This repository includes VS Code task/debug files in `.vscode`.

1. Build task:
   - Press `Ctrl+Shift+B` on Windows
   - Press `Cmd+Shift+B` on macOS
   - Choose `build JournalApp`
2. Debug launch:
   - Open Run and Debug panel
   - Select `Launch JournalApp (Avalonia)`
   - Press `F5`

You can also run these tasks from **Terminal -> Run Task**:

- `build JournalApp`
- `run JournalApp.Presentation`
- `watch JournalApp.Presentation`

## Run Tests

```bash
dotnet test JournalApp.Business.Tests/JournalApp.Business.Tests.csproj
```

## Common Troubleshooting

### SDK not found

Check installed SDKs:

```bash
dotnet --list-sdks
```

If .NET 9 is missing, install .NET 9 SDK and rerun restore/build.

### App does not start from VS Code

1. Confirm you are in the workspace root containing `JournalApp.sln`.
2. Run `dotnet build JournalApp.sln` in terminal and fix any reported errors.
3. Retry `F5` with `Launch JournalApp (Avalonia)`.

### AutoMapper license warning

A development warning may appear at startup. It does not block local runs.
