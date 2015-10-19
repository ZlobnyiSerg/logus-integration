#Logus HMS Integration Example

# Сообщения

В процессе работы Логус отправляет в шину сообщения. Любая заинтересованная система может подписаться на любой тип сообщения и гарантированно получать их из интеграционной шины. Перечень сообщений и примерный состав данных приведены в следующих разделах.

## ReservationUpdatedMessage

Сообщение отправляется при любом изменении брони: изменение полей (комментарий, номер телефона гостя и т.п.), длительности, тарифов, начислении на счёт брони и т.п.

Тело сообщения содержит всю информацию по брони:

1. Все основные и допольнительные поля (настраиваемые через интерфейс администрирования)
2. Информацию по каждому гостю брони
3. Информацию о размещении с детализацией по дням (тариф, тип комнаты, кол-во гостей, пакеты и услуги, стоимость проживания)

Важно отметить, что при изменении состояния брони также отправляется сообщение *ReservationUpdatedMessage*

## ReservationStatusChangedMessage

Сообщение отправляется при изменении состояния брони (поселение, выселение, отмена и т.п.). По атрибутивному составу идентично *ReservationUpdatedMessage* плюс содержит дополнительный признак *PreviousStatus* - идентификатор предыдущего состояния.

## GuestProfileUpdatedMessage

Возникает при любых изменениях в профиле гостя.

Содержит полную информацию по профилю, включая дополнительные поля, баланс профиля, телефоны, данные о документе (паспорт, св-во о рождении и т.п.)

## RoomOccupationChangedMessage

Сообщение отправляется в шину при изменении состояния занятости комнаты (поселение и выселение гостя). Содержит информацию о комнате, идентфикаторах заселяющейся или выезжающей брони.


## AvailabilityChangedEvent

Сообщение об изменении наличия в номерном фонде. Отправляется в случаях, которые могут повлечь изменение количества свободных номеров. Содержит в себе информацию о:

1. Временном периоде, за который наличие изменяется
2. Типе комнаты
3. Квоте (если наличие изменяется в рамках квоты)

# Команды

Команды представляют собой особый вид сообщений, который внешняя система может направить в Логус для выполнения определённого действия или операции. В ответ на команду Логус может отправлять сообщения-ответы. Поддерживаемые команды перечислены ниже.

## CreateReservationRequest
Запрос на создание новой брони. Реализован в соответствии со спецификацей *OpenTravel Alliance*.

## PostTransactionRequest
Данный запрос позволяет осуществлять начисление услуги или фиксирование платежа на любой счёт в Логусе (на счёт брони, группы, профиля гостя или компании). Из основных ключевых особенностей следует выделить такие:

1. Поддержка начислений по номеру комнаты или номеру счёта
2. Поддержка начислений с детализацией
3. Поддержка начислений с группировкой транзакций в "финансовый документ" - счёт на оплату или путёвку
4. Поддержка "холостых" начислений, когда фактически сумма не начисляется на счёт, но в ответ Логус отправит информацию по состоянию баланса карманов и баланса счёта как если бы начисление было произведено. Это даёт возможность управлять депозитами и следить за балансом гостя/счёта.

## CancelTransactionRequest
Запрос на корректировку ранее начисленной транзакции/транзакций.

## CancelInvoiceRequest
Запрос на корректировку (отмену) финансового документа (счёта на оплату или путёвки)

## CreateGuestProfileRequest
Команда на создание нового профиля гостя в Логусе.
