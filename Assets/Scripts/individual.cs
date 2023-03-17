using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class individual : MonoBehaviour
{
    public GameObject controller;
    public bool fell;
    // Start is called before the first frame update
    void Start()
    {
        fell = false;
        controller = GameObject.Find("Controller");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.up.y < 0.3 && fell ==false)
        {
            Call();
        }
    }

    void Call()
    {
        controller.GetComponent<bolos>().DetectarCaidos();
        fell = true;

    }
}
