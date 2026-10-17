using System.ComponentModel.DataAnnotations;

namespace S1120359CoreMVClab1005.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [StringLength(100)]
        public string Department { get; set; }
            
        // 一位學生可以推薦多個景點 (? è 允許為 null, FK: 不會輸入資料)
        public ICollection<Spot>? Spots { get; set; }
        // 一位學生可以投多個票（例如對不同景點）, (? 允許為 null, FK: 不會輸入資料)
        // public ICollection<Vote>? Votes { get; set; }
    }
}
