using UnityEngine;
using System.Collections;

public class addCameraVR : Photon.MonoBehaviour
{
    public GameObject camera;
	// Use this for initialization
	void Start () {
        bool localObject = photonView.isMine;
        
        if (localObject)
        {
            Object newCam = Instantiate(camera, transform.position, transform.rotation);
            var newTransform = ((GameObject)newCam).transform;
            newTransform.parent = transform;
        }
    }
	
	// Update is called once per frame
	void Update () {
       
	}
}
