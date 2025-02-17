using UnityEngine;

public class Fan : Trap
{
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag.Equals("Player"))
		{
			_animatorTrap.SetTrigger("active");
		}
	}
}