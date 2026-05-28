using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject hoodCamera;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            mainCamera.SetActive(!mainCamera.activeSelf);
            hoodCamera.SetActive(!hoodCamera.activeSelf);
        }
    }
}