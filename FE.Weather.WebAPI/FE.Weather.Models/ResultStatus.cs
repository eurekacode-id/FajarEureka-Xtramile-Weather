using System;
using System.Collections.Generic;
using System.Text;

namespace FE.Weather.Models
{
    public class ResultStatus
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = string.Empty;

        public ResultStatus() { }

        private ResultStatus(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
        public static ResultStatus CreateSuccessStatus()
        {
            return new ResultStatus(isSuccess: true, message: string.Empty);
        }

        public static ResultStatus CreateErrorStatus(string errorMessage)
        {
            return new ResultStatus(isSuccess: false, message: errorMessage);
        }
    }

    public class ResultStatus<TResult>
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public TResult ResultData { get; set; } = default;
        public string MessageType { get; set; } = ResultStatusType.SUCCESS;

        public ResultStatus() { }
        protected ResultStatus(bool isSuccess, string message, TResult resultData)
        {
            IsSuccess = isSuccess;
            Message = message;
            ResultData = resultData;
            MessageType = isSuccess ? ResultStatusType.SUCCESS : ResultStatusType.ERROR;
        }
        protected ResultStatus(bool isSuccess, string message, TResult resultData, string messageType)
        {
            IsSuccess = isSuccess;
            Message = message;
            ResultData = resultData;
            MessageType = messageType;
        }
        public static ResultStatus<TResult> CreateSuccessStatus(TResult resultDataToSend)
        {
            return new ResultStatus<TResult>(
                isSuccess: true,
                message: string.Empty,
                resultData: resultDataToSend);
        }

        public static ResultStatus<TResult> CreateWarningStatus(string warningMessage, TResult resultDataToSend)
        {
            return new ResultStatus<TResult>(
                isSuccess: true,
                message: warningMessage,
                resultData: resultDataToSend,
                messageType: ResultStatusType.WARNING);
        }

        public static ResultStatus<TResult> CreateErrorStatus(string errorMessage)
        {
            return new ResultStatus<TResult>(
                isSuccess: false,
                message: errorMessage,
                resultData: default(TResult));
        }
    }

    public static class ResultStatusType
    {
        public static readonly string SUCCESS = "SUCCESS";
        public static readonly string WARNING = "WARNING";
        public static readonly string ERROR = "ERROR";
    }
}
