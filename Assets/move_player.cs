using UnityEngine;
using System.Collections;

public class move_player : MonoBehaviour {
    public GameObject rLeg1;
    public GameObject lLeg1;
    public GameObject rLeg2;
    public GameObject lLeg2;
    bool right, left,click;
    float xStart, yStart;
    Rigidbody2D headRB;
	// Use this for initialization
	void Start () 
    {
        right = false;
        left = false;
        xStart = gameObject.transform.position.x;
        yStart = gameObject.transform.position.y;
        headRB = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update() 
    {
        click = false;
        if (Input.GetMouseButtonDown(0))
        {
            //if (!click && !right)
            //{
            //    StopAllCoroutines();
            //    StartCoroutine(UseMotor(rLeg1, lLeg1));
            //    headRB.constraints = RigidbodyConstraints2D.FreezeRotation;
            //    right = true;
            //    click = true;
            //    left = false;
            //}
            //if (!click && !left)
            //{
            //    StopAllCoroutines();
            //    headRB.constraints = RigidbodyConstraints2D.FreezeRotation;
            //    StartCoroutine(UseMotor(lLeg1, rLeg1));
            //    left = true;
            //    click = true;
            //    right = false;
            //}
            StartCoroutine("scriptStep");

        }
	}
    IEnumerator UseMotor(GameObject legin, GameObject legout)
    {
        HingeJoint2D rleng1HJ = legin.gameObject.GetComponent<HingeJoint2D>();
        HingeJoint2D lleng1HJ = legout.gameObject.GetComponent<HingeJoint2D>();
        
        Rigidbody2D rleng2RB = rLeg2.gameObject.GetComponent<Rigidbody2D>();
        Rigidbody2D lleng2RB = lLeg2.gameObject.GetComponent<Rigidbody2D>();
        //rleng1HJ.motor.motorSpeed = -90f;
        JointMotor2D leginMOtor = rleng1HJ.motor;
        leginMOtor.motorSpeed = -120f;
        rleng1HJ.motor = leginMOtor;
        JointMotor2D legoutnMOtor = lleng1HJ.motor;
        legoutnMOtor.motorSpeed = 20f;
        lleng1HJ.motor = legoutnMOtor;
        rleng1HJ.useMotor = true;
        lleng1HJ.useMotor = true;
        for (int i = 0; i < 5; i++)
        {
            //gameObject.transform.position = new Vector2(gameObject.transform.position.x+0.02f, gameObject.transform.position.y);
            headRB.AddForce(new Vector2(i, 0));
            yield return new WaitForSeconds(0.06f);
        }
                        
        rleng1HJ.useMotor = false;
        lleng1HJ.useMotor = false;
        headRB.constraints = RigidbodyConstraints2D.None;
        yield return new WaitForSeconds(1);
        rleng2RB.constraints = RigidbodyConstraints2D.None;
        lleng2RB.constraints = RigidbodyConstraints2D.None;        
    }

    IEnumerator scriptStep()
    {
        HingeJoint2D rlengHJ = rLeg1.gameObject.GetComponent<HingeJoint2D>();
        Rigidbody2D rleng2RB = rLeg2.gameObject.GetComponent<Rigidbody2D>();
        HingeJoint2D llengHJ = lLeg1.gameObject.GetComponent<HingeJoint2D>();
        Rigidbody2D lleng2RB = lLeg2.gameObject.GetComponent<Rigidbody2D>();
        JointMotor2D rMOtor = rlengHJ.motor;
        rMOtor.motorSpeed = -120f;
        rlengHJ.motor = rMOtor;
        JointMotor2D lMOtor = llengHJ.motor;
        lMOtor.motorSpeed = 60f;
        llengHJ.motor = lMOtor;
        rlengHJ.useMotor = true;
        llengHJ.useMotor = true;
        yield return new WaitForSeconds(0.4f);
        rlengHJ.useMotor = false;
        llengHJ.useMotor = false;
        headRB.constraints = RigidbodyConstraints2D.None;
    }
    
}
