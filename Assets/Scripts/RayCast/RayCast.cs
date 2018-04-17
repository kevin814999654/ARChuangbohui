using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RayCast : MonoBehaviour {
    public delegate void Onlooking();
    public static event Onlooking OnLooking;
    public delegate void OnClick();
    public static event OnClick OnClicking;
    [HideInInspector]
    public Transform RayCastHolder;
    private bool Onexit = true;
    public bool EnableRaycast = true;
    public static RayCast instance;

    public Scroll scroll;
    // Use this for initialization
    void Start() {
        if (instance == null) {
            instance = this;
        }
    }
    // Update is called once per frame
    void Update() {
        if (EnableRaycast) {
            looking();
         //   Debug.Log("doing");
        }
    }

    void looking() {
        //if (Input.GetMouseButtonDown(0))
        // {
        RaycastHit hit;

        //Ray ray = Camera.main.ScreenPointToRay(Gizmos.position);

        //  Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 fwd = Camera.main.transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(Camera.main.transform.position, fwd, out hit))
        {
            if (hit.collider != null)
            {
                if (hit.collider.tag == "InteractiveObj")
                {
                    if (RayCastHolder == null)
                    {
                         RayCastHolder = hit.collider.transform;
                        // SubScribeAndDeSub(true);
                    //     Debug.Log("Hit different object, from null to object");
                        //enter;
                        OnPointerEnter();
                    }
                    else {
                        if (RayCastHolder != hit.collider.transform)
                        {//enter

                      //      Debug.Log("Hit different object, unsubscribe the perivous one");
                            SubScribeAndDeSub(false);

                            RayCastHolder = hit.collider.transform;

                          // SubScribeAndDeSub(true);
                    //        Debug.Log("Hit different object, subscribe the current one");
                             OnPointerEnter();
                        }
                        else
                        {
                            OnPointUpdate();
                            RayCastHolder = hit.collider.transform;
                    //        Debug.Log("Hit same object");                          
                            //update
                        }
                    }
                }
            }

        }
        else
        {
            if (Onexit)
            {//OnExit
                OnPointExit();
            }
            else {

         //       Debug.Log("Hit Nothing Update");

            }
           
        }
        // if (OnClickEvent!=null)

        // }
    }

    void OnPointerEnter() {
        Onexit = true;
        try
        {
            ClientScript client = RayCastHolder.GetComponent<ClientScript>();
            scroll.UpdateScroll(client.sample.animationsObject);
        }
        catch (Exception e)
        {

            Debug.Log(e);
        }
        GizemoCtr.instance.isbreak = false;
       StartCoroutine( GizemoCtr.instance.Loadinfo(()=> SubScribeAndDeSub(true)));

        
        //  OnLooking();
    }

    void OnPointUpdate() {

    }

    void OnPointExit()
    {
        Onexit = false;
      //  Debug.Log("HIT NOTHING Current client DeSubscribe !");
        SubScribeAndDeSub(false);
        GizemoCtr.instance.isbreak = true;
        StartCoroutine(GizemoCtr.instance.Loadinfo(() => SubScribeAndDeSub(true)));
        if (OnLooking != null) {
          //  OnLooking();
        }        
        RayCastHolder = null;
    }

    void SubScribeAndDeSub( bool i) {
        if (RayCastHolder != null) {
            if (RayCastHolder.GetComponent<ClientScript>() != null)
            {
                ClientScript client = RayCastHolder.GetComponent<ClientScript>();
                if (!i)
                {
                    client.UnSubscribe();
                }
                else
                {
                    client.SubScribe();
                    EnableRaycast = false;
                }
            }
        }
    }
}

