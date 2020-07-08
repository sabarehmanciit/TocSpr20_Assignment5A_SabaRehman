using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    public float speed;
    public GameObject TextBoxContainer;
    public Text countText;
    public Text winText;
    private int count;
    private int hitCount;
    private List<TextMesh> palindromes;


    private void Start()
    {

        rb = GetComponent<Rigidbody>();
        count = 0;
        hitCount = 0;
        SetCountText();
        palindromes = new List<TextMesh>(10);
        TextBoxContainer.SetActive(false);
        winText.text = "";
    }

    private void FixedUpdate()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick up"))
        {
            var textMesh = other.gameObject.GetComponentInChildren<TextMesh>();
            hitCount++;

            if (IsPalindrome(textMesh.text))
            {
                count++;
                other.gameObject.SetActive(false);

                palindromes.Add(textMesh);
                SetCountText();
            }
            else
            {
                other.gameObject.SetActive(false);
            }

            GameOver();
        }
    }

    private void SetCountText()
    {
        countText.text = "Score " + count;
    }

    private void GameOver()
    {
        if (hitCount < 10) return;

        winText.text = "Palindrrome Strings: \n";
        foreach (var palindrome in palindromes)
        {
            winText.text += palindromes.IndexOf(palindrome) + 1 + ".  " + palindrome.text;
            if (!palindromes.LastOrDefault().Equals(palindrome))
                winText.text += "\n";
        }

        TextBoxContainer.SetActive(true);
        Application.Quit();
    }

    private static bool IsPalindrome(string str)
    {
        var ch = str.ToCharArray();
        Array.Reverse(ch);
        var rev = new string(ch);
        return str.Equals(rev, StringComparison.OrdinalIgnoreCase);
    }

}