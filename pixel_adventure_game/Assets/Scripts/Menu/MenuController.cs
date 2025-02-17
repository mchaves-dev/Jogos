using UnityEngine;

public sealed class MenuController : MonoBehaviour
{
	[SerializeField] private GameObject OptionsMenu;
	[SerializeField] private GameObject StartGame;

	private void Update()
	{
		GetForKeysToStartTheGame();
	}

	private void GetForKeysToStartTheGame()
	{
		if (Input.anyKeyDown)
		{
			StartGame.SetActive(false);
			OptionsMenu.SetActive(true);
		}
	}
}