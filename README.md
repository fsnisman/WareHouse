# WareHouse
WareHouse - это магазин приложение, которое устанавливается на Windows 7-10 с поддержкой .NET Fraemwork v4.7.2.

# ПРЕДУПРЕЖДЕНИЕ
Программа не будет работать из-за локального пути к базе данным. Если вы же намерены скачать проект и пользоваться им, то нужно изменить путь в самом проекте.

# Инструкция по изменению пути Базы данных
1. Открывает проект InternetStore.sln, выберете и нажмите на компонент DBInternetStore.mdf. 
2. Во свойствах найдийте строку подключение и скопируйте ее полностью.
3. Дальше заходим в код трех форма LoginForm.cs RegesterFrom.cs и MainFrom.cs.
4. В начане будет комментарий "Иницализация бд" и ниже, где прописан SqlConnection, меняем строку подключение на тот, который вы скопировали. И так во всех трех формах.
5. Компилируем проект.
6. Готово! Теперь можно пользоваться приложением.
