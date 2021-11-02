using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LocationManager : MonoBehaviour
{
    [SerializeField]
    protected List<Location> locations;

    [SerializeField]
    protected float maxTime = 9f;

    [SerializeField]
    protected SpawnItem template;

    private float currentTime;

    public List<Location> filledLocations = new List<Location>();


    private void Update()
    {
        currentTime += Time.deltaTime/2;
        if (currentTime >= maxTime)
        {
            // Reset
            currentTime = 0;

            if (locations.Count == 0)
            {
                return;
            }

            // Do the thing
            int selectedIndex = Random.Range(0, locations.Count);
            Location selectedLocation = locations[selectedIndex];
            SpawnItem clone = Instantiate(template);
            selectedLocation.PlaceItem(clone);
            locations.Remove(selectedLocation);
            filledLocations.Add(selectedLocation);
        }
    }
}

