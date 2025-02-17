using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public abstract class EnemyPatrol : Enemy
{
	[SerializeField] protected Transform _pointWallCollider;
	[SerializeField] protected LayerMask _layerMask;

	private float _radiusCircleColliderWall = 0.1f;

	private void OnDrawGizmos() => Gizmos.DrawWireSphere(_pointWallCollider.position, _radiusCircleColliderWall);

	protected bool IsHitTheWall()
	{
		if (_pointWallCollider != null)
			return Physics2D.OverlapCircle(_pointWallCollider.position, _radiusCircleColliderWall, _layerMask);

		return false;
	}
}