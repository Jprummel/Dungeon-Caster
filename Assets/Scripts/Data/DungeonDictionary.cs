using UnityEngine;

public class DungeonDictionary : MonoBehaviour {
    
	void Awake () { 
        CheckOrAddKey(LevelNames.TUTORIAL);
        CheckOrAddKey(LevelNames.CAVE);
        CheckOrAddKey(LevelNames.RUINS);
        CheckOrAddKey(LevelNames.OUTSIDE_RUINS);
        CheckOrAddKey(LevelNames.LAVA);
        CheckOrAddKey(LevelNames.JUNGLE_TEMPLE);
	}
    
    void CheckOrAddKey(string keyToCheck)
    {
        if (!PlayerData.LevelStars.ContainsKey(keyToCheck)){
            PlayerData.LevelStars.Add(keyToCheck,0);
        }
    }
}
