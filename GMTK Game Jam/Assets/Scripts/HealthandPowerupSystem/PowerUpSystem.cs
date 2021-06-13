using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSystem : MonoBehaviour
{
    /*
     Let's see, how the powerup system will work
        +Connect 2 horizontal lines using the Line Renderer to the GameObject
        +Create 2 power ups, one will increase the speed variable, another will increase the health slowly over time...1 point every 5 seconds.
    */
    public KeyBoardInput kbi;

    public bool isSpeed = false;
    public void SpeedPowerUp()
    {
        kbi.horizontalMultiplier = 2;
        //Increase Speed by calling the Speed control component of the player
    }

    public bool isRegeneration = false;
    public void RegenerationPowerUp()
    {
        //incerase health
    }
    public bool isDamage = false;
    public void DamagePowerUp()
    {
        //increase damage and amplify the particle effects.
    }
}
