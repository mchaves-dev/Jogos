using UnityEngine;

public abstract class Trap : MonoBehaviour
{
	protected Animator _animatorTrap;

	private void Start()
	{
		_animatorTrap = GetComponent<Animator>();
	}

}