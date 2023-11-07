using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Takki : MonoBehaviour
{
    public TextMeshProUGUI texti;
   
    public void Start()
    {
        // ef núverandi sena er loka senan sem er numer 3
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            // þá birtast lokastig
            texti.text = "Lokastig " + PlayerMovment.count.ToString();
        }
        
    }

    public void Byrja()
    {
        // function sem er notuð á start tökkunum til að byrja á level 1
        SceneManager.LoadScene(1);
    }
    // þegar leikurinn er búinn þá loadast sena 3
    public void Endir()
    {
        SceneManager.LoadScene(3);
        // og count er endursett í 0
        PlayerMovment.count = 0;
    }
    
}
