using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    PlayerData playerData;
    Battle battle;
    BattleCamera battleCam;
    [SerializeField] GameObject[] balls;
    PlayerAnimationEvent playerAnimationEvent;
    [SerializeField] private Transform player_Zone;
    [SerializeField] private Transform start_Ball_Positon;
    private Vector3 enemy_Zone;
    private Vector3 set_Playerzone = new Vector3(-1,3.4f,5);
    public float throwSpeed = 5f; // 공을 던질 속도
    public float throwHeight = 3f; // 공이 도달할 높이

    private void Start()
    {
        playerData = FindObjectOfType<PlayerData>();
        playerAnimationEvent = FindObjectOfType<PlayerAnimationEvent>();
        playerAnimationEvent.onBallEvent.AddListener(() => Ball_Throw());
        battle = FindObjectOfType<Battle>();
        battleCam = FindObjectOfType<BattleCamera>();
        battleCam.SwitchCamera(0);
    }

    public void Ball_Throw()
    {
        StartCoroutine(Start_co());
    }
    private IEnumerator Start_co()
    {
        balls[0].transform.position = start_Ball_Positon.transform.position;
        balls[0].transform.LookAt(player_Zone);
        Rigidbody ballRigidbody = balls[0].GetComponent<Rigidbody>();
        ballRigidbody.velocity = CalculateThrowVelocity(balls[0].transform.position, player_Zone.transform.position + set_Playerzone, throwSpeed, throwHeight);
        yield return new WaitForSeconds(0.5f);
        battleCam.SwitchCamera(1);
        GameObject obj = playerData.player_Pokemon[battle.selected_Pokemon].gameObject;
        obj.transform.position = player_Zone.transform.position;
        obj.tag = "PlayerPokemon";
        yield return new WaitForSeconds(1.2f);
        StartBattle();
    }
    public void StartBattle()
    {
        battleCam.SwitchCamera(2);
        battle.StartBattle();
    }

    private Vector3 CalculateThrowVelocity(Vector3 start, Vector3 target, float speed, float height)
    {
        float distance = Vector3.Distance(start, target);
        float time = distance / speed;
        float verticalVelocity = (height - start.y + target.y) / time;

        Vector3 velocity = target - start;
        velocity.y = verticalVelocity;
        velocity.Normalize();
        velocity *= speed;

        return velocity;
    }
}
