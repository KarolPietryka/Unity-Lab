using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Moq;
using NSubstitute;

public class GameMasterTest
{
    private IMouse getMouseMock(Vector3 fakeMousePosition)
    {
        var mouse = Substitute.For<IMouse>();
        mouse.GetMousePosition().Returns(fakeMousePosition);  

        return mouse;
    }

    /*private IMouse getMouseMock(Vector3 LastMouseClickPosition)
    {
        var mouse = Substitute.For<IMouse>();
        mouse.LastMouseClickPosition.Returns(LastMouseClickPosition);

        return mouse;
    }
    private GameMaster getGameMasterMock(IMouse mouse,IMouse mouse)
    {
        var gameMaster = Substitute.For<GameMaster>();
        gameMaster.SetMouse(mouse);
        gameMaster.SetMouse(mouse);
        return gameMaster;
    }*/


}

