using UnityEngine;
using UnityEngine.UI;

public class UIBar : MonoBehaviour
{
    public Image fillImage;
    public StatManager statManager;
    public StatID statID;
    Stat stat;

    void Start()
    {
        if ((stat = statManager.ReadStat(statID)) != null)
        {
            stat.OnValueChanged += UpdateBar;
        }

        UpdateBar();
    }

    void UpdateBar()
    {
        if (fillImage != null && stat != null)
            fillImage.fillAmount = stat.maxValue <= 0 ? 0f : stat.currentValue / stat.maxValue;
        else
            Debug.Log("UpdateBar() isn't working!");
    }

    private void OnDisable()
    {
        stat.OnValueChanged -= UpdateBar;
    }
}
