using LogixApi_v02.DbContexts;
using LogixApi_v02.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
namespace LogixApi_v02.Helpers
{
    public static class DateHelper
    {
        public static string DateToString(DateTime date)
        {
            return date.ToString("yyyy/MM/dd");
        }

        public static string DateToString(DateTime date, CultureInfo culture)
        {
            return date.ToString("yyyy/MM/dd", culture);
        }
        public static DateTime StringToDate1(string? dateString)
        {
            if (string.IsNullOrEmpty(dateString) || dateString.Length != 10)
            {
                throw new ArgumentException("Invalid date string format.");
            }
            string[] dateParts = dateString.Split('/');
            if (dateParts.Length != 3)
            {
                throw new ArgumentException("Invalid date string format.");
            }

            int year, month, day;
            if (!int.TryParse(dateParts[0], out year) || dateParts[0].Length != 4 || !int.TryParse(dateParts[1], out month) || !int.TryParse(dateParts[2], out day))
            {
                throw new ArgumentException("Invalid date string format.");
            }

            return new DateTime(year, month, day);
        }


        public static DateTime StringToDate2(string dateString)
        {
            DateTime parsedDate;
            string[] formats = { "yyyy/MM/dd", "MM/dd/yyyy", "dd/MM/yyyy" };

            if (!DateTime.TryParseExact(dateString, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                throw new ArgumentException("Invalid date string format.");
            }

            return parsedDate;
        }


        public static string? FixConvertDateFormate(string str_date)
        {
            DateTime date;
            if (
                DateTime.TryParseExact(str_date, "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date)
                || DateTime.TryParseExact(str_date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date)
                || DateTime.TryParseExact(str_date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date)
                || DateTime.TryParseExact(str_date, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date)

           )
            {


            }
            else
            {
                return null;
            }

            return date.ToString("yyyy/MM/dd");
        }

     


    }
}
