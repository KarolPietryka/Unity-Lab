using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Moq;
using NSubstitute;

public class GameMasterTest
{
    private IInputProvider getInputProviderMock(Vector3 fakeMousePosition)
    {
        var inputProvider = Substitute.For<IInputProvider>();
        inputProvider.GetMousePosition().Returns(fakeMousePosition);  

        return inputProvider;
    }

    private IMouse getMouseMock(Vector3 LastMouseClickPosition)
    {
        var mouse = Substitute.For<IMouse>();
        mouse.LastMouseClickPosition.Returns(LastMouseClickPosition);

        return mouse;
    }
    private GameMaster getGameMasterMock(IInputProvider inputProvider,IMouse mouse)
    {
        var gameMaster = Substitute.For<GameMaster>();
        gameMaster.SetInputProvider(inputProvider);
        gameMaster.SetMouse(mouse);
        return gameMaster;
    }


}

