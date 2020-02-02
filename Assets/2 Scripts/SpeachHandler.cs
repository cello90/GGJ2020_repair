using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeachHandler : MonoBehaviour
{
    public Animator anim;
    public Animator ai_animation;
    public Text words;

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
        string text = e.Subtype;
        words.text = text;
        anim.SetBool("Talking", true);
    }

    void EndTalk(object obj, InfoEventArgs<GameObject> e)
    {
        anim.SetBool("Talking", false);
    }

    public void AITalk(object obj, InfoEventArgs<AudioClip, string> e)
    {
        ai_animation.SetBool("Talking", true);
        Text text = GameObject.Find("ShipAnim").transform.Find("RawImage").transform.Find("Text").GetComponent<Text>();
        text.text = e.Subtype;
        AITalkingAnimation = true;
    }

    private void Update()
    {
        if(AITalkingAnimation == true)
        {
            // Get user input
            if(Input.GetAxis("L_E") > 0)
            {
                ai_animation.SetBool("Talking", false);
                Game.instance.PauseGame(false);
                Debug.Log("Should get rid of text");
                AITalkingAnimation = false;
            }
        }
    }
}
