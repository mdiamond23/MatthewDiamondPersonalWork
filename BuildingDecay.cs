/// <summary>
/// Checks if building is near outpost or HQ
/// </summary>
public bool InRangeOfOutposts()
{
    for (int i = 0; i < GameManager.Instance.allOutposts.Count; i++)
    {
        float distance = Vector3.Distance(transform.position, GameManager.Instance.allOutposts[i].transform.position);

        float range = GameManager.Instance.allOutposts[i].building.buildingData.SafetyRange;
        if (distance <= range)
        {
            return true; // In range of an outpost or HQ
        }
    }

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
            yield break;
        }

        yield return null;
    }
}
