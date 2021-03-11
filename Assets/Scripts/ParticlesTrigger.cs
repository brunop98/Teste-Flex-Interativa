using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesTrigger : MonoBehaviour
{
    public bool canRunParticles = true;
    public ParticleSystem particles;

   

    private void OnCollisionEnter(Collision collision)
    {
        if (!canRunParticles) return;
        if (particles.isPlaying) return;


        Vector3 pos = Vector3.zero;

        foreach (ContactPoint i in collision.contacts)
        {
            pos += i.point;
        }

        pos /= collision.contacts.Length;

        particles.transform.position = pos;
        particles.Play();
    }
}
