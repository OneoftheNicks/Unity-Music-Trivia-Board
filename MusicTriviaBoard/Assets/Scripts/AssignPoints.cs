using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignPoints : MonoBehaviour
{
    private static int score1 = 0;
    private static int score2 = 0;
    private static int qCount = 0;
    public Text T1Score;
    public Text T2Score;
    public VideoClipLibrary videoConfirm;
    public AudioClipLibrary audioConfirm;
    public GameObject backdrop;
    public GameObject CatsAndQuests;

    public GameObject finalQuestion;

    //value for current question score
    int pending = 0;
    public void setPend(int value)
    {
        pending = value;
    }

    public void PointstoT1()
    {
        if (backdrop.activeSelf)
        {
            score1 += pending;
            T1Score.text = score1.ToString();
            //stop audio and video
            videoConfirm.EndVideo();
            audioConfirm.ResetTimer();
            backdrop.SetActive(false);
            CatsAndQuests.SetActive(true);
            qCount++;
        }
    }

    public void PointstoT2()
    {
        if (backdrop.activeSelf)
        {
            score2 += pending;
            T2Score.text = score2.ToString();
            //stop audio and video
            videoConfirm.EndVideo();
            audioConfirm.ResetTimer();
            backdrop.SetActive(false);
            CatsAndQuests.SetActive(true);
            qCount++;
        }
    }

    public void nullPoints()
    {
        videoConfirm.EndVideo();
        audioConfirm.ResetTimer();
        backdrop.SetActive(false);
        CatsAndQuests.SetActive(true);
        qCount++;
    }

    public void setScore1(int score)
    {
        score1 = score;
    }

    public void setScore2(int score)
    {
        score2 = score;
    }

    public void forceFinal()
    {
        CatsAndQuests.SetActive(false);
        finalQuestion.SetActive(true);
    }

    void Update()
    {
        //check if all questions are finished with the point totals
        //the sum of the two scores should be 18,750 at the max.
        //more if adjusted via dev menu

        if(qCount >= 30)
        {
            //turn off the main board and show the final question
            CatsAndQuests.SetActive(false);
            finalQuestion.SetActive(true);
        }

        Debug.Log(qCount);
    }
}
