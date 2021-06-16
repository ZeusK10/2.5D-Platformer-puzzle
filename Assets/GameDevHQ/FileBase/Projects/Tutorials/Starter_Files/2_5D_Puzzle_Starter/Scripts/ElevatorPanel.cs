using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject indicator;
    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                indicator.GetComponent<MeshRenderer>().material.color = Color.green;
            }
        }
    }
}
