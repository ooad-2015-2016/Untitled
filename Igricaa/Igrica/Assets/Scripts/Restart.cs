using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour
{
   public void RestartGame()
    {
        //stavlja vec postojeci level
        Application.LoadLevel(Application.loadedLevel);
    }

}
