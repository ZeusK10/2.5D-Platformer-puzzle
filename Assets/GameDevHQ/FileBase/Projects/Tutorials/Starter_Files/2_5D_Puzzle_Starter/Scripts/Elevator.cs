using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private bool _elevatorCalled;
    private Vector3 _currentTarget;
    private GameObject _player;
    private float _speed = 2.0f;
    [SerializeField]
    private Transform _targetA, _targetB;
    public void CallElevator()
    {
        if (transform.position == _targetA.position)
        {
            _currentTarget = _targetB.position;
        }
        else if (transform.position == _targetB.position)
        {
            _currentTarget = _targetA.position;
        }
        _elevatorCalled = true;
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Player")
        {
            other.transform.parent = this.transform;
            if (Mathf.Abs(transform.position.y-_targetA.position.y)<0.5 || Mathf.Abs(transform.position.y - _targetB.position.y) < 0.5)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    CallElevator();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="Player")
        {
            other.transform.parent = null;
        }
    }

    private void FixedUpdate()
    {
        if(_elevatorCalled==true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _currentTarget, _speed * Time.deltaTime);
            if(transform.position==_currentTarget)
            {
                _elevatorCalled = false;
            }
        }
    }
}
