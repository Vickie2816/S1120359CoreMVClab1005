# ASP.NET Core MVC CRUD 專案

## 專案簡介

本專案使用 ASP.NET Core MVC 與 Entity Framework Core 建立資料管理系統，實作資料的新增、查詢、修改與刪除（CRUD）功能。

本次以 Food 資料為主要實作內容，透過 MVC 架構完成前後端資料傳遞與資料庫操作。

## 使用技術

- C#
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server / LocalDB
- HTML
- CSS
- Bootstrap

## 主要功能

### Food 資料管理
- 查看 Food 資料列表
- 新增 Food 資料
- 查看 Food 詳細資料
- 修改 Food 資料
- 刪除 Food 資料

### 其他資料
專案亦包含 Student 與 Spot 資料模型及相關 MVC 架構。

## 專案架構

- `Controllers/`：處理 HTTP Request 與 CRUD 邏輯
- `Models/`：定義資料模型
- `Views/`：MVC View 頁面
- `Migrations/`：Entity Framework Core 資料庫 Migration
- `wwwroot/`：CSS、JavaScript 與前端資源
- `Program.cs`：ASP.NET Core 應用程式啟動與服務設定
- `TourSurveyContext.cs`：Entity Framework Core DbContext

## CRUD 操作

| 功能 | 說明 |
|---|---|
| Create | 新增 Food 資料 |
| Read | 查詢及查看 Food 資料 |
| Update | 修改 Food 資料 |
| Delete | 刪除 Food 資料 |

## 開發環境

- Visual Studio
- .NET 10
- ASP.NET Core MVC
- Entity Framework Core

## 學習成果

透過本專案熟悉 ASP.NET Core MVC 的基本架構，並實際操作 Entity Framework Core 與資料庫，完成單一資料表的 CRUD 功能。