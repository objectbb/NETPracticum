using System;
namespace BB_Practicum_API.Rules
{
    public abstract class AbstractRuleMultipleOrder : IRule
    {
        public string ErrorMsg { get { return "Error"; } }
        public abstract string ReturnMsg(IDish dish, int? pos = null);
    }
}
