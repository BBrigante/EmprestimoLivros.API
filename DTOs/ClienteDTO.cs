using EmprestimosLivros.API.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace EmprestimosLivros.API.DTOs
{
    public class ClienteDTO
    {
        [IgnoreDataMember]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'CPF' deve ser preenchido.")]
        [StringLength(14)]
        [MinLength(14, ErrorMessage = "O CPF deve conter no mínimo 14 caracteres. ( Exemplo: '000.000.000-00' ) ")]
        public string? CliCpf { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' deve ser preenchido.")]
        [StringLength(200)]
        [MaxLength(200, ErrorMessage = "O Nome deve conter no máximo 200 caracteres. ( Exemplo: 'Alcides Oliveira da Silva' ) ")]
        public string? CliNome { get; set; }

        [Required(ErrorMessage = "O campo 'Endereço' deve ser preenchido.")]
        [StringLength(200)]
        [MaxLength(200, ErrorMessage = "O Endereço deve conter no máximo 200 caracteres. ( Exemplo: 'Rua Hernesto Oliveira' )")]
        public string? CliEndereco { get; set; }

        [Required(ErrorMessage = "O campo 'Cidade' deve ser preenchido.")]
        [StringLength(100)]
        [MaxLength(100, ErrorMessage = "A Cidade deve conter 100 caracteres. ( Exemplo: 'São Bernardo do Campo' )")]
        public string? CliCidade { get; set; }

        [Required(ErrorMessage = "O campo 'Bairro' deve ser preenchido.")]
        [StringLength(100)]
        [MaxLength(100, ErrorMessage = "O Bairro deve conter 100 caracteres. (Exemplo: 'Santa maria' )")]
        public string? CliBairro { get; set; }

        [Required(ErrorMessage = "O campo 'Número' deve ser preenchido.")]
        [StringLength(50)]
        [MaxLength(50, ErrorMessage = "O Número deve conter 50 caracteres. (Exemplo: '1000' )")]
        public string? CliNumero { get; set; }

        [Required(ErrorMessage = "O campo 'Celular' deve ser preenchido.")]
        [StringLength(14)]
        [MinLength(14, ErrorMessage = "O Celular deve conter no mínimo 14 caracteres. (Exemplo: '(00)00000.0000' )")]
        public string? CliTelefoneCelular { get; set; }

        [Required(ErrorMessage = "O campo 'Telefone' deve ser preenchido.")]
        [StringLength(13)]
        [MinLength(13, ErrorMessage = "O Telefone deve conter no mínimo 13 caracteres. (Exemplo: '(00)0000.0000)' ")]
        public string? CliTelefoneFixo { get; set; }        
    }
}
