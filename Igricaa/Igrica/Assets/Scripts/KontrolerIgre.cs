using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class KontrolerIgre : MonoBehaviour
{
    public Camera cam;
    public GameObject[] Odjeca;
    private float maxWidth;

    public GameObject gameOverText;
    public GameObject restartButton;
    public GameObject playButton;

    private bool playing;
    public KoferController koferCtrl;

    // Use this for initialization
    void Start()
    {
        {
            if (cam == null)

                cam = Camera.main;
        }
        playing = false;
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
      //  Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        /* Renderer odj = GetComponent<Renderer>();
         float odjecaWidth = odj.bounds.extents.x;
         maxWidth = targetWidth.x - odjecaWidth;*/
    }


    public void Play()
    {
        playButton.SetActive(false);
        koferCtrl.ToggleControl(true);
        StartCoroutine(Spawn());
    }


    //spawn as many object as we can
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2.0f);
        playing = true;
        while (koferCtrl.BrojZivota > 0)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-9.6f, 9.6f), transform.position.y, 0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(Odjeca[(int)Random.Range(0, Odjeca.Length)], spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(0.5f, 2.0f));

        }
          yield return new WaitForSeconds(0.5f);
             gameOverText.SetActive(true);
             yield return new WaitForSeconds(1.0f);
             restartButton.SetActive(true);
    }



}
