using System;

namespace Project_Budget.Model
{
    public interface IBaseModel
    {
        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }
        Guid Id { get; set; }
    }
}