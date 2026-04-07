using UnityEngine;

public class InstantTeleportBowling : MonoBehaviour
{
    public GameObject player;
    //private Rigidbody playerRb;
    public GameObject targetObj;
    private Rigidbody targetObjRb;
    public Vector3 offSet = new Vector3(1, 0.7f, 1);

    private bool canFlash = true;
    //private int LayerNumber;

    void Start()
    {
        //LayerNumber = LayerMask.NameToLayer("flashLayer");
    }
    void Update()
    {
        if (targetObj != null)
        {
            if (Input.GetKeyDown(KeyCode.G) && canFlash == true)
            {
                //StopClipping();
                Flash();
                Land();
            }
        }
    }
    void Flash()
    {
        Physics.IgnoreCollision(targetObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        targetObjRb = targetObj.GetComponent<Rigidbody>();
        //playerRb = player.GetComponent<Rigidbody>();
        //playerRb.isKinematic = true;
        //playerRb.linearVelocity = targetObjRb.linearVelocity;        
        player.transform.position = targetObj.transform.position + offSet;
        //player.layer = LayerNumber;
    }
    void Land()
    {
        Physics.IgnoreCollision(targetObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        //player.layer = 0;
        //playerRb.isKinematic = false;
    }
    //void StopClipping() //function only called when dropping/throwing
    //{
    //    var clipRange = Vector3.Distance(targetObj.transform.position, transform.position); //distance from holdPos to the camera
    //    //have to use RaycastAll as object blocks raycast in center screen
    //    //RaycastAll returns array of all colliders hit within the cliprange
    //    RaycastHit[] hits;
    //    hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), clipRange);
    //    //if the array length is greater than 1, meaning it has hit more than just the object we are carrying
    //    if (hits.Length > 1)
    //    {
    //        //change object position to camera position 
    //        targetObj.transform.position = transform.position + new Vector3(0f, -0.5f, 0f); //offset slightly downward to stop object dropping above player 
    //        //if your player is small, change the -0.5f to a smaller number (in magnitude) ie: -0.1f
    //    }
    //}
}
