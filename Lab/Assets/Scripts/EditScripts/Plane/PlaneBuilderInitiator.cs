﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlaneBuilderInitiator{ //TODO Del?

    protected IFirstUpLeftMazeElementPositionProvider firstUpLeftMazeElementPositionProvider;
    protected INumberOfMazeElementsInGamePlaneArea numberOfMazeElementsInGamePlaneArea;
    private IPlaneBuilder planeBuilder;
    private IPlaneElementsBounds planeElementsBounds;

    public IPlaneBuilder PlaneBuilder
    {
        get { return planeBuilder; }
        set { planeBuilder = value; }
    }
    public IPlaneElementsBounds PlaneElementsBounds
    {
        get { return planeElementsBounds; }
        set { planeElementsBounds = value; }
    }

    public void SetPlaneController(IPlaneBuilder _planeBuilder)
    {
        PlaneBuilder = _planeBuilder;
    }
    public void SetPlaneElementsBounds(IPlaneElementsBounds _planeElementsBounds)
    {
        PlaneElementsBounds = _planeElementsBounds;
    }
}
