﻿## Команды CLI

Entity Framework Core - добавление нужных зависимостей

```
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

Установка [EF Core CLI](https://docs.microsoft.com/en-us/ef/core/cli/dotnet) (если еще не установлен)

```
dotnet tool install --global dotnet-ef
```

Добавление и удаление миграций

```
dotnet ef migrations add InitialCreate
dotnet ef migrations remove
```

Применение миграций к БД

```
dotnet ef database update
```

Вывод SQL команд на основе миграций (флаг `-i` для проверки повторного применения)

```
dotnet ef migrations script -i
```
