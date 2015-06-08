using UnityEngine;
using System.Collections;

public class Map_Scale : MonoBehaviour 
{
    public GameObject Target;
    
	// Use this for initialization
	void Start () 
    {
       // transform.localScale = new Vector3(health / 100, transform.localScale.y, transform.localScale.z);
	}
	
	// Update is called once per frame
	void Update () 
    {
        Debug.Log(Target.transform.position.x);

        var tx = Target.transform.position.x;
        var ty = Target.transform.position.y;
        var tz = Target.transform.position.z;
        transform.localScale = new Vector3(Mathf.Abs(tz)/10, Mathf.Abs(tz)/10, Mathf.Abs(tz)/10);
	}
}
