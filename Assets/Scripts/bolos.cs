using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolos : MonoBehaviour
{
    private AudioSource audi;
    public AudioClip strike;
    public GameObject pines, spawn, conjunto;
    public int falllen;
    public bool goal;
    // Start is called before the first frame update
    void Start()
    {
        falllen = 0;
        audi = gameObject.GetComponent<AudioSource>();
        bowlin();
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
            Destroy(conjunto);
            goal = true;
            Invoke("Rewind", 3f);

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

    public void bowlin()
    {
        conjunto =  Instantiate(pines, spawn.transform.position, spawn.transform.rotation);

    }

    public void Rewind()
    {
        audi.Stop();
        conjunto = Instantiate(pines, spawn.transform.position, spawn.transform.rotation);

    }
}
