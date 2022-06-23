using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevConsoleListener : MonoBehaviour
{
    public GameObject DevMenu;
    private bool openMenu;

    //because I'm in the same scene this will be easier then the first time, we can use pubs
    public InputField fixT1;
    public InputField fixT2;
    public Text T1Score;
    public Text T2Score;

    //grab the vars for the score keeping
    public AssignPoints assignPoints;


    // Start is called before the first frame update
    void Start()
    {
        openMenu = false;
        DevMenu.SetActive(openMenu);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            openMenu = !openMenu;
            DevMenu.SetActive(openMenu);
        }

        if (Input.GetKeyDown(KeyCode.Return) && openMenu)
        {
            //checking for no input
            if (fixT1.text != string.Empty)
            {
                T1Score.text = fixT1.text;
                assignPoints.setScore1(int.Parse(fixT1.text));
            }

            if (fixT2.text != string.Empty)
            {
                T2Score.text = fixT2.text;
                assignPoints.setScore2(int.Parse(fixT2.text));
            }
            //Debug.Log("Team 1 is " + team1 + "\nTeam 2 is " + team2);
        }


    }
}
