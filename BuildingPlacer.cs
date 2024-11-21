public void PreparePlacedBuilding(BuildingData buildingData, EntityManager builder = null)
{
    // Destroy previous phantom building
   ShowRangeIndicators(true);

    if (placingBuilding != null && !placingBuilding.IsFixed)
    {
        Destroy(placingBuilding.Transform.gameObject);
    }

    placingBuilding = new Building(buildingData, GameManager.Instance.gamePlayersParams.myPlayerId);
    if (builder != null) this.builder = builder;
    UpdateBuildingMouseLocation();

    if (placingBuilding.buildingData.attackRange > 0 && placingBuilding.buildingManager.AttackRangeIndicator != null)
    {
        float rangeSize = Unit.GetSelectionCircleScale(placingBuilding.buildingData.attackRange * 2 * 1.05f);
        placingBuilding.buildingManager.AttackRangeIndicator.GetComponent<DecalProjector>().size = new Vector3(rangeSize, rangeSize, 15);
        placingBuilding.buildingManager.AttackRangeIndicator.SetActive(true);
    }
}

/// <summary>
/// Places the current phantom building
/// </summary>
protected void PlaceBuilding()
{
    if (!placingBuilding.CanBuy) return;

    GameManager.Instance.RemoveResources(placingBuilding.Data.cost);
    placingBuilding.Place();
    placingBuilding.Transform.GetComponent<BuildingManager>().UpdateHealthbar();
    placeBuildingSound.Play();

    if (builder != null)
    {
        builder.entity.QueueTaskFromRightClick(TaskType.BuildRepair, placingBuilding.Transform.gameObject, null);
        builder = null;
    }
    placingBuilding = null;
    rotatingBuilding = false;

    placingBuilding.buildingManager.AttackRangeIndicator.SetActive(false);
    ShowRangeIndicators(false);
}

/// <summary>
/// Stop placing a building, destroy the current phantom building
/// </summary>
protected void CancelPlacedBuilding()
{
    Destroy(placingBuilding.Transform.gameObject);
    placingBuilding = null;
    builder = null;
    rotatingBuilding = false;   
    justCanceled = true;

    placingBuilding.buildingManager.AttackRangeIndicator.SetActive(false);
    ShowRangeIndicators(false);
}
