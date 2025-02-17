
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
	private CapsuleCollider2D _capsuleCollider;
	public string _nextNivel;

	private void Start()
	{
		_capsuleCollider = GetComponent<CapsuleCollider2D>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag.Equals("Player"))
		{
			GameController.Instance.ShowFinishGame();
			Player.Instance.SpeedMovimentPlayer = 0f;
			Player.Instance.JumpForce = 0f;
		}
	}
}
