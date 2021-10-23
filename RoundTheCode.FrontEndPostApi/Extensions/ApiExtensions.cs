using System;

namespace RoundTheCode.FrontEndPostApi.Extensions
{
    public static class ApiExtensions
    {
        public static TService NotNull<TService>(this TService controller)
        {
            if (controller == null)
            {
                throw new ArgumentNullException(nameof(controller));
            }

            return controller;
        }
    }
}
