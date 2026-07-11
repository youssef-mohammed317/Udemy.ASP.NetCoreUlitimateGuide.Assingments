using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksApp.DAL.Entities;

public class SellOrder
{
    public Guid SellOrderID { get; set; }
    [Required]
    public string? StockSymbol { get; set; }
    [Required]
    public string? StockName { get; set; }
    public DateTime? DateAndTimeOfOrder { get; set; }
    [Range(1, 100000)]
    public uint? Quantity { get; set; }//1-100000
    [Range(1, 10000)]
    public double? Price { get; set; }//1-10000
}
