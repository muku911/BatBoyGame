using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGFollow : MonoBehaviour {

    public Transform player;

    public Transform Bg1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        

        if (player.position.x != transform.position.x && player.position.x > -2.5f && player.position.x < 5f)
        {
            transform.position = Vector3.Lerp(transform.position,
                new Vector3(player.position.x, player.position.y, transform.position.z), 0.1f);
        }
        Bg1.transform.position = new Vector3(transform.position.x , Bg1.transform.position.y, Bg1.transform.position.z);
    }
}
