using Cerberus.Application.Common.Interfaces;
using System;

namespace Cerberus.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
