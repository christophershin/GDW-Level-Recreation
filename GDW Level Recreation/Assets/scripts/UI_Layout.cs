using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Layout : MonoBehaviour
{

    public Image hpIcon;
    public TMP_Text num;
    private GameObject player;

    private List<Image> icons = new();
    private int numShown;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("Player");
        numShown  = player.GetComponent<PlayerController>().MaxPlayerHP;
        

        for(int i=0; i<numShown; ++i)
        {
            Image icon = Instantiate(hpIcon);
            icon.rectTransform.SetParent(transform, false);
            icons.Add(icon);
        }
    }

    // Update is called once per frame
    void Update()
    {   
        num.text = "Player: " + numShown;
        if(numShown!=player.GetComponent<PlayerController>().PlayerHP && numShown!=0)
        {

            numShown = player.GetComponent<PlayerController>().PlayerHP;
            

            for(int i=numShown; i<icons.Count; ++i)
            {
                icons[i].gameObject.SetActive(false);

            }

        }

    }
}
