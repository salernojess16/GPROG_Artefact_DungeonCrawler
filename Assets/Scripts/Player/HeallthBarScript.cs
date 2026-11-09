using UnityEngine;
using UnityEngine.UI;
public class HeallthBarScript : MonoBehaviour
{
    public Slider healthBarSlider;
    public PlayerStats playerStats;

    public float maxHealth = 100;

    void Start()
    {
        healthBarSlider.maxValue = maxHealth;
    }

    void Update()
    {
        healthBarSlider.value = playerStats.hp;
    }
}
