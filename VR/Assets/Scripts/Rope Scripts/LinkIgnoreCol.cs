using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkIgnoreCol : MonoBehaviour
{

    void Start()
    {
        Physics.IgnoreLayerCollision(9, 11);
    }

/*    void OnDestroy()
    {
        transform.parent.SendMessage("ChildWasDestroyed");
    }

    void DestroyThisObject()
    {
        Destroy(gameObject);
    }*/
}
