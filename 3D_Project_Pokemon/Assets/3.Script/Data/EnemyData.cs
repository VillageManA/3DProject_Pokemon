using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public static EnemyData Instance { get; private set; }

    // ���õ� �� Ʈ���̳��� ���� ������ ������ ����
    public PokemonStats[] SelectedEnemyPokemon { get; set; }

    private void Awake()
    {
        // �̱��� �ν��Ͻ� ����
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
}
