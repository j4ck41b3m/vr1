using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using TMPro;

public class inputthingej : MonoBehaviour
{
    public TextMeshProUGUI textoJuego;
    private List<UnityEngine.XR.InputDevice> dispositivosDetectados;
    private Vector2 primary2DAxis, primaryTouch;


    // Start is called before the first frame update
    void Start()
    {
        dispositivosDetectados = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevices(dispositivosDetectados);

    }

    // Update is called once per frame
    public void MuestraDispositivo()
    {
        textoJuego.text = "";
        foreach (var device in dispositivosDetectados)
        {
            textoJuego.text += (string.Format("Device found with name '{1}' , '{2}' =", device.name, device.characteristics.ToString()));
        }
    }
    public void DetectarDispositivo()
    {
        //textoJuego.text = "";
        
    }


    public void muestraThumbEst()
    {
        Debug.Log("primaryTouch =" + this.primaryTouch);
    }

    public void muestraPrimary2DAxis()
    {
        Debug.Log("primary2DAxis =" + this.primary2DAxis);
    }

    void Update()
    {
        //dispositivosDetectados[2]
    }


}
