using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    
    public Image healthbar;
    public Image healtBarEffect;
    float maxhealth = 100f;
    public static float health;

    private float healthspeed = 0.003f;

    void Start()
    {
       healthbar = GetComponent<Image>();
       health = maxhealth;
    }

    void Update()
    {
        healthbar.fillAmount = health / maxhealth;
        if(healtBarEffect.fillAmount > healthbar.fillAmount) {
            healtBarEffect.fillAmount -= healthspeed;
        } else {
            healtBarEffect.fillAmount = healthbar.fillAmount;
        }
        if (health == 0)
        {
        SceneManager.LoadScene("Menu");
        }
    }
    void maxHp(){
        if(health < 100){
            health += 20;
        }
    }
    void minHp(){
        if(health > 100){
            health = 100;
        }
    }
}
