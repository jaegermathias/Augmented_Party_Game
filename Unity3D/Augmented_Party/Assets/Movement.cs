using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public int geschwindigkeit;
    public bool animation;
    // Use this for initialization
    void Start()
    {
        geschwindigkeit = 5;
        animation = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (animation)
        {
            //Rotation Kreuz
            transform.Rotate(0, 0, Time.deltaTime + geschwindigkeit);
            transform.Rotate(0, Time.deltaTime, 0, Space.World);

            //Hover effect kreuz
            float ausschlag = 0.50f;
            float geschwindigkeit = 0.50f;
            transform.position += ausschlag * (Mathf.Sin(2 * Mathf.PI * geschwindigkeit * Time.time) - Mathf.Sin(2 * Mathf.PI * geschwindigkeit * (Time.time - Time.deltaTime))) * transform.forward;
        }
    }
}
