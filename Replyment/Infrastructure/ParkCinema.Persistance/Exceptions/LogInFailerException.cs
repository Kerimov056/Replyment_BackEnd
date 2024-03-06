﻿using System.Net;

namespace Replyment.Persistance.Exceptions;

public class LogInFailerException : Exception, IBaseException
{
    public int StatusCode { get; set; }

    public string CustomMessage { get; set; }

    public LogInFailerException(string message) : base(message) 
    {
        CustomMessage = message;
        StatusCode = (int)HttpStatusCode.BadRequest;
    }
}
