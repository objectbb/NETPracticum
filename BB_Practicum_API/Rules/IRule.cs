using System;
namespace BB_Practicum_API.Rules
{
    public interface IRule
    {
        string ReturnMsg(IDish dish, int? pos=null);
    }
}
