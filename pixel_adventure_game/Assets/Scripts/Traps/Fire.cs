using UnityEngine;

public class Fire : Trap
{
	private Animator _animator;

	[SerializeField] public float _timeOn;
	[SerializeField] public float _timeOff;

	private bool _isOn;
	private bool _isHit;
	private float _timeNextExchange;
	public int _life = 2;

	private void Start()
	{
		_animator = GetComponent<Animator>();
		_timeNextExchange = Time.time + 1;
	}

	private void Update()
	{
		//Pega o tempo atual de jogo e compara com o tempo de execução para alternar.
		if (Time.time >= _timeNextExchange)
		{
			ControllerFire();
			_animator.SetBool("on", _isOn);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			_life--;
			_animator.SetTrigger("hit");

			//Quando está ligada e sofrer hit deve continuar ligada!
			if (_isOn == false)
				_timeNextExchange = Time.time + 0.3f;

			if (_life == 0)
				Destroy(this.gameObject);
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
			Player.Instance.DamagePlayer(0.5f);
	}

	public void ControllerFire()
	{
		_isOn = !_isOn;

		if (_isOn)
			_timeNextExchange = Time.time + _timeOn;
		else
			_timeNextExchange = Time.time + _timeOff;
	}
}