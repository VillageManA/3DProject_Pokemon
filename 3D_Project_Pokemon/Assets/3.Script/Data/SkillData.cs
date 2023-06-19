using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Skill" , fileName ="Skill")]
public class SkillData : ScriptableObject
{
    [SerializeField] private string Name;
    [SerializeField] private int PP;
    [SerializeField] private int Damage;
    [SerializeField] private int Hitrate;
    //[SerializeField] private int ;
    [SerializeField] private int Number_of_Attack;

    [Header("�Ӽ�")]
    [SerializeField] PropertyType propertyType;
   

    [Header("�켱��")]
    [SerializeField] private int Priority;
    [Header("�������� Ư������")]
    [SerializeField] private attackType AttackType;

    public enum attackType
    {
        Attack , Speicial
    }
    public enum PropertyType
    {
        Normal, Fight, Poison, Earth, Flight, Bug, Rock, Ghost, Steel, Fire, Water, Electricty, Grass, Ice, Esper, Dragon, Evil, Fairy, None
    }
}
