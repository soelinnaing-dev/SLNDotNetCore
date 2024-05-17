namespace SLNDotNetCore.PizzaAPI.Features.Pizza.Query
{
    public class PizzaQuery
    {
        public static string orderquery { get; } = @"select po.*,p.PizzaName,p.Price from Tbl_PizzaOrder po
inner join Tbl_Pizza p on po.PizzaId = p.PizzaId
where po.PizzaOrderInvoiceNo = @pizzaOrderInvoiceNo";

        public static string detailsQuery { get; } = @"select pod.*,pe.ExtraName,pe.ExtraPrice from Tbl_PizzaOrderDetails pod
inner join Tbl_Extra pe on pod.PizzaExtraId = pe.ExtraId
where pod.PizzaOrderInvoiceNo = @pizzaOrderInvoiceNo";
    }
}
