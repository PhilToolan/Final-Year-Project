using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weight : MonoBehaviour
{
	public float distanceFromChainEnd = 0.6f;

	public void ConnectRopeEnd(Rigidbody endRB)
	{
		HingeJoint joint = gameObject.AddComponent<HingeJoint>();
		joint.autoConfigureConnectedAnchor = false;
		joint.connectedBody = endRB;
		joint.anchor = Vector3.zero;
		joint.connectedAnchor = new Vector3(0f, -distanceFromChainEnd, 0f);
	}

}