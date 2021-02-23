using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public List<MovingPlatForm> rotatingList;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayer(GameObject _player) 
    {
        player = _player;
        upDatePlayer();
    }
    public void upDatePlayer() 
    {
        if(rotatingList.Count != 0)
        {
            foreach(MovingPlatForm mp in rotatingList)
            {
                mp.Player = player;
            }
        }
    }

}
