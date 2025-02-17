using UnityEngine;

public abstract class Fruit : MonoBehaviour
{
	public GameObject _animationWhenCollecting;
	protected SpriteRenderer _spriteRenderFruit;
	protected CircleCollider2D _circleCollider2DFruit;

	public void Start()
	{
		_spriteRenderFruit = GetComponent<SpriteRenderer>();
		_circleCollider2DFruit = GetComponent<CircleCollider2D>();
	}
	
	public enum EFruits
	{
		Pineapple = 1,
		Apple = 2,
		Banana = 3,
		Cherrie = 4,
		Strawberry = 5
	}
}