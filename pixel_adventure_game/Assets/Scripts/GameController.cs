using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static Fruit;

public class GameController : MonoBehaviour
{
	public GameObject _pineappleUI;
	public GameObject _appleUI;
	public GameObject _bananaUI;
	public GameObject _cherrieUI;

	public GameObject _gameOverUI;
	public GameObject _finishGame;

	public InventoryPlayer _inventoryPlayer;

	public static GameController Instance;

	private void Awake()
	{
		Instance = this;
	}

	public void UpdateScore(int valueFruitAdd, EFruits eFruit)
	{
		Text textBoxFruit;

		switch (eFruit)
		{
			case EFruits.Pineapple:
				textBoxFruit = _pineappleUI.gameObject.GetComponentInChildren<Text>();
				_inventoryPlayer._totalCountPineapple += valueFruitAdd;
				textBoxFruit.text = _inventoryPlayer._totalCountPineapple.ToString().PadLeft(3, '0');
				break;
			case EFruits.Apple:
				textBoxFruit = _appleUI.gameObject.GetComponentInChildren<Text>();
				_inventoryPlayer._totalCountApple += valueFruitAdd;
				textBoxFruit.text = _inventoryPlayer._totalCountApple.ToString().PadLeft(3, '0');
				break;
			case EFruits.Banana:
				textBoxFruit = _bananaUI.gameObject.GetComponentInChildren<Text>();
				_inventoryPlayer._totalCountBanana += valueFruitAdd;
				textBoxFruit.text = _inventoryPlayer._totalCountBanana.ToString().PadLeft(3, '0');
				break;
			case EFruits.Cherrie:
				textBoxFruit = _cherrieUI.gameObject.GetComponentInChildren<Text>();
				_inventoryPlayer._totalCountCherrie += valueFruitAdd;
				textBoxFruit.text = _inventoryPlayer._totalCountCherrie.ToString().PadLeft(3, '0');
				break;
		}
	}

	public void ShowGameOver()
	{
		if (_gameOverUI != null)
			_gameOverUI.SetActive(true);
	}

	private void HideGamerOver()
	{
		if (_gameOverUI != null)
			_gameOverUI.SetActive(false);
	}

	public void ShowFinishGame()
	{
		if (_finishGame != null)
			_finishGame.SetActive(true);
	}

	private void HideFinish()
	{
		if (_finishGame != null)
			_finishGame.SetActive(false);
	}

	public void RestartScene()
	{
		HideGamerOver();
		HideFinish();

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void NextScene()
	{
		HideGamerOver();
		HideFinish();

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void ExitGame()
	{
		Application.Quit();
	}

}