using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class RPSMenu : MonoBehaviour
{


    public Image SwordButton;
    public Image ShieldButton;
    public Image BreakButton;

    public Animator attackPrompt;

    GameObject[] PlayerTurnIcons = { null, null, null, null, null, null };
    GameObject[] EnemyTurnIcons = { null, null, null, null, null, null };

    StringBuilder playerQueue;

    string selectedOption;

    int currentTurnIcon;

    // Use this for initialization
    void Start()
    {
        playerQueue = new StringBuilder("NNNNNN");
        selectedOption = "Sword";
        GameObject TurnIcons = GameObject.Find("TurnIcons");
        for(int i = 0; i < 6; i++)
        {
            int currentTurn = i + 1;
            GameObject CurrentTurnIcons = TurnIcons.transform.Find("Turn" + currentTurn + "Icons").gameObject;
            PlayerTurnIcons[i] = CurrentTurnIcons.transform.Find("PlayerT").gameObject;
            EnemyTurnIcons[i] = CurrentTurnIcons.transform.Find("EnemyT").gameObject;
        }
        PlayerTurnIcons[0].transform.Find("IconAnim").gameObject.SetActive(true);

        ResetColors();
    }

    // Update is called once per frame
    void Update()
    {
        attackPrompt.SetInteger("MoveEntered", currentTurnIcon);
        MenuInput();

    }

    void ResetColors() {
        SwordButton.color = new Color32(255, 255, 255, 125);
        ShieldButton.color = new Color32(255, 255, 255, 125);
        BreakButton.color = new Color32(255, 255, 255, 125);
    }

    void MenuInput() {
        if (Input.GetKeyDown(KeyCode.T))
        {
            print(playerQueue);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedOption = "Sword";
            ResetColors();
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectedOption = "Shield";
            ResetColors();
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectedOption = "Break";
            ResetColors();
        }
        switch (selectedOption)
        {
            case "Sword":
                SwordButton.color = new Color32(255, 255, 255, 255);
                break;
            case "Shield":
                ShieldButton.color = new Color32(255, 255, 255, 255);
                break;
            case "Break":
                BreakButton.color = new Color32(255, 255, 255, 255);
                break;
        }

        if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Z)) && currentTurnIcon < 6)
        {
            switch(selectedOption){
                case "Sword":
                    playerQueue[currentTurnIcon] = 'A';
                    PlayerTurnIcons[currentTurnIcon].GetComponent<Image>().sprite = SwordButton.GetComponent<Image>().sprite;
                    PlayerTurnIcons[currentTurnIcon].transform.Find("IconAnim").gameObject.SetActive(false);
                    if(currentTurnIcon != 5) { currentTurnIcon++; }
                    
                    PlayerTurnIcons[currentTurnIcon].transform.Find("IconAnim").gameObject.SetActive(true);
                    break;

                case "Shield":
                    playerQueue[currentTurnIcon] = 'G';
                    PlayerTurnIcons[currentTurnIcon].GetComponent<Image>().sprite = ShieldButton.GetComponent<Image>().sprite;
                    PlayerTurnIcons[currentTurnIcon].transform.Find("IconAnim").gameObject.SetActive(false);
                    if (currentTurnIcon != 5) { currentTurnIcon++; }
                    PlayerTurnIcons[currentTurnIcon].transform.Find("IconAnim").gameObject.SetActive(true);
                    break;

                case "Break":
                    playerQueue[currentTurnIcon] = 'B';
                    PlayerTurnIcons[currentTurnIcon].GetComponent<Image>().sprite = BreakButton.GetComponent<Image>().sprite;
                    PlayerTurnIcons[currentTurnIcon].transform.Find("IconAnim").gameObject.SetActive(false);
                    if (currentTurnIcon != 5) { currentTurnIcon++; }
                    PlayerTurnIcons[currentTurnIcon].transform.Find("IconAnim").gameObject.SetActive(true);
                    break;
            }
        }
        else if(Input.GetKeyDown(KeyCode.X)){
            if(!((currentTurnIcon - 1) < 0)) {
                PlayerTurnIcons[currentTurnIcon].transform.Find("IconAnim").gameObject.SetActive(false);
                currentTurnIcon--;
                PlayerTurnIcons[currentTurnIcon].transform.Find("IconAnim").gameObject.SetActive(true);
            }
        }
    }
}
