namespace EcoSolution.Domain.Interface.Application.Services
{
    public interface ILoggerService
    {
        void Information(string originClass, string method, string mensage);
        void Warning(string originClass, string method, string mensage);
        void Error(Exception exception);
        void CloseAndFlush();
    }
}
