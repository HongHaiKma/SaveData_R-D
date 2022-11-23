using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(
        fileName = "CharacterSavedDataCollection.asset",
        menuName = SOArchitecture_Utility.COLLECTION_SUBMENU + "CharacterSavedData",
        order = 120)]
    public class Test : Collection<HeroTest>
    {

    }

    public class HeroTest
    {

    }
}