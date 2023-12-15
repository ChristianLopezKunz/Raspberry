using System.ComponentModel.DataAnnotations;

namespace Raspberry.Models
{
    public class Scanner
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public  DateTime DateTime { get; set; }
        [Required]
        public int zealandId { get; set; }

        public Scanner(int id, DateTime dateTime, int zealandId)
        {
            this.id = id;
            DateTime = dateTime;
            this.zealandId = zealandId;
        }

        public Scanner()
        {
            
        }

        public override bool Equals(object? obj)
        {
            return obj is Scanner scanner &&
                   id == scanner.id &&
                   DateTime == scanner.DateTime &&
                   zealandId == scanner.zealandId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id, DateTime, zealandId);
        }

        public override string ToString()
        {
            return $"{{{nameof(id)}={id.ToString()}, {nameof(DateTime)}={DateTime.ToString()}, {nameof(zealandId)}={zealandId.ToString()}}}";
        }
    }
}
