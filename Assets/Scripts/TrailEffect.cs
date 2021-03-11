using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class TrailEffect : MonoBehaviour
{

    TrailRenderer t;



    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<TrailRenderer>();
       
    }

    public void SetTrailActive(bool n)
    {
        t.enabled = n;
    }

    public void ClearTail()
    {
        t.Clear();
    }


}
