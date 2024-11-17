using UnityEngine;

public class CommandBeltCanvas : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private CommandBelt commandBelt;
    [SerializeField]
    private Transform commandBeltContainer;

    public void OnClick_Execute() 
    {
        commandBelt.Init(player.GetComponent<IEntity>());
    }

}
