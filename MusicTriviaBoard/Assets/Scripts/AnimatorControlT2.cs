using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControlT2 : MonoBehaviour
{
    //wait for title 1 to finish and hold
    public Animator T1con;
    private Animator T2con;
    private bool T2Done;
    public Animator T3Con;

    //get script for title controller
    public TitleController TC;

    // Start is called before the first frame update
    void Start()
    {
        T2con = GetComponent<Animator>();
        T2Done = false;
        //T2con.StopPlayback()

        //hold before start
        T2con.speed = 0;
        T3Con.speed = 0;
        //note that speed applies to all animations in the controller
    }

    // Update is called once per frame
    void Update()
    {
        //if T1's current state as Hold
        if(T1con.GetCurrentAnimatorStateInfo(0).IsName("Hold") && T2con.speed != 1)
        {
            /*isName returns a Bool value
            the array index on get anim state is referring to the layer in the editor
            in this case base layer 0
            */

            //echo debug
            Debug.Log("T1 state is hold");

            //then set the first state of T2 to being playing, ie speed to 1
            T2con.speed = 1;
            //get anim state speed is only a get, has no set method

            T2Done = true;
            //Send message to other empties to enable rest of title screen
            //SendMessage("StartAfterTitle"); --Send message only works within the 
            //children of the gameobject
        }

        if(T2Done)
        {
            /*doing it this way actually caused both to animate
            I'm leaving it this way but if i needed it to be after 
            there would have to be a condition for t2 to be at Hold
            */
            T3Con.speed = 1;
        }

        //Wait for title2 to finish
        if(T3Con.GetCurrentAnimatorStateInfo(0).IsName("Hold"))
        {
            //then set the start bool in event manager
            TC.setStartBool(true);
        }
    }
}
