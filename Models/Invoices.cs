using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFSystem.Models
{
    public class Invoices
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(50)]
        [Column("invoice_number")]
        public required string InvoiceNumber { get; set; }

        [Required]
        [Column("cnpj_service_provider")]
        public string CnpjServiceProvider { get; set; }

        [Required]
        [Column("cnpj_taker", TypeName = "char(14)")]
        public string CnpjTaker { get; set; }

        [Required]
        [Column("date_issue")]
        public DateOnly DateIssue { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("service_description")]
        public string ServiceDescription { get; set; }

        [Required]
        [Column("total_amount", TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Column("creation_date")]
        public DateTime CriationDate { get; set; } = DateTime.UtcNow;

    }
}
