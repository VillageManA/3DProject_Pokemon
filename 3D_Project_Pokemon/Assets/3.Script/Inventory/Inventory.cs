using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<ItemData, int> itemDictionary = new Dictionary<ItemData, int>(); // �����۰� ������ �����ϴ� ��ųʸ�

    public void AddItem(ItemData item, int quantity = 1)
    {
        if (itemDictionary.ContainsKey(item))
        {
            itemDictionary[item] += quantity; // �̹� �ִ� �������̸� ������ ����
        }
        else
        {
            itemDictionary.Add(item, quantity); // ���ο� �������̸� ��ųʸ��� �߰�
        }
    }

    public void RemoveItem(ItemData item, int quantity = 1)
    {
        if (itemDictionary.ContainsKey(item))
        {
            itemDictionary[item] -= quantity; // �������� ������ ����

            if (itemDictionary[item] <= 0)
            {
                itemDictionary.Remove(item); // �������� ������ 0 ���ϸ� ����
            }
        }
    }

    public int GetItemCount(ItemData item)
    {
        if (itemDictionary.ContainsKey(item))
        {
            return itemDictionary[item]; // �������� ������ ��ȯ
        }
        else
        {
            return 0; // �������� ������ 0�� ��ȯ
        }
    }


}
