using System.Globalization;

namespace API.Ultils
{
    public class FormatDateTimeUtils
    {
        public static DateTime ParseDateTimeLikeSSMS(string dateString)
        {
            //'T'HH: mm: ss
            string format = "yyyy-MM-dd"; // Adjust format based on your string
            DateTime convertedDateTime;
            convertedDateTime = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);
            return convertedDateTime;
        }
    }
}
