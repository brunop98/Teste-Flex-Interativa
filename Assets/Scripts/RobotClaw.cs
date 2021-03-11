using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RobotClaw : MonoBehaviour
{

    public CheckPoint extenalPoint1;
    public CheckPoint extenalPoint2;
    [Space]
    public CheckPoint internalPoint1;
    public CheckPoint internalPoint2;

    public GameObject holdingItem;
    Rigidbody _holdingItemBody;
    [Space]
    public Text holdingText;
    Transform _holdingItemParent;
    [Header("Effects")]
    public UnityEvent onGrab;
    public UnityEvent onDrop;

    private void Start()
    {
        UpdateText();
    }

    void Update()
    {
        Debug.Log("Can grab: " + CheckIfCanGrab() + " | Dropped: " + CheckIfDropped());

        if (CheckIfCanGrab())
        {
            Grab();
        } else if (CheckIfDropped())
        {
            Drop();
        }
        
    }


    /// <summary>
    /// Verifica se pode pegar algum objeto
    /// </summary>
    /// <returns>Retorna true caso possa pegar algum objeto</returns>
    bool CheckIfCanGrab()
    {
        if (holdingItem) return false;

        if (!internalPoint1.masterObject) return false;
        if (!internalPoint2.masterObject) return false;

        if (extenalPoint1.masterObject) return false;
        if (extenalPoint2.masterObject) return false;

        if (internalPoint1.masterObject != internalPoint2.masterObject) return false;

        return true;
    }

    bool CheckIfDropped()
    {
        if (!holdingItem) return false;

        if (internalPoint1.masterObject && internalPoint2.masterObject) return false;

        return true;
        
    }

    void Grab()
    {
        onGrab.Invoke();
        holdingItem = internalPoint1.masterObject ;

        if (holdingItem.GetComponent<Rigidbody>()) {
            _holdingItemBody = holdingItem.GetComponent<Rigidbody>();
            _holdingItemBody.isKinematic = true;            
        }

        if (holdingItem.GetComponent<ParticlesTrigger>())
        {
            holdingItem.GetComponent<ParticlesTrigger>().enabled = true;
        }

        _holdingItemParent = holdingItem.transform.parent;
        holdingItem.transform.SetParent(this.transform);

        UpdateText();
    }

    void Drop()
    {
        onDrop.Invoke();
        if (_holdingItemBody != null)
        {
            _holdingItemBody.isKinematic = false;
            _holdingItemBody = null;
        }

        if (_holdingItemParent)
            holdingItem.transform.SetParent(_holdingItemParent);
        else
            holdingItem.transform.parent = null;

        holdingItem = null;
        UpdateText();
    }

    void UpdateText()
    {
        holdingText.text = "Segurando: " + (holdingItem ? holdingItem.name : " - ");
    }
}
