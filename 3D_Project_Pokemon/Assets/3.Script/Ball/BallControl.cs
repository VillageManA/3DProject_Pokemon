using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    PlayerData playerData;
    [SerializeField] GameObject[] balls;
    PlayerAnimationEvent playerAnimationEvent;
    [SerializeField] private Transform player_Zone;
    [SerializeField] private Transform start_Ball_Positon;
    private Vector3 enemy_Zone;

    public float throwSpeed = 5f; // 공을 던질 속도
    public float throwHeight = 3f; // 공이 도달할 높이

    private void Awake()
    {
        playerData = FindObjectOfType<PlayerData>();
        playerAnimationEvent = FindObjectOfType<PlayerAnimationEvent>();
        playerAnimationEvent.onBallEvent.AddListener(() => Ball_Throw());

    }

    public void Ball_Throw()
    {
        balls[0].transform.position = start_Ball_Positon.transform.position;
        balls[0].transform.LookAt(player_Zone);
        Rigidbody ballRigidbody = balls[0].GetComponent<Rigidbody>();
        ballRigidbody.velocity = CalculateThrowVelocity(balls[0].transform.position, player_Zone.transform.position, throwSpeed, throwHeight);

    }
    public void StartBattle(int Num = 0)
    {
        GameObject obj = Instantiate(playerData.player_Pokemon[Num].gameObject, player_Zone.transform.position, Quaternion.identity);
        obj.tag = "PlayerPokemon";
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
