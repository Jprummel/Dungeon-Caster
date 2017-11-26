using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryUtilities : MonoBehaviour {

    public static T CheckOrAddToDict<T>(Dictionary<T,T> dictToCheck, T keyToCheck, T valueToAdd)
    {
        if (!dictToCheck.ContainsKey(keyToCheck))
        {
            dictToCheck.Add(keyToCheck,valueToAdd);
        }
        return keyToCheck;
    }
}
