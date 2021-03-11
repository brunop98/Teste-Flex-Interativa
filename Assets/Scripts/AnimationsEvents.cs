using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsEvents : MonoBehaviour
{
    public Transform robotClaw;
    public Rigidbody cube;
    

    Transform _oldObjectParent;
    Vector3 _cubeStartPos;
    Quaternion _cubeStartRot;
    ParticlesTrigger _cubeParticles;

    private void Start()
    {
        _cubeStartPos = cube.transform.position;

        _cubeStartRot = cube.transform.rotation;
        _cubeParticles = cube.GetComponent<ParticlesTrigger>();
    }

    public void PickUpCube()
    {
        cube.isKinematic = true;

        _oldObjectParent = cube.transform.parent ;
        cube.transform.parent = robotClaw;
    }

    public void DropCube()
    {
        cube.transform.SetParent(_oldObjectParent);
        cube.isKinematic = false;
    }

    public void ResetCube()
    {
        cube.transform.position = _cubeStartPos;
        cube.transform.rotation = _cubeStartRot;
    }


    public void ActiveCubeParticles(string n)
    {
        _cubeParticles.canRunParticles = bool.Parse(n.ToLower());
    }

    public void DisableAnimator()
    {
        GetComponent<Animator>().enabled = false;
    }

}
