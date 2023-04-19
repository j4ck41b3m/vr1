using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class individual : MonoBehaviour
{
    public GameObject controller;
    public bool hit, fell;
    public AudioSource audi;
    public AudioClip bonk;
    // Start is called before the first frame update
    void Start()
    {
        hit = false;
        fell = false;
        controller = GameObject.Find("Controller");
        audi = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.up.y < 0.9 && hit == false)
        {
            audi.PlayOneShot(bonk);
            hit = true;
        }

        if (transform.up.y < 0.3 && fell ==false)
        {
            Call();
            Destroy(gameObject, 0.3f);
        }

       

    }

    void Call()
    {

        controller.GetComponent<bolos>().DetectarCaidos();
        fell = true;
    }
}
