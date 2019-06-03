using UnityEngine;

/// <summary>
/// Event holder
/// </summary>
public class EventHolder : MonoBehaviour {

    /// <summary>
    /// Персонаж
    /// </summary>
    MainHero pl;

	void Start ()
    {
        pl = transform.root.GetComponent<MainHero>();    	
	}
	
    /// <summary>
    /// Специальная атака
    /// </summary>
    public void ThrowProjectile()
    {
        pl.specialAttack = true;
    }
}
