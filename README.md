# PlaywrightDemo

### Visual Studio 2022環境設置

### 步驟 1：先安裝必要的 NuGet 套件

1. 打開 Visual Studio 2022，創建一個新的 **MSTest** 測試專案。
2. 在新專案創建完成後，右鍵點擊專案，選擇 **Manage NuGet Packages**，並安裝以下幾個必要的套件：
    - **Microsoft.Playwright**：Playwright 的 C# 客戶端。
    - **MSTest.TestFramework**：支持 MSTest 測試框架。
    - **MSTest.TestAdapter**：支持 MSTest 運行器。

在 **NuGet Package Manager** 中，搜尋並安裝以下Package：

```bash
Microsoft.Playwright
MSTest.TestFramework
MSTest.TestAdapter
```

### 步驟 2：初始化 Playwright

安裝完相關的 NuGet 包後，你需要在項目中初始化 Playwright。Playwright 需要下載相應的瀏覽器二進制文件。你可以通過執行以下命令來下載這些二進制文件：

打開 **Package Manager Console** 並執行：

```bash
Playwright install
```

這個命令會下載 Chromium、Firefox 和 WebKit 的瀏覽器二進制文件。