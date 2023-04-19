using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOOKATME : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("MainCamera");
        gameObject.transform.LookAt(player.transform);
        gameObject.transform.position = new Vector3(target.transform.position.x, target.transform.position.y + 0.3f, target.transform.position.z);
    }
}
