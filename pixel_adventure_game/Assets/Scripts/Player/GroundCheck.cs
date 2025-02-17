using UnityEngine;

public sealed class GroundCheck : MonoBehaviour
{
	private Player _player;

	private void Start()
	{
		//Busca no objeto pai o componete
		_player = gameObject.transform.parent.GetComponent<Player>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer.Equals(8))
		{
			_player.IsJump = false;
			_player.IsDoubleJump = false;
			_player.LiberateDoubleJump = false;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag.Equals("gameOver"))
		{
			GameController.Instance.ShowGameOver();
			Destroy(_player.gameObject);
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.layer.Equals(8))
		{
			_player.IsJump = true;
			_player.LiberateDoubleJump = true;
		}
	}
}