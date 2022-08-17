public abstract class PlayerControlBaseState
{
	protected PlayerInputControl player;

	public PlayerControlBaseState ()
	{
		
	}

	public PlayerControlBaseState (PlayerInputControl p)
	{
		player = p;
	}

	public abstract void OnStart();

	public abstract void OnUpdate();

	public abstract void OnExit();

}
