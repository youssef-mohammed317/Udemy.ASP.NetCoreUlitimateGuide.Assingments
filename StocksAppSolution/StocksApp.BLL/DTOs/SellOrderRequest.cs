using StocksApp.BLL.CustomValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksApp.BLL.DTOs;

public class SellOrderRequest
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
    [Range(1, 10000)]
    [Required]
    public double? Price { get; set; }
}
