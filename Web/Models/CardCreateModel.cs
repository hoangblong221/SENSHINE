namespace Web.Models
{
    public class CardCreateModel
    {
        public string CardNumber { get; set; } = null!;
        public DateTime? CreateDate { get; set; }
        public string? Status { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
