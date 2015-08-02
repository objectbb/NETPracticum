using System;
namespace BB_Practicum_API
{
    public interface IDish
    {
        string Name { get; set; }
        string Type { get; set; }
        int TypeId { get; set; }
        bool IsMultiple { get; set; }
        string TimeofDay { get; set; }
    }
}
