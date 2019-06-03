using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiCharacter : MonoBehaviour
{
    #region Variables

    /// <summary>
    /// Управляемый персонаж
    /// </summary>
    MainHero pc;

    /// <summary>
    /// Противник
    /// </summary>
    MainHero en;

    /// <summary>
    /// Дистанция изменения состояния
    /// </summary>
    public float changeStateTolerance = 3;

    /// <summary>
    /// Максимальное время нахождения на большой дистанции
    /// </summary>
    public float normalRate = 1;

    /// <summary>
    /// Время нахождения на большой дистанции
    /// </summary>
    float nrmTimer;

    /// <summary>
    /// Максимально время нахождения на маленькой дистанции
    /// </summary>
    public float closeRate = 0.5f;

    /// <summary>
    /// Время нахождения на маленькой дистанции
    /// </summary>
    float clTimer;

    /// <summary>
    /// Максимальная длительность блока
    /// </summary>
    public float blockingRate = 1.5f;

    /// <summary>
    /// Длительность блока
    /// </summary>
    float blTimer;

    /// <summary>
    /// Максимальная длительность состояния
    /// </summary>
    public float aiStateLife = 1;

    /// <summary>
    /// Длительность состояния
    /// </summary>
    float aiTimer;

    /// <summary>
    /// Спровоцирован ли
    /// </summary>
    bool initiateAI;

    /// <summary>
    /// Близко ли к противнику
    /// </summary>
    bool closeCombat;

    /// <summary>
    /// Получено ли случайное число
    /// </summary>
    bool gotRandom;

    /// <summary>
    /// Случайное число
    /// </summary>
    float storeRandom;

    /// <summary>
    /// Сработал ли блок
    /// </summary>
    bool blocking;
    
    /// <summary>
    /// Сгенерирована ли атака
    /// </summary>
    bool randomizeAttacks;

    /// <summary>
    /// Количество сгенерированных атак
    /// </summary>
    int numberOfAttacks;

    /// <summary>
    /// Количество произведенных атак
    /// </summary>
    int curNumAttacks;

    /// <summary>
    /// Частота прыжка
    /// </summary>
    public float JumpRate = 1;

    /// <summary>
    /// Шанс прыжка
    /// </summary>
    float jRate;

    /// <summary>
    /// Прыгнул ли
    /// </summary>
    bool jump;

    /// <summary>
    /// Время без прыжка
    /// </summary>
    float jtimer;

    /// <summary>
    /// Структура состояний
    /// </summary>
    public enum AIState
    {
        closeState,
        normalState,
        resetAI
    }

    /// <summary>
    /// Состояния
    /// </summary>
    public AIState aiState;

    #endregion

    void Start()
    {
        pc = GetComponent<MainHero>();
    }

    void Update()
    {
        if(!en)
        {
            en = pc.enemy.GetComponent<MainHero>();
        }

        CheckDistance();
        States();
        AIAgent();
    }
    
    #region Functions

    /// <summary>
    /// Установка состояния
    /// </summary>
    void States()
    {
        switch (aiState)
        {
            case AIState.closeState:
                CloseState();
                break;
            case AIState.normalState:
                NormalState();
                break;
            case AIState.resetAI:
                ResetAI();
                break;
        }
        Blocking();
        Jumping();
    }

    /// <summary>
    /// Действия АИ
    /// </summary>
    void AIAgent()
    {
        if (initiateAI)
        {
            aiState = AIState.resetAI;
            float multiplier = 0;

            if (!gotRandom)
            {
                storeRandom = ReturnRandom();
                gotRandom = true;
            }

            if (!closeCombat)
            {
                multiplier += 30;
            }
            else
            {
                multiplier -= 30;
            }

            if (storeRandom + multiplier < 50)
            {
                Attack();
            }
            else
            {
                Movement();
            }

        }
    }

    /// <summary>
    /// Атака
    /// </summary>
    void Attack()
    {
        if (!gotRandom)
        {
            storeRandom = ReturnRandom();
            gotRandom = true;
        }

        if (storeRandom < 75)
        {
            if (!randomizeAttacks)
            {
                numberOfAttacks = (int)Random.Range(1, 4);
                randomizeAttacks = true;
            }

            if (curNumAttacks < numberOfAttacks)
            {
                int attackNumber = Random.Range(0, pc.attack.Length);

                pc.attack[attackNumber] = true;

                curNumAttacks++;
            }
        }
        else
        {
            if (curNumAttacks < 1)
            {
                pc.specialAttack = true;
                curNumAttacks++;
            }
        }
    }

    /// <summary>
    /// Передвижение
    /// </summary>
    void Movement()
    {
        if (!gotRandom)
        {
            storeRandom = ReturnRandom();
            gotRandom = true;
        }

        if (storeRandom < 90)
        {
            if (pc.enemy.position.x < transform.position.x)
                pc.horizontal = -1;
            else
                pc.horizontal = 1;
        }
        else
        {
            if (pc.enemy.position.x < transform.position.x)
                pc.horizontal = 1;
            else
                pc.horizontal = -1;
        }
    }

    /// <summary>
    /// Обновление действий
    /// </summary>
    void ResetAI()
    {
        aiTimer += Time.deltaTime;

        if (aiTimer > aiStateLife)
        {
            initiateAI = false;
            pc.horizontal = 0;
            pc.vertical = 0;
            aiTimer = 0;

            gotRandom = false;

            storeRandom = ReturnRandom();

            if (storeRandom < 50)
                aiState = AIState.normalState;
            else
                aiState = AIState.closeState;

            curNumAttacks = 1;
            randomizeAttacks = false;
        }
    }

    /// <summary>
    /// Проверка дистанции с противником
    /// </summary>
    void CheckDistance()
    {
        float distance = Vector3.Distance(transform.position, pc.enemy.position);

        if (distance < changeStateTolerance)
        {
            if (aiState != AIState.resetAI)
                aiState = AIState.closeState;
            closeCombat = true;
        }
        else
        {
            if (aiState != AIState.resetAI)
                aiState = AIState.normalState;

             if (closeCombat)
             {
                if (!gotRandom)
                {
                    storeRandom = ReturnRandom();
                    gotRandom = true;
                }
                if (storeRandom < 60)
                {
                    Movement();
                }
             }
            closeCombat = false;
        }
    }

    /// <summary>
    /// Блокирование
    /// </summary>
    void Blocking()
    {
        if (pc.damage)
        {
            if (!gotRandom)
            {
                storeRandom = ReturnRandom();
                gotRandom = true;
            }

            if (storeRandom < 50)
            {
                blocking = true;
                pc.damage = false;
                pc.blocking = true;
            }
        }
        if (blocking)
        {
            blTimer += Time.deltaTime;

            if (blTimer > blockingRate)
            {
                pc.blocking = false;
                blTimer = 0;
            }
        }
    }

    /// <summary>
    /// Большая дистанция
    /// </summary>
    void NormalState()
    {
        nrmTimer += Time.deltaTime;

        if (nrmTimer > normalRate)
        {
            initiateAI = true;
            nrmTimer = 0;
        }
    }

    /// <summary>
    /// Маленькая дистанция
    /// </summary>
    void CloseState()
    {
        clTimer += Time.deltaTime;

        if (clTimer > closeRate)
        {
            clTimer = 0;
            initiateAI = true;
        }
    }
    
    /// <summary>
    /// Прыжок
    /// </summary>
    void Jumping()
    {
        if(en.jumpKey || jump)
        {
            pc.vertical = 1;
            jump = false;
        }
        else
        {
            pc.vertical = 0;
        }

        jtimer += Time.deltaTime;

        if (jtimer > JumpRate* 10)
        {
            jRate = ReturnRandom();

            if (jRate < 50)
            {
                jump = true;
            }
            else
            {
                jump = false;
            }

            jtimer = 0;
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

    #endregion
}
