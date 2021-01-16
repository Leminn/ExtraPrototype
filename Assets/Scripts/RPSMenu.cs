using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class RPSMenu : MonoBehaviour
{
    [Header("Buttons")]

    public Image SwordButton;
    public Image ShieldButton;
    public Image BreakButton;

    [Header("Sliders")]

    public Slider playerHPBar;
    public Slider playerMPBar;
    public Slider enemyHPBar;

    [Header("Text Elements")]

    public TextMeshProUGUI playerHPText;
    public TextMeshProUGUI playerMPText;
    public TextMeshProUGUI enemyHPText;

    public Animator attackPrompt;

    GameObject[] PlayerTurnIcons = { null, null, null, null, null, null };
    GameObject[] EnemyTurnIcons = { null, null, null, null, null, null };

    StringBuilder playerQueue;

    BattleManager battleManager;

    string selectedOption;

    int currentTurnIcon;

    // Use this for initialization
    void Start()
    {
        battleManager = GetComponent<BattleManager>();
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
        SetMaxStats();
        ResetColors();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            SetStats();
            print(playerQueue);
            print(battleManager.RPSCheckAllTurns(playerQueue.ToString()));
        }
        if (Input.GetKeyDown(KeyCode.R))
        {

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
                    if (currentTurnIcon != 5) { currentTurnIcon++; }
                    else { attackPrompt.SetBool("PromptReady", true); }
                    
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
                attackPrompt.SetBool("PromptReady", false);
                PlayerTurnIcons[currentTurnIcon].transform.Find("IconAnim").gameObject.SetActive(false);
                currentTurnIcon--;
                PlayerTurnIcons[currentTurnIcon].transform.Find("IconAnim").gameObject.SetActive(true);
            }
        }
    }
    
    string FourDigits(int input)
    {
        switch (Math.Floor(Math.Log10(input) + 1))
        {
            case 1:
                return "000" + input;
                
            case 2:
                return "00" + input;

            case 3:
                return "0" + input;
        }
        return input.ToString();
    }
    void SetMaxStats()
    {
        playerHPBar.maxValue = battleManager.playerMaxHealth;
        playerHPBar.value = battleManager.playerHealth;
        playerHPText.text = FourDigits(battleManager.playerHealth);

        playerMPBar.maxValue = battleManager.playerMaxMagic;
        playerMPBar.value = battleManager.playerMagic;
        playerMPText.text = FourDigits(battleManager.playerMagic);

        enemyHPBar.maxValue = battleManager.enemyHealth;
        enemyHPBar.value = battleManager.enemyHealth;
        enemyHPText.text = FourDigits(battleManager.enemyHealth);

    }

    public void SetStats()
    {
        
        playerHPBar.value = battleManager.playerHealth;
        playerMPBar.value = battleManager.playerMagic;
        enemyHPBar.value = battleManager.enemyHealth;
    }
}
