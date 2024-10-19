```     /// <summary>
    /// Checks if building is near outpost or HQ
    /// </summary>
    public bool InRangeOfOutposts()
    {
        float range = 15f; // Define the range in which a building is safe from decay
        for (int i = 0; i < GameManager.Instance.allOutposts.Count; i++)
        {
            float distance = Vector3.Distance(transform.position, GameManager.Instance.allOutposts[i].transform.position);
            Debug.Log($"Checking distance to outpost {i}: {distance}");

            if (distance <= range)
            {
                Debug.Log($"In Range of Outpost or HQ");
                return true; // In range of an outpost or HQ
            }
        }

        Debug.Log($"Not In Range of Outpost or HQ");
        return false; // No outpost nearby
    }

    /// <summary>
    /// decays building over time. 
    /// </summary>
    public IEnumerator Decay()
    {

        float totalHealth = building.buildingData.health;
        float decayDuration = 15f; 
        float decayAmountPerSecond = totalHealth / decayDuration;
        float accumulatedDamage = 0f;

        while (Unit.currentHealth > 0)
        {
            float damageThisFrame = decayAmountPerSecond * Time.deltaTime;

            accumulatedDamage += damageThisFrame;

            if (accumulatedDamage >= 1f)
            {
                int damageToApply = Mathf.FloorToInt(accumulatedDamage);
                accumulatedDamage -= damageToApply;
                TakeDamage(damageToApply, null);
            }
            if (Unit.currentHealth <= 0)
            {
                Debug.Log("Building destroyed due to decay");
                yield break;
            }

            yield return null;
        }
    }

    /// <summary>
    /// Adds outpost to list in game manager if it's an outpost or hq
    /// </summary>
    public void AddOutpostsToList()
    {
        if (building.buildingData.id == "headquarters" || building.buildingData.id == "outpost")
        {
            GameManager.Instance.allOutposts.Add(this);
        }
    } ``` 
