using FE.Weather.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FE.Weather.Repositories.Services
{
    public abstract class AbstractService<TRequest, TResponse>
    {
        protected string WarningMessage { get; set; }

        public virtual ResultStatus<TResponse> Execute(TRequest request)
        {
            try
            {
                TResponse result = ProcessRequest(request);

                if (!string.IsNullOrWhiteSpace(WarningMessage))
                {
                    return ResultStatus<TResponse>.CreateWarningStatus(WarningMessage, result);
                }
                return ResultStatus<TResponse>.CreateSuccessStatus(result);
            }
            catch (Exception ex)
            {
                return ResultStatus<TResponse>.CreateErrorStatus(ex.Message);
            }
        }

        protected abstract TResponse ProcessRequest(TRequest request);
    }
}
