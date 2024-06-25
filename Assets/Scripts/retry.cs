using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retry : MonoBehaviour
{
   public void reload(){
    SceneManager.LoadScene(1);
   }

   public void loadMenu(){
    SceneManager.LoadScene(0);
   }
}
