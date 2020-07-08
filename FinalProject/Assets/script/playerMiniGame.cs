using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class playerMiniGame : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	public Text countText;
	public Text winText;
	private int count;


	void Start()
	{

		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";

	}
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement= new Vector3(moveHorizontal, 0.0f, moveVertical);
		rb.AddForce(movement * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
		if (other.gameObject.CompareTag ("PICK"))
		{
			other.gameObject.SetActive (false);
			count = count + 2;
			SetCountText ();
		}
	}
	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12)
		{
			winText.text = "Winner";
			Application.Quit();
		}
	}

}