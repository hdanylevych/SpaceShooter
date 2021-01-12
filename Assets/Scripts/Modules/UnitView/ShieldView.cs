using UnityEngine;

public class ShieldView : MonoBehaviour
{
    private const float MinShieldColorAlpha = 0.2f;
    private const float MaxShieldColorAlpha = 1f;
    private readonly string ShieldsSpritesLocation = "Shields";

    private Color _shieldColor = new Color(1, 1, 1, MinShieldColorAlpha);

    private Sprite[] _shieldSprites;
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private UnitView _unitView;

    // Start is called before the first frame update
    void Start()
    {
        _shieldSprites = Resources.LoadAll<Sprite>(ShieldsSpritesLocation);
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _spriteRenderer.color = _shieldColor;
        SetCurrentShieldSprite();

        this._unitView.Model.Attacked += OnUnitAttacked;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, -0.1f);
        SetCurrentShieldSprite();

        _shieldColor.a = Mathf.Max(MinShieldColorAlpha, _shieldColor.a - 0.001f);
        _spriteRenderer.color = _shieldColor;
    }

    private void SetCurrentShieldSprite()
    {
        int currentShieldIndex = Mathf.RoundToInt(_shieldSprites.Length * _unitView.Model.Health / _unitView.Model.MaxHealth);

        currentShieldIndex = _shieldSprites.Length - currentShieldIndex;
        currentShieldIndex = currentShieldIndex == _shieldSprites.Length ? currentShieldIndex - 1 : currentShieldIndex;
        currentShieldIndex = currentShieldIndex < 0 ? 0 : currentShieldIndex;

        _spriteRenderer.sprite = _shieldSprites[currentShieldIndex];
    }

    private void OnUnitAttacked(UnitModel model, IAttacker attacker)
    {
        _shieldColor.a = Mathf.Min(MaxShieldColorAlpha, _shieldColor.a + 0.15f);
        _spriteRenderer.color = _shieldColor;
    }
}
