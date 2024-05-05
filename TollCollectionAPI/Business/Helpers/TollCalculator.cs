﻿

using Business.Models;
using Data.Models;
using Holidays;

namespace Business.Helpers
{
    public static class TollCalculator
    {

        private static int GetTollFee(DateTime date)
        {
            if (IsTollFreeDate(date)) return 0;

            int hour = date.Hour;
            int minute = date.Minute;

            if ((hour == 6 && minute >= 0 && minute < 30) || (hour >= 8 && hour < 15) || (hour == 18 && minute < 30))
                return 9;
            else if ((hour == 6 && minute >= 30 && minute < 60) || 
                (hour == 8 && minute >= 0 && minute < 30) || 
                (hour == 15 && minute >= 0 && minute < 30) || 
                (hour == 17) || (hour == 18 && minute >= 0 && minute < 30))
                return 16;
            else if ((hour == 7) || (hour == 15 && minute >= 30) || (hour == 16))
                return 22;
            else
                return 0;
        }

        private static bool IsTollFreeDate(DateTime date)
        {  
            return ReturnDates.isHoliday(date, ReturnDates.Country.Sweden, true, true) || date.Month == 7;
        }

        public static TollResult CalculateTaxPerDay(List<TollPassage> tollPassages)
        {
            var tolResult = new TollResult
            {
                VehicleRegistrationNumber = tollPassages.FirstOrDefault()!.RegistrationNumber,
                TotalTaxAmount = 0
            };

            int i = 0;
            while (i < tollPassages.Count)
            {
                DateTime currentTimestamp = tollPassages[i].Timestamp;
                int maxHourTax = GetTollFee(currentTimestamp);

                int j = i + 1;
                while (j < tollPassages.Count && tollPassages[j].Timestamp <= currentTimestamp.AddMinutes(60))
                {
                    int tax = GetTollFee(tollPassages[j].Timestamp);
                    if (tax > maxHourTax)
                    {
                        maxHourTax = tax;
                    }
                    j++;
                }

                tolResult.TotalTaxAmount += maxHourTax;
                if (tolResult.TotalTaxAmount > 60)
                    tolResult.TotalTaxAmount = 60;

                i = j;
            }

            return tolResult;
        }
    }
}
