using UnityEngine;
/// <summary>
/// Player2 set up
/// </summary>
public class Player2SetUp : MonoBehaviour {

    /// <summary>
    /// Устанавливает тип управления персонажем 2
    /// </summary>
    /// <param name="dropDownIndex">>Индекс из выпадающего списка</param>
    public void PlayVs(int dropDownIndex)
    {
        switch (dropDownIndex)
        {
            case 0:
                GetComponent<MainHero>().AiCharacter = false;
                break;
            case 1:
                GetComponent<MainHero>().AiCharacter = true;
                break;
            case 2:
                GetComponent<MainHero>().AiCharacter = true;
                break;
        }

    }
}
