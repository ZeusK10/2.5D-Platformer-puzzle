using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Moveable")
        {
            if(Mathf.Abs(other.transform.position.x-transform.position.x)<=0.1f)
            {
                Rigidbody rbody = other.GetComponent<Rigidbody>();
                if(rbody!=null)
                {
                    rbody.isKinematic = true;
                }
                MeshRenderer renderer = GetComponentInChildren<MeshRenderer>();
                if(renderer!=null)
                {
                    renderer.material.color = Color.green;
                }
                Destroy(this);
            }
        }
    }
}
