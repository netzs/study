private const string ColorPrefix = "<color=#{0}>";
// Удалено и перенесено непосредственно в место использования.


(string)scriptClassField.GetValue(annotation)
// ->
scriptClassField.GetValue(annotation).ToString();
// Замена неоднозначного преобразования на более стандартное.


var progress = 1f * _cameraModel.Progress / CameraDescription.MaxProgress;
// ->
float progress = (float)_cameraModel.Progress / CameraDescription.MaxProgress;
// Преобразование типов заменено на более явное


_zeroValueY = (zeroValueY - _minY) / (_maxY - _minY);
// ->
int height = _maxY - _minY;
_zeroValueY = height == 0 ? 0 : (zeroValueY - _minY) / (_maxY - _minY);
// Убрал потенциальное деление на 0.


 (int)((_now.Get() - _ts) / 1000f);
// ->
 Mathf.FloorToInt((_now.Get() - _ts) / 1000f);
// Более явное преобразование (метод unity, а не C#).



newCleanAmount = Math.Min(oldCleanAmount + incCleanAmount, _maxCashAmount);
// ->
 Mathf.FloorToInt((_now.Get() - _ts) / 1000f);
newCleanAmount = LimitSum(oldCleanAmount, incCleanAmount, _maxCashAmount);

private static int LimitSum(int a, int b, int limit)
{
        long sum = (long) a + b;
        sum = Math.Min(sum, limit);
        int result = Convert.ToInt32(sum);
        return result;
}

// Сумма может выходить за границы int. В этом случае ограничиваем максимальным значением.


return previousTime == currentTime;
// ->
return Math.Abs(previousTime - currentTime) < _eps;
// Некорректное сравнение.

if (GetScaleSqr(item.MarkerType) > (pointPos - new Vector2(item.Position.x, item.Position.z)).sqrMagnitude)
// ->
float itemScaleSqr = GetScaleSqr(item.MarkerType);
float pointToMarkerLenSqr = (pointPos - new Vector2(item.Position.x, item.Position.z)).sqrMagnitude;
bool isPickMarker = itemScaleSqr > pointToMarkerLenSqr;
if (isPickMarker)
// Сложное выражение разбито на несколько переменных с более понятным именованием.


public const int LaunderingCleanToDirtyRate = 2;
public const float LaunderingDirtyToCleanRate = 1f / LaunderingCleanToDirtyRate;
...
var incCleanAmount = (int)(recycledAmount * _launderingDirtyToCleanRate);
// ->
public const float LaunderingDirtyToCleanRate = 1f / LaunderingCleanToDirtyRate;
...
int incCleanAmount = recycledAmount / _launderingCleanToDirtyRate;
// Заменил умножение на вещественное число делением на целое.


if (partyMemberModel.TryGetCharacterInfo(out var characterInfo) && characterInfo.IsInVehicle && characterInfo.InVehicleEntityId == vehicleEntityId)
// ->
bool isMemberInCurrentVehicle = partyMemberModel.TryGetCharacterInfo(out var characterInfo) && characterInfo.IsInVehicle && characterInfo.InVehicleEntityId == vehicleEntityId);
if (isMemberInCurrentVehicle)
// Добавил именование условия.


if (_npcs.TryGetValue(npcEntityId, out var item) && item.entityId == entityId)
// ->
bool isSelectNpc = _npcs.TryGetValue(npcEntityId, out var item) && item.entityId == entityId;
if (isSelectNpc)
// Добавил именование условия.


if (index > -1 && index < _models.Count)
// ->
bool isValidIndex = index > -1 && index < _models.Count;
if (isValidIndex)
// Добавил именование условия.




