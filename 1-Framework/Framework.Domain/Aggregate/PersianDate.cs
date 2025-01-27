﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Framework.Domain.Aggregate
{
    public partial class PersianDate : ValueObject
    {
        protected PersianDate() { }
        public  PersianDate(DateTime date)
        {
            this.date = (int)date.ToPersianDate();
        }

        public PersianDate(int date)
        {
            this.date = date;
        }
        public static implicit operator PersianDate(int d)
        {
            return new PersianDate(d);
        }

        private int date;
        public virtual int Date
        {
            get { return date; }
        }
        public virtual int Year { get { return date / 10000; } }
        public virtual int Month { get { return (date / 100) % 100; } }
        public virtual int Day { get { return date % 10000; } }

        public static bool operator <(PersianDate date, PersianDate fromDate)
        {
            return date.Date < fromDate.Date;
        }

        public static bool operator >(PersianDate date, PersianDate fromDate)
        {
            return date.Date > fromDate.Date;
        }

        public static bool operator <=(PersianDate date, PersianDate fromDate)
        {
            return date.Date <= fromDate.Date;
        }

        public static bool operator >=(PersianDate date, PersianDate fromDate)
        {
            return date.Date >= fromDate.Date;
        }
    }
}