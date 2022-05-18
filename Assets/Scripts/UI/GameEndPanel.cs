using UnityEngine;
using UnityEngine.UI;

public class GameEndPanel : MonoBehaviour
{
    [SerializeField] private Text _gameEndText;

    public void Open(string text)
    {
        _gameEndText.text = text;
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}