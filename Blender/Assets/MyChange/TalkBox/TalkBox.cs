using UnityEngine;

[CreateAssetMenu(fileName = "TalkBox", menuName = "TalkBox")]

public class TalkBox : ScriptableObject 
{
    [Header("對話內容"), TextArea(1, 3)]
    public string[] talkContents;
    
}