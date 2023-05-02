using UnityEngine;

[CreateAssetMenu(menuName = "Dialgoue/ Dialogue Object")]
public class DialogueSys : ScriptableObject
{
    [SerializeField][TextArea] private string[] dialogue;
    [SerializeField] private Response[] responses;

    public string[] Dialogue => dialogue;

    public bool HasResponses => Responses != null && responses.Length > 0;
    public Response[] Responses => responses;
}
