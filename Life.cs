using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public Image healthFill;
    public float maxWidth = 200f;

    private float currentWidth;

    private void Awake()
    {
        currentWidth = maxWidth;
    }

    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        float healthPercentage = currentHealth / maxHealth;
        float newWidth = maxWidth * healthPercentage;

        healthFill.rectTransform.sizeDelta = new Vector2(newWidth, healthFill.rectTransform.sizeDelta.y);
    }
}
