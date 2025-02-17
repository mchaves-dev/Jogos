using UnityEngine;

public sealed class Mushroom : EnemyPatrol
{
	[SerializeField] public float _maxDurationIdle;
	[SerializeField] public float _maxDurationRun;

	private bool _isRunning = false;
	private float _nextExchangeTime;

	private void Start()
	{
		_nextExchangeTime = Time.time + _maxDurationRun;
	}

	private void FixedUpdate()
	{
		if (_isRunning)
			AddVelocityEnemyX();
	}

	private void Update()
	{
		//Define o tempo da próxima troca de estado
		if (Time.time >= _nextExchangeTime)
		{
			_isRunning = !_isRunning;
			_nextExchangeTime = Time.time + (_isRunning ? _maxDurationRun : _maxDurationIdle);
		}

		if (_isRunning && IsHitTheWall())
		{
			FlipEnemy();
			ReverseSpeedEnemy();
		}

		AnimationsControllers();
	}

	private void AnimationsControllers()
	{
		_animatorEnemy.SetBool("run", _isRunning);
	}
}