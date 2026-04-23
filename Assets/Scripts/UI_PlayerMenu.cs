using UnityEngine;

public class UI_PlayerMenu : MonoBehaviour
{
    private bool IsOpen { get; set; }

    private void Awake() {
        gameObject.SetActive(true);

        IsOpen = false;
        gameObject.SetActive(IsOpen);
    }

    public void ToggleView()
    {
        IsOpen = !IsOpen;
        gameObject.SetActive(IsOpen);
    }
}
