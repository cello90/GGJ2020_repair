using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeachHandler : MonoBehaviour
{
    public Animator anim;
    public Animator ai_animation;
    public Text words;

    public float timeSinceStart = 0f;

    bool AITalkingAnimation = false;

    private void OnEnable()
    {
        Game.EnterCollider += Talk;
        Game.ExitCollider += EndTalk;
        Game.CompleteTask += AITalk;
    }

    private void OnDisable()
    {
        Game.EnterCollider -= Talk;
        Game.ExitCollider -= EndTalk;
        Game.CompleteTask -= AITalk;
    }

    public void Talk(object obj, InfoEventArgs<GameObject, string> e)
    {
        string text = "";
        if (e.Subtype == null)
        {
            text = e.Subtype;
        }
        else
        {
            text = e.Subtype;
        }

        words.text = text;
        anim.SetBool("Talking", true);
    }

    void EndTalk(object obj, InfoEventArgs<GameObject> e)
    {
        anim.SetBool("Talking", false);
    }

    public void AITalk(object obj, InfoEventArgs<AudioClip, string> e)
    {
        if(e.Subtype == null || e.Subtype == "")
        {
            Debug.LogError("Missing text");
        }

        Debug.Log("AI: " + e.Subtype);

        // Set animation
        ai_animation.SetBool("Talking", true);

        // Set text of animation object
        Text text = GameObject.Find("ShipAnim").transform.Find("RawImage").transform.Find("Text").GetComponent<Text>();
        text.text = e.Subtype;

        // Set location variable
        AITalkingAnimation = true;

        // Debug
        Debug.Log("AI Should have a message pop up");

        timeSinceStart = 0f;
    }

    public void UpdateHintText(string e)
    {

    }

    private void Update()
    {
        if(AITalkingAnimation == true)
        {
            if(timeSinceStart > 2f)
                // Get user input
                if(Input.GetAxis("L_E") > 0)
                {
                    ai_animation.SetBool("Talking", false);
                    Game.instance.PauseGame(false);
                    Debug.Log("Should get rid of text");
                    AITalkingAnimation = false;
                }

            timeSinceStart += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            Game.instance.PauseGame(true);
            Game.instance.CompletedATask(this.gameObject, Game.instance.json.GetMessage(1), null);
        }
    }
}
