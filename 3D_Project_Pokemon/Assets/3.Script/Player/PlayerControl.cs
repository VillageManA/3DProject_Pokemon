using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    [SerializeField] private Animator Player_Ani;
    private PlayerMoveMent playerMoveMent;
    #region 싱글톤 선언
    private static PlayerControl instance = null;
    public static PlayerControl Instance
    {
        get { return instance; }
    }

    #endregion
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
        Player_Ani = GetComponent<Animator>();
        playerMoveMent = GetComponent<PlayerMoveMent>();
    }



    #region 애니메이션 온오프
    public void StartIdleAni()
    {
        Player_Ani.SetBool("Idle", true);
    }
    public void EndIdleAni()
    {
        Player_Ani.SetBool("Idle", false);
    }
    public void StartMoveAni()
    {
        Player_Ani.SetBool("Move", true);
    }
    public void EndMoveAni()
    {
        Player_Ani.SetBool("Move", false);
    }
    public void StartRunAni()
    {
        Player_Ani.SetBool("Run", true);
    }
    public void EndRunAni()
    {
        Player_Ani.SetBool("Run", false);
    }
    public void StartLeftTurn()
    {
        Player_Ani.SetBool("LeftTurn", true);
    }public void EndLeftTurn()
    {
        Player_Ani.SetBool("LeftTurn", false);
    }   
    public void StartRightTurn()
    {
        Player_Ani.SetBool("RightTurn", true);
    }public void EndRightTurn()
    {
        Player_Ani.SetBool("RightTurn", false);
    }
    #endregion
}

