using System.ComponentModel.DataAnnotations;

namespace simplebank.Model
{
    public class TransferCreateDTO
    {
        [Required(ErrorMessage = "O Id do remetente é obrigatório!")]
        public int FromUserId { get; set; }

        [Required(ErrorMessage = "O Id do destinatario é obrigatório!")]
        public int ToUserId { get; set; }

        [Required(ErrorMessage = "O valor da transferencia é obrigatório!")]
        public double Amount { get; set; }
    }
}