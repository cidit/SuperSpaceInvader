using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataAggregate : MonoBehaviour
{
    // Game data goes here in attributes.

    // ======================

    public static GameDataAggregate CreateGameDataAggregate()
    {
        return new GameDataAggregate();
    }
}
