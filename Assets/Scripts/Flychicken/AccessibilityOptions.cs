using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AccessibilityOptions : MonoBehaviour
{
    public Toggle staminaToggle;
    public Toggle fallProtectionToggle;

    private const string EstaminaKey = "EstaminaActivada";
    private const string ProteccionCaidaKey = "ProteccionCaidaActivada";

    void Start()
    {
        // Agrega oyentes a los eventos onValueChanged de los toggles
        staminaToggle.onValueChanged.AddListener(OnStaminaToggleValueChanged);
        fallProtectionToggle.onValueChanged.AddListener(OnFallProtectionToggleValueChanged);
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("EstaminaActivada", 0) == 1)
        {
            staminaToggle.SetIsOnWithoutNotify(true);
        }

        if (PlayerPrefs.GetInt("ProteccionCaidaActivada", 0) == 1)
        {
            fallProtectionToggle.SetIsOnWithoutNotify(true);
        }
    }

    void OnStaminaToggleValueChanged(bool isOn)
    {
        PlayerPrefs.SetInt(EstaminaKey, isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    void OnFallProtectionToggleValueChanged(bool isOn)
    {
        PlayerPrefs.SetInt(ProteccionCaidaKey, isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
}
