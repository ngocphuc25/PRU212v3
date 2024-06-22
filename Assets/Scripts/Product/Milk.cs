using UnityEngine;

public class Milk : MonoBehaviour, IItem
{
    public ItemType type => _type;
    public int maxSlot => _maxSlot;

    public Sprite icon => _icon;

    [SerializeField] private ItemType _type;
    [SerializeField] private int _maxSlot;
    [SerializeField] private Sprite _icon;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ProductPool.Instance.ReturnToPool(gameObject);
            var player = other.GetComponent<PlayerMovement>();
            player.Inventory.AddItem(this, 1);
        }
    }
}
