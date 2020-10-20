using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitView : MonoBehaviour
{
    private UnitModel _model;

    public UnitModel Model => _model;

    public void Initialize(UnitModel unitModel)
    {
        _model = unitModel;
    }

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = _model.Skin;
    }

    private void Update()
    {
        if (Model.IsDead == true)
        {
            _model = null;
            // return view to the pool
        }

        transform.position = Model.Position;
    }
}
