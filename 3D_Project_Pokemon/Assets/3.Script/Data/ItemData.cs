using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/ItemData", fileName = "ItemData")]
public class ItemData : ScriptableObject
{
    [Header("������ �̸�")]
    [SerializeField] private string Name;
    [Header("������ ����")]
    [SerializeField] private int Quantity;
    [Header("ȸ����")]
    [SerializeField] private int HealingHp;
    [SerializeField] private int HealingHpPercent;
    [SerializeField] private int HealingPp;
    [SerializeField] private int HealingPpPercent;
    [Header("����")]
    [SerializeField] private int Price;
    [SerializeField] private int SellPrice;
    //[SerializeField] private int MachineNum;
    [Header("������ Ÿ��")]
    [SerializeField] private ItmeType Type;
    public enum ItmeType
    {
        Portion, Important, Ball, SkillMachine, Equip, ETC
    }


}
