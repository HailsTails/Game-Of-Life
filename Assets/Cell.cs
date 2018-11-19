using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    CellStatus status;
    private const int NEIGHBOURS_UPPER_LIMIT = 3;
    private const int NEIGHBOURS_LOWER_LIMIT = 2;
    private const int REPRODUCTION_LIMIT = 3;

    public new SpriteRenderer renderer;
    public Sprite deadSprite;
    public Sprite aliveSprite;
    // Start is called before the first frame update
    void Start()
    {
        status = CellStatus.dead;
        InvokeRepeating("CheckNextStatus", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (status == CellStatus.alive)
        {
            this.renderer.sprite = aliveSprite;
        } else
        {
            this.renderer.sprite = deadSprite;
        }
    }

    public void CheckNextStatus()
    {
        int currentNeighbourCount = 3;
        if(status == CellStatus.alive)
        {
            if(StaysAliveNextRound(currentNeighbourCount))
            {
                this.status = CellStatus.alive;
                return;
            }
        } else
        {
            if(ReproducesNextRound(currentNeighbourCount))
            {
                this.status = CellStatus.alive;
                return;
            } 
        }
        this.status = CellStatus.dead;
    }

    private bool StaysAliveNextRound(int neighbours)
    {
        if(neighbours < NEIGHBOURS_LOWER_LIMIT || neighbours > NEIGHBOURS_UPPER_LIMIT)
            return false;
        return true;
    }

    private bool ReproducesNextRound(int neighbours)
    {
        if(neighbours == REPRODUCTION_LIMIT)
        {
            return true;
        }
        return false;
    }
}

public enum CellStatus
{
    alive,
    dead
}

