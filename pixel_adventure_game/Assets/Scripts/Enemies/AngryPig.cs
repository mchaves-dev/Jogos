using UnityEngine;

public sealed class AngryPig : Enemy
{
	[SerializeField] private float _jumpForceEnemy;
	[SerializeField] private Transform _transformeColliderUp;
	[SerializeField] private Transform _transformeColliderDown;
	[SerializeField] private Transform _transformeHeadPoint;
	[SerializeField] private LayerMask _layerMask;

	private Animator _animatorEmemy;
	private CapsuleCollider2D _capsuleCollider2DEnemy;
	private BoxCollider2D _boxCollider2D;

	private void Start()
	{
		_rigidbody2DEnemy = GetComponent<Rigidbody2D>();
		_animatorEmemy = GetComponent<Animator>();
		_capsuleCollider2DEnemy = GetComponent<CapsuleCollider2D>();
		_boxCollider2D = gameObject.GetComponentInChildren<BoxCollider2D>();
	}

	private void Update()
	{
		//adicionar uma velocidade a um gameobject
		_rigidbody2DEnemy.velocity = new Vector2(_speedMovimentEnemyX, _rigidbody2DEnemy.velocity.y);

		//cria um colisor entre dois pontos e retornar true quando colide em algum objeto
		var collision = Physics2D.Linecast(_transformeColliderUp.position, _transformeColliderDown.position, _layerMask);

		if (collision)
		{
			FlipEnemy();
			ReverseSpeedEnemy();
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag.Equals("Player"))
		{
			//verifica se o primeiro contato de colisor foi no alto da cabeça do enimigo
			if ((collision.contacts[0].point.y - _transformeHeadPoint.position.y) > 0)
			{
				_capsuleCollider2DEnemy.enabled = false;
				_boxCollider2D.enabled = false;
				_animatorEmemy.SetTrigger("hit");
				_speedMovimentEnemyX = 0f;
				_rigidbody2DEnemy.AddForce(new Vector2(0f, _jumpForceEnemy), ForceMode2D.Impulse);
				_rigidbody2DEnemy.bodyType = RigidbodyType2D.Kinematic;
				Destroy(gameObject, 0.33f);
			}
			else
			{
					Player.Instance.DamagePlayer(1);
			}
		}
	}
}