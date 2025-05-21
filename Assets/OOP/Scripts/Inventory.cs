using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Transform[] _itemSlots = new Transform[4];

    private List<Item> _items = new List<Item>();
    private int _maxItems => _itemSlots.Length;
    private int _nextIndexToUse = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            UseItem();
    }

    public bool AddItem(Item item)
    {
        if (_items.Count >= _maxItems)
        {
            Debug.Log("Инвентарь полон!");
            return false;
        }

        item.OnPickedUp();

        _items.Add(item);
        int index = _items.Count - 1;

        item.transform.SetParent(_itemSlots[index]);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;

        Destroy(item.GetComponent<Collider>());
        return true;
    }

    public void UseItem()
    {
        if (_items.Count == 0)
        {
            Debug.Log("Нет предметов для использования.");
            return;
        }

        Item item = _items[_nextIndexToUse];

        item.Use(gameObject);

        Destroy(item.gameObject);

        if (_nextIndexToUse >= _items.Count)
            _nextIndexToUse = 0;

        _items.RemoveAt(_nextIndexToUse);

    }

}
