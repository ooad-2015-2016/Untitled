using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Score : MonoBehaviour {

    public Text scoreText;
    public int odjecaValue;
    private int score;

	// Use this for initialization
	void Start () {
        score = 0;
        scoreText.text = "Score:\n" + score;
        UpdateScore();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bomba")
         {
            score -= 0;
        }
        else
        {
            score += odjecaValue;
            UpdateScore();
        }

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bomba")
        {
            score -= 0;
        }
    }
    void UpdateScore ()
    {
        scoreText.text = "Score:\n" + score;

    }
	
}
