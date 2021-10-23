using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] private float timeToDestroy;

    private bool _isCarrying;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Bumped into " + other.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Package":
                if (!_isCarrying)
                {
                    Debug.Log("Package picked up");
                    _isCarrying = true;
                    Destroy(other.gameObject, timeToDestroy);
                }
                
                break;

            case "Consumer":
                if (_isCarrying)
                {
                    Debug.Log("Package delivered");
                    _isCarrying = false;
                }

                break;
        }
    }
}
