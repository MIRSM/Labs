using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1SetUp : MonoBehaviour {

    /// <summary>
    /// Устанавливает тип управления персонажем 1
    /// </summary>
    /// <param name="dropDownIndex">Индекс из выпадающего списка</param>
    public void PlayVs(int dropDownIndex)
    {
        switch (dropDownIndex)
        {
            case 2:
                GetComponent<MainHero>().AiCharacter = true;
                break;
            default:
                GetComponent<MainHero>().AiCharacter = false;
                break;
        }

    }
}
