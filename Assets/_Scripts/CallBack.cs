using UnityEngine;

public class CallBack : MonoBehaviour
{
    public GameObject baseball;
    //private Rigidbody baseballRb;
    public GameObject playerObj;
    //private Rigidbody playerObjRb;
    public Vector3 offSet = new Vector3(1, 0.7f, 1);

    private bool canFlash = true;
    //private int LayerNumber;

    void Start()
    {
        //LayerNumber = LayerMask.NameToLayer("flashLayer");
    }
    void Update()
    {
        if (playerObj != null)
        {
            if (Input.GetKeyDown(KeyCode.H) && canFlash == true)
            {
                //StopClipping();
                Flash();
                Land();
            }
        }
    }
    void Flash()
    {
        Physics.IgnoreCollision(playerObj.GetComponent<Collider>(), baseball.GetComponent<Collider>(), true);
        //baseballRb = baseball.GetComponent<Rigidbody>();
        //baseballRb.isKinematic = true;
        //baseballRb.linearVelocity = playerObjRb.linearVelocity;
        baseball.transform.position = playerObj.transform.position + offSet;
        //baseball.layer = LayerNumber;
    }
    void Land()
    {
        Physics.IgnoreCollision(playerObj.GetComponent<Collider>(), baseball.GetComponent<Collider>(), false);
        //baseball.layer = 0;
        //baseballRb.isKinematic = false;
    }
}