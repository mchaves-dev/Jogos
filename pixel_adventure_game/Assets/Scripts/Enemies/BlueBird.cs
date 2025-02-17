using UnityEngine;

public sealed class BlueBird : EnemyPatrol
{
	private CapsuleCollider2D _capsuleCollider2;
	public CapsuleCollider2D _circleCollider2D;

	private void FixedUpdate() => HandleFly();

	private void Start()
	{
		_capsuleCollider2 = GetComponent<CapsuleCollider2D>();
	}

	private void HandleFly()
	{
		AddVelocityEnemyX();

		if (IsHitTheWall())
		{
			FlipEnemy();
			ReverseSpeedEnemy();
		}
	}

	private void OnTriggerStay2D(Collider2D colider)
	{
		if (colider.gameObject.CompareTag("Player"))
			DamageEnemy(1);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			FlipEnemy();
			ReverseSpeedEnemy();
			Player.Instance.DamagePlayer(1);
		}
	}

	public override void DamageEnemy(float damage)
	{
		if (_maxLifeEnemy <= 0)
		{
			_capsuleCollider2.enabled = false;
			_circleCollider2D.enabled = false;
		}

		base.DamageEnemy(damage);
	}
}