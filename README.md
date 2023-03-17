# Информационная система для компании ООО «Телеком Нева Связь»
Данный репозиторий содержит:
+ ER-диаграмму (.pdf)
+ DataDictionary
+ Программа с модулем авторизации

## Начало работы

Необходимо скачать репозиторий как zip-файл, либо зайдя в viual studio нажать "Клонировать репозиторий" и всатвить ссылку из адресной строки, предварительно скопировав ее со страницы с репозиторием.

### Необходимые условия

Для установики данного программного обеспечения необходимо наличие программы Microsoft Visual Studio. Для работы с данной прогораммой необходимо наличие компьютера, удовлетовряющего минимальным требования среды разработки "Visual Studio", ознакомится с которыми можно на официальном сайте.

### Установка

Для zip-архив:
+ Разархивировать скачанный архив
+ Открыть проект

##Основные механики

Данный программный продукт имеет клиент-серверную архитектуру. База данных рассположена на сервере, а сама программа находится на клиентских компьютерах. Работа авторизации организуется следующим образом:

при вводе номера сотрудника и нажатию «Enter» происходит проверка: если номер сотрудника есть в базе данных, то поле для ввода пароля становится активным и в нем установлен курсор;
после ввода пароля по нажатию на «Enter» если он корректный, то открывается модальное окно со сгенерированным кодом доступа. В течение 10 секунд после закрытия окна с кодом пользователь должен ввести код и авторизоваться;
если же пользователь не успевает или не вводит корректный код, то он становится не действительным и его нужно получить заново, нажав на кнопку обновления;
если авторизация происходит успешно, то сотруднику выводится сообщение об этом с названием его роли.
Для тестирования процесса авторизации можно воспользоваться следующим пользователем: Номер - 88009226666; Пароль - 0000.

## Авторы

* **Ледров Егор** - *Разработчика* - [Vip_Ghost](https://github.com/VipGhost-dev)