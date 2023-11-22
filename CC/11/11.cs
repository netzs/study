1
float newLookPitch = _playerRotationInput.Pitch;
if (newLookPitch < _topThreshold)
{
        newLookPitch = Mathf.Clamp(_playerRotationInput.Pitch + look.y, _playerRotationInput.Pitch, _bottomThreshold);
}
else if (newLookPitch > _bottomThreshold)
{
        newLookPitch = Mathf.Clamp(_playerRotationInput.Pitch + look.y, _topThreshold, _playerRotationInput.Pitch);
}
else
{
        newLookPitch = Mathf.Clamp(_playerRotationInput.Pitch + look.y, _topThreshold, _bottomThreshold);
}

// ->

float newLookPitch = GetLookPitch(look);
...

private float GetLookPitch(Vector2 look)
{
    float newLookPitch = _playerRotationInput.Pitch;

    if (newLookPitch < _topThreshold)
    {
        return Mathf.Clamp(_playerRotationInput.Pitch + look.y, _playerRotationInput.Pitch, _bottomThreshold);
    }

    if (newLookPitch > _bottomThreshold)
    {
        return Mathf.Clamp(_playerRotationInput.Pitch + look.y, _topThreshold, _playerRotationInput.Pitch);
    }

    return Mathf.Clamp(_playerRotationInput.Pitch + look.y, _topThreshold, _bottomThreshold);
}

// Вынес расчет в отдельный метод.


2
private class ParticleContentValue
{
    public float Ts { get; set; }
    public IDisposableContent<ParticleSystem> Content { get; set; }
}

// ->

private class ParticleContentValue
{
    public float Ts { get; private set; }
    public IDisposableContent<ParticleSystem> Content { get; private set; }

    public void Set(float ts, IDisposableContent<ParticleSystem> content)
    {
        Ts = ts;
        Content = content;
    }
}

// Вынес установку значений из сеттеров в отдельный метод, что снижает область видимости.


3
{
        // Тут было линейное создание большого количества объектов, которые зависят друг от друга, но они должны быть в одном месте, чтобы наглядно видеть картину в целом.
}
// ->
{
        {
                // ...
        }
        {
                // ...
        }
        {
                // ...
        }
}

// Разбил у условные блоки, в соответствии с зависимостями которые можно выделить.

4
            var spawnPoint = _parkingDialogModel.Description;
            Message message;

            if (slotModel.Description.Equals(_vehicleGroupModel.SelectedVehicleSlotForSummon.Value))
            {
                message =  ...
            }
            else
            {
                message = ...
            }

// ->

        Message message = GetMessage(slotModel);

        private Message GetMessage(IVehicleSlotModel<TVehicleSlotDescription, TVehicle> slotModel)
        {
            var spawnPoint = _parkingDialogModel.Description;
                // ...
        }

// Вынес часть метода в отдельную функцию, тем самым уменьшив зону видимости вспомогательной переменной. И еще просто уменьшая размер зоны видимости уменьшается зона всего что внутри.

5

_isRequest = true;
var response = await _roomConnectionsBattle.SendMessage(message);

if (response.IsLeft)
{
        CustomLogger.Network.Warning("SpawnCarMessage: {0}", response.AsLeft.AsString());
}

_isRequest = false;

// ->

SendMessage(message);

...

private async Task SendMessage(Message message)
{
    _isRequest = true;

    var response = await _roomConnectionsBattle.SendMessage(message);

    if (response.IsLeft)
    {
        CustomLogger.Network.Warning("SpawnCarMessage: {0}", response.AsLeft.AsString());
    }

    _isRequest = false;
}

// Еще часть метода в отдельный метод.

6
public readonly PositionModel CharacterPositionModel = new();
public readonly RotationModel CharacterRotationModel = new();
public readonly PositionModel VehiclePositionModel = new();
public readonly RotationModel VehicleRotationModel = new();

// ->

public class TransformModel
{
    public readonly IPositionModel PositionModel = new PositionModel();
    public readonly IRotationModel RotationModel = new RotationModel();

    public void Set(Vector3 position, Quaternion rotation)
    {
	...
    }
}

public readonly TransformModel CharacterTransformModel = new();
public readonly TransformModel VehicleTransformModel = new();

// Выделил части полей класса в отдельный объекты, подходящие по смыслу.

7
public class PriorityQueue<TItem, TPriority> : IPriorityQueue<TItem, TPriority>
// ->
internal class PriorityQueue<TItem, TPriority> : IPriorityQueue<TItem, TPriority>

// Ограничил модификатора доступа рамками модуля.

8
// Сгруппировал несколько файлов и обобщил в Assembly definitions (особенность unity).

9
// Переделал статический класс в нестатический.


10
Vector3 camPos = handVector - (targetForward * (Mathf.Lerp(CameraDistance, CameraDistanceAimed, weight) - _dampingCorrection.z));
float collisionCorrectionBetweenFollowAndHand = 0, collisionBetweenCameraAndHand = _camPosCollisionCorrection;
Vector3 collidedHand = ResolveCollisions(root, handVector, -1, CameraRadius * 1.05f, ref collisionCorrectionBetweenFollowAndHand);
Vector3 resultPosition = ResolveCollisions(collidedHand, camPos, CinemachineCore.DeltaTime, CameraRadius, ref collisionBetweenCameraAndHand);
hasCollision = Mathf.Abs(collisionCorrectionBetweenFollowAndHand) > float.Epsilon;
return resultPosition;

// ->
float collisionCorrectionBetweenFollowAndHand = 0;
Vector3 collidedHand = ResolveCollisions(root, handVector, -1, CameraRadius * 1.05f, ref collisionCorrectionBetweenFollowAndHand);
Vector3 camPos = handVector - (targetForward * (Mathf.Lerp(CameraDistance, CameraDistanceAimed, weight) - _dampingCorrection.z));
Vector3 resultPosition = ResolveCollisions(collidedHand, camPos, CinemachineCore.DeltaTime, CameraRadius, ref _camPosCollisionCorrection);
hasCollision = Mathf.Abs(collisionCorrectionBetweenFollowAndHand) > float.Epsilon;
return resultPosition;

// Перенесение инициализации переменных ближе к месту их использования уменьшает область видимости.

11
public class HintView : MonoBehaviour
{
        [field: SerializeField] public TextMeshProUGUI text { get; private set; }
}

// ->

public class HintView : MonoBehaviour
{
        [field: SerializeField] private TextMeshProUGUI _text;

        public void SetText(string hintText)
        {
            _text.text = hintText;
        }
}
// Поменял публичной доступ к полю на метод установки значения.

12
public long EndTs;
// ->
private long EndTs;

// Поменял доступ на приватный, просто потому что в публичном доступе пропала необходимость, но код остался.

13
protected Dictionary<TTargetTrigger, (ITargetAction, TTargetOptions)> TargetTriggerKeys => _actionsWithOptions;
// Удалил. Доступ был не нужны.

14
public class ExitModel
{
    public ExitModel(ExitDescription exitDescription)
    {
        ...
    }

    public bool Check(LocationDescription locationDescription)
    {
        ...
    }
}

// ->

public class ExitModel
{
    private readonly LocationDescription _locationDescription;

    public ExitModel(ExitDescription exitDescription, LocationDescription locationDescription)
    {
        _locationDescription = locationDescription;
        ...
    }

    public bool Check()
    {
        ...
    }
}

// Перенес данные которые не должны изменяться в конструктор, тем самым уменьшив зону видимости переменной во при вызове - ее не нужно прокидывать.

15

public Dictionary<int, string> CachedFPSTexts = new(120);
// ->
public readonly Dictionary<int, string> CachedFPSTexts = new(120);

// Добавил модификатор readonly



