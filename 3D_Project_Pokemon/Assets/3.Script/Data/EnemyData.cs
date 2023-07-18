using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public static EnemyData Instance { get; private set; }

    // 선택된 적 트레이너의 몬스터 정보를 저장할 변수
    public PokemonStats[] SelectedEnemyPokemon { get; set; }

    private void Awake()
    {
        // 싱글톤 인스턴스 생성
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
