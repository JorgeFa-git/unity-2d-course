using UnityEngine;

public class FlickerColor : MonoBehaviour
{
    private int _modifier = 1;

    private Color _color;
    
    private SpriteRenderer _spriteRenderer;
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _color = _spriteRenderer.color;
    }

    void Update()
    {
        if (_color.a <= 1f && _color.a >= 0)
        {
            _color += new Color(0, 0, 0, .3f * Time.deltaTime * _modifier);
            
            _color = _spriteRenderer.color.a < 0 ? new Color(_color.r, _color.g, _color.b, 0) : _color;
            _color = _color.a > 1 ? new Color(_color.r, _color.g, _color.b, 1) : _color;
        }
        
        if ((int)_color.a == 0 || _color.a.Equals(1f)) _modifier *= -1;

        _spriteRenderer.color = _color;
    }
}
