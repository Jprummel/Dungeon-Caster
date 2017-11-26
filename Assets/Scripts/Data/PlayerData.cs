using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    public static int AcquiredStars;
    public static int CaveStars;
    public static int RuinsStars;

    public static bool CompletedTutorial;

    public static Dictionary<string, int> LevelStars = new Dictionary<string, int>();
}
