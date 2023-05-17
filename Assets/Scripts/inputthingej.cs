using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using TMPro;

public class inputthingej : MonoBehaviour
{
    public TextMeshProUGUI info, consolatxt, txtMonitorCentral, txtMonitorIzquierda, txtMonitorDerecha;
    private List<UnityEngine.XR.InputDevice> gamecontrollers;
    private List<UnityEngine.XR.InputDevice> dispositivosDetectados;
    bool triggerValue, primaryButton, primaryTouch, secondaryButton, secondaryTouch, gripButton, primary2DAxistouch, primary2DAxisclick;

    bool triggerValue1, primaryButton1, primaryTouch1, secondaryButton1, secondaryTouch1, gripButton1, primary2DAxistouch1, primary2DAxisclick1;
    bool isTracked, isTracked1, isTrackedG;
    float gripsensi, triggersensi, gripsensi1, triggersensi1;
    private Vector2 primary2DAxis, primary2DAxis1;
    Vector3 posicion, posicion1, posicionG;
    Quaternion rotacion,rotacion1, rotacionG;
    Vector3 velocity,velocity1, angularVelocity, angularVelocity1, aceleracion, aceleracion1, angularAceleracion, angularAceleracion1, velocityG, angularVelocityG, aceleracionG, angularAceleracionG;

    bool userPresence;
    Vector3 leftOjoPosition, rightOjoPosition, leftOjoVelocity, rightOjoVelocity, centerEyePos, centerEyeVel;
    Quaternion rightOjoRotation, leftOjoRotation, centerEyeRot;
    public bool monitorEncendido, tabletEncendida;

    public Toggle velocidadgafastoggle, botonAtoggle, joystickToggle;
    public TextMeshProUGUI velocidadgafas, botonA, joystick, textoTablet;
    // Start is called before the first frame update
    void Start()
    {
        dispositivosDetectados = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevices(dispositivosDetectados);
        monitorEncendido = false;
        tabletEncendida = false;
    }

    // Update is called once per frame
    
    void Update()
    {
        //mando
        dispositivosDetectados[2].TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue); // gatillo
        dispositivosDetectados[2].TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out primary2DAxis);// joystick
        dispositivosDetectados[2].TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out primaryButton);// A o X
        dispositivosDetectados[2].TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryTouch, out primaryTouch);
        dispositivosDetectados[2].TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryTouch, out secondaryTouch);// Y o B
        dispositivosDetectados[2].TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out secondaryButton);
        dispositivosDetectados[2].TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out gripButton);
        dispositivosDetectados[2].TryGetFeatureValue(UnityEngine.XR.CommonUsages.grip, out gripsensi);
        dispositivosDetectados[2].TryGetFeatureValue(UnityEngine.XR.CommonUsages.trigger, out triggersensi);
        dispositivosDetectados[2].TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out primary2DAxisclick);
        dispositivosDetectados[2].TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisTouch, out primary2DAxistouch);

        dispositivosDetectados[1].TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue1); // gatillo
        dispositivosDetectados[1].TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out primary2DAxis1);// joystick
        dispositivosDetectados[1].TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out primaryButton1);// A o X
        dispositivosDetectados[1].TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryTouch, out primaryTouch1);
        dispositivosDetectados[1].TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryTouch, out secondaryTouch1);// Y o B
        dispositivosDetectados[1].TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out secondaryButton1);
        dispositivosDetectados[1].TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out gripButton1);
        dispositivosDetectados[1].TryGetFeatureValue(UnityEngine.XR.CommonUsages.grip, out gripsensi1);
        dispositivosDetectados[1].TryGetFeatureValue(UnityEngine.XR.CommonUsages.trigger, out triggersensi1);
        dispositivosDetectados[1].TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out primary2DAxisclick1);
        dispositivosDetectados[1].TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisTouch, out primary2DAxistouch1);

        //comunes
        dispositivosDetectados[2].TryGetFeatureValue(UnityEngine.XR.CommonUsages.isTracked, out isTracked);
        dispositivosDetectados[2].TryGetFeatureValue(UnityEngine.XR.CommonUsages.devicePosition, out posicion);
        dispositivosDetectados[2].TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceRotation, out rotacion);
        dispositivosDetectados[2].TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceVelocity, out velocity);
        dispositivosDetectados[2].TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceAngularVelocity, out angularVelocity);
        dispositivosDetectados[2].TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceAcceleration, out aceleracion);
        dispositivosDetectados[2].TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceAngularAcceleration, out angularAceleracion);

        dispositivosDetectados[1].TryGetFeatureValue(UnityEngine.XR.CommonUsages.isTracked, out isTracked1);
        dispositivosDetectados[1].TryGetFeatureValue(UnityEngine.XR.CommonUsages.devicePosition, out posicion1);
        dispositivosDetectados[1].TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceRotation, out rotacion1);
        dispositivosDetectados[1].TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceVelocity, out velocity1);
        dispositivosDetectados[1].TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceAngularVelocity, out angularVelocity1);
        dispositivosDetectados[1].TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceAcceleration, out aceleracion1);
        dispositivosDetectados[1].TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceAngularAcceleration, out angularAceleracion1);


        //Gafas
        dispositivosDetectados[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.userPresence, out userPresence); // llevas las gafas puestas
        dispositivosDetectados[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.leftEyePosition, out leftOjoPosition);
        dispositivosDetectados[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.rightEyePosition, out rightOjoPosition);
        dispositivosDetectados[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.leftEyeRotation, out leftOjoRotation);
        dispositivosDetectados[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.rightEyeRotation, out rightOjoRotation);
        dispositivosDetectados[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.leftEyeVelocity, out leftOjoVelocity);
        dispositivosDetectados[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.rightEyeVelocity, out rightOjoVelocity);
        dispositivosDetectados[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.centerEyePosition, out centerEyePos);
        dispositivosDetectados[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.centerEyeRotation, out centerEyeRot);
        dispositivosDetectados[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.centerEyeVelocity, out centerEyeVel);

        dispositivosDetectados[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.isTracked, out isTrackedG);
        dispositivosDetectados[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.devicePosition, out posicionG);
        dispositivosDetectados[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceRotation, out rotacionG);
        dispositivosDetectados[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceVelocity, out velocityG);
        dispositivosDetectados[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceAngularVelocity, out angularVelocityG);
        dispositivosDetectados[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceAcceleration, out aceleracionG);
        dispositivosDetectados[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceAngularAcceleration, out angularAceleracionG);



        if (monitorEncendido)
        {
            txtMonitorIzquierda.text = "Input Mando Izquierdo" +
                       "\n moviendo el joystick" + primary2DAxis1 +
                       "\n Tienes pulsado trigger " + triggerValue1 + triggersensi1 +
                       "\n tienes pulsado A " + primaryButton1 +
                       "\n tienes pulsado B " + secondaryButton1 +
                       "\n tienes el dedo sobre la A " + primaryTouch1 +
                       "\n tienes el dedo sobre la B " + secondaryTouch1 +
                       "\n tienes pulsado grip " + gripButton1 + gripsensi1 +
                       "\n tienes el dedo en el joyystick " + primary2DAxistouch1 +
                       "\n tienes pulsado el joystick " + primary2DAxisclick1 +
                       "\n Dispositivo trackeado " + isTracked1 +
                       "\n Posiocion " + posicion1 + " Rotacion " + rotacion1 +
                       "\n Velocidad " + velocity1 + "Velocidad Angular " + angularVelocity1 +
                       "\n Aceleracion " + aceleracion1 + "Aceleracion Angular " + angularAceleracion1;

            txtMonitorDerecha.text = "Input Mando Derecho" +
                       "\n moviendo el joystick" + primary2DAxis +
                       "\n Tienes pulsado trigger " + triggerValue + triggersensi +
                       "\n tienes pulsado A " + primaryButton +
                       "\n tienes pulsado B " + secondaryButton +
                       "\n tienes el dedo sobre la A " + primaryTouch +
                       "\n tienes el dedo sobre la B " + secondaryTouch +
                       "\n tienes pulsado grip " + gripButton + gripsensi +
                       "\n tienes el dedo en el joyystick " + primary2DAxistouch +
                       "\n tienes pulsado el joystick " + primary2DAxisclick +
                       "\n Dispositivo trackeado " + isTracked +
                       "\n Posiocion " + posicion + " Rotacion " + rotacion +
                       "\n Velocidad " + velocity + "Velocidad Angular " + angularVelocity +
                       "\n Aceleracion " + aceleracion + "Aceleracion Angular " + angularAceleracion;

            txtMonitorCentral.text = "Inputs Gafas" +
                                       "\nTienes las gafas puestas " + userPresence +
                                       "\n Posicion del ojo Izquierdo " + leftOjoPosition + "Rotacion" + leftOjoRotation +
                                       "\n Velocidad ojo Izquierdo " + leftOjoVelocity +
                                       "\n Posicion del ojo Derecho " + rightOjoPosition + "Rotacion" + rightOjoRotation +
                                       "\n Velocidad ojo Derrecho " + rightOjoVelocity +
                                       "\n Posicion del ojo Central " + centerEyePos + "Rotacion" + centerEyeRot +
                                       "\n Velocidad ojo Central " + centerEyeVel +
                                       "\n Dispositivo trackeado " + isTrackedG +
                                       "\n Posiocion " + posicionG + " Rotacion " + rotacionG +
                                       "\n Velocidad " + velocityG + "Velocidad Angular " + angularVelocityG +
                                       "\n Aceleracion " + aceleracionG + "Aceleracion Angular " + angularAceleracionG;
            
        }
        else
        {
            txtMonitorDerecha.text = "";
            txtMonitorIzquierda.text = "";
        }



        if (velocidadgafastoggle.isOn)
        {
            velocidadgafas.text = "Velocidad: " + velocityG;
        }
        else
        {
            velocidadgafas.text = "";
        }

        if (botonAtoggle.isOn)
        {
            botonA.text = "Tienes el dedo sobre el boton; " + primaryTouch + "\n Tienes pulsado el boton: " + primaryButton;
        }
        else
        {
            botonA.text = "";
        }

        if (joystickToggle.isOn)
        {
            joystick.text = "Tienes el dedo sobre el joystick: " + primary2DAxistouch + "\n Tienes pulsado el joystick: " + primary2DAxisclick + "\n Movimiento Joystick: " + primary2DAxis;
        }
        else
        {
            joystick.text = "";
        }

        if (tabletEncendida)
        {
            textoTablet.text = "Posicion del mando:" + posicion + "\n Rotacion " + rotacion + "\n Velocidad del mando " + velocity;
        }

        else
        {
            textoTablet.text = "";
        }


    }



    public void MuestraDispositivos()
    {
        var texto = "";
        foreach (var device in dispositivosDetectados)
        {
            texto += (string.Format("\n Device found with name '{0}' and role '{1}'", device.name, device.role.ToString()));
        }
        Informacion(texto);
    }

    public void MuestraCaracterisiticasMando()
    {
        var inputFeatures = new List<UnityEngine.XR.InputFeatureUsage>();
        var device = dispositivosDetectados[2]; //mando derecho

        if (device.TryGetFeatureUsages(inputFeatures))
        {
            var texto = "";
            foreach (var feature in inputFeatures)
            {
                texto += (string.Format("\n Feature{0}", feature.name));
            }
            Informacion(texto);
        }
    }
    public void Informacion(string texto)
    {
        info.text = texto;
    }
    public void Consola(string texto)
    {
        info.text = texto;
    }

    public void EncenderMonitor()
    {
        monitorEncendido = !monitorEncendido;
    }

    public void EncenderTablet()
    {
        tabletEncendida = !tabletEncendida;
    }



}
