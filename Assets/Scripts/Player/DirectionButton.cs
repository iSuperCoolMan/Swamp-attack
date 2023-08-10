using UnityEngine;

public class DirectionButton
{
    public DirectionButton(string directionName, KeyCode keyCode, Vector3 direction)
    {
        DirectionName = directionName;
        KeyCode = keyCode;
        Direction = direction;
    }

    public string DirectionName { get; private set; }
    public KeyCode KeyCode { get; private set; }
    public Vector3 Direction { get; private set; }
}
