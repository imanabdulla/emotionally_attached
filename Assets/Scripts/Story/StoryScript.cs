using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryScript : MonoBehaviour
{
    [Serializable]
    public class Conversation
    {
        public string characterName;
        public Color characterNameColor;
        public string characterScript;
    }

    [SerializeField] private Conversation[] conversation;
    [SerializeField] private Text characterScriptText, characterNameText;
    private string currentScript;

    private void Start()
    {
        StartCoroutine(TypeStoryScript(characterNameText, characterScriptText));
    }

    private IEnumerator TypeStoryScript(Text charName, Text charScript)
    {
        for (int i = 0; i < conversation.Length; i++)
        {
            charName.color = charScript.color = conversation[i].characterNameColor;
            charName.text = conversation[i].characterName;

            for (int j = 0; j <= conversation[i].characterScript.Length; j++)
            {
                currentScript = conversation[i].characterScript.Substring(0, j);
                charScript.text = currentScript;

                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitForSeconds(0.5f);
        }
        FinishStory();
    }

    //close button event trigger
    public void FinishStory()
    {
        StoryManager.storyManager.LoadSceneInCoroutine("MainMenu&Map");
    }
}