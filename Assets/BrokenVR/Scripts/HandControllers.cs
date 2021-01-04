using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControllers : MonoBehaviour
{

    [SerializeField] private OVRInput.Controller rightController;
    
	/*public SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device;*/

    private Rigidbody rb;
    public bool isGrabbed;
    public GameObject grabbedObject;
    //public GameManager gameManager;
    public GameObject handModels;

    

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per framer
	void Update () {
		/*device = SteamVR_Controller.Input ((int)trackedObj.index);

        if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
        }*/
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "BrokenPiece" && isGrabbed == false)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                GrabObject(other);
            }
        }

        if (other.gameObject.tag == "Phone" && isGrabbed == false)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                GrabPhone(other);

            }
        }

        if (other.gameObject.tag == "BrokenPiece" && isGrabbed == true)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                ReleaseObject(other);
            }
        }

        if (other.gameObject.tag == "Phone" && isGrabbed == true)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                ReleasePhone(other);
            }
        }
    }


    public void GrabObject(Collider coli)
    {
        isGrabbed = true;
        coli.gameObject.transform.SetParent(gameObject.transform);
        //coli.gameObject.transform.rotation = transform.rotation;

        if (coli.gameObject.GetComponent<Rigidbody>())
        {
            Rigidbody coliRb = coli.gameObject.GetComponent<Rigidbody>();
            coliRb.isKinematic = true;
            coliRb.useGravity = false;
        }
        
        //handModels.SetActive(false);

        coli.GetComponent<CapsuleCollider>().isTrigger = true;
    }

    public void ReleaseObject(Collider coli)
    {
        isGrabbed = false;
        coli.gameObject.transform.SetParent(null);
        if (coli.gameObject.GetComponent<Rigidbody>())
        {
            Rigidbody coliRb = coli.gameObject.GetComponent<Rigidbody>();

            coliRb.isKinematic = false;
            coliRb.useGravity = true;
    
        }

        //Debug.Log(rb.velocity);
        //handModels.SetActive(true);

        coli.GetComponent<CapsuleCollider>().isTrigger = false;

    }

    public void GrabPhone(Collider coli)
    {
        isGrabbed = true;
        coli.gameObject.transform.SetParent(gameObject.transform);

        if (coli.gameObject.GetComponent<Rigidbody>())
        {
            Rigidbody coliRb = coli.gameObject.GetComponent<Rigidbody>();
            coliRb.isKinematic = true;
            coliRb.useGravity = false;

        }
      

        coli.transform.localPosition = new Vector3(0, 0.03f, 0.03f);
        coli.transform.localRotation = Quaternion.Euler(3.42f, 180, 2.3f);
        coli.GetComponent<BoxCollider>().isTrigger = true;

        handModels.SetActive(false);

    }

    public void ReleasePhone(Collider coli)
    {
        isGrabbed = false;
        coli.gameObject.transform.SetParent(null);
        Rigidbody coliRb = coli.gameObject.GetComponent<Rigidbody>();
        coliRb.isKinematic = false;
        coliRb.useGravity = true;
        
        coli.GetComponent<BoxCollider>().isTrigger = false;

        handModels.SetActive(true);
    }

    public void Reset()
    {
        isGrabbed = false;
        grabbedObject = null;
        handModels.SetActive(true);
    }
}
