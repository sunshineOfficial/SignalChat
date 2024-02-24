# SignalChat — ASP.NET Web API based on WebSockets

## Технологии
* ASP.NET 8
* SignalR
* Dapper
* Docker
* PostgreSQL
* Swagger
* xUnit

## Установка и запуск

1. Клонируем репозиторий
```shell
git clone https://github.com/sunshineOfficial/SignalChat.git
```
2. Устанавливаем [Docker](https://www.docker.com/products/docker-desktop/)
3. Запускаем [build.sh](build.sh)
4. Открываем [Swagger](http://localhost/swagger/index.html)
5. Для взаимодействия с хабами SignalR по WebSocket устанавливаем [Postman](https://www.postman.com) и создаем свою WebSocket коллекцию

## Пример работы с ChatHub

1. Устанавливаем соединение с хабом. Пример строки запроса: `ws://localhost/chathub?access_token=qwerty`
2. Устанавливаем протокол общения с хабом
```json
{
    "protocol": "json",
    "version": 1
}
```
**НЕ ЗАБЫВАЕМ СПЕЦИАЛЬНЫЙ СИМВОЛ ОКОНЧАНИЯ СООБЩЕНИЯ**

3. Отправляем запросы к хабу. Например:
```json
{
    "arguments": [
        {
            "Name": "New chat",
            "UserIds": [
                1, 2, 3
            ]
        }
    ],
    "invocationId": "0",
    "target": "CreateChat",
    "type": 1
}
```
