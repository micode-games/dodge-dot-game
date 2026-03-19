using UnityEngine;

public class LoseManager : MonoBehaviour
{
    [SerializeField] private PlayerCollision playerCollision;
    [SerializeField] private GameObject loseUI;

    private void Start()
    {
        loseUI.SetActive(false);
    }

    private void Update()
    {
        if (playerCollision.isDead)
        {
            loseUI.SetActive(true);
        }
    }
}