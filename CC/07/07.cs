3.1.

public class InventoryItemDescription
{
    public static InventoryItemDescription RoomKey0 { get; } = new InventoryItemDescription("room_key_0", type: InventoryItemTypeDescription.KeyContainer, cellsSize: InventoryItemCellsSizeDescription.Size1x1, basePrice: 540, stackSize: 1, isSellAvailable: true); // было
    public static InventoryItemDescription RoomKey1 { get; } = InventoryItemDescription.CreateKey("room_key_1", basePrice: 540); // стало

    private static InventoryItemDescription CreateKey(string id, int basePrice)
    {
        return new InventoryItemDescription(id, type: InventoryItemTypeDescription.KeyContainer, cellsSize: InventoryItemCellsSizeDescription.Size1x1, basePrice:basePrice, stackSize: 1, isSellAvailable: true);
    }

    private InventoryItemDescription(string id, InventoryItemTypeDescription type, InventoryItemCellsSizeDescription cellsSize, int stackSize, int basePrice, bool isSellAvailable)
    {
        // ...
    }
}

public class PlayerPartyData
{
    public PlayerPartyData PartyData(...)
    {
            // ...
    }

    public PlayerPartyData SingleMemberPartyData(...)
    {
            // ...
    }

    public PlayerPartyData NoPartyData()
    {
            // ...
    }

    public PlayerPartyData ClientData()
    {
            // ...
    }

    private PlayerPartyData()
    {
            // ...
    }
}

public class Clothes
{
    private Clothes(...)
    {
            // ...
    }

    public static Clothes DefaultMan()
    {
            // ...
    }
    public static Clothes DefaultWoman()
    {
            // ...
    }
    public static Clothes Custom(...)
    {
            // ...
    }
}

3.2
ScreenFactory // интерфейс
BattleScreenFactory // определение

MarkerModel - PingMakerModel

TargetSubsystem - UnityRaycastTargetSubsystem




