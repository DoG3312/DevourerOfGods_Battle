using UnityEngine;

public class PlayerController : Controller
{
    public PlayerMovement playerMovement;

    protected override void Awake()
    {
        base.Awake();
        model = new PlayerModel(stats);
        model.HealthChanged += view.OnHealthChanged;
    }

    public void Update()
    {
        playerMovement.MoveUpdate();
    }
    private void FixedUpdate()
    {
        playerMovement.MoveFixedUpdate();
    }
}
