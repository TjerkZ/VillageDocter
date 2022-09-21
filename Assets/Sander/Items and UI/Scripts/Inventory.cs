using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, IItemContainer
{
   [SerializeField] List<Item> items;
   [SerializeField] Transform itemsParent;
   [SerializeField] ItemSlot[] itemSlots;

    private void OnValidate()
    {
        if(itemsParent != null)
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();

            RefreshUI();

    }

    private void RefreshUI()
    {
        int i = 0;
        for(; i<items.Count && i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = items[i];
        }

        for (; i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = null;
        }
    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if(itemSlots[i].Item == item)
            {
                itemSlots[i].Item = item;
                return true;
            }
        }
        return false;
    }

    public bool RemoveItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if(itemSlots[i].Item == item)
            {
                itemSlots[i].Item = null;
                return true;
            }
        }
        return false;
    }

    public bool IsFull()
    {
        return items.Count >= itemSlots.Length;
    }

    public bool ContainsItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
            {
                 if(itemSlots[i].Item == item)
                {
                    
                    return true;
                }
            }
        return false;
    }

    public int ItemCount(Item item)
    {
        int number = 0;
        for (int i = 0; i < itemSlots.Length; i++)
            {
                 if(itemSlots[i].Item == item)
                {
                    
                    number++;
                }
            }
      return number;
    }
}
