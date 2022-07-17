using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This manages shooting actions and swappable weapon logic.
/// </summary>

public class ShootyPlayer : MonoBehaviour
{
    [SerializeField] private ProjectilePooling PewPool;

    public string WeaponType;
    public Vector2 iniVel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
		{
            PewPool.Shootenany(0, iniVel);
		}
    }
}
