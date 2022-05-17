using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsGenerator : MonoBehaviour
{
    #region Declarations

    // Object To Be Regenerated //

    [SerializeField] private GameObject _object;

    // Position //

    [SerializeField] private Transform _objectGenerator;

    #endregion

    #region Regenerate Objects

    // Call Regenerator //

    public void Regenerate()
    {
        StartCoroutine(RegenerateWorldObject());
    }
       

    public IEnumerator RegenerateWorldObject()
    {
        // Time To Complete Regeneration //

        yield return new WaitForSeconds(10f);

        // Regenerator //

        GameObject newIten = Instantiate(_object, _objectGenerator);

       

    }

    #endregion

}
