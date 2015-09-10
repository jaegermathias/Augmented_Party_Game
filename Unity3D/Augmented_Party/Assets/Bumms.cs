using UnityEngine;
using System.Collections;

public class Bumms : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    
    }
    void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.name == "PlayerDINGENS")
            {
            
           // other.gameObject.Rigidbody.AddForce(0,0,1);
            }
    }
}
