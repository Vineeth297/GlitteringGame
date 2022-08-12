public abstract class PlayerControlBaseState
{
	protected PlayerInputControl player;
	public abstract void OnStart();

	public abstract void OnUpdate();

	public abstract void OnExit();

}
