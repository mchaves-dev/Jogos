using UnityEngine;

public class SpikeHead : Trap
{
	private Rigidbody2D _rigidbody2d;

	[SerializeField] private float _speedMove;
	[SerializeField] private LayerMask _layerMask = 1;
	[SerializeField] private Transform _pointWallCollider;
	[SerializeField] private Transform _pointGroundCollider;

	private float _radiusCircleColliderWall = 0.1f;

	private void Start()
	{
		_rigidbody2d = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		_rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, _speedMove);
	}

	private void Update()
	{
		if (IsHitTheWall())
		{
			_speedMove *= -1f;
			transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(_pointWallCollider.position, _radiusCircleColliderWall);
		Gizmos.DrawWireSphere(_pointGroundCollider.position, _radiusCircleColliderWall);
	}

	protected bool IsHitTheWall()
	{
		if (_pointWallCollider != null && _pointGroundCollider != null)
			return Physics2D.OverlapCircle(_pointWallCollider.position, _radiusCircleColliderWall, _layerMask)
				|| Physics2D.OverlapCircle(_pointGroundCollider.position, _radiusCircleColliderWall, _layerMask);

		return false;
	}
}