using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolos : MonoBehaviour
{
    public Transform[] pines;
    float threshold = 0.3f;
    private AudioSource audi;
    public AudioClip strike;
    public int falllen;
    public bool goal;
    // Start is called before the first frame update
    void Start()
    {
        falllen = 0;
        audi = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        /*foreach (Transform pin in pines)
        {
            if (pin.up.y < threshold)
                ++falllen;
        }*/

        

        if (falllen >= 9 && goal == false)
        {

            print("SODAAAA");
            audi.PlayOneShot(strike);

            goal = true;

        }

    }

    public void DetectarCaidos()
    {
      falllen++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ball"))
        DetectarCaidos();
    }
}
