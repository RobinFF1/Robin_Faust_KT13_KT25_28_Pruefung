using System;

namespace StundenplanDb.Components.Pages
{
    public partial class StundenplanCreate
    {
        // Falls deine Komponente / Model bereits andere Namen verwendet,
        // passe die Namen entsprechend an (StartTime, EndTime, Datum).
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public DateTime? Datum { get; set; }

        // Bind an <input type="time" />
        public string StartTimeString
        {
            get => StartTime.HasValue ? StartTime.Value.ToString("HH:mm") : string.Empty;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    StartTime = null;
                    return;
                }
                if (TimeOnly.TryParse(value, out var parsed))
                    StartTime = parsed;
                else
                    StartTime = null;
            }
        }

        public string EndTimeString
        {
            get => EndTime.HasValue ? EndTime.Value.ToString("HH:mm") : string.Empty;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    EndTime = null;
                    return;
                }
                if (TimeOnly.TryParse(value, out var parsed))
                    EndTime = parsed;
                else
                    EndTime = null;
            }
        }

        // Bind an <input type="date" />
        public string DatumString
        {
            get => Datum.HasValue ? Datum.Value.ToString("yyyy-MM-dd") : string.Empty;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Datum = null;
                    return;
                }
                if (DateTime.TryParse(value, out var parsed))
                    Datum = parsed.Date;
                else
                    Datum = null;
            }
        }
    }
}