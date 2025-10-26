using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
public class NetworkUi : MonoBehaviour
{
    [SerializeField] private Button startHostButton;
    [SerializeField] private Button startClientButton;

    private void Awake()
    {
        startHostButton.onClick.AddListener((() =>
        {
            NetworkManager.Singleton.StartHost();
            Hide();
        }));
        startClientButton.onClick.AddListener((() =>
        {
            NetworkManager.Singleton.StartClient();
            Hide();
        }));
    }
    private void Hide()
    {
        startHostButton.gameObject.SetActive(false);
        startClientButton.gameObject.SetActive(false);
    }
}
