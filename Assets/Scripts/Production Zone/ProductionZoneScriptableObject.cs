using UnityEngine;

[CreateAssetMenu(fileName = "Create object", menuName = "Arcade Idle/New Production zone")]
public class ProductionZoneScriptableObject : ScriptableObject
{
    [SerializeField] private string _zoneName;

    [SerializeField] private int _zonePrice;

    [SerializeField] private GameObject _zonePrefab;

    [SerializeField] private Vector3 _zonePosition;

    [SerializeField] private bool _isLocked;

    [TextArea] [SerializeField] private string _zoneDescription;

    public string ZoneName
    {
        get { return _zoneName; }
    }

    public int ZonePrice
    {
        get { return _zonePrice; }
    }

    public GameObject ZonePrefab
    {
        get { return _zonePrefab; }
    }

    public Vector3 ZonePosition
    {
        get { return _zonePosition; }
    }

    public bool IsLocked
    {
        get { return _isLocked; }
    }
    
    public string ZoneDescription
    {
        get { return _zoneDescription; }
    }
}