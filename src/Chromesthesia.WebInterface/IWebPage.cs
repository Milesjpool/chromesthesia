namespace Chromesthesia.WebInterface
{
    public interface IWebPage<out T>
    {
        T Render();
    }
}