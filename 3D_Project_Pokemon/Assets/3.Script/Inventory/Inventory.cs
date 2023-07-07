using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<ItemData, int> itemDictionary = new Dictionary<ItemData, int>(); // 아이템과 수량을 관리하는 딕셔너리

    public void AddItem(ItemData item, int quantity = 1)
    {
        if (itemDictionary.ContainsKey(item))
        {
            itemDictionary[item] += quantity; // 이미 있는 아이템이면 수량을 증가
        }
        else
        {
            itemDictionary.Add(item, quantity); // 새로운 아이템이면 딕셔너리에 추가
        }
    }

    public void RemoveItem(ItemData item, int quantity = 1)
    {
        if (itemDictionary.ContainsKey(item))
        {
            itemDictionary[item] -= quantity; // 아이템의 수량을 감소

            if (itemDictionary[item] <= 0)
            {
                itemDictionary.Remove(item); // 아이템의 수량이 0 이하면 제거
            }
        }
    }

    public int GetItemCount(ItemData item)
    {
        if (itemDictionary.ContainsKey(item))
        {
            return itemDictionary[item]; // 아이템의 수량을 반환
        }
        else
        {
            return 0; // 아이템이 없으면 0을 반환
        }
    }


}
