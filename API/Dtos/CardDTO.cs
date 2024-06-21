using API.Models;

namespace API.Dtos
{
    public class CardDTO
    {
        public int Id { get; set; }
        public string CardNumber { get; set; } = null!;
        public DateTime? CreateDate { get; set; }
        public string? Status { get; set; }
        public decimal? TotalPrice { get; set; }

        public string? CustomerName { get; set; }
        public string? Phone { get; set; }

        public List<string>? ComboName { get; set; }
        public int InvoiceId { get; set; }
    }
}
