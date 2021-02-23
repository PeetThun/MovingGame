using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject respawnPoint;

    public void Respawnplayer(GameObject player)
    {
        player.GetComponent<PlayerDestroy>().DestroyPlayer();
        GameObject newplayer = Instantiate(playerPrefab, respawnPoint.transform.position, Quaternion.identity);
    }
}
