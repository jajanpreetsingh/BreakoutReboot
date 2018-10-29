public class Constants
{
}

public enum Scenes
{
    Level1 = 0,
    Level2,
    Level3,
}

public enum GameState
{
    Stopped,
    Playing,
    Paused,
    Over
}

public enum BrickType
{
    White,
    Blue,
    Green,
    Red
}

public enum BallState
{
    Playing,
    Reset,
}

public static class Tags
{
    public const string Ball = "Ball";
    public const string Paddle = "Paddle";
}

public enum ColorHex
{
    //0080FFFF,
    //00FF4CFF
}