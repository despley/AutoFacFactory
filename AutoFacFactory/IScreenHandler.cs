namespace AutoFacFactory
{
    public interface IScreenHandler<in T>where T : Screen, new()
    {
        Screen CreateScreen();
    }
}