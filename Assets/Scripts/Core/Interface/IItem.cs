using UnityEngine;

public interface IItem
{
    ItemType type { get; }
    int maxSlot { get; }
    Sprite icon { get; }
}

public enum ItemType
{
    None,
    Milk,
    Seed

}
