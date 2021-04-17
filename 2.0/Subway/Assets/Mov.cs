using UnityEngine;

public class Mov : MonoBehaviour
{

    private CharacterController _characterController;
    private Vector3 moveVec, gravity;

    public float speed, jumpSpeed;

    private int laneNumber = 1,
        lanesCount = 2;

    public float firstsLanePos,
        laneDistance,
        sideSpeed;
        
    bool but = true;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        moveVec = new Vector3(1, 0, 0);
        gravity = Vector3.zero;
    }


    void Update()
    {
        if(_characterController.isGrounded)
        {
            gravity = Vector3.zero;
            if(Input.GetAxisRaw("Vertical") > 0)
            {
                gravity.y = jumpSpeed;
            }
        }
        else
        {
            gravity += Physics.gravity *Time.deltaTime *  3;
        }
        moveVec.x = speed;
        moveVec += gravity;
        moveVec *= Time.deltaTime;
       // moveVec += gravity;
        float input = Input.GetAxis("Horizontal");


        if (Mathf.Abs(input) > .1f)
        {
            if (but)
            {


                but = false;

                laneNumber += (int)Mathf.Sign(input);
                laneNumber = Mathf.Clamp(laneNumber, 0, lanesCount);
            }

            

        }
        else
        {
            but = true;
        }
        _characterController.Move(moveVec);
        Vector3 newPos = transform.position;

        newPos.z = Mathf.Lerp(newPos.z, firstsLanePos + (laneNumber * laneDistance), Time.deltaTime * sideSpeed);


        transform.position = newPos;
       


       
        

    }
}


