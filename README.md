# OS Checker Rounded WinForms

Приложение на C# Windows Forms для проверки версии операционной системы.

<img width="403" height="400" alt="Снимок экрана 2026-03-01 183516" src="https://github.com/user-attachments/assets/118ba04f-7f2d-4db6-985d-3a90c933c65a" />

## Функциональность

- Отображение версии ОС, платформы, сервис-пака
- Проверка совместимости (Windows XP и выше)
- Скругленные углы окна через GDI
- Скругленные углы кнопок через GraphicsPath

## Интерфейс

- butCheckOS — проверка совместимости
- button1 — закрытие программы
- listBox1 — информация об ОС

## Куда можно встроить

- В установщики программ для проверки совместимости
- В системные утилиты
- В демонстрацию работы с Environment.OSVersion
- Как пример создания скругленных окон

## Требования

- Windows
- .NET Framework / .NET Core с WinForms

## Примечание

Скругление углов реализовано через GDI (CreateRoundRectRgn) и GraphicsPath.
