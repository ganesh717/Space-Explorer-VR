using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class DisableGrabbingHandModel : MonoBehaviour
{
    public GameObject lefthandmodel;
    public GameObject righthamdmodel;
    
    
    // Start is called before the first frame update
    void Start()
    {

        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(HideGrabbingHand);
        grabInteractable.selectExited.AddListener(ShowingGrabbingHand);

    }
    
      public void HideGrabbingHand(SelectEnterEventArgs args)
    {
        if(args.interactorObject.transform.tag == "Left Hand")
        {
           lefthandmodel.SetActive(false);            
        }
          else if (args.interactorObject.transform.tag == "Right Hand")
        {
            righthamdmodel.SetActive(false);
        }
    }
    
       public void ShowingGrabbingHand(SelectExitEventArgs args)
    {
        if (args.interactorObject.transform.tag == "Left Hand")
        {
            lefthandmodel.SetActive(true);
        }
        else if (args.interactorObject.transform.tag == "Right Hand")
        {
            righthamdmodel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
