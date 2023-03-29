using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class bolos : MonoBehaviour
{
    private AudioSource audi;
    public AudioClip strike;
    public GameObject pines, spawn, conjunto, cleaner;
    public int falllen;
    public bool goal;
    public TextMeshProUGUI puntuacion, mensaje;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        falllen = 0;
        audi = gameObject.GetComponent<AudioSource>();
        bowlin();
        mensaje.text = "DERRIBALOS";
        anim = cleaner.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*foreach (Transform pin in pines)
        {
            if (pin.up.y < threshold)
                ++falllen;
        }*/

        puntuacion.text = falllen + "/10";

        if (falllen >= 9 && goal == false)
        {

            print("SODAAAA");
            audi.PlayOneShot(strike);
            goal = true;
            Invoke("Rewind", 4f);
            mensaje.text = "PLENO!!!";
            Destroy(conjunto, 3f);
            anim.SetTrigger("clean");

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
        falllen = 0;
        goal = false;
        conjunto = Instantiate(pines, spawn.transform.position, spawn.transform.rotation);
        mensaje.text = "DERRIBALOS";

    }
}
