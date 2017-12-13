using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {


    Vector3 jump = Vector3.up * 20;

    // Use this for initialization
    void Start () {
        

    }
	
	void FixedUpdate ()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 2.0f;
        
        transform.Translate(0, 0, x);

        if (Input.GetKey(KeyCode.Space))
        {
            if(transform.position.y < 0.7f)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(jump);
            }
        }

    }
}
