using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{

    public Image background;
    public TMP_Text winConText;
    public TMP_Text time;
    public TMP_Text bossText;
    private GameObject the_player;
    [SerializeField] private GameObject Button;
    [SerializeField] private GameObject BlackScreen;
    [SerializeField] private List<GameObject> cacoDemons;
    private int timeScore;

    // Start is called before the first frame update
    void Start()
    {

        the_player = GameObject.Find("Player");
        background.gameObject.GetComponent<Image>().enabled = false;
        winConText.enabled = false;
        Button.SetActive(false);
        BlackScreen.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        WinConditions();
        time.text = "Time: " + timeScore;
        bossText.text = "Bosses Left: " + (cacoDemons.Count);
    }

    void WinConditions()
    {
        
        if(background.gameObject.GetComponent<Image>().enabled == false)
        {
            timeScore = (int)Time.timeSinceLevelLoad;
        }


        if(the_player.GetComponent<PlayerController>().PlayerHP<=0)
        {

            background.gameObject.GetComponent<Image>().enabled = true;
            winConText.enabled = true;
            Button.SetActive(true);
            BlackScreen.SetActive(true);
            winConText.text = "GAME OVER!";
            
        }else{

            for(int i=0; i<cacoDemons.Count; i++){

                if(cacoDemons[i] == null)
                {
                    cacoDemons.RemoveAt(i);
                    
                }
            }
            
            if(cacoDemons.Count == 0)
            {
                background.gameObject.GetComponent<Image>().enabled = true;
                winConText.enabled = true;
                Button.SetActive(true);
                BlackScreen.SetActive(true);
                winConText.text = "VICTORY!";
            }
        }

    }


}
