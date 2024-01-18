using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MeteorPistol : MonoBehaviour
{
    public ParticleSystem Particles;

    public LayerMask layerMask;
    public Transform ShootSource;
    public float distance = 10;

    private bool rayactivate = false;

    // Start is called before the first frame update
    void Start()
    {
       XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x =>StartShoot());
        grabInteractable.deactivated.AddListener(x =>StopShoot());

    }

    public void StartShoot()
    {
        AudioManager.instance.Play("Pistol");
        Particles.Play();
        rayactivate = true;
    }

    public void StopShoot()
    {
        AudioManager.instance.Stop("Pistol");

        Particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        rayactivate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rayactivate)
              RaycastCheck();
    }

    void RaycastCheck()
    {
        RaycastHit hit;
        bool hashit = Physics.Raycast(ShootSource.position, ShootSource.forward, 
            out hit,distance,layerMask);

        if (hashit)
        {
            hit.transform.gameObject.SendMessage("Break", SendMessageOptions.DontRequireReceiver);
        }
    }
}
