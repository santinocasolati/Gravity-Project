using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    [SerializeField] private PlayerMovement playerMovement;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void SetDirections(Vector2 move, Vector2 jump)
    {
        playerMovement.SetDirections(move, jump);
    }
}
