using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;
using UnityEngine.UI;

public class SwordDamage : MonoBehaviourPunCallbacks
{
    public int playerHealthPoints;
    

    private void OnTriggerEnter(Collider other)
    {
        string ObjIsmi = other.gameObject.name;
        if (ObjIsmi.Equals("Sword"))
        {
            playerHealthPoints -= 20;
            playerHealthPoints.text = canSayaci + "";
        }
    }

}
