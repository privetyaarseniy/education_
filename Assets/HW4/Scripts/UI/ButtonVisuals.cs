using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ButtonVisuals : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private Color _onMouseDownTextColor;
    [SerializeField]
    private Sprite _onMouseDownSprite;

    private TextMeshProUGUI _text;
    private Image _image;
    private Color _baseColor;

    private void Awake()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _image = GetComponent<Image>();

        _baseColor = _text.color;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _text.color = _onMouseDownTextColor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _text.color = _baseColor;
    }
}
