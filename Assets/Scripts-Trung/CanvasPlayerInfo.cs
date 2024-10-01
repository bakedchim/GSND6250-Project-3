using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasPlayerInfo : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public TMP_Text healthText;
    public TMP_Text ammoText;
    
    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + playerInfo.playerCurrentHealth + "/" + playerInfo.playerMaxHealth;
        ammoText.text = "Ammo: " + playerInfo.playerCurrentAmmo + "/" + playerInfo.playerMaxAmmo;
    }
}
