using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KoferController : MonoBehaviour
{

    public Camera cam;
    public float speed;
    private float maxWidth;
    public Text heartsText;

    private int brojZivota;

    public int  BrojZivota
    {
        get { return brojZivota; }
        set { brojZivota = value; }
    }
    



    private bool canControl;
    // Use this for initialization
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        BrojZivota = 3;
        canControl = false;
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        Renderer ren = GetComponent<Renderer>();
        float KoferPrazanWidth = ren.bounds.extents.x;
        maxWidth = targetWidth.x - KoferPrazanWidth;
        heartsText.text = "Hearts\n" + brojZivota;
    }

    // Update is called once per physics timestep
    void FixedUpdate()
    {
        if (canControl)
        {
            // Vector3 rawPosition = cam.ScreenToWorldPoint(Input.GetKey());
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (this.transform.position.x > -maxWidth)
                {
                    transform.position += Vector3.left * speed * Time.deltaTime;
                }
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (this.transform.position.x < maxWidth)
                {
                    transform.position += Vector3.right * speed * Time.deltaTime;
                }
            }
        }


    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bomba")
        {
            UpdateHearts();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bomba")
        {
            UpdateHearts();
        }
       

    }
    public void ToggleControl(bool toggle)
    {
        canControl = toggle;
    }

    public void UpdateHearts()
    {
        brojZivota--;
        heartsText.text = "Hearts:\n" + brojZivota;
    }
}
