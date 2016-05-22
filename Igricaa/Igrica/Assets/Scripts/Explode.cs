using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Explode : MonoBehaviour {

    public GameObject explosion;
    public ParticleSystem effect;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Kofer")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            effect.transform.parent = null;
            effect.Stop();
            Destroy(effect.gameObject, 1.0f);
            Destroy(gameObject);
        }
    }
}
