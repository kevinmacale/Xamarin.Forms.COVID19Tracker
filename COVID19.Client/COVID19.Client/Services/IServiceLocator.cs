namespace COVID19.Client.Services
{
    public interface IServiceLocator
    {
        T Get<T>() where T : class;
        void Register<T>(T service, bool replace = true);
        void UnRegister<T>();
    }
}