﻿namespace CashFlow.Exception;

public abstract class CashFlowException : SystemException
{
    protected CashFlowException(string message) : base(message)
    {

    }
}
