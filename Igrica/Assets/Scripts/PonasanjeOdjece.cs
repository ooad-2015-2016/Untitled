using UnityEngine;
using System.Collections;

public class PonasanjeOdjece : MonoBehaviour
{

    public float brzina = 1f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position - new Vector3(0, brzina * Time.deltaTime, 0);
    }
}
