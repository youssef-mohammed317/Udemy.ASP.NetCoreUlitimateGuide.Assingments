using StocksApp.Core.CustomValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksApp.Core.DTOs;

public class BuyOrderRequest
{
    [Required]
    public string? StockSymbol { get; set; }
    [Required]
    public string? StockName { get; set; }

    [DateRange(startDate: "2000-01-01")]
    public DateTime? DateAndTimeOfOrder { get; set; }
    [Range(1, 100000)]
    [Required]
    public uint? Quantity { get; set; }
    [Required]
    [Range(1, 10000)]
    public double? Price { get; set; }
}
