using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
	protected Rigidbody2D _rigidbody2DEnemy;
	protected Animator _animatorEnemy;

	[SerializeField] protected int _maxLifeEnemy = 1;
	[SerializeField] protected float _speedMovimentEnemyX = 0;
	[SerializeField] protected float _speedMovimentEnemyY = 0;
	[SerializeField] public Transform _transformeHeadPoint;
	[SerializeField] public float _delayDestroyObjetDie;

	private float _radiusCircleColliderWall = 0.1f;

	private void Awake()
	{
		_rigidbody2DEnemy = GetComponent<Rigidbody2D>();
		_animatorEnemy = GetComponent<Animator>();
	}


	public void FlipEnemy()
	{
		transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
	}

	public void ReverseSpeedEnemy()
	{
		_speedMovimentEnemyX *= -1;
	}

	public void AddVelocityEnemyX()
	{
		if (_rigidbody2DEnemy != null)
			_rigidbody2DEnemy.velocity = new Vector2(_speedMovimentEnemyX, _rigidbody2DEnemy.velocity.y);
	}

	public void AddVelocityEnemyY()
	{
		if (_rigidbody2DEnemy != null)
			_rigidbody2DEnemy.velocity = new Vector2(_rigidbody2DEnemy.velocity.x, _speedMovimentEnemyY);
	}

	public virtual void DamageEnemy(float damage)
	{
		if (_maxLifeEnemy <= 0)
		{
			PlayerMoviment.Instance.AddImpulsePlayer(1, 2);
			_speedMovimentEnemyX = 0f;
			_speedMovimentEnemyY = 0f;
			_animatorEnemy.SetTrigger("hit");
			_rigidbody2DEnemy.AddForce(new Vector2(0f, 3), ForceMode2D.Impulse);
			_rigidbody2DEnemy.bodyType = RigidbodyType2D.Kinematic;
			Destroy(gameObject, _delayDestroyObjetDie);
		}
		else
		{
			_maxLifeEnemy--;
			_rigidbody2DEnemy.AddForce(new Vector2(2f,2f), ForceMode2D.Impulse);
		}
	}
}