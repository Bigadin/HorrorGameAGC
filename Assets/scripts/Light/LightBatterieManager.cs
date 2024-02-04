using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBatterieManager : MonoBehaviour
{
    int batterieSlot = 5;// 5+1 bcz list
    float BatterieSlotTimer;
    [SerializeField] List<GameObject> batterieslots = new List<GameObject>();
    [SerializeField] Light flashLight;
    bool hasChanged;
    [SerializeField] Animator LightAnime;
    private bool lightTorchOn;
    [SerializeField] float LightTorcheBatteriePerSlot = 10;

    public static LightBatterieManager instance { get; private set; }

    private void Start()
    {
        instance = this;
        BatterieSlotTimer = LightTorcheBatteriePerSlot;
    }
    private void Update()
    {

        BatterieSlotTimerCounter();
        if (batterieSlot < 0)
        {
            flashLight.gameObject.SetActive(false);
        }
        InputManager();


    }
    void InputManager()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TriggerLightHorrorAction();
        }
        if (Input.GetMouseButtonDown(1))
        {
            // sound for torche tiktak
            lightTorchOn = !lightTorchOn;
            flashLight.gameObject.SetActive(lightTorchOn);
        }
    }
    void BatterieSlotTimerCounter()
    {
        if (batterieSlot >= 0 && lightTorchOn)
        {
            BatterieSlotTimer -= Time.deltaTime;

            if (BatterieSlotTimer < 0 && !hasChanged)
            {
                hasChanged = true;
                batterieSlot--;
                UpdateBatterieLvl();
                flashLight.intensity -= 20;
                BatterieSlotTimer = LightTorcheBatteriePerSlot;
            }
        }
    }
    public void TriggerLightHorrorAction() // .2 -> 2
    {
        LightAnime.SetTrigger("onOff");

    }
    public void UpdateBatterieLvl()
    {
        for (int i = 0; i < batterieslots.Count; i++)
        {
            if (i > batterieSlot)
            {
                batterieslots[i].SetActive(false);
            }
            else
            {
                batterieslots[i].SetActive(true);

            }
        }
        hasChanged = false;

    }
    public void addBattery()
    {
        if (batterieSlot <= 0)
        {
            flashLight.gameObject.SetActive(true);
        }
        batterieSlot++;
        flashLight.intensity += 2;

    }
}
