using UnityEngine;

public sealed class PlayerAnimation : MonoBehaviour
{
	private Animator _playerAnim;

	private void Start() => _playerAnim = GetComponent<Animator>();

	public void StartHitAnimation()
	{
		_playerAnim.SetTrigger("hit");
	}

	public void SetWalkAnimation(bool walk)
	{
		_playerAnim.SetBool("walk", walk);
	}

	public void SetJumpAnimation(bool jump)
	{
		_playerAnim.SetBool("jump", jump);
	}

	public void SetDoubleJumpAnimation(bool doubleJump)
	{
		_playerAnim.SetBool("doubleJump", doubleJump);
	}
}