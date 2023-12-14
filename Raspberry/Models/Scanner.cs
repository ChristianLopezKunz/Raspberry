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
        public int zealandid { get; set; }

        public Scanner(int id, DateTime dateTime, int zealandid)
        {
            this.id = id;
            DateTime = dateTime;
            this.zealandid = zealandid;
        }

        public Scanner()
        {
            
        }

        public override bool Equals(object? obj)
        {
            return obj is Scanner scanner &&
                   id == scanner.id &&
                   DateTime == scanner.DateTime &&
                   zealandid == scanner.zealandid;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id, DateTime, zealandid);
        }

        public override string ToString()
        {
            return $"{{{nameof(id)}={id.ToString()}, {nameof(DateTime)}={DateTime.ToString()}, {nameof(zealandid)}={zealandid.ToString()}}}";
        }
    }
}
