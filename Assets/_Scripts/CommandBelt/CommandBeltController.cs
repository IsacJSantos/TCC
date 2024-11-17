using UnityEngine;

public class CommandBeltController : Singleton<CommandBeltController>
{
    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private MainCommandBelt mainCommandBelt;
    public MainCommandBelt getMainCommandBelt { get => mainCommandBelt; }
    [SerializeField]
    private MethodBelt methodCommandBelt;
    public MethodBelt getMethodCommandBelt { get => methodCommandBelt; }
    [SerializeField]
    private Transform commandBeltContainer;

    public void OnClick_Execute()
    {
        mainCommandBelt.Init(player.GetComponent<IEntity>());
    }

}
