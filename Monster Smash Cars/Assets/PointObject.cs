using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointObject : MonoBehaviour {
    public int value;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<RCC_CameraConfig>())
        {
            GetComponent<MeshRenderer>().enabled = false;
            //SpawnSystem.instance.Respawn(this.transform);
            other.GetComponent<RCC_CameraConfig>().points += value;
            transform.parent.GetComponent<PointScript>().busy = false;
            Destroy(gameObject,0.5f);
        }
    }
}
