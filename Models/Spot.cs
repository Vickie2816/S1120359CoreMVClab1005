using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S1120359CoreMVClab1005.Models
{
    public class Spot
    {
        [Key]
        public int SpotId { get; set; }
        [Required, StringLength(150)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [StringLength(200)]
        public string Location { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        // 推薦該景點的學生 (外鍵)
        [ForeignKey("Recommender")]
        public int RecommenderId { get; set; }
        public Student? Recommender { get; set; }
        // 一個景點可以被多張投票記錄關聯 (? 允許為 null, FK: 不會輸入資料)
        // public ICollection<Vote>? Votes { get; set; }
    }
}