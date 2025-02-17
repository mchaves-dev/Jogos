using UnityEngine;

public abstract class Box : MonoBehaviour
{
	private Animator _animatorBox;

	[SerializeField] private int _lifeBox;

	private void Start()
	{
		_animatorBox = GetComponent<Animator>();
	}

	protected void DamageBox()
	{
		_lifeBox--;
		if (_lifeBox <= 0)
		{
			Destroy(gameObject, 0.050f);
		}

		_animatorBox.SetTrigger("hit");

	}

	private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
	{
		ManagerCollision(collision.gameObject, collision.contacts);
	}

	private void ManagerCollision(GameObject gameObject, ContactPoint2D[] contracts)
	{
		if (gameObject.CompareTag("Player"))
		{
			if ((contracts[0].point.y - (transform.position.y + 0.0996f)) > 0)
				DamageBox();
		}
	}
}