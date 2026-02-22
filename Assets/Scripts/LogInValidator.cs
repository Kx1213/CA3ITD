using UnityEngine;
using TMPro;

public class LoginValidator : MonoBehaviour
{
    [Header("Input Fields")]
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;

    [Header("Correct Credentials")]
    public string correctUsername = "admin";
    public string correctPassword = "1234";

    private bool isVerified = false;
    // SceneLoader reference
    public SceneLoader sceneLoader;
    public string nextSceneName;

    public void TryLogin()
    {
        string u = usernameField.text;
        string p = passwordField.text;

        if (u == correctUsername && p == correctPassword)
        {
            isVerified = true;
            Debug.Log("Login Success!");
        }
        else
        {
            isVerified = false;
            Debug.Log("Wrong username or password!");
        }
    }

    public void TryTeleport()
    {
        if (isVerified)
        {
            sceneLoader.LoadSceneByName(nextSceneName);
        }
        else
        {
            Debug.Log("Access denied. Wrong username or password.");
        }
    }
}
