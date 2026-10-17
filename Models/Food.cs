using System.ComponentModel.DataAnnotations;

namespace S1120359CoreMVClab1005.Models
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }

        [Required(ErrorMessage = "請輸入美食名稱")]
        [StringLength(100)]
        [Display(Name = "美食名稱")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "請選擇美食類別")]
        [StringLength(50)]
        [Display(Name = "美食類別")]
        public string Category { get; set; } = string.Empty;

        [Required(ErrorMessage = "請輸入店家名稱")]
        [StringLength(100)]
        [Display(Name = "店家名稱")]
        public string Restaurant { get; set; } = string.Empty;

        [Required(ErrorMessage = "請輸入地點")]
        [StringLength(200)]
        [Display(Name = "地點")]
        public string Location { get; set; } = string.Empty;

        [Range(0, 100000, ErrorMessage = "價格不可小於 0")]
        [Display(Name = "價格")]
        public decimal Price { get; set; }

        [Range(1, 5, ErrorMessage = "評分請輸入 1 到 5")]
        [Display(Name = "推薦評分（1～5）")]
        public int Rating { get; set; } = 5;

        [StringLength(500)]
        [Display(Name = "美食介紹")]
        public string? Description { get; set; }
    }
}
