using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBatterieManager : MonoBehaviour
{
    int batterieSlot = 5;// 5+1 bcz list
    float BatterieSlotTimer = 5f;
    [SerializeField] List<GameObject> batterieslots = new List<GameObject>();
    [SerializeField] Light flashLight;
    bool hasChanged;
    [SerializeField] Animator LightAnime;

    public static LightBatterieManager instance {  get; private set; }
    private void Update()
    {
        if(batterieSlot >= 0)
        {
            BatterieSlotTimer -= Time.deltaTime;

            if (BatterieSlotTimer < 0 && !hasChanged)
            {
                hasChanged = true;
                batterieSlot--;
                UpdateBatterieLvl();
                flashLight.intensity -= 2;
                BatterieSlotTimer = 5f;
            }
        }

        if(batterieSlot < 0)
        {
            flashLight.gameObject.SetActive(false);
        }
      
    }
    public void TriggerLightHorrorAction() // 1 -> 5
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
        if(batterieSlot <= 0)
        {
            flashLight.gameObject.SetActive(true);
        }
        batterieSlot++;
        flashLight.intensity += 2;

    }
}
