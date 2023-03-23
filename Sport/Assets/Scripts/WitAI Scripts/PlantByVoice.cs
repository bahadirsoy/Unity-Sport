using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantByVoice : MonoBehaviour
{
    [SerializeField] Transform plantAreas;

    [SerializeField] GameObject carrotPlant;
    [SerializeField] GameObject cornPlant;
    [SerializeField] GameObject eggplantPlant;
    [SerializeField] GameObject tomatoPlant;
    [SerializeField] GameObject turnipPlant;

    public void PlantCommand(string[] values)
    {
        /*Debug.Log("Intent: " + values[0]);
        Debug.Log("Place: " + values[1]);*/

        if(values[0] == "plant")
        {
            foreach (Transform plantArea in plantAreas)
            {
                if(plantArea.gameObject.GetComponent<PlantArea>().plantState == "Plant")
                {
                    switch (values[1])
                    {
                        case "carrot":
                            plantArea.gameObject.GetComponent<PlantArea>().Plant(carrotPlant);
                            break;
                        case "corn":
                            plantArea.gameObject.GetComponent<PlantArea>().Plant(cornPlant);
                            break;
                        case "eggplant":
                            plantArea.gameObject.GetComponent<PlantArea>().Plant(eggplantPlant);
                            break;
                        case "tomato":
                            plantArea.gameObject.GetComponent<PlantArea>().Plant(tomatoPlant);
                            break;
                        case "turnip":
                            plantArea.gameObject.GetComponent<PlantArea>().Plant(turnipPlant);
                            break;
                    }
                }
            }
        }
    }
}
