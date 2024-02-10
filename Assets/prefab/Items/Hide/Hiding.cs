using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour,IInteractable
{
    private Transform player;
    bool ishiding = false;
    [SerializeField]Transform[] hide_point;
    private void Start()
    {
        player = GameObject.Find("player").transform;
    }
    public void Interact()
    {
        hide();
        print(player.name + " " + " hide : " + ishiding);
    }

    void hide()
    {
        if (!ishiding)
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.position =  hide_point[0].position;
            ControlPlayer.playerStat = ControlPlayer.PlayerStat.hiding;
            player.Rotate(0,180,0);
            LightBatterieManager.instance.offLight();
            player.GetComponent<CharacterController>().enabled = true;

            ishiding = true;
        }
        else
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.position = hide_point[1].position;
            ControlPlayer.playerStat = ControlPlayer.PlayerStat.normal;
            LightBatterieManager.instance.onLight();
            player.GetComponent<CharacterController>().enabled = true;
            ishiding = false;
        }
    }   
}
