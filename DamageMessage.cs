using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMessage : MonoBehaviour {

    private int life;
    private int lifeSpan;
	// Use this for initialization
	void Start()
    {
        life = 0;
        lifeSpan = 20;
	}
	
	// Update is called once per frame
	void Update()
    {
        float size = 1f / lifeSpan;
        life++;
        this.transform.localScale += new Vector3(size, size, size);
        if(life > lifeSpan)
        {
            Destroy(this.gameObject);
        }
	}
}
