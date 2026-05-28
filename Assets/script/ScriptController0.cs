using UnityEngine;

public class ScriptController : MonoBehaviour
{
    [Header("Scripts da câmera")]
    public MonoBehaviour followCameraScript;

    [Header("Câmera normal")]
    public Camera mainCamera;

    [Header("Modo ativado")]
    private bool usandoFollow = true;

    void Update()
    {
        // Aperta F para trocar
        if (Input.GetKeyDown(KeyCode.F))
        {
            usandoFollow = !usandoFollow;

            // Liga/desliga script
            followCameraScript.enabled = usandoFollow;

            Debug.Log("Modo câmera: " + usandoFollow);
        }
    }
}