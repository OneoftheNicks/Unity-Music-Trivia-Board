using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ValueTransfer : MonoBehaviour
{
    private VideoClipLibrary videoes;
    private AudioClipLibrary musicTracks;

    //grab the text from the text fields and don't destroy on board 1/2 load
    //same with score between board 1/2
    public InputField T1;
    public InputField T2;
    
    //this is what we mainly need to keep inbetween scenes
    private string team1;
    private string team2;
    //private int score1;
    //private int score2;

    //make reference variables for the UI in Board1
    private Text T1Name;
    private Text T2Name;

    //gui notif
    public GameObject set1;
    public GameObject set2;

    private float timer1;
    private float timer2;

    private bool toChange = true;
    // Start is called before the first frame update
    void Start()
    {
        //default values
        team1 = "Right Team";
        team2 = "Left Team";
        //score1 = 0;
        //score2 = 0;

        set1.SetActive(false);
        set2.SetActive(false);
    }

    // Awake is called when the object is being loaded
    //Note that start and awake are only called once on don'tdestroy on load objects
    void Awake()
    {
        //this should keep names and scores active across all scene transitions
        DontDestroyOnLoad(this.gameObject);
        //Debug.Log("Current scene is: " + SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        //wait for enter, seems to be the easy way for this atm
        //could try more elegant ways later
        if(Input.GetKeyDown(KeyCode.Return) && SceneManager.GetActiveScene().name == "TitleStartup")
        {
            team1 = T1.text;
            team2 = T2.text;

            Debug.Log("Team 1 is " + team1 + "\nTeam 2 is " + team2);

            timer1 = 0.0f;
            timer2 = 0.0f;

            set1.SetActive(true);
            set2.SetActive(true);
        }

        timer1 += Time.smoothDeltaTime;
        timer2 += Time.smoothDeltaTime;

        //without this I'll get a null reference error and that for some reason cause the script to abort passing the values over
        if (SceneManager.GetActiveScene().name == "TitleStartup")
        {
            if (set1.activeSelf && timer1 > 3.0f)
            {
                set1.SetActive(false);
            }

            if (set2.activeSelf && timer1 > 3.0f)
            {
                set2.SetActive(false);
            }
        }
        //test public reference on destroy
        /* seems like on a new load the public references won't matter
        if(Input.GetKeyDown(KeyCode.Comma))
        {
            Debug.Log("comma press");
            Destroy(T1);
            Destroy(T2);
        }
        */

        if (toChange)
        {
            if (SceneManager.GetActiveScene().name == "Board")
            {
                T1 = null;
                T2 = null;

                Destroy(set1);
                Destroy(set2);
            
                //initialize/assign each private Text with it's board reference via the name
                T1Name = GameObject.Find("T1Name").GetComponent<Text>();
                T2Name = GameObject.Find("T2Name").GetComponent<Text>();
                //T1Score = GameObject.Find("Team1Score").GetComponent<Text>();
                //T2Score = GameObject.Find("Team2Score").GetComponent<Text>();

                if (GameObject.Find("T1Name").activeInHierarchy)
                {
                    Debug.Log("TextFields are active");
                }

                //assign values to board objects
                T1Name.text = team1;
                T2Name.text = team2;
                //T1Score.text = score1.ToString();
                //T2Score.text = score2.ToString();

                toChange = false;
            }
        }
    }

    //method for the start Button on Title
    public void StartGame()
    {
        SceneManager.LoadScene("Board", LoadSceneMode.Single);
    }

}
