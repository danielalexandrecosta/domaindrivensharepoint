using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using Castle.Components.Validator;

namespace TrackMan.Framework.Validation
{
    public static class ValidationExtensions
    {
        static readonly ValidatorRunner Validator = new ValidatorRunner(new CachedValidationRegistry());
        static readonly ResourceManager Manager = new ResourceManager(
            "TrackMan.Framework.Resources.ValidationMessages", Assembly.GetExecutingAssembly());

        public static bool IsValid<T>(this T objectToValidate)
        {
            return Validator.IsValid(objectToValidate);
        }

        public static string[] ErrorMessages<T>(this T objectToValidate)
        {
            var messages = new List<string>();
            Array.ForEach(
                Validator.GetErrorSummary(objectToValidate).ErrorMessages,
                msg => messages.Add(Manager.GetString(msg)));

            return messages.ToArray();
        }
    }
}