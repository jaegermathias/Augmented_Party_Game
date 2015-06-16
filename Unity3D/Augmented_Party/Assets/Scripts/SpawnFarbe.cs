using UnityEngine;
using System.Collections;

public class SpawnFarbe : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //nix
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!(other.transform.parent.gameObject.transform.parent.gameObject.tag == "Player"))
        {
            return;
        }

        GameObject spieler = other.transform.parent.gameObject.transform.parent.gameObject;
        GameObject marker = transform.gameObject;

        switch (marker.name)
        {
            case "Spawn_Pos1":
                {
                    spieler.transform.GetChild(0).transform.GetChild(0).GetComponent<Renderer>().material.color = Color.blue;
                    Debug.Log("Case 1");
                    break;
                }
            case "Spawn_Pos2":
                {
                    spieler.transform.GetChild(0).transform.GetChild(0).GetComponent<Renderer>().material.color = Color.red;
                    Debug.Log("Case 2");
                    break;
                }
            case "Spawn_Pos3":
                {
                    spieler.transform.GetChild(0).transform.GetChild(0).GetComponent<Renderer>().material.color = Color.yellow;
                    Debug.Log("Case 3");
                    break;
                }
            case "Spawn_Pos4":
                {
                    spieler.transform.GetChild(0).transform.GetChild(0).GetComponent<Renderer>().material.color = Color.green;
                    Debug.Log("Case 4");
                    break;
                }
            default:
                break;
        }
    }
}
