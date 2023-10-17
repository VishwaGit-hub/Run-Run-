using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float score;
    private PlayerController playercontrollerscript;
    public Transform startingPoint;
    public float lerpSpeed;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        playercontrollerscript=GameObject.Find("Player").GetComponent<PlayerController>();

        playercontrollerscript.gameOver = true;
        StartCoroutine(PlayerIntro());
    }

    // Update is called once per frame
    void Update()
    {
        if(!playercontrollerscript.gameOver)
        {
            if(playercontrollerscript.superSpeed)
            {
                score += 2;
            }
            else
            {
                score++;
            }
            Debug.Log(score);
        }
    }

    IEnumerator PlayerIntro()
    {
        Vector3 startPos = playercontrollerscript.transform.position;
        Vector3 endPos = startingPoint.position;
        float journeyLength = Vector3.Distance(startPos, endPos);
        float startTime = Time.time;
        float distanceCovered = (Time.time - startTime) * lerpSpeed;
        float fractionOfJourney = distanceCovered / journeyLength;
        playercontrollerscript.GetComponent<Animator>().SetFloat("Speed_Multiplier",
        0.5f);
        while (fractionOfJourney < 1)
        {
            distanceCovered = (Time.time - startTime) * lerpSpeed;
            fractionOfJourney = distanceCovered / journeyLength;
            playercontrollerscript.transform.position = Vector3.Lerp(startPos, endPos,
fractionOfJourney);
            yield return null;

        }
        playercontrollerscript.GetComponent<Animator>().SetFloat("Speed_Multiplier",1.0f);
        playercontrollerscript.gameOver = false;
    }
}
