using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainHero : MonoBehaviour
{
    #region Variables

    /// <summary>
    /// Индекс персонажа
    /// </summary>
    public int PlayerNumber = 1;

    /// <summary>
    /// Управляется ли персонаж с помощью АИ
    /// </summary>
    public bool AiCharacter;

    /// <summary>
    /// Противник
    /// </summary>
    public Transform enemy;

    /// <summary>
    /// Ригидбоди объекта
    /// </summary>
    private Rigidbody2D rb;

    /// <summary>
    /// Аниматор объекта
    /// </summary>
    Animator anim;

    /// <summary>
    /// Перемещение по оси Х
    /// </summary>
    public float horizontal;

    /// <summary>
    /// Перемещение по оси Y
    /// </summary>
    public float vertical;

    /// <summary>
    /// Максимальная скорость передвежения персонажа
    /// </summary>
    public float maxSpeed = 25f;

    /// <summary>
    /// Вектор передвежения
    /// </summary>
    Vector3 movement;

    /// <summary>
    /// Сидит ли персонаж
    /// </summary>
    bool crouch;

    /// <summary>
    /// Сила прыжка (устанавливается из дебаг окна)
    /// </summary>
    public float JumpForce = 20;

    /// <summary>
    /// Сила прыжка
    /// </summary>
    float jmpForce;

    /// <summary>
    /// Максимальная продолжительность прыжка
    /// </summary>
    public float JumpDuration = 0.1f;

    /// <summary>
    /// Продолжительность прыжка
    /// </summary>
    float jmpDuration;

    /// <summary>
    /// Прыгает ли
    /// </summary>
    public bool jumpKey;

    /// <summary>
    /// Падает ли
    /// </summary>
    bool falling;

    /// <summary>
    /// Стоит ли на земле
    /// </summary>
    bool onGround;

    /// <summary>
    /// Скорость атаки
    /// </summary>
    public float attackRate = 0.3f;

    /// <summary>
    /// Массив с вариантами атаки
    /// </summary>
    public bool[] attack = new bool[2];

    /// <summary>
    /// Продолжительность нажатий клавиш атаки 
    /// </summary>
    float[] attacktimer = new float[2];

    /// <summary>
    /// Количество нажатий клавиш атаки
    /// </summary>
    int[] timesPressed = new int[2];

    /// <summary>
    /// Нанесен ли урон
    /// </summary>
    public bool damage = false;

    /// <summary>
    /// Максимальная продолжительность неуязвимости после получения урона
    /// </summary>
    public float noDamage = 1;

    /// <summary>
    /// Продолжительность неуязвимости после получения урона
    /// </summary>
    float noDamageTimer;

    /// <summary>
    /// Сработал ли блок
    /// </summary>
    public bool blocking = false;

    /// <summary>
    /// Максимальная продолжительность блока
    /// </summary>
    public float blockingRate = 1.5f;

    /// <summary>
    /// Продолжительность блока
    /// </summary>
    float blTimer;

    /// <summary>
    /// Нажата ли клавиша специальной атаки
    /// </summary>
    public bool specialAttack;

    /// <summary>
    /// Время жизни прожектайла специальной атаки
    /// </summary>
    float prLifeTime = 0.3f;

    /// <summary>
    /// Получено ли случайное число
    /// </summary>
    bool gotRandom;

    /// <summary>
    /// Случайное число
    /// </summary>
    float storeRandom;

    /// <summary>
    /// Прожектайл
    /// </summary>
    public GameObject projectile;

    /// <summary>
    /// Аудиомикшер
    /// </summary>
    public AudioMixer am;

    /// <summary>
    /// Источник звука удара
    /// </summary>
    public AudioSource Au;

    /// <summary>
    /// Упало ли здоровье ниже 0
    /// </summary>
    public bool die = false;

    /// <summary>
    /// Максимальное время работы игры после смерти персонажа
    /// </summary>
    float deathAnimLife = 0.2f;

    /// <summary>
    /// Время работы игры после смерти персонажа
    /// </summary>
    float deathAnimTimer;

    /// <summary>
    /// Слайдер со здоровьем персонажа
    /// </summary>
    public Slider healthBar;

    /// <summary>
    /// Текущее здоровье
    /// </summary>
    public float CurrentHealth { get; set; }

    /// <summary>
    /// Максимальное здоровье
    /// </summary>
    public float MaxHealth { get; set; }

    /// <summary>
    /// Текст "Continue"
    /// </summary>
    public GameObject ContinueText;

    /// <summary>
    /// Текст "...WIN"
    /// </summary>
    public Text WinText;

    /// <summary>
    /// Объект со слайдером здоровья (для паузы)
    /// </summary>
    public GameObject plH;

    /// <summary>
    /// Нажата ли пауза
    /// </summary>
    public bool paused = false;

    /// <summary>
    /// Уровень громкости
    /// </summary>
    public float volume;

    /// <summary>
    /// Объект меню паузы
    /// </summary>
    public GameObject pauseMenu;

    #endregion
    
    void Start()
    {
        Cursor.visible = false;

        am.GetFloat("volume", out volume);

        Time.timeScale = 1;

        GetComponents<CircleCollider2D>()[1].enabled = false;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();

        am.GetFloat("volume", out volume);
        WinText.gameObject.SetActive(true);
        WinText.enabled = false;

        ContinueText.SetActive(false);
        MaxHealth = 100f;
        CurrentHealth = MaxHealth;
        healthBar.value = CalculateHealth();

        healthBar.enabled = false;
        jmpForce = JumpForce;

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject pl in players)
        {
            if (pl.transform != this.transform)
            {
                enemy = pl.transform;
            }
        }


        Au = GetComponent<AudioSource>();
    }

    void Update()
    {
        PauseApp();
        AttackInput();
        ScaleCheck();
        OnGroundCheck();
        Blocking();
        Damage();
        SpecialAttack();
        UpdateAnimator();
        GameOver();
    }

    void FixedUpdate()
    {
        if (AiCharacter)
        {

            if (!GetComponent<AiCharacter>())
            {
                gameObject.AddComponent<AiCharacter>();
            }
            GetComponent<AiCharacter>().enabled = true;
        }
        else
        {
            GetComponent<AiCharacter>().enabled = false;
        }

        if (!AiCharacter)
        {
            horizontal = Input.GetAxis("Horizontal" + PlayerNumber.ToString());
            vertical = Input.GetAxis("Vertical" + PlayerNumber.ToString());
        }
        Vector3 movement = new Vector3(horizontal, 0, 0);

        crouch = (vertical < -0.1f);

        CircleCollider2D[] cr;
        cr = GetComponents<CircleCollider2D>();

        if (vertical > 0.1f)
        {
            if (!jumpKey)
            {
                jmpDuration += Time.deltaTime;
                jmpForce += Time.deltaTime;

                if (jmpDuration < JumpDuration)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jmpForce);
                    jumpKey = false;

                }
                else
                {
                    jumpKey = true;
                    jmpDuration = 0;
                }
            }
            else
                if (onGround) jumpKey = false;
        }

        if (!onGround && vertical < 0.1f)
        {
            falling = true;
        }

        if (attack[0] && !jumpKey || attack[1] && !jumpKey)
        {
            movement = Vector3.zero;
        }

        if (!crouch && !damage && !blocking)
        {
            cr[1].enabled = true;
            rb.AddForce(movement * maxSpeed);
        }
        else
        {
            if (!jumpKey)
            {
                rb.velocity = Vector3.zero;
                cr[1].enabled = false;
            }
        }

    }

    #region Functions

    /// <summary>
    /// Изменение гравитации в зависимости от положения
    /// </summary>
    void OnGroundCheck()
    {
        if (!onGround)
        {
            rb.gravityScale = 5;
        }
        else
        {
            rb.gravityScale = 1;
        }
    }

    /// <summary>
    /// Нажатие клавиш атаки
    /// </summary>
    void AttackInput()
    {
        if (Input.GetButtonDown("Attack1" + PlayerNumber.ToString()))
        {
            attack[0] = true;
            attacktimer[0] = 0;
            timesPressed[0]++;

            CircleCollider2D[] enemyCC = enemy.GetComponents<CircleCollider2D>();
            enemyCC[1].enabled = true;
        }

        if (attack[0])
        {
            attacktimer[0] += Time.deltaTime;
            if (attacktimer[0] > attackRate || timesPressed[0] >= 4)
            {
                attacktimer[0] = 0;
                attack[0] = false;
                timesPressed[0] = 0;

            }
        }

        if (Input.GetButtonDown("Attack2" + PlayerNumber.ToString()))
        {
            attack[1] = true;
            attacktimer[1] = 0;
            timesPressed[1]++;

            CircleCollider2D[] enemyCC = enemy.GetComponents<CircleCollider2D>();
            enemyCC[1].enabled = true;
        }

        if (attack[1])
        {
            attacktimer[1] += Time.deltaTime;
            if (attacktimer[1] > attackRate || timesPressed[0] >= 4)
            {
                attacktimer[1] = 0;
                attack[1] = false;
                timesPressed[1] = 0;

            }
        }
    }

    /// <summary>
    /// Получение урона
    /// </summary>
    void Damage()
    {
        if (damage)
        {
            noDamageTimer += Time.deltaTime;

            if (noDamageTimer > noDamage)
            {
                damage = false;
                noDamageTimer = 0;
            }
            if (CurrentHealth <= 0f)
            {
                die = true;
                damage = false;
            }
        }
    }

    /// <summary>
    /// Специальная атака
    /// </summary>
    void SpecialAttack()
    {
        if (specialAttack)
        {

            GameObject pr = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            DestroyObject(pr, prLifeTime);
            Vector3 nrDir = new Vector3(enemy.position.x, transform.position.y, 0);
            Vector3 dir = nrDir - transform.position;
            pr.GetComponent<Rigidbody2D>().AddForce(dir * 10, ForceMode2D.Impulse);

            specialAttack = false;

        }
    }

    /// <summary>
    /// Обновление анимации
    /// </summary>
    void UpdateAnimator()
    {

        anim.SetBool("Die", die);
        anim.SetBool("Attack1", attack[0]);
        anim.SetBool("Attack2", attack[1]);
        anim.SetBool("Crouch", crouch);
        anim.SetBool("OnGround", this.onGround);
        anim.SetBool("Falling", this.falling);
        anim.SetFloat("Movement", Mathf.Abs(horizontal));
        anim.SetBool("Blocking", blocking);
    }

    /// <summary>
    /// Проверка на соприкосновение с полом
    /// </summary>
    /// <param name="col">Коллайдер, с которым соприкасается персонаж</param>
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Ground")
        {
            onGround = true;

            jumpKey = false;
            jmpDuration = 0;
            jmpForce = JumpForce;
            falling = false;
        }

    }

    /// <summary>
    /// Проверка на отталкивание от пола
    /// </summary>
    /// <param name="col">Коллайдер, от которого отталкивается персонаж</param>
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.tag == "Ground")
        {
            onGround = false;
        }

    }

    /// <summary>
    /// Разворот в сторону противника
    /// </summary>
    void ScaleCheck()
    {
        if (transform.position.x < enemy.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = Vector3.one;
    }

    /// <summary>
    /// Окончание игры
    /// </summary>
    void GameOver()
    {
        if (CurrentHealth <= 0f)
        {
            deathAnimTimer += Time.deltaTime;
            if (deathAnimTimer > deathAnimLife)
            {
                Time.timeScale = 0;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Cursor.visible = true;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                }
            }
        }
    }

    /// <summary>
    /// Возвращает текущее здоровье
    /// </summary>
    /// <returns>Текущее здоровье</returns>
    float CalculateHealth()
    {
        return CurrentHealth / MaxHealth;
    }

    /// <summary>
    /// Блокирование
    /// </summary>
    void Blocking()
    {
        if (damage)
        {
            if (!gotRandom)
            {
                storeRandom = ReturnRandom();
                gotRandom = true;
            }

            if (storeRandom < 50)
            {
                blocking = true;
                damage = false;
                blocking = true;
            }
        }

        if (blocking)
        {
            blTimer += Time.deltaTime;

            if (blTimer > blockingRate)
            {
                blocking = false;
                blTimer = 0;
            }
        }
    }

   /// <summary>
   /// Возвращает случайное число
   /// </summary>
   /// <returns>Случайное число</returns>
    float ReturnRandom()
    {
        float retVal = Random.Range(0, 101);
        return retVal;
    }

    /// <summary>
    /// Ставит игру на паузу
    /// </summary>
    void PauseApp()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                Cursor.visible = true;
                Time.timeScale = 0;
                paused = true;
                //показать меню паузы
                pauseMenu.SetActive(true);
                plH.SetActive(false);
            }

        }
    }

    /// <summary>
    /// Продолжает игру (Кнопка "Continue")
    /// </summary>
    public void ContinueBut()
    {
        plH.SetActive(true);
        //healthBar.enabled = true;
        Time.timeScale = 1;
        paused = false;
        pauseMenu.SetActive(false);
        Cursor.visible = false;
    }

    /// <summary>
    /// Переход на сцену с главным меню (Кнопка "Main menu")
    /// </summary>
    public void MenuBut()
    {
        Time.timeScale = 1;
        paused = false;
        pauseMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    /// <summary>
    /// Выход из игры (Кнопка "Quit")
    /// </summary>
    public void QuitBut()
    {
        Application.Quit();
    }
    #endregion
}
