using UnityEngine;
using System.Collections;
using System;

public class Respawn : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        try
        {
            int leben = other.transform.parent.gameObject.transform.parent.gameObject.GetComponent<ZusaetzlicheCarInfo>().leben - 1;
            String objektTag = other.transform.parent.gameObject.transform.parent.gameObject.tag;

            if (leben > 0 && objektTag == "Player")
            {
                GameObject car = other.transform.parent.gameObject.transform.parent.gameObject;
                car.transform.position = car.GetComponent<ZusaetzlicheCarInfo>().spawn;

                switch (car.GetComponent<ZusaetzlicheCarInfo>().StartPos)
                {
                    case 1:
                        car.transform.rotation = new Quaternion(0.0f, -0.7f, 0.0f, -0.7f);
                        car.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                        car.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        Debug.Log("Blaues Autoo");
                        break;
                    case 2:
                        car.transform.rotation = new Quaternion(0.0f, 1.0f, 0.0f, 0.0f);
                        car.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                        car.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        break;

                    case 3:
                        car.transform.rotation = new Quaternion(0.0f, -0.7f, 0.0f, 0.7f);
                        car.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                        car.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        break;

                    case 4:
                        car.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, -1.0f);
                        car.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                        car.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        break;

                    default:
                        break;
                }
                car.GetComponent<Rigidbody>().velocity = Vector3.zero;
                car.GetComponent<ZusaetzlicheCarInfo>().leben--;
            }
        }
        catch (NullReferenceException ex)
        {
            return;
        }
    }
}
