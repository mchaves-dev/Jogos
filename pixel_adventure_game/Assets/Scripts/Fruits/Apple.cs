using UnityEngine;

public class Apple : Fruit
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			_animationWhenCollecting.SetActive(true);
			_circleCollider2DFruit.enabled = false;
			_spriteRenderFruit.enabled = false;
			GameController.Instance.UpdateScore(1, EFruits.Apple);
			Destroy(gameObject, 0.4f);
		}
	}
}