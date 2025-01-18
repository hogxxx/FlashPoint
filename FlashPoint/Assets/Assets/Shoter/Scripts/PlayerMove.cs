using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerMove : MonoBehaviour
{

	public float dirX;


	public float dirY;


	public float speed;


	public Joystick joystick;


	private Rigidbody2D pl_rb;


	private Transform pl_tr;


	private Vector2 rotX;


	public Button fireButton;


	public GameObject fire;


	public GameObject[] lifes;


	public int life;


	public Transform playerTr;


	public Transform cameraTr;


	public int places;


	public GameObject mainBullet;

	private void Awake()
	{
		if (MyClass.rang == 0)
		{
			placesscore.placesRedact(8);
			return;
		}
		if (MyClass.rang == 1)
		{
			placesscore.placesRedact(17);
			return;
		}
		if (MyClass.rang == 2)
		{
			placesscore.placesRedact(31);
			return;
		}
		if (MyClass.rang == 3)
		{
			placesscore.placesRedact(63);
			return;
		}
		if (MyClass.rang == 4)
		{
			placesscore.placesRedact(63);
			return;
		}
		if (MyClass.rang == 5)
		{
			placesscore.placesRedact(127);
			return;
		}
		if (MyClass.rang == 6)
		{
			placesscore.placesRedact(127);
			return;
		}
		if (MyClass.rang == 7)
		{
			placesscore.placesRedact(255);
		}
	}

	private void Start()
	{
		this.pl_rb = base.GetComponent<Rigidbody2D>();
		this.pl_tr = base.GetComponent<Transform>();
		this.fireButton.onClick.AddListener(new UnityAction(this.fireVoid));
		for (int i = 0; i <= MyClass.lifes; i++)
		{
			this.lifes[i].SetActive(true);
		}
		placesscore.unlockplacesRedact0();
	}

	private void Update()
	{
		this.dirX = this.joystick.Horizontal;
		this.dirY = this.joystick.Vertical;
	}

	private void FixedUpdate()
	{
		this.pl_rb.velocity = new Vector2(this.dirX * this.speed, this.dirY * this.speed);
		if (this.dirY < 0f && this.dirX > 0f)
		{
			this.pl_rb.rotation = (-1f + this.dirX) * 90f - 90f;
			return;
		}
		if (this.dirY < 0f && this.dirX < 0f)
		{
			this.pl_rb.rotation = (1f + this.dirX) * 90f + 90f;
			return;
		}
		if (this.dirY > 0f)
		{
			this.pl_rb.rotation = -this.dirX * 90f;
		}
	}

	private void fireVoid()
	{
		this.fire.SetActive(true);
		base.Invoke("noFire", 0.2f);
	}

	private void noFire()
	{
		this.fire.SetActive(false);
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Finish"))
		{
			if (this.life <= MyClass.lifes - 1)
			{
				this.lifes[MyClass.lifes - this.life].SetActive(false);
				this.playerTr.position = new Vector3(0f, 0f, 0f);
				this.cameraTr.position = new Vector3(0f, 0f, -10f);
			}
			else
			{
				SceneManager.LoadScene(0);
			}
			this.life++;
		}
		if (collision.CompareTag("home"))
		{
			this.mainBullet.SetActive(false);
		}
	}

	public void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("home"))
		{
			this.mainBullet.SetActive(true);
		}
	}

	
}
