using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkIgnoreCol : MonoBehaviour
{

    void Start()
    {
        Physics.IgnoreLayerCollision(9, 11);
    }

}
