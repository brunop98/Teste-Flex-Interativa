using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CheckPoint : MonoBehaviour
{

    public GameObject masterObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger) return;

        masterObject = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.isTrigger) return;
        masterObject = null;
    }


}
