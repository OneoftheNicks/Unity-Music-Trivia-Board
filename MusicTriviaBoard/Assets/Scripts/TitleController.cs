using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour
{
    //grab empty containers of the other title elements
    public GameObject UIContainer;
    public GameObject PartiContainer;

    //start bool variable
    private bool DoStart = false;
    public void setStartBool(bool newBool)
    {
        DoStart = newBool;
    }

    // Start is called before the first frame update
    void Start()
    {
        //start disabled until the title animations are done
        UIContainer.SetActive(false);
        PartiContainer.SetActive(false);
    }

    void Update()
    {
        //wait for doStart to be updated by T2Animcontroller
        if(DoStart)
        {
            //set rest of the title as active
            UIContainer.SetActive(true);
            PartiContainer.SetActive(true);
        }
    }
}
