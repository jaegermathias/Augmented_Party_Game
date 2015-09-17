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

            

            int leben = other.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Spieler>().spielerLeben;
            String objektTag = other.transform.parent.gameObject.transform.parent.gameObject.tag;

            GameObject car = other.transform.parent.gameObject.transform.parent.gameObject;
            Debug.Log("Runtergéfallen ist: "+car.GetComponent<Spieler>().spielerStartpos);
            if (leben > 0 && objektTag == "Player")
            {
                car.transform.position = car.GetComponent<Spieler>().spawn;

				switch (car.GetComponent<Spieler>().spielerStartpos)
                {
                    case 1:
                        car.transform.rotation = new Quaternion(0.0f, -0.7f, 0.0f, -0.7f);
                        car.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                        car.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        //Debug.Log("Blaues Autoo Leben: "+leben );
					car.GetComponent<Spieler>().spielerLebenAktualisieren();
                        break;
                    case 2:
                        car.transform.rotation = new Quaternion(0.0f, 1.0f, 0.0f, 0.0f);
                        car.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                        car.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        //Debug.Log("Rot Autoo Leben: " + leben);
					car.GetComponent<Spieler>().spielerLebenAktualisieren();
                        break;

                    case 3:
                        car.transform.rotation = new Quaternion(0.0f, -0.7f, 0.0f, 0.7f);
                        car.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                        car.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        //Debug.Log("Gelb Autoo Leben: " + leben);
					car.GetComponent<Spieler>().spielerLebenAktualisieren();
                        break;

                    case 4:
                        car.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, -1.0f);
                        car.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                        car.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        Debug.Log("grün Autoo Leben: " + leben);
					car.GetComponent<Spieler>().spielerLebenAktualisieren();
                        break;

                    default:
                        break;
                }

				GameObject Spielelogik = GameObject.FindGameObjectWithTag("Spielelogik");
				Spielelogik.GetComponent<Spielelogik>().SpielerStatusAktualisieren();
                //car.GetComponent<Rigidbody>().velocity = Vector3.zero;
                //car.GetComponent<Spieler>().leben--;
            }
            else
            {
                Debug.Log("Keines davon");
				car.GetComponent<Spieler>().spielerLeben--;
            }
        }
        catch (NullReferenceException ex)
        {
            return;
        }
    }
}
