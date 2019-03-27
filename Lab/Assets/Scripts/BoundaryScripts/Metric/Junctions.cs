using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Junctions  {

    public static void ProcessJunctionParametersBaseOn(IUniversalMetric metric, List<IMazeElement> neighbourMazeElementList)
    {
        int counterOfPossibleMazeElementsToMoveFromCurrentMazeElement = 0;

        foreach (IMazeElement neighbourMazeElement in neighbourMazeElementList)
        {
            if (!neighbourMazeElement.IsMazeWall)
            {
                counterOfPossibleMazeElementsToMoveFromCurrentMazeElement++;
            }
        }

        switch (counterOfPossibleMazeElementsToMoveFromCurrentMazeElement)
        {
            case 0:
                //Non-MazeWall island case
                break;
            case 1:
                metric.IncreaseNumberOfDeadEnds();
                break;               
            case 2:
                metric.IncreaseNumberOfHallwayNodes();
                break;
            case 3:
                metric.IncreaseNumberOfThreeWayJunctions();          
                break;
            case 4:
                metric.IncreaseNumberOfFourWayJunctions();
                break;
            default:
                throw new System.NotImplementedException(string.Format("Number of neighbours can not be less then 1 and greater then 4. Now is {0}", counterOfPossibleMazeElementsToMoveFromCurrentMazeElement));
        }
    }
}
