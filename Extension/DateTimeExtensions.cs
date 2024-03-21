using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAppAPI.Extension
{
    public static class DateTimeExtensions
{
    public static int CalculateAge(this DateOnly dob)
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        var age = today.Year - dob.Year;

        var hasHadBirthdayThisYear = dob <= today.AddDays(-age * 365); 

        return hasHadBirthdayThisYear ? age : age - 1;
    }
}
}