namespace API.Dtos
{
    public class CreateCardDTO
    {
        public string CardNumber { get; set; } = null!;
        public DateTime? CreateDate { get; set; }
        public string? Status { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
