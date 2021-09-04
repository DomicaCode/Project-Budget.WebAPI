using System.ComponentModel.DataAnnotations;

namespace Project_Budget.WebAPI.Models
{
    public class CategoryViewModel
    {
        #region Properties

        [Required]
        public string Name { get; set; }

        #endregion Properties
    }
}