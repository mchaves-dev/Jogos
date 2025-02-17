using UnityEngine;

public sealed class FatBird : EnemyPatrol
{
	[SerializeField] private CircleCollider2D circleCollider2D;
	[SerializeField] private BoxCollider2D boxCollider2D;

	[SerializeField] private float _maxDurationFly;
	[SerializeField] private float _maxDurationFall;

	private bool _isFly = false;
	private float _nextExchangeTime;

	private void Start()
	{
		_nextExchangeTime = _maxDurationFall + Time.time;
	}

	private void FixedUpdate()
	{
		//Movimenta o inimigo para cima enquanto está voando
		if (_isFly && IsHitTheWall() == false)
			AddVelocityEnemyY();
	}

	private void Update()
	{
		//Define o tempo da próxima troca de estado
		if (Time.time >= _nextExchangeTime)
		{
			_isFly = !_isFly;
			_nextExchangeTime += Time.time + (_isFly ? _maxDurationFly : _maxDurationFall);
		}

		AnimationsController();
	}
	

	private void AnimationsController()
	{
		_animatorEnemy.SetBool("fly", _isFly);
		_animatorEnemy.SetBool("ground", !_isFly);
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
			_nextExchangeTime = Time.time;	
			Player.Instance.DamagePlayer(1);
		}
	}

	public override void DamageEnemy(float damage)
	{
		if (_maxLifeEnemy <= 0)
		{
			circleCollider2D.enabled = false;
			boxCollider2D.enabled = false;
		}

		base.DamageEnemy(damage);
	}
}