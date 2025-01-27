﻿using System;
using System.Globalization;

namespace Framework.Domain.Aggregate
{
    public partial class PersianDateTime : ValueObject
    {
        protected PersianDateTime() { }

        public PersianDateTime(DateTime dateTime)
        {
            this.dateTime = dateTime.ToPersianDate() * 1000000000 + dateTime.ToPersianTime();
        }
        public PersianDateTime(long? dateTime)
        {
            dateTime = dateTime < 10000000000000000 ? dateTime * 1000 : dateTime;
            DateTime = dateTime ?? 13000101000000000;
        }

        public static implicit operator PersianDateTime(long d)
        {
            return new PersianDateTime(d);
        }

        private long date;
        public virtual long Date
        {
            get { return date; }
            set
            {
                date = value;
                dateTime = date * 1000000000 + Time;
            }
        }

        private long time;
        public virtual long Time
        {
            get { return time; }
            set
            {
                time = value;
                dateTime = date * 1000000000 + time;
            }
        }

        private long dateTime;
        public virtual long DateTime
        {
            get { return date * 1000000000 + time; }
            private set
            {
                dateTime = value;
                date = value / 1000000000;
                time = value % 1000000000;
            }
        }

        public DateTime ToDateTime()
        {
            var calendar = new PersianCalendar();
            return new DateTime(this.Year, this.Month, this.Day, this.Hour, this.Minute, this.Second, this.Milisecond, calendar);
        }
        public DateTimeOffset ToDateTimeOffset()
        {
            return new DateTimeOffset(ToDateTime());
        }
        public int Year { get { return (int)Date / 10000; } }
        public int Month { get { return (int)Date / 100 % 100; } }
        public int Day { get { return (int)Date % 100; } }
        public int Hour { get { return (int)Time / 10000000; } }
        public int Minute { get { return (int)Time / 100000 % 100; } }
        public int Second { get { return (int)Time / 1000 % 100; } }
        public int Milisecond { get { return (int)Time % 1000; } }
    }
}