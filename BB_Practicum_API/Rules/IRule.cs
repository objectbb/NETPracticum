using System;
namespace BB_Practicum_API.Rules
{
    public interface IRule
    {
        bool ReturnMsg(IDish dish, int? pos=null);
    }
}
