using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    public Rigidbody attachPoint;

    SteamVR_TrackedObject trackedObj;
    GameObject attachedObj;
    public SteamVR_TrackedController trackedController;
    bool firstClick = false;
    private void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        trackedController = GetComponent<SteamVR_TrackedController>();
    }

    private void FixedUpdate()
    {
        
        if(attachedObj)
        {
            attachedObj.transform.rotation = transform.rotation;
            attachedObj.transform.localEulerAngles = new Vector3(-90, 0, 0);

            //reset position if stuf got weird
            if((attachedObj.transform.position - transform.position).magnitude > 1)
            {
                attachedObj.transform.localPosition = Vector3.zero;
                attachedObj.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
        
    }

    private void TriggerClickedWhileHoldingObject(object sender, ClickedEventArgs e)
    {
        if(firstClick)
        {
            firstClick = false;
            return;
        }
        if(attachedObj.GetComponent<SpringJoint>())
            Destroy(attachedObj.GetComponent<SpringJoint>());
        attachedObj.transform.SetParent(null);
        attachedObj.GetComponent<Rigidbody>().useGravity = true;
        attachedObj.GetComponent<Rigidbody>().freezeRotation = false;
        attachedObj = null;
        trackedController.TriggerClicked -= TriggerClickedWhileHoldingObject;
    }

    private void OnTriggerStay(Collider other)
    {
        var device = SteamVR_Controller.Input((int)trackedObj.index);
        if (!attachedObj && 
            device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) &&
            other.GetComponent<InteractableObject>())
        {
            attachedObj = other.gameObject.transform.root.gameObject;
            attachedObj.transform.position = transform.position;
            var joint = attachedObj.AddComponent<SpringJoint>();
            //joint.breakForce = 5;
            joint.connectedBody = attachPoint;
            attachedObj.GetComponent<Rigidbody>().useGravity = false;
            attachedObj.GetComponent<Rigidbody>().freezeRotation = true;
            attachedObj.transform.SetParent(transform);

            trackedController.TriggerClicked -= TriggerClickedWhileHoldingObject;
            trackedController.TriggerClicked += TriggerClickedWhileHoldingObject;

            firstClick = true;
        }
    }
}
