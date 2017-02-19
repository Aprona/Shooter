using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TAMKShooter.Data;
using TAMKShooter;
using System;

public class InputManager : MonoBehaviour {

    private PlayerUnits units;
    public Vector3 input;

    // Use this for initialization
    void Start () {
        units = FindObjectOfType<PlayerUnits>();       
	}
	
	// Update is called once per frame
	void Update () {

        GetInput();        
	}

    private void GetInput()
    {
        foreach (KeyValuePair<PlayerData.PlayerId, PlayerUnit> player in units._players)
        {
            float horizontal = 0;
            float vertical = 0;
            bool shoot = false;

            if (player.Key == PlayerData.PlayerId.Player1)
            {
                horizontal = Input.GetAxis("P1 Horizontal");
                vertical = Input.GetAxis("P1 Vertical");
                shoot = Input.GetButton("P1 Shoot");                                       
            }
            else if (player.Key == PlayerData.PlayerId.Player2)
            {
                horizontal = Input.GetAxis("P2 Horizontal");
                vertical = Input.GetAxis("P2 Vertical");
                shoot = Input.GetButton("P2 Shoot");
            }
            else if (player.Key == PlayerData.PlayerId.Player3)
            {
                horizontal = Input.GetAxis("P3 Horizontal");
                vertical = Input.GetAxis("P3 Vertical");
                shoot = Input.GetButton("P3 Shoot");
            }
            else if (player.Key == PlayerData.PlayerId.Player4)
            {
                horizontal = Input.GetAxis("P4 Horizontal");
                vertical = Input.GetAxis("P4 Vertical");
                shoot = Input.GetButton("P4 Shoot");
            }

            input = new Vector3(horizontal, 0, vertical);

            if (input != Vector3.zero)
                player.Value.Mover.MoveToDirection(input);

            if (shoot)
            {
                player.Value.Weapons.Shoot(player.Value.ProjectileLayer);
            }
        }
    }
}
