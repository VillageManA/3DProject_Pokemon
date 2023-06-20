using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Data
{
    public string Name;
    public int MaxHp;
    public int Attack;
    public int Defence;
    public int SpAttack;
    public int SpDefence;
    public int Speed;
    public Type Type1;
    public Type Type2;
    public enum Type
    {
        Normal, Fight, Poison, Earth, Flight, Bug, Rock, Ghost, Steel, Fire, Water, Electricty, Grass, Ice, Esper, Dragon, Evil, Fairy, None
    }
}
public class PokemonData : MonoBehaviour
{
    Data Pokemon = new Data() { Name = "이상해씨", MaxHp = 45, Attack = 49, Defence = 49, SpAttack = 65, SpDefence = 65, Speed = 45, Type1 = Data.Type.Grass, Type2 = Data.Type.None };
    // Start is called before the first frame update
    string FilePath = "Assets/DataBase/Pokemon.json";
    void Start()
    {
        string JsonData = JsonUtility.ToJson(Pokemon);
        File.WriteAllText(FilePath, JsonData);
        Debug.Log("제이슨 파일 저장");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
