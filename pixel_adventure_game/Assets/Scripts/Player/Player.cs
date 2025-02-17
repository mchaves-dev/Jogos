using UnityEngine;
using static UnityEngine.UI.Image;

[RequireComponent(typeof(PlayerAnimation))]
[RequireComponent(typeof(PlayerMoviment))]
public sealed class Player : MonoBehaviour
{
	private PlayerAnimation _playerAnimation;
	private PlayerMoviment _playerMoviment;

	public PlayerAnimation PlayerAnimation => _playerAnimation;
	public PlayerMoviment PlayerMoviment => _playerMoviment;

	public void Start()
	{
		_inicialSpeed = _speedMovimentPlayer;
		_playerAnimation = GetComponent<PlayerAnimation>();
		_playerMoviment = GetComponent<PlayerMoviment>();
		Instance = this;
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			DamagePlayer(1);
		}
	}

	#region Control Variables

	//Moviment
	private float _inicialSpeed;
	[SerializeField] private float _speedMovimentPlayer;
	private float _directionPlayer;

	//Jump
	[SerializeField] private float _jumpForce;
	private bool _isJump = false;
	private bool _isDoubleJump = false;
	private bool _liberateDoubleJump = false;

	//Hit
	private bool _isHit = false;
	#endregion

	#region Properties

	public static Player Instance;

	public bool IsHit
	{
		get => _isHit;
		set => _isHit = value;
	}

	public bool IsJump
	{
		get => _isJump;
		set => _isJump = value;
	}

	public bool IsDoubleJump
	{
		get => _isDoubleJump;
		set => _isDoubleJump = value;
	}

	public bool LiberateDoubleJump
	{
		get => _liberateDoubleJump;
		set => _liberateDoubleJump = value;
	}

	public float SpeedMovimentPlayer
	{
		get => _speedMovimentPlayer;
		set => _speedMovimentPlayer = value;
	}

	public float JumpForce
	{
		get => _jumpForce;
		set => _jumpForce = value;
	}

	public float Direction
	{
		get => _directionPlayer;
		set => _directionPlayer = value;
	}

	#endregion

	public void DamagePlayer(float damage)
	{
		IsHit = true;
		SetNewSpeedPlayer(0);
		_playerAnimation.StartHitAnimation();
		_playerMoviment.SetEnableFlipPlayer(false);
		GameController.Instance.ShowGameOver();
		Destroy(gameObject, 0.5f);
	}

	private void SetNewSpeedPlayer(float newSpeed)
	{
		_speedMovimentPlayer = newSpeed;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		ManagerCollision(collision.gameObject);
	}

	private void ManagerCollision(GameObject gameObject)
	{
		if (gameObject.CompareTag("DamageAngryPig"))
			DamagePlayer(1);
		else if (gameObject.CompareTag("DamageFatBird"))
			DamagePlayer(1);
		else if (gameObject.CompareTag("DamageSpike"))
			DamagePlayer(1);
		else if (gameObject.CompareTag("DamageMushroom"))
			DamagePlayer(1);
		else if (gameObject.CompareTag("DamageSaw"))
			DamagePlayer(1);
	}
}