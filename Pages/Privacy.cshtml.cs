using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webapp2.Pages;

public class PrivacyModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;
    [BindProperty]
    public Dictionary<string, List<BookingSlot>> schedule{ get; set; }
    //public Dictionary<string, List<BookingSlot>> dict=new Dictionary<string, List<BookingSlot>>();
    public PrivacyModel(ILogger<PrivacyModel> logger )
    {
        _logger = logger;
    }
     public IActionResult Index()
        {
           // 模擬生成 5 天的時間段 (週一至週五)
           schedule = new Dictionary<string, List<BookingSlot>>();
            var startDate = DateTime.Today;

            // 確保從週一開始
            while (startDate.DayOfWeek != DayOfWeek.Monday)
            {
                startDate = startDate.AddDays(-1);
            }

            // 建立週一至週五的時段資料
            for (int day = 0; day < 5; day++)
            {
                var currentDate = startDate.AddDays(day);
                var slots = new List<BookingSlot>();
                for (int hour = 17; hour < 21; hour++) // 從 5 PM 到 9 PM
                {
                    slots.Add(new BookingSlot
                    {
                        Date = currentDate,
                        Time = new TimeSpan(hour, 0, 0),
                        IsAvailable = true // 預設為可用
                    });
                }

                schedule.Add(currentDate.ToString("yyyy-MM-dd"), slots);
            }

            return Page();
        }
    public IActionResult OnGet()
    {
        ViewData["EndDate"] = DateTime.Parse("2024-11-30");
         // 模擬生成 5 天的時間段 (週一至週五)
           schedule = new Dictionary<string, List<BookingSlot>>();
            var startDate = DateTime.Today;

            // 確保從週一開始
            while (startDate.DayOfWeek != DayOfWeek.Monday)
            {
                startDate = startDate.AddDays(-1);
            }

            // 建立週一至週五的時段資料
            var slots = new List<BookingSlot>();
            for (int day = 0; day < 5; day++)
            {
                var currentDate = startDate.AddDays(day);
               // for (int hour = 17; hour < 21; hour++) // 從 5 PM 到 9 PM
                //{
                slots.Add(new BookingSlot
                    {
                        Date = currentDate,
                        Time = new TimeSpan(12, 15, 0),
                        IsAvailable = true // 預設為可用
                    });
                    slots.Add(new BookingSlot
                    {
                        Date = currentDate,
                        Time = new TimeSpan(17, 30, 0),
                        IsAvailable = true // 預設為可用
                    });
                     slots.Add(new BookingSlot
                    {
                        Date = currentDate,
                        Time = new TimeSpan(18, 10, 0),
                        IsAvailable = true // 預設為可用
                    });
                      slots.Add(new BookingSlot
                    {
                        Date = currentDate,
                        Time = new TimeSpan(18, 50, 0),
                        IsAvailable = true // 預設為可用
                    });
                      slots.Add(new BookingSlot
                    {
                        Date = currentDate,
                        Time = new TimeSpan(19, 30, 0),
                        IsAvailable = true // 預設為可用
                    });
                     slots.Add(new BookingSlot
                    {
                        Date = currentDate,
                        Time = new TimeSpan(20, 10, 0),
                        IsAvailable = true // 預設為可用
                    });
               // }

                schedule.Add(currentDate.ToString("yyyy-MM-dd"), slots);
            }
            
            slots.Add(new BookingSlot
                    {
                        Date = Convert.ToDateTime(ViewData["EndDate"]),
                        Time = new TimeSpan(9, 30, 0),
                        IsAvailable = true // 預設為可用
                    });
                    slots.Add(new BookingSlot
                    {
                        Date = Convert.ToDateTime(ViewData["EndDate"]),
                        Time = new TimeSpan(10, 10, 0),
                        IsAvailable = true // 預設為可用
                    });
                     slots.Add(new BookingSlot
                    {
                         Date = Convert.ToDateTime(ViewData["EndDate"]),
                        Time = new TimeSpan(10, 50, 0),
                        IsAvailable = true // 預設為可用
                    });
                      slots.Add(new BookingSlot
                    {
                        Date = Convert.ToDateTime(ViewData["EndDate"]),
                        Time = new TimeSpan(11,30, 0),
                        IsAvailable = true // 預設為可用
                    });
            schedule.Add(Convert.ToDateTime(ViewData["EndDate"]).ToString("yyyy-MM-dd"), 
            slots);
            return Page();
    }
}
 public class BookingSlot
    {
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public bool IsAvailable { get; set; }
    }
