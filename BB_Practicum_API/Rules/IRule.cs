using System;
namespace BB_Practicum_API.Rules
{
    public interface IRule
    {
        bool IsCorrect(IDish dish, int? pos=null);
    }
}
