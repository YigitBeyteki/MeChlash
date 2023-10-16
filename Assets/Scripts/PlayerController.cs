using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;

public class PlayerController : MonoBehaviourPunCallbacks, IPunObservable
{
    [HideInInspector]
    public int id;

    [Header("Info")]
    public float moveSpeed;
    public float jumpForce;
    public float playerHealthPoints;
    
    [HideInInspector]
    public bool isAlive;

    [Header("Components")]
    public Rigidbody rig;
    public Player photonPlayer;

    public static PlayerController instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            




        }

        if (photonView.IsMine)
        {
            Move();

            if (Input.GetKeyDown(KeyCode.Space))
                TryJump();
        }

    }

    void TryJump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, 0.7f))
        {
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        rig.velocity = new Vector3(-x, rig.velocity.y, -z);

    }

    [PunRPC]
    public void Initialize(Player player)
    {
        photonPlayer = player;
        id = player.ActorNumber;

        GameManager.instance.players[id - 1] = this;

        if (!photonView.IsMine)
        {
            rig.isKinematic = true;
        }

    }

    [PunRPC]
    void TakeDamage(float damage)
    {
        if (playerHealthPoints > damage)
        {
            playerHealthPoints -= damage;
        }else if (playerHealthPoints <= damage) 
        {

        
        }
        



    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(playerHealthPoints);
        }
        else if (stream.IsReading)
        {
            playerHealthPoints = (float)stream.ReceiveNext();
        }
    }





}


