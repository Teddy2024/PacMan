using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class TalkSystem : MonoBehaviour
{
    [SerializeField, Range(0, 20f)]
    private float noInputTime = 10f;
    private float _noInputTime;
    [SerializeField, Range(0, 0.5f)]
    private float talkIntervalTime = 0.5f;
    [SerializeField] private TalkBox opening;
    [SerializeField] private KeyCode dialogueKey = KeyCode.Space;

    private WaitForSeconds talkInterval => new WaitForSeconds(talkIntervalTime);
    
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TextMeshProUGUI talkContent;

    
    private void Awake() 
    {
        StartDialogue(opening);
    }  

    private void Update() 
    {
        NoInput();
    }

    public void StartDialogue(TalkBox data)
    {
        StartCoroutine(FadeGroup());
        StartCoroutine(TyperEffect(data));
    }
        
    private IEnumerator FadeGroup(bool fadeIn = true)
    {
        float increase = fadeIn ?  0.1f : -0.1f;
        for(int i = 0; i < 10; i++)
        {
            canvasGroup.alpha += increase;
            yield return new WaitForSeconds(0.2f);
        }
    }

    private IEnumerator TyperEffect(TalkBox data)
    {
        for(int j = 0; j < data.talkContents.Length; j++)
        {
            talkContent.text = "";
            string dialogue = data.talkContents[j];
            talkContent.text += dialogue;
            yield return talkInterval;
            

            while (!Input.GetKeyDown(dialogueKey))
            {
                yield return null;
            }
        }
        StartCoroutine(FadeGroup(false));
    }

    private void NoInput()
    {
        if(canvasGroup.alpha < 1){return;}
        _noInputTime += Time.deltaTime;
        if(Input.GetKeyDown(dialogueKey))
        {
            _noInputTime = 0;
        }
        else if(_noInputTime >= noInputTime)
        {
            StartCoroutine(FadeGroup(false));
        }
    }
}