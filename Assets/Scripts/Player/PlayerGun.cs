using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{

    private PlayerUI playerUI;
    private InputManager inputManager;

    public GunSystem gunSystem;


    void Start()
    {
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
        // gunSystem = GetComponent<GunSystem>();
    }

    void Update()
    {
        string ammoText = GenerateAmmoText();
        if(gunSystem.bulletsLeft <= 0)
            playerUI.UpdateAmmoText(ammoText, Color.red);
        else
            playerUI.UpdateAmmoText(ammoText, Color.white);
    }

    // May need optimization
    string GenerateAmmoText()
    {
        return $"{gunSystem.bulletsLeft} / {gunSystem.magazineSize}"; 
    }
}
