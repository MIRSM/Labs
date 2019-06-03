using UnityEngine;

/// <summary>
/// Damage script
/// </summary>
public class DamageScript : MonoBehaviour
{
    /// <summary>
    /// Наносимый урон
    /// </summary>
    public float damage = 10f;

    /// <summary>
    /// Соприкосновение коллайдера кулака с объектами
    /// </summary>
    /// <param name="other">Коллайдер, с которым соприкасается кулак</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.root != transform.root && other.tag != "Ground" && !other.isTrigger && other.tag != "Wall")
        {
            if(other.tag!="Projectile")
            if (!other.transform.GetComponent<MainHero>().blocking && !other.transform.GetComponent<MainHero>().damage)
            {

                other.transform.GetComponent<MainHero>().damage = true;

                //Триггер анимации
                other.transform.root.GetComponentInChildren<Animator>().SetTrigger("Damage");

                //Звук удара
                other.transform.GetComponent<MainHero>().Au.Play();

                //Отнимание здоровья у противника
                other.transform.GetComponent<MainHero>().CurrentHealth -= damage;
                other.transform.GetComponent<MainHero>().healthBar.value = other.transform.GetComponent<MainHero>().CurrentHealth / other.transform.GetComponent<MainHero>().MaxHealth;

                //Вывод надписи Победы
                if (other.transform.GetComponent<MainHero>().CurrentHealth <= 0f)
                {
                    other.transform.GetComponent<MainHero>().GetComponents<CircleCollider2D>()[1].enabled=false;

                    other.transform.GetComponent<MainHero>().WinText.text = other.transform.GetComponent<MainHero>().enemy.name + " WIN!" ;
                    other.transform.GetComponent<MainHero>().WinText.enabled = true;
                    other.transform.GetComponent<MainHero>().ContinueText.SetActive(true);
                }
            }
        }
    }
}