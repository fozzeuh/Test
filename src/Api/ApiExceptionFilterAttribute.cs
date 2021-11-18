using System;
using System.Collections.Generic;
using Application.Exception;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api
{
	public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
	{
		private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

		public ApiExceptionFilterAttribute()
		{
			// Register known exception types and handlers.
			_exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
			{
				{ typeof(SellerAlreadyExistException), HandleSellerAlreadyExistException },
				{ typeof(SellerDoesntExistException), HandleSellerDoesntExistException },
			};
		}

		public override void OnException(ExceptionContext context)
		{
			HandleException(context);

			base.OnException(context);
		}

		private void HandleException(ExceptionContext context)
		{
			Type type = context.Exception.GetType();
			if (_exceptionHandlers.ContainsKey(type))
			{
				_exceptionHandlers[type].Invoke(context);
				return;
			}

			if (!context.ModelState.IsValid)
			{
				HandleInvalidModelStateException(context);
				return;
			}

			HandleUnknownException(context);
		}

		private void HandleSellerAlreadyExistException(ExceptionContext context)
		{
			var exception = (SellerAlreadyExistException)context.Exception;

			var details = new ValidationProblemDetails()
			{
				Title = exception.Message
			};

			context.Result = new ConflictObjectResult(details);

			context.ExceptionHandled = true;
		}

		private void HandleInvalidModelStateException(ExceptionContext context)
		{
			var details = new ValidationProblemDetails(context.ModelState)
			{
			};

			context.Result = new BadRequestObjectResult(details);

			context.ExceptionHandled = true;
		}

		private void HandleSellerDoesntExistException(ExceptionContext context)
		{
			var exception = (SellerDoesntExistException)context.Exception;

			var details = new ProblemDetails()
			{
				Title = "The specified resource was not found.",
				Detail = exception.Message
			};

			context.Result = new NotFoundObjectResult(details);

			context.ExceptionHandled = true;
		}

		private void HandleUnknownException(ExceptionContext context)
		{
			var details = new ProblemDetails
			{
				Status = StatusCodes.Status500InternalServerError,
				Title = "An error occurred while processing your request."
			};

			context.Result = new ObjectResult(details)
			{
				StatusCode = StatusCodes.Status500InternalServerError
			};

			context.ExceptionHandled = true;
		}
	}
}