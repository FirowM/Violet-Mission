using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayIten : MonoBehaviour
{

    #region Declarations

    //Itens Properties In Game//

    [SerializeField] private ItenCreator _iten;

    [SerializeField] Text _textQNT;

    [SerializeField] Text _textNAME;

    [SerializeField] RawImage _icon;

    #endregion

    #region Start and Update

    void Start()
    {
        _textQNT.text = "" + _iten.Quantity;
        _icon.texture = _iten.Icon;
        _textNAME.text = "" + _iten.ItenName;
    }

       
    void Update()
    {
        
    }

    #endregion
}
