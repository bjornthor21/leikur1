using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using TMPro;

public class PlayerMovment : MonoBehaviour
{
    // breytur sem skilgreina hraða leikmanns og kraft stökks
    public float speed = 0.2f;
    public float sideways = 0.2f;
    public float jump = 0.2f;

    // breyta sem heldur utan um stig
    public static int count;
    public TextMeshProUGUI countText;

    void Start()
    {
        Debug.Log("byrja");
    }

    // 50 sinnum á sekúndu
    void FixedUpdate()
    {
        //áfram
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += transform.forward * speed ;
        }
        // til baka
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += -transform.forward * speed;

        }
        //hægri
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += transform.right * sideways;
        }
        //vinstri
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //hreyfir player um sideways í hvert skipti sem ýtt er á leftArrow
            transform.position += -transform.right * sideways;
        }
        // stökkva
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position +=transform.up *jump;
        }
        
        // snúa leikmanni
        if (Input.GetKey("g"))
        {
            transform.Rotate(new Vector3(0, 5, 0));
        }
        if (Input.GetKey("f"))
        {
            transform.Rotate(new Vector3(0, -5, 0));
        }

        if (Input.GetKey("q"))// ef ýtt er á q
        {
            // endursetur stöðu leikmanns til að snúa fram og beint
            transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }

        // ef leikmaður festist á einhvern hátt er hægt að ýta á r til að endursetja leikinn
        if (Input.GetKey("r"))
        {
            Restart();
        }

        // ef leikmaður dettur af platform þá endursetist leikurinn
        if (transform.position.y <= -1)
        {
            Restart();
        }
        
    }

    // collision á mismundani hlutum
    void OnCollisionEnter(Collision collision)
    {
        // ef leikmaður snertir pening þá hækka stig um 3
        if (collision.collider.tag == "pikk")
        {
            // eyðir pening
            collision.collider.gameObject.SetActive(false);
            count = count + 3;
            // uppfærir stiga teljarann
            SetCountText();
        }

        // ef leikmaður snertir hindrun þá lækka stig um 3
        if (collision.collider.tag == "hindrun")
        {
            count = count - 3;
            // uppfærir stiga teljarann
            SetCountText();
        }
    }

    // skrifar stig á stiga teljarann
    void SetCountText()
    {
        countText.text = "STIG: " + count.ToString();

        // ef stig verða 0 eða minna þá er leikmaður dauður og stiga teljarinn uppfærist
        if (count <= 0)
        {
            this.enabled = false;//kemur í veg fyrir að playerinn geti hreyfst áfram eftir dauðan
            countText.text = "Dauður Stig: " + count.ToString();

            // enduræsist með 2 sekúndu bið
            StartCoroutine(Bida());
        }

    }

    // tveggja sekúnda bið
    IEnumerator Bida()
    {
        yield return new WaitForSeconds(2);
        Restart();
    }

    // byrjar á senu notað til í byrjunar senu
    public void Byrja()
    {
        SceneManager.LoadScene(1);
    }

    // endursetur leikinn og stiga teljarann
    public void Restart()
    {
        count = 0;
        SceneManager.LoadScene(0);
    }

}
