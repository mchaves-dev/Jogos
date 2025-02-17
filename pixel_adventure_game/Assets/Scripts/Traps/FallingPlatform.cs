using UnityEngine;

public class FallingPlatform : Trap
{
	private TargetJoint2D _targetJoint2DTrap;
	private BoxCollider2D _boxCollider2dTrap;
	private Animator _animatorTrap;

	[SerializeField] private float _timeBeforeFalling;

	private void Start()
	{
		_targetJoint2DTrap = GetComponent<TargetJoint2D>();
		_boxCollider2dTrap = GetComponent<BoxCollider2D>();
		_animatorTrap = GetComponent<Animator>();
	}

	private void OnCollisionEnterPlayerWithTrap()
	{
		_targetJoint2DTrap.enabled = false;
		_boxCollider2dTrap.isTrigger = true;
		_animatorTrap.speed = 0.2f;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag.Equals("Player"))
			Invoke("OnCollisionEnterPlayerWithTrap", _timeBeforeFalling);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag.Equals("Player"))
		{
			if (collision.gameObject.layer.Equals(10))
				Destroy(gameObject);
		}
	}
}