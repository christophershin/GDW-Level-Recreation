using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{

    public Image background;
    public TMP_Text winConText;
    private GameObject the_player;
    [SerializeField] private GameObject Button;
    [SerializeField] private GameObject BlackScreen;

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
    }

    void WinConditions()
    {
        if(the_player.GetComponent<PlayerController>().PlayerHP<=0)
        {

            background.gameObject.GetComponent<Image>().enabled = true;
            winConText.enabled = true;
            Button.SetActive(true);
            BlackScreen.SetActive(true);
            winConText.text = "GAME OVER!";
            
        }

    }


}
