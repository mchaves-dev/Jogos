using UnityEngine;

public sealed class PlayerMoviment : MonoBehaviour
{
	#region Components
	private Rigidbody2D _rigidbodyPlayer;
	#endregion

	private Player Player;
	public static PlayerMoviment Instance;

	private void Start()
	{
		_rigidbodyPlayer = GetComponent<Rigidbody2D>();
		Player = FindObjectOfType<Player>();
		Instance = this;
	}

	#region Actions

	private void Move()
	{
		this.Player.PlayerAnimation.SetWalkAnimation(true);
		_rigidbodyPlayer.velocity = new Vector2(Player.Direction * Player.SpeedMovimentPlayer, _rigidbodyPlayer.velocity.y);
	}

	private void Jump()
	{
		//caso esteja levando dano não deixa pular
		if (Player.IsHit)
			return;

		if (!Player.IsJump)
		{
			AddImpulsePlayer(0f, Player.JumpForce);
			this.Player.PlayerAnimation.SetJumpAnimation(true);
		}
		else if (Player.LiberateDoubleJump)
		{
			AddImpulsePlayer(0f, Player.JumpForce * 0.5f);
			this.Player.PlayerAnimation.SetDoubleJumpAnimation(true);
			Player.LiberateDoubleJump = false;
			Player.IsDoubleJump = true;
		}

	}

	private void LoadingInput()
	{
		Player.Direction = Input.GetAxis("Horizontal");

		if (Player.Direction != 0)
			Move();
		else
			this.Player.PlayerAnimation.SetWalkAnimation(false);

		if (Input.GetKeyDown(KeyCode.Space))
			Jump();
		else
		{
			this.Player.PlayerAnimation.SetJumpAnimation(false);
			this.Player.PlayerAnimation.SetDoubleJumpAnimation(false);
		}
	}

	#endregion

	public void AddImpulsePlayer(float forceImpulseX, float forceImpulseY)
	{
		_rigidbodyPlayer.AddForce(new Vector2(forceImpulseX, forceImpulseY), ForceMode2D.Impulse);
	}

	public void SetEnableFlipPlayer(bool enableFlip)
	{
		this.enableFlip = enableFlip;
	}

	bool enableFlip = true;

	private void FlipPlayer()
	{
		if (enableFlip == false) return;

		if (Player.Direction > 0)
			transform.eulerAngles = new Vector3(0f, 0f, 0f);
		else if (Player.Direction < 0)
			transform.eulerAngles = new Vector3(0f, 180f, 0f);
	}

	private void Update()
	{
		LoadingInput();
		FlipPlayer();
	}
}