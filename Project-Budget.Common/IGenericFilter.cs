using System;

namespace Project_Budget.Common
{
    public interface IGenericFilter
    {
        string Abrv { get; set; }
        Guid? Id { get; set; }
        string Name { get; set; }
    }
}