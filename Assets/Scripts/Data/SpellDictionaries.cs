using System.Collections.Generic;
using UnityEngine;

public class SpellDictionaries : MonoBehaviour {

    public static Dictionary<string, string> FirenadoDictionary = new Dictionary<string, string>();
    public static Dictionary<string, string> WaterOrbDictionary = new Dictionary<string, string>();
    public static Dictionary<string, string> EarthDictionary = new Dictionary<string, string>();
    public static Dictionary<string, string> LightningDictionary = new Dictionary<string, string>();
    public static Dictionary<string, string> LightBeamDictionary = new Dictionary<string, string>();
    public static Dictionary<string, string> DarknessDictionary = new Dictionary<string, string>();

    private void Awake()
    {
        FillFireDict();
        FillWaterDict();
        FillEarthDict();
        FillLighningDict();
        FillLightDict();
        FillDarknessDict();
    }

    void FillFireDict()
    {
        DictionaryUtilities.CheckOrAddToDict(FirenadoDictionary, "Firenado", SpellComboTypes.FIRE);
        DictionaryUtilities.CheckOrAddToDict(FirenadoDictionary, "Firenado2", SpellComboTypes.FIRE2);
    }

    void FillWaterDict()
    {
        DictionaryUtilities.CheckOrAddToDict(WaterOrbDictionary, "WaterOrb", SpellComboTypes.WATER);
        DictionaryUtilities.CheckOrAddToDict(WaterOrbDictionary, "WaterOrb2", SpellComboTypes.WATER2);
        DictionaryUtilities.CheckOrAddToDict(WaterOrbDictionary, "WaterOrb3", SpellComboTypes.WATER3);
        DictionaryUtilities.CheckOrAddToDict(WaterOrbDictionary, "WaterOrb4", SpellComboTypes.WATER4);
        DictionaryUtilities.CheckOrAddToDict(WaterOrbDictionary, "WaterOrb5", SpellComboTypes.WATER5);
        DictionaryUtilities.CheckOrAddToDict(WaterOrbDictionary, "WaterOrb6", SpellComboTypes.WATER6);
        DictionaryUtilities.CheckOrAddToDict(WaterOrbDictionary, "WaterOrb7", SpellComboTypes.WATER7);
        DictionaryUtilities.CheckOrAddToDict(WaterOrbDictionary, "WaterOrb8", SpellComboTypes.WATER8);
    }

    void FillEarthDict()
    {
        DictionaryUtilities.CheckOrAddToDict(EarthDictionary, "Earth", SpellComboTypes.EARTH);
        DictionaryUtilities.CheckOrAddToDict(EarthDictionary, "Earth2", SpellComboTypes.EARTH2);
    }

    void FillLighningDict()
    {
        DictionaryUtilities.CheckOrAddToDict(LightningDictionary, "Lightning", SpellComboTypes.LIGHTNING);
        DictionaryUtilities.CheckOrAddToDict(LightningDictionary, "Lightning2", SpellComboTypes.LIGHTNING2);
    }

    void FillLightDict()
    {
        DictionaryUtilities.CheckOrAddToDict(LightBeamDictionary, "Light", SpellComboTypes.LIGHT);
        DictionaryUtilities.CheckOrAddToDict(LightBeamDictionary, "Light2", SpellComboTypes.LIGHT2);
    }

    void FillDarknessDict()
    {
        DictionaryUtilities.CheckOrAddToDict(DarknessDictionary, "Darkness", SpellComboTypes.DARK);
        DictionaryUtilities.CheckOrAddToDict(DarknessDictionary, "Darkness2", SpellComboTypes.DARK2);
        DictionaryUtilities.CheckOrAddToDict(DarknessDictionary, "Darkness3", SpellComboTypes.Dark3);
        DictionaryUtilities.CheckOrAddToDict(DarknessDictionary, "Darkness4", SpellComboTypes.Dark4);
        DictionaryUtilities.CheckOrAddToDict(DarknessDictionary, "Darkness5", SpellComboTypes.Dark5);
        DictionaryUtilities.CheckOrAddToDict(DarknessDictionary, "Darkness6", SpellComboTypes.Dark6);
        DictionaryUtilities.CheckOrAddToDict(DarknessDictionary, "Darkness7", SpellComboTypes.Dark7);
        DictionaryUtilities.CheckOrAddToDict(DarknessDictionary, "Darkness8", SpellComboTypes.Dark8);
        DictionaryUtilities.CheckOrAddToDict(DarknessDictionary, "Darkness9", SpellComboTypes.Dark9);
        DictionaryUtilities.CheckOrAddToDict(DarknessDictionary, "Darkness10", SpellComboTypes.Dark10);
        DictionaryUtilities.CheckOrAddToDict(DarknessDictionary, "Darkness11", SpellComboTypes.Dark11);
        DictionaryUtilities.CheckOrAddToDict(DarknessDictionary, "Darkness12", SpellComboTypes.Dark12);
        DictionaryUtilities.CheckOrAddToDict(DarknessDictionary, "Darkness13", SpellComboTypes.Dark13);
        DictionaryUtilities.CheckOrAddToDict(DarknessDictionary, "Darkness14", SpellComboTypes.Dark14);
        DictionaryUtilities.CheckOrAddToDict(DarknessDictionary, "Darkness15", SpellComboTypes.Dark15);
        DictionaryUtilities.CheckOrAddToDict(DarknessDictionary, "Darkness16", SpellComboTypes.Dark16);
    }
}