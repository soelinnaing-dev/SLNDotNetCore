using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SLNDotNetCore.PizzaAPI.Models
{
    [Table("Tbl_Pizza")]
    public class Pizza
    {
        [Key]
        public int PizzaId { get; set; }
        public string PizzaName { get; set; }
        public decimal Price { get; set; }
        [NotMapped]
        public string PizzaPriceStr { get { return "$" + Price; } }
    }

    [Table("Tbl_Extra")]
    public class Extra
    {
        [Key]
        public int ExtraId { get; set; }
        public string ExtraName { get; set; }
        public decimal ExtraPrice {  get; set; }
        [NotMapped]
        public string ExtraPriceStr { get {  return "$" + ExtraPrice; } }
    }

    [Table("Tbl_PizzaOrder")]
    public class PizzaOrder
    {
        [Key]
        public int PizzaOrderId { get; set; }
        public string PizzaOrderInvoiceNo { get; set; }
        public int PizzaId { get; set; }
        public decimal TotalAmount { get; set; }
        [NotMapped]
        public string TotalAmountStr { get { return "$" + TotalAmount; } }
    }

    [Table("Tbl_PizzaOrderDetails")]
    public class PizzaOrderDetails
    {
        [Key]
        public int PizzaOrderDetailsId { get; set; }
        public string PizzaOrderInvoiceNo { get;set; }
        public int PizzaExtraId { get; set; }
    }

    public class RequestOrder
    {
        public int PizzaId { get; set; }
        public int[] extra { get; set; }
    }
    
    public class OrderResponse
    {
        public string Message { get; set; }
        public string invoiceNo {get; set; }
        public  decimal TotalAmount { get; set; }
    }

    public class OrderInvoiceHead
    {
        public int PizzaOrderId { get; set; }
        public string PizzaOrderInvoiceNo { get; set; }
        public int PizzaId { get; set; }
        public decimal TotalAmount { get; set; }
        public string PizzaName { get; set; }
        public decimal Price { get; set; }
    }

    public class OrderInvoiceDetails
    {
        public int PizzaOrderDetailsId { get; set; }
        public string PizzaOrderInvoiceNo { get; set; }
        public int PizzaExtraId { get; set; }
        public string ExtraName { get; set; }
        public decimal ExtraPrice { get; set; }
    }

    public class OrderInvoiceHeadDetailResponse
    {
        public OrderInvoiceHead order { get; set; }
        public List<OrderInvoiceDetails> orderDetails { get; set;}
    }
}
