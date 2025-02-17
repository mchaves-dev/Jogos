using UnityEngine;

public sealed class PlayerMoviments : MonoBehaviour
{
	private Rigidbody2D _rigidbody2DPlayer;

	[SerializeField] private float _speedPlayerMoviment;
	[SerializeField] private Vector3 _nextPositionPlayer;

	private void Start()
	{
		_rigidbody2DPlayer = GetComponent<Rigidbody2D>();
		_nextPositionPlayer = _rigidbody2DPlayer.position;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && PlayerSelect.Instace._playerSelect)
			_nextPositionPlayer = GetTransformeNestPosition();

		MovePlayerToNewPosition(_nextPositionPlayer);
	}

	private Vector3 GetTransformeNestPosition()=>  Camera.main.ScreenToWorldPoint(Input.mousePosition);

	private void MovePlayerToNewPosition(Vector3 nextPositionPlayer)
	{
		_rigidbody2DPlayer.MovePosition(Vector3.MoveTowards(_rigidbody2DPlayer.position, nextPositionPlayer, _speedPlayerMoviment * Time.deltaTime));
	}
}