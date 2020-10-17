using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitExhaustView : MonoBehaviour
{
    private UnitModel _model;
    private Vector3 _previousPosition = Vector3.zero;

    [SerializeField] private GameObject _backExhaust;
    [SerializeField] private GameObject _topExhaust;
    [SerializeField] private GameObject _bottomExhaust;

    // Start is called before the first frame update
    private void Start()
    {
        _model = gameObject.GetComponent<UnitView>().Model;
        _previousPosition = _model.Position;
        
        // Disable view
        _bottomExhaust.SetActive(false);
        _topExhaust.SetActive(false);
    }

    private void Update()
    {
        if (_model.Position.y > _previousPosition.y)
        {
            _bottomExhaust.SetActive(true);
        }
        else if (_model.Position.y < _previousPosition.y)
        {
            _topExhaust.SetActive(true);
        }
        else
        {
            _bottomExhaust.SetActive(false);
            _topExhaust.SetActive(false);
        }

        _previousPosition = _model.Position;
    }


}
