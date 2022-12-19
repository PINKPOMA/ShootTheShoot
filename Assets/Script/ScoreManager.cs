using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreManager : Singleton<ScoreManager>
{
    [FormerlySerializedAs("Score")] public int score;
}
