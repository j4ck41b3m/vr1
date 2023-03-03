using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoladeBolos : MonoBehaviour
{
    public Transform spawnpoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5)
            transform.position = spawnpoint.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("end"))
            transform.position = spawnpoint.position;
    }
}
