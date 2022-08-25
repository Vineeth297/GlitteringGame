public class PlayerControlBaseState
{
	protected static PlayerInputControl Player;
	protected PlayerControlBaseState() { }
	public PlayerControlBaseState(PlayerInputControl input)
	{
		Player = input;
	}

	public virtual void OnStart() { }

	public virtual void OnUpdate() { }

	public virtual void OnExit() { }
}
