using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRotation : MonoBehaviour
{
    [Tooltip("Animate the transform to the min rotation")]
    public bool animateOnStart = true;
    [Space]
    public bool lockAxisX;
    public bool lockAxisY;
    public bool lockAxisZ;
    [Space]
    public Vector3 minRotation;
    public Vector3 maxRotation;

    IEnumerator Start()
    {
        if (lockAxisX)
        {
            minRotation.x = transform.position.x;
            maxRotation.x = transform.position.x;
        }
        if (lockAxisY)
        {
            minRotation.y = transform.position.y;
            maxRotation.y = transform.position.y;
        }
        if (lockAxisZ)
        {
            minRotation.z = transform.position.z;
            maxRotation.z = transform.position.z;
        }

        if (animateOnStart)
        {
            Vector3 rot = transform.localRotation.eulerAngles;

            for (float i = 0;  i < 1; i += Time.deltaTime)
            {
                transform.localRotation = Quaternion.Euler(Vector3.Slerp(rot, minRotation, i));
                yield return null;
            }
        }

        print(gameObject.name + " | " + Vector3.Cross(minRotation, maxRotation)); ;
    }

    public void SetRotation(float normalizedValue)
    {

        transform.localRotation = Quaternion.Euler(Vector3.LerpUnclamped(minRotation, maxRotation, normalizedValue));
    }

    
}

