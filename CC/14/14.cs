1.1
// Препятствует камере, но не препятствует таргет системе.
public static readonly int TargetObstacle = LayerMask.NameToLayer("TargetObstacle");

// Описание поведения, для пользователей, которые не могут посмотреть применение в коде.

1.2
// TODO: PWD-13716

// Плохой или недоделанный код, который будет исправлен в соответствующем тикете.

1.3
// Algorithm - https://confluence ....

// Ссылка на алгоритм.

1.4
// Работа с данными пользователя, которые не будет обнуляться

// Краткое описание модуля.

1.5
// Настройте матрицу наклонной проекции так, чтобы ближняя плоскость была нашей плоскостью отражения.

// Краткое описание сложной формулы.

1.6

// На сколько увеличили маркер относительно разрешения экрана
private float GetScaleSqr(MapMarkerType markerType)

// Тяжело подобрать правильное именование, так чтобы это было понятно.

1.7
// skip 4 chars
_index += 4;

// Неочевидный шаг алгоритма.



2.1
private void LateUpdate()
{
        // First bone calculation
        codeBlock1


        // Second bone calculation
        codeBlock2
}

// ->

private void LateUpdate() {
        FirstBoneCalculation();
        SecondBoneCalculation();
}
private void FirstBoneCalculation()
{
        codeBlock1
}

private void SecondBoneCalculation()
{
        codeBlock2
}


// Переместил код в блоки с соответствующими названиями из комментариев

2.2
//Spawn car
private void SpawnCar()
{
    if (_battleEntitiesModel.Player is not {ServerModel: var serverModel }) return;
    VehicleTrunkClearingAttention.TryShowAttentionSpawnVehicle(serverModel, _globalModel.ModalDialogScreenModel, _screenContent, SendSpawnCarMessage, _parkingPosition);
}

// Просто удалил комментарий. Он дублирует название метода.

2.3

if (SystemInfo.deviceType == DeviceType.Handheld) // || UnityEditor.EditorApplication.isRemoteConnected)
// ->
if (SystemInfo.deviceType == DeviceType.Handheld)

// Убрал закомментированный старый код

2.4

_updater = new CompositeUpdater(new List<IUpdater>
{
        //must be used first
        new InventoryDragAndDropEmptyResetUpdater(inventoryModels.InventoryDragAndDropModel),

        //must be used in the middle
        new InventoryDragAndDropModelUpdater(inventoryModels.InventoryDragAndDropModel, inventoryUiView.InventoryCellsUiView, inventoryClientModel, inventoryModels.ClickableItemsModel),
        // ...
        new HighlightedItemsUpdater(inventoryModels.InventoryDragAndDropModel, inventoryUiModel.Player.ClientModel.UseItemsRule, inventoryClientModel, inventoryModels.HighlightedItemsModel),

        //must be used by the end
        new UseItemModelUpdater(inventoryUiModel.Player.ClientModel.UseItemModel, battleInputModel, inventoryUiModel.Player.ServerModel, globalModel.PersonalNotificationModel, battleScreenContent.LocalizationKeys.UnavailableKeys, disposable),
});

//->

var beforeUpdater = new InventoryDragAndDropEmptyResetUpdater(inventoryModels.InventoryDragAndDropModel);
var mainUpdater = new CompositeUpdater(new List<IUpdater>
{
        new InventoryDragAndDropModelUpdater(inventoryModels.InventoryDragAndDropModel, inventoryUiView.InventoryCellsUiView, inventoryClientModel, inventoryModels.ClickableItemsModel),
        // ...
        new HighlightedItemsUpdater(inventoryModels.InventoryDragAndDropModel, inventoryUiModel.Player.ClientModel.UseItemsRule, inventoryClientModel, inventoryModels.HighlightedItemsModel),
});
var afterUpdater = new UseItemModelUpdater(inventoryUiModel.Player.ClientModel.UseItemModel, battleInputModel, inventoryUiModel.Player.ServerModel, globalModel.PersonalNotificationModel, battleScreenContent.LocalizationKeys.UnavailableKeys, disposable);

_updater = new CompositeUpdater(new List<IUpdater> {
        beforeUpdater,
        mainUpdater,
        afterUpdater,
});

// Комментарии о порядке элементов поменял на более явное задание порядка.


2.5
[field: SerializeField] public Event KnockdownGrounded { get; private set; }
[field: SerializeField] public Event ReviveSound { get; private set; }
// Receive damage group
[field: SerializeField] public Switch Armor { get; private set; }
[field: SerializeField] public Switch DropArmor { get; private set; }
[field: SerializeField] public Switch Health { get; private set; }
// Footstep group
[field: SerializeField] public Switch FootstepWalk { get; private set; }
[field: SerializeField] public Switch FootstepCrouch { get; private set; }
[field: SerializeField] public Switch FootstepSprint { get; private set; }
[field: SerializeField] public Switch FootstepKnocked { get; private set; }
// Belonging group
[field: SerializeField] public Switch BelongingSelf { get; private set; }
[field: SerializeField] public Switch BelongingOther { get; private set; }

//->

[field: SerializeField] public Event KnockdownGrounded { get; private set; }
[field: SerializeField] public Event ReviveSound { get; private set; }
[field: Header("Receive damage group")]
[field: SerializeField] public Switch Armor { get; private set; }
[field: SerializeField] public Switch DropArmor { get; private set; }
[field: SerializeField] public Switch Health { get; private set; }
[field: Header("Footstep group")]
[field: SerializeField] public Switch FootstepWalk { get; private set; }
[field: SerializeField] public Switch FootstepCrouch { get; private set; }
[field: SerializeField] public Switch FootstepSprint { get; private set; }
[field: SerializeField] public Switch FootstepKnocked { get; private set; }
[field: Header("Belonging group")]
[field: SerializeField] public Switch BelongingSelf { get; private set; }
[field: SerializeField] public Switch BelongingOther { get; private set; }


// Перенес комментарии в атрибут, текст будет отображаться не только в коде (там где он не так сильно нужен), но и в редакторе Unity, где наглядность более важна



