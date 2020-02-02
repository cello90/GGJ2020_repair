using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSON_Manager : MonoBehaviour
{

    public story_jsons story = null;
    public story_jsons hints = null;

    private void OnEnable()
    {
        if (story == null && Game.instance.json_file)
        {
            story = new story_jsons();
            hints = new story_jsons();
            //TextAsset asset = (TextAsset)Resources.Load("GGJ.json",typeof(TextAsset));
            //Debug.Log(asset);
            string txt = "";
            txt = Game.instance.hints.text;
            txt = Game.instance.json_file.text;
            //Debug.Log(txt);
            hints = JsonUtility.FromJson<story_jsons>(txt);
            story = JsonUtility.FromJson<story_jsons>(txt);
        }

        //foreach (string s in story.book)
        //{
        //    Debug.Log(s);
        //}


        //Debug.Log(GetMessage(0));

    }

    public string GetHints(int msg)
    {
        return hints.book[msg];
    }

    public string GetMessage(int msg)
    {
        if (story == null)
            Debug.LogError("!!! Should have a story_jsons item");

        if (story.book.Count > 0)
            Debug.Log("Should have " + story.book.Count + " items in JSON");

        if (msg > story.book.Count)
            Debug.LogError("!!!");
        return story.book[msg];
    }
}

[System.Serializable]
public class story_jsons
{
    public List<string> book = new List<string>();
}

[System.Serializable]
public class story_json
{
    public string chapter;
}
