using System;
using System.ComponentModel.DataAnnotations;

namespace LexiconLMS.Core.Attributes
{
    /// <summary>
    /// Ensures that the start date comes before the end date.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false)]
    public class DateOrderAttribute : ValidationAttribute
    {
        public string StartDatePropertyName { get; }
        public string EndDatePropertyName { get; }

        public DateOrderAttribute(string startDatePropertyName, string endDatePropertyName)
        {
            StartDatePropertyName = startDatePropertyName;
            EndDatePropertyName = endDatePropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // TODO: Implementation of the validation logic goes here.
            return ValidationResult.Success;
        }
    }

    /// <summary>
    /// Ensures that dates do not overlap with other entities' dates.
    /// </summary>
    /// 
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false)]
    public class NotOverlappingDatesAttribute : ValidationAttribute
    {
        public string DateRangeStartPropertyName { get; }
        public string DateRangeEndPropertyName { get; }

        public NotOverlappingDatesAttribute(string dateRangeStartPropertyName, string dateRangeEndPropertyName)
        {
            DateRangeStartPropertyName = dateRangeStartPropertyName;
            DateRangeEndPropertyName = dateRangeEndPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // TODO: Implement the validation logic
            return ValidationResult.Success;
        }
    }

    /// <summary>
    /// Ensures that dates are contained within the parent entity's dates.
    /// </summary>
    public class DateContainedWithinAttribute : ValidationAttribute
    {
        public string ParentStartDatePropertyName { get; }
        public string ParentEndDatePropertyName { get; }

        public DateContainedWithinAttribute(string parentStartDatePropertyName, string parentEndDatePropertyName)
        {
            ParentStartDatePropertyName = parentStartDatePropertyName;
            ParentEndDatePropertyName = parentEndDatePropertyName;
        }

        // Example validation logic implementation
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // TODO: Implement the validation logic
            return ValidationResult.Success;
        }
    }
}
