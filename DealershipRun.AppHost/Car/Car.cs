using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealershipRun.AppHost.Car
{
    public class Car
    {
        private long id { get; set; }
        private string brand { get; set; }
        private string model { get; set; }
        private int year { get; set; }
        private double price { get; set; }
        private double mileage { get; set; }
        private CarStatus carStatus { get; set; }

    }
}
