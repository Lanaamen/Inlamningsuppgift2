using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWon : MonoBehaviour
{
    private int numberOfStumps=6;
    public GameObject youWonScreen;

    //Metod f�r att �terst�lla numberOfStumps och s�tta youWonScreen som falsk, denna metod kallas
    // i skriptet bowlingReset, s� att �ven dessa �terst�lls n�r stumparna �terst�lls
    public void Restart()
    {
        //�terst�ller numberOfStumps till 6
       numberOfStumps=6; 
       //S�tter youWonScreen som falsk
       youWonScreen.SetActive(false);
    }

  //Metod f�r n�r bowlingstumparna tr�ffas och om man f�r en strike och d� vinner, eller ej
  private void OnCollisionEnter(Collision collision)
    {
        //Om gamobjektet(bowlingstone) tr�ffar gameobjekt med tagg bowlingstumps
        if (collision.collider.CompareTag("Bowlingstumps"))
        {
            //Om numberOfStumps �r st�rre �n 0, allts� om man inte kolliderat med samtliga 6
            if (numberOfStumps> 0) 
            {
                //Subtrahera 1 fr�n numberOfStumps samt inaktivera den kolliderade stumpen
                numberOfStumps=numberOfStumps-1;
                collision.collider.gameObject.SetActive(false);

                //om numberOfStumps �r 0 eller likamed 0 s� aktiveras youWonScreen
                if (numberOfStumps == 0) 
                
                {
                    youWonScreen.SetActive(true);
                }
            }
            
        }
    }

   
}
