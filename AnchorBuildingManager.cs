public class AnchorBuildingManager : BuildingManager
{
    public GameObject RangeIndicator;

    protected override void Start()
    {
        base.Start();

        float rangeSize = Unit.GetSelectionCircleScale(building.buildingData.SafetyRange * 2 * 1.05f);
        RangeIndicator.GetComponent<DecalProjector>().size = new Vector3(rangeSize, rangeSize, 15);
    }

    /// <summary>
    /// Enables and Disables the Range indicator
    /// </summary>
    public void TurnRangeIndicator(bool value)
    {
        RangeIndicator.SetActive(value);
    }

    /// <summary>
    /// Remove this from siblings when dead
    /// </summary>
    protected override void PreDie()
    {
        base.PreDie();

        GameManager.Instance.allOutposts.Remove(this);
    }

    protected override IEnumerator PostCompleteInitCR()
    {
        GameManager.Instance.allOutposts.Add(this);

        yield return base.PostCompleteInitCR();
    }
}
