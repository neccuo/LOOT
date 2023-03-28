using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI promptText;
    [SerializeField] private TextMeshProUGUI ammoText;

    [SerializeField] private Image crosshair;
    // crosshair add-on when hitting the enemy
    [SerializeField] private GameObject hitMark;


    [SerializeField] private Sprite defaultCH;
    [SerializeField] private Sprite interactCH;

    private void Awake() 
    {
        Cursor.visible = false;
        HitMarkActive(false);
    }

    public void UpdatePromptText(string promptMessage)
    {
        promptText.text = promptMessage;
    }

    public void UpdateAmmoText(string ammoInfo)
    {
        ammoText.text = ammoInfo;
    }

    public void UpdateAmmoText(string ammoInfo, Color color)
    {
        ammoText.text = ammoInfo;
        ammoText.color = color;
    }

    public void HitMarkActive(bool isActive)
    {
        hitMark.SetActive(isActive);
    }

    public void DefaultCrosshair()
    {
        crosshair.transform.localScale = new Vector3(0.75f, 0.75f, 1.0f);
        crosshair.color = Color.white;
        crosshair.sprite = defaultCH;
    }

    public void InteractCrosshair()
    {
        crosshair.transform.localScale = new Vector3(0.25f, 0.25f, 1.0f);
        crosshair.color = Color.green;
        crosshair.sprite = interactCH;
    }
}
