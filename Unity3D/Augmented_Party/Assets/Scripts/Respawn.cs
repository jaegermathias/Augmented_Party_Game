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
            GameObject gefallenGo = other.transform.parent.gameObject.transform.parent.gameObject;
            GameObject SpieleLogi = GameObject.FindGameObjectWithTag("Spielelogik");
            SpieleLogi.GetComponent<Spielelogik>().SpielerStatusAktualisieren(gefallenGo);

            int leben = other.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Spieler>().leben;
            String objektTag = other.transform.parent.gameObject.transform.parent.gameObject.tag;

            if (leben > 0 && objektTag == "Player")
            {
                GameObject car = other.transform.parent.gameObject.transform.parent.gameObject;
                car.transform.position = car.GetComponent<Spieler>().spawn;

                switch (car.GetComponent<Spieler>().StartPos)
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
                car.GetComponent<Spieler>().leben--;
            }
        }
        catch (NullReferenceException ex)
        {
            return;
        }
    }
}
