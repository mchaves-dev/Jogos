using UnityEngine;

public class Cherrie : Fruit
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			_animationWhenCollecting.SetActive(true);
			_circleCollider2DFruit.enabled = false;
			_spriteRenderFruit.enabled = false;
			GameController.Instance.UpdateScore(1, EFruits.Cherrie);
			Destroy(gameObject, 0.4f);
		}
	}
}