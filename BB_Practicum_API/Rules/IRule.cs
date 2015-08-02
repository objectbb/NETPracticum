using System;
namespace BB_Practicum_API.Rules
{
    public interface IRule
    {
        bool IsBroken(IDish dish, int? pos=null);
    }
}
