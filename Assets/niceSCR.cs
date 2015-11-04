using UnityEngine;
using System.Collections;

public class niceSCR : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine("Move");
        }
	}

    IEnumerator Move()
    {
        for (int i = 0; i < 10; i++)
        {
            gameObject.transform.position=new Vector2(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y);
            yield return new WaitForFixedUpdate();
        }
    }

}
