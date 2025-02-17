using UnityEngine;

public class Tampoline : Trap
{
	[SerializeField]
	private float _jumpForceOnPlayer;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag.Equals("Player"))
		{
			var rigidbody2DPlayer = collision.rigidbody;
			rigidbody2DPlayer.AddForce(new Vector3(0f, _jumpForceOnPlayer), ForceMode2D.Impulse);
			_animatorTrap.SetTrigger("jump");
		}
	}
}