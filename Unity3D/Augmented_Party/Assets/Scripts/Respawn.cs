using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	private void OnTriggerEnter (Collider other)
	{
		if(other.transform.parent.gameObject.transform.parent.gameObject.tag == null){
			return;
		}
		if (other.transform.parent.gameObject.transform.parent.gameObject.GetComponent<ZusaetzlicheCarInfo> ().leben > 0 
		    && other.transform.parent.gameObject.transform.parent.gameObject.tag == "Player") {
			GameObject car = other.transform.parent.gameObject.transform.parent.gameObject;
			car.transform.position = car.GetComponent<ZusaetzlicheCarInfo>().spawn;
			//Richtige Rotationsrichtung
			if(car.GetComponent<ZusaetzlicheCarInfo>().farbe == Color.blue){
				car.transform.rotation = new Quaternion(0.0f , 0.0f , 0.0f , -1.0f);
			}
			if(car.GetComponent<ZusaetzlicheCarInfo>().farbe == Color.red){
				car.transform.rotation = new Quaternion(0.0f , -0.7f , 0.0f , -0.7f);
			}
			if(car.GetComponent<ZusaetzlicheCarInfo>().farbe == Color.yellow){
				car.transform.rotation = new Quaternion(0.0f , 1.0f , 0.0f , 0.0f);
			}
			if(car.GetComponent<ZusaetzlicheCarInfo>().farbe == Color.green){
				car.transform.rotation = new Quaternion(0.0f , -0.7f , 0.0f , 0.7f);
			}
			car.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			//car.GetComponent<ZusaetzlicheCarInfo> ().leben --;
		}
	}

	private void bla (Collider other)
	{
		if (!(other.transform.parent.gameObject.transform.parent.gameObject.tag == "Player")) {
			return;
		} 
		Destroy (other.gameObject);
	}
}
