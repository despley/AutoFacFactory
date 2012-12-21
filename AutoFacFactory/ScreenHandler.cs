namespace AutoFacFactory
{
    public class ScreenHandler<T> : IScreenHandler<T> where T: Screen, new()
    {
        public Screen CreateScreen()
        {
            return new T();
        }
    }
}