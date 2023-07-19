using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isField;
    public bool isOpenUI;
    public bool isBattle;
    public bool[] EndBattle;
    public bool isTalk;


    private static GameManager instance = null;
    public static GameManager Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        EndBattle = new bool[10];
    }
    
}
