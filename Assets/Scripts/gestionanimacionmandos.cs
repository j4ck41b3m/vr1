using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class gestionanimacionmandos : MonoBehaviour
{
    public Animator animador;
    private List<UnityEngine.XR.InputDevice> gameControllers;
    // Start is called before the first frame update
    void Start()
    {
        animador = GetComponent<Animator>();
       gameControllers = new List<UnityEngine.XR.InputDevice> ();
        UnityEngine.XR.InputDevices.GetDevicesWithRole(UnityEngine.XR.InputDeviceRole.LeftHanded, gameControllers);
    }

    // Update is called once per frame
    void Update()
    {
        bool cierramano;
        if (gameControllers[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out cierramano) && cierramano)
        {
            animador.SetBool("coger", true);
        }
        else
        {
            animador.SetBool("coger", false);
        }
    }
}
