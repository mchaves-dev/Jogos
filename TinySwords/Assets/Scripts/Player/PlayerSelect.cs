using UnityEngine;

public sealed class PlayerSelect : MonoBehaviour
{
	public static PlayerSelect Instace;

	private SpriteRenderer _spriteRenderer;
	public bool _playerSelect;

	private void Awake()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
		Instace = this;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
			SelectPlayer();
	}

	private void SelectPlayer()
	{
		//Seleciona o player
		if (IsClickedPlayer() && _playerSelect == false)
		{
			_playerSelect = true;
			_spriteRenderer.enabled = true;
		}
		else if (IsClickedPlayer() == false && _playerSelect)
		{
			_playerSelect = false;
			_spriteRenderer.enabled = false;
		}
	}

	private bool IsClickedPlayer()
	{
		var radiusPlayerSelect = Input.mousePosition + new Vector3(10, 10, 10);
		var playerSeleciton = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(radiusPlayerSelect), Vector2.zero);
		return playerSeleciton.collider != null && playerSeleciton.collider.CompareTag("Player");
	}
}