using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalQuestionSelect : MonoBehaviour
{
    //very similar to regular button select
    public int AssetIndex;
    public int QuValue;
    public VideoClipLibrary videoObject;
    public AudioClipLibrary audioObject;
    public AssignPoints points;
    public GameObject backdrop;
    public GameObject finalQuestion;

    //grab this buttons component
    private Button thisBtn;

    //update the slider and timer
    public Slider slider;

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
        finalQuestion.SetActive(false);

        //set the button just pressed as un interactable after phase shift
        thisBtn.interactable = false;

        //do other changes
        slider.maxValue = 40;
        audioObject.setWatch(40.0f);
    }

}
