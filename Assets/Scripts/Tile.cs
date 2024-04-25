using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class Tile : MonoBehaviour
{
    [Header("Tile Sprites")]
    [SerializeField] private Sprite unclickedTile;
    [SerializeField] private Sprite flaggedTile;
    [SerializeField] private List<Sprite> clickedTiles;
    [SerializeField] private Sprite mineTile;
    [SerializeField] private Sprite mineWrongTile;
    [SerializeField] private Sprite mineHitTile;

    [Header("GM set via code")]
    public GameManager gameManager;


    private SpriteRenderer spriteRenderer;
    private GameObject powerUpsManager;
    private PowerUps powerUps;
    public bool flagged = false;
    public bool active = true;
    public bool isMine = false;
    public bool flagActive = false;
    public int mineCount = 0;


    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        powerUpsManager = GameObject.Find("PowerUps");
        powerUps = powerUpsManager.GetComponent<PowerUps>();
    }

    private void Update()
    {
        //llamada a la funcion del powerup de la bandera
        PowerUpFlag();
    }

    private void OnMouseOver()
    {
        if (active)
        {

            if (Input.GetMouseButtonDown(0))
            {
                //llamada a la funcion del power up del escudo
                //se llama primero a la funcion del escudo con el fin de que se compruebe si este esta activo
                //y si el tile es una mina
                PowerUpShield();
                ClickedTile();   
            }
            else if (Input.GetMouseButtonDown(1))
            {
                flagged = !flagged;
                if (flagged)
                {
                    spriteRenderer.sprite = flaggedTile;
                }
                else
                {
                    spriteRenderer.sprite = unclickedTile;
                }
            }
        }
        else
        {
            if (Input.GetMouseButton(0) && Input.GetMouseButtonDown(1))
            {
                gameManager.ExpandIfFlagged(this);
            }
        }

    }


    public void ClickedTile()
    {
        if (active & !flagged)
        {
            active = false;
            if (isMine)
            {
                spriteRenderer.sprite = mineHitTile;
                gameManager.GameOver();
            }
            else
            {
                spriteRenderer.sprite = clickedTiles[mineCount];
                if (mineCount == 0)
                {
                    gameManager.ClickNeighbours(this);
                }

                gameManager.CheckGameOver();
            }
        }
    }

    public void ShowGameOverState()
    {
        if (active)
        {
            active = false;
            if (isMine & !flagged)
            {
                spriteRenderer.sprite = mineTile;
            }
            else if (flagged & !isMine)
            {
                spriteRenderer.sprite = mineWrongTile;
            }

        }
    }

    public void SetFlaggedIfMine()
    {
        if (isMine)
        {
            flagged = true;
            spriteRenderer.sprite = flaggedTile;
        }
    }


    //funciones que se encargan de intervenir los tiles y ejecutar la logica de las minas
    //se hacen por separado ya que una necesita hubicarse necesariamente en el update y la otra
    // necesita llamarse antes de cambiar el estado del tile al hacer click
    //en caso de querer hacer modificaciones a los tiles, relacionadas a los power ups, se recomienda
    //hacerlo en las siguientes funciones

    public void PowerUpFlag()
    {
        //se comprueba si el tile es una mina y si el power up de la bandera esta activado
        if (isMine == true)
        {
            //en caso de ser asi, se cambia el estado del tile 
            if (powerUps.isFlagPAct == true)
            {
                flagged = true;
                flagActive = true;
                SetFlaggedIfMine();
            }
            
        }
        //en caso de no ser una mina y ya que se a activado el power up, se pocede a ejecutar el click en la casilla
        if (isMine == false)
        {
            if (powerUps.isFlagPAct)
            {
                ClickedTile();
            }
        }
    }

    //funcion que se encarga de la logica del power up del escudo
    public void PowerUpShield()
    {
        //se comprueba si es una mina
        if (isMine == true)
        {
            //se verifica si el power up esta activado y dado que su funcion se ejecuta
            //cada que se hace click, se le resta un punto al numero de usos que tiene el power up
            if (powerUps.isShieldPAct == true)
            {
                flagged = true;
                flagActive = true;
                powerUps.countShieldP -= 1;
            }
            //se comprueba si el power up fue desactivado para asi cambiar el estado de los tiles
            else if (powerUps.isShieldPAct == false)
            {
                flagged = false;
                flagActive = false;
            }
        }
    }



}
