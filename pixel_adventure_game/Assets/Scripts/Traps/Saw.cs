using UnityEngine;

public class Saw : Trap
{
	[SerializeField] private Transform _pointStart;
	[SerializeField] private Transform _pointEnd;
	[SerializeField] private float _speedMovimentOnScene;

	private bool _invertedDirectionSaw;

	private void Update()
	{
		MoveSawToTime();
	}

	private void MoveSawToTime()
	{
		if (_invertedDirectionSaw)
			transform.position = Vector2.MoveTowards(transform.position, _pointStart.position, _speedMovimentOnScene * Time.deltaTime);
		else
			transform.position = Vector2.MoveTowards(transform.position, _pointEnd.position, _speedMovimentOnScene * Time.deltaTime);

		if (Vector2.Distance(transform.position, _pointStart.position) <= 0 || Vector2.Distance(transform.position, _pointEnd.position) <= 0)
			_invertedDirectionSaw = !_invertedDirectionSaw;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		ManagerCollision(collision.gameObject);
	}

	private void ManagerCollision(GameObject gameObject)
	{
		if (gameObject.CompareTag("Player"))
			Player.Instance.DamagePlayer(1);
	}
}