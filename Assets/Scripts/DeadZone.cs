using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform respwanPoint;
    [SerializeField] private RespawSystem rs;

    private void OnTriggerEnter(Collider other)
    {
        rs.Respawnplayer(other.gameObject);
    }
}
