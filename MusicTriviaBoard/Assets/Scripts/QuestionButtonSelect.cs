using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video; //<-- need this in C# scripts

public class QuestionButtonSelect : MonoBehaviour
{
    /*
    //Grab Button from GameObject
    private Button qBox;
    //private Scene VideoSceneAdd; //this will be the additive scene for the video player
    //Decided to just set a screen with a video agrument for each button in the same board scene
    //We need to pass the correct video and song to the Transfer DontDestroyOnLoad script
    public VideoClip qClip;
    //this is specific to each question
    //then we can get the script from the transfer object and send the new reference to the clip to it
    private ValueTransfer VT;
    //Valuetransfer is tagged with GameController
    --------------------------------------------------
    Actually, lets have the main audio and video cource hold all assets in an array
    then the button can send the index to the what needs to be played
    */

    public int AssetIndex;
    public int QuValue;
    public VideoClipLibrary videoObject;
    public AudioClipLibrary audioObject;
    public AssignPoints points;
    public GameObject backdrop;
    public GameObject CatsAndQuests;

    //grab this buttons component
    private Button thisBtn;

    private void Start()
    {
        thisBtn = gameObject.GetComponent<Button>();
    }

    public void sendToPlayers()
    {
        //send the index value to the asset arrays
        videoObject.SetIndex(AssetIndex);
        audioObject.SetIndex(AssetIndex);
        points.setPend(QuValue);
        backdrop.SetActive(true);
        CatsAndQuests.SetActive(false);

        //set the button just pressed as un interactable after phase shift
        thisBtn.interactable = false;
    }
}
