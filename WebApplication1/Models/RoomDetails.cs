using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class RoomDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(7, MinimumLength = 3, ErrorMessage = "Only 3 to 7 character allowed.")]
        public string RegistrationId { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Only 20 character allowed.")]

        public string Name { get; set; }

        [Required]
        [StringLength(1, ErrorMessage = "Only 1 character allowed.")]
        public string RoomType { get; set; }

        [Required]
        [StringLength(1, ErrorMessage = "Only 1 character allowed.")]
        public string RoomCategory { get; set; }

        [Required]
        [StringLength(1, ErrorMessage = "Only 1 character allowed.")]
        public string BedType { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BookingDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]

        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

        public int price { get; set; }

        public int totdays { get; set; }



    }
}