using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject indicator;
    private bool _elevatorCalled;
    [SerializeField]
    private int _requiredCoins = 8;
    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Player")
        {
            Player player = other.GetComponent<Player>();
            if(Input.GetKeyDown(KeyCode.E) && player.CoinsCollected()>=_requiredCoins)
            {
                if(_elevatorCalled==false)
                { 
                    indicator.GetComponent<MeshRenderer>().material.color = Color.green;
                    _elevatorCalled = true;
                    Elevator elevator = GameObject.Find("Elevator").GetComponent<Elevator>();
                    elevator.CallElevator();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if(_elevatorCalled==true)
            {
                indicator.GetComponent<MeshRenderer>().material.color = Color.red;
                _elevatorCalled = false;
            } 
        }
    }
}
