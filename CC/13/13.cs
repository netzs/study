1
for (var i = 0; i < _sectorElementViews.Length; i++)
{
        var sectorElementView = _sectorElementViews[i];

        if (i < amount)
        {
            sectorElementView.SetActive(true);
            var angle = sectorElementStep * i;

            sectorElementView.SetAngle(angle);
        }
        else
        {
            sectorElementView.SetActive(false);
        }
}
// ->
var currentCount = 0;
foreach (var sectorElementView in _sectorElementViews)
{
        if (currentCount < amount)
        {
            sectorElementView.SetActive(true);
            var angle = sectorElementStep * currentCount;

            sectorElementView.SetAngle(angle);
        }
        else
        {
            sectorElementView.SetActive(false);
        }
        currentCount++;
}
// Обращение напрямую к индексу использовалось, чтобы получить


2
private readonly float[] _slidingSpeed = new float[3];

private float ShiftSpeed()
{
        float speed = _deadReckoningModel.LinearVelocity.Length();
        _slidingSpeed[0] = _slidingSpeed[1];
        _slidingSpeed[1] = _slidingSpeed[2];
        _slidingSpeed[2] = speed;
        return _slidingSpeed.Average();
}

// ->

private readonly Queue<float> _slidingSpeed = new();

private float ShiftSpeed()
{
        float speed = _deadReckoningModel.LinearVelocity.Length();
        _slidingSpeed.Enqueue(speed);
        return _slidingSpeed.Average();
}

// LINQ позволил поменять массив на очередь.

3
SetChildAlongAxis(rectChildren[i], 0, startOffset.x + (cellSize[0] + spacing[0]) * positionX + m_SkewX * positionY, cellSize[0]);
SetChildAlongAxis(rectChildren[i], 1, startOffset.y + (cellSize[1] + spacing[1]) * positionY + m_SkewY * positionX, cellSize[1]);
// ->
SetChildAlongAxis(rectChildren[i], 0, startOffset.x + (cellSize.x + spacing.x) * positionX + m_SkewX * positionY, cellSize.x);
SetChildAlongAxis(rectChildren[i], 1, startOffset.y + (cellSize.y + spacing.y) * positionY + m_SkewY * positionX, cellSize.y);

// Почему-то использовалось обращение к элементам Vector2 через индексы.

4
[field: SerializeField] public PointerButtonView[] QuickSlotsButtonViews { get; private set; }
// ->
[field: SerializeField] public QuickSlotButtonViews QuickSlotsButtonViews { get; private set; }

public class QuickSlotButtonViews
{
        [field: SerializeField] public PointerButtonView WeaponSlot1 { get; private set; }
        [field: SerializeField] public PointerButtonView WeaponSlot2 { get; private set; }
        [field: SerializeField] public PointerButtonView PocketSlot1 { get; private set; }
        [field: SerializeField] public PointerButtonView PocketSlot2 { get; private set; }
        [field: SerializeField] public PointerButtonView PocketSlot3 { get; private set; }
        [field: SerializeField] public PointerButtonView PocketSlot4 { get; private set; }
}
// Элементы быстрого доступа персонажа. Их строго фиксированное количество, и для каждого элемента свои строго определенные константы и настройки. Возможность изменения количества или тика крайне маловероятный процесс.

5
float totalDistance = (_points[0].position - _points[^1].position).sqrMagnitude;
for (int i = 1; i < _points.Length; i++)
{
        totalDistance += (_points[i].position - _points[i - 1].position).sqrMagnitude;
}

// ->

float totalDistance = 0;
var prev = _points.Last();
foreach (var cur in _points)
{
        totalDistance += (prev.position - cur.position).sqrMagnitude;
        prev = cur;
}

// Избавился от математики в индексах посредством итерирования.




