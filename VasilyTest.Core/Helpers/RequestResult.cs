﻿using Microsoft.AspNetCore.Http;

namespace VasilyTest.Core.Helpers
{
    public class RequestResult
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public bool IsSuccess => StatusCode == StatusCodes.Status200OK;

        public RequestResult() { StatusCode = StatusCodes.Status200OK; }

        public RequestResult(int statusCode)
        {
            StatusCode = statusCode;
        }
    }

    public class RequestResult<T> : RequestResult
    {
        public T Obj { get; set; }

        public RequestResult() { }

        public RequestResult(int statusCode) : base(statusCode) { }
    }
}
