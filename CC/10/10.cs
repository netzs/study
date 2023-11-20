1
var first = _notificationModel.First();
// ->
INotificationModel first = _notificationModel.First();
// Вроде бы как C# является языком со строгой типизацией, но все равно убрал несколько var
2
// Убрал несколько неиспользуемых переменных.
3
            var result = tip;
// 12 строк кода.
            if (collisionCorrection > Epsilon)
                result -= dir * collisionCorrection;

            return result;
// ->
var result = tip - ;
if (collisionCorrection > Epsilon) {
        result -= dir * collisionCorrection;
}

return result;

// Перенос объявления переменной к месту использования.

4
            var spawnPoint = _parkingDialogModel.Description;
// 7 строк кода, в котором есть return.
             Message message = slotModel.Description switch
                {
                    CarSlotDescription => new SpawnCarMessage(spawnPoint.EntityId),
                    HelicopterSlotDescription => new SpawnHelicopterMessage(spawnPoint.EntityId),
                    _ => throw new IndexOutOfRangeException(slotModel.Description.GetType().Name)
                };
// ->
// 7 строк кода, в котором есть return.
            var spawnPoint = _parkingDialogModel.Description;
             Message message = slotModel.Description switch
                {
                    CarSlotDescription => new SpawnCarMessage(spawnPoint.EntityId),
                    HelicopterSlotDescription => new SpawnHelicopterMessage(spawnPoint.EntityId),
                    _ => throw new IndexOutOfRangeException(slotModel.Description.GetType().Name)
                };
// Перенос объявления переменной к месту использования
5
private float _alphaChangeSpeed = 2.5f;
// ->
private const float ALPHA_CHANGE_SPEED = 2.5f;
// Добавил const.

6
private int _lastCallerIndex = -1;
// ->
private int _lastCallerIndex;
// Начальная инициализация заведомо некорректным значением.
7
int sum;
// ->
int sum = 0;
// Начальная инициализация (не смотря на то что не обязательна стоит добавлять).
8
public ref T GetEvent(int index)
{
        return ref _data[index];
}
// ->
public ref T GetEvent(int index)
{
        if (index < 0 || index > _count)
        {
            throw new IndexOutOfRangeException();
        }
        return ref _data[index];
}
// Проверка выхода за границы массива.
9
private Mesh[] _meshes;
// ->
private Mesh[] _meshes = Array.Empty<Mesh>();
// Инициализация пустым массивом.
10
var currentSum = 0;
for (var i = 0; i < _count; i++)
{
.....
}
// ->
for (int currentSum = 0, i = 0; i < _count; i++)
{
.....
}
// Внесение переменной, которая не нужна за границами цикла в инициализацию цикла.
11

ITargetAction    resultTarget = null;
// 5 строк
bool hasTarget = false;
// еще 4
for (int i = 0; i < size; i++)
{

// ->
// 9 строк, где не используются эти переменные.
bool hasTarget = false;
ITargetAction resultTarget = null;
for (int i = 0; i < size; i++)
{
// Объявление переменных в месте их использования.
12
var minItem = _markerViews.Values.First();
foreach (var item in _currentMarkers.Values)
{
//...
}

minItem = _newMarkers.Values.First();
foreach (var item in _newMarkers.Values)
{
//...
}

// ->
var minCurrentItem = _markerViews.Values.First();
foreach (var item in _currentMarkers.Values)
{
//...
}

var minNewItem = _newMarkers.Values.First();
foreach (var item in _newMarkers.Values)
{
//...
}
// Убрал повторное использование переменной.
13
[field: SerializeField] public float AnimWeight { get; private set; }
// ->
[field: Range(0,1)]
[field: SerializeField] public float AnimWeight { get; private set; }
// Задание диапазона значения переменной на уровне редактора Unity.

14
public void SetParam(int factor, float minSingleArea, float minPolygonArea)
// ->
public MeshMaker(MeshFilter item, int factor, float minSingleArea, float minPolygonArea)
// Был метод, который инициализировал поля класса. Перенес их в конструкторы.


15
private float _minSingleArea = 0.2f;
// ->
private readonly float _minSingleArea = 0.2f;
// Так как в предыдущем примере инициализация была в конструкторе, можно добавить атрибут readonly, что не позволит случайно изменить значение.




