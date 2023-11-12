1.
GameSettingsProcessor - GameSettingAppling
// Класс умеет только применять настройки.

FindExcludedTriangles - FilterTriangles
// Класс занимается поиском треугольников, вне заданной зоны.

UseReloadWeapon - ReloadingWeaponRules
// Проверки для перезарядки оружия. Use не несет нагрузки. Глагол Reload.

PingMarkerInfo - PingMarkerViewParam
// Хранение параметров для отрисовки маркера. Info не несет нагрузки. Название не полностью раскрывает суть класса.

RotationData - RotationTimeChange
// Изменение поворота в течении времени. Data не несет нагрузки, а при этом название не раскрывает смысл.

2.
AddItem - Add
// Item ничего не значит.

AddNotification - Add
// Notification нужно, но это свидетельствует о неправильной ответственности, и стоит переделать прежде всего ее.

Remove - RemoveHint
// Аналогично предыдущему - 2 модели в одной.

ClearLists - Clear
// Lists в контексте модели не играет роли.

ClearHintPositions - Clear
// 2 модели в одной.

EnqueueStartedHidingObject - EnqueueStoppedHidingObject - Enqueue
// Аналогично.

SetValue - Set
// Value лишнее.




