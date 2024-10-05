using EcoSolution.Domain.Interface.Application.Services;
using EcoSolution.Domain.Interface.Infra.Data;
using EcoSolution.Infra.CrossCutting.Handlers.Notifications;
using EcoSolution.Infra.CrossCutting.Handlers.Validators;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using EcoSolution.Domain.DTos.Base;

namespace EcoSolutionApi.Filters
{
    public class QResultActionFilter : IActionFilter, IExceptionFilter
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationHandler _notificationHandler;
        private readonly ILoggerService _logger;
        private readonly IValidatorHandler _validatorHandler;


        public QResultActionFilter(IUnitOfWork unitOfWork, INotificationHandler notificationHandler, ILoggerService logger, IValidatorHandler validatorHandler)
        {
            _unitOfWork = unitOfWork;
            _notificationHandler = notificationHandler;
            _logger = logger;
            _validatorHandler = validatorHandler;
        }

        private GenericResponseDTo CreateResultDefault(object value)
        {
            bool success = !_notificationHandler.HasNotificationsErrors();

            List<string> messages = _notificationHandler.GetNotifications().Select(x => x.Message).ToList();

            _notificationHandler.DisposeNotifications();

            _logger.CloseAndFlush();

            if (!success)
            {
                if (_validatorHandler.Commit())
                    _unitOfWork.Commit();
                else
                    _unitOfWork.RollBack();
            }
            else
                _unitOfWork.Commit();

            return new GenericResponseDTo
            {
                Sucesso = success,
                Data = value != null ? ((JsonResult)value).Value : null,
                Mensagens = messages
            };
        }

        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null) return;

            context.Result = new JsonResult(CreateResultDefault(context.Result));
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var erros = context.ModelState
                    .Where(ms => ms.Value.Errors.Count > 0)
                    .SelectMany(ms => ms.Value.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                context.Result = new BadRequestObjectResult(new GenericResponseDTo
                {
                    Sucesso = false,
                    Mensagens = erros
                });
            }
        }

        public void OnException(ExceptionContext context)
        {
            _notificationHandler.AddNotification(context?.Exception.Message, NotificationType.Error);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            context.ExceptionHandled = true;
            context.Result = new JsonResult(CreateResultDefault(context.Result));
        }

    }
}
