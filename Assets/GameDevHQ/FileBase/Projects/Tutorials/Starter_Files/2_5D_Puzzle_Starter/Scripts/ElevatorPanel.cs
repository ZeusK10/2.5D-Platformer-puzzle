using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject indicator;
    [SerializeField]
    private int _requiredCoins = 8;
    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Player")
        {
            Player player = other.GetComponent<Player>();
            if(Input.GetKeyDown(KeyCode.E) && player.CoinsCollected()>=_requiredCoins)
            {
                indicator.GetComponent<MeshRenderer>().material.color = Color.green;
            }
        }
    }
}
