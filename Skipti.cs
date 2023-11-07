using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skipti : MonoBehaviour
{
    void Start()
    {

    }

    // þegar þú snertir trigger byrjar næsta sena
   private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false); 
        // með 2 sekúndu bið
        StartCoroutine(Bida());
    }

    // bida er fall sem bíður í 2 sek og loadar næstu senu
    IEnumerator Bida()
    {
        yield return new WaitForSeconds(2);
        Endurræsa();
    }


    public void Endurræsa()
    {
        // loadar næstu senu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);//næsta sena
        // ef senan er númer 3
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            // endursetur stigateljarann
            PlayerMovment.count = 0;
        }
    }

}
