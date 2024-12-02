using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
namespace webapp2.Pages;

public class PrivacyModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;
    [BindProperty]
    public DateTime startDate { get; set; }
     public DateTime endDate { get; set; }
public string desc{get;set;}
        public Dictionary<string, List<BookingSlot>> schedule{ get; set; }
    //public Dictionary<string, List<BookingSlot>> dict=new Dictionary<string, List<BookingSlot>>();
    public PrivacyModel(ILogger<PrivacyModel> logger )
    {
        _logger = logger;
    }
     public IActionResult Index()
        {
            ViewData["startDate"] ="2024-12-02";
            ViewData["endDate"] ="2024-12-07";
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
    public void GenerateData(string startDate,string endDate)
    {
        // 模擬生成 5 天的時間段 (週一至週五)
           this.schedule = new Dictionary<string, List<BookingSlot>>();
            //var startDate = DateTime.Today;

            // 確保從週一開始
            //while (startDate.DayOfWeek != DayOfWeek.Monday)
            //{
            //    startDate = startDate.AddDays(-1);
            //}

            // 建立週一至週五的時段資料
            var slots = new List<BookingSlot>();
            for (int day = 0; day < 5; day++)
            {
                var currentDate = Convert.ToDateTime(startDate).AddDays(day);
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
                        Date = Convert.ToDateTime(endDate),
                        Time = new TimeSpan(9, 30, 0),
                        IsAvailable = true // 預設為可用
                    });
                    slots.Add(new BookingSlot
                    {
                        Date = Convert.ToDateTime(endDate),
                        Time = new TimeSpan(10, 10, 0),
                        IsAvailable = true // 預設為可用
                    });
                     slots.Add(new BookingSlot
                    {
                         Date = Convert.ToDateTime(endDate),
                        Time = new TimeSpan(10, 50, 0),
                        IsAvailable = true // 預設為可用
                    });
                      slots.Add(new BookingSlot
                    {
                        Date = Convert.ToDateTime(endDate),
                        Time = new TimeSpan(11,30, 0),
                        IsAvailable = true // 預設為可用
                    });
            schedule.Add(Convert.ToDateTime(endDate).ToString("yyyy-MM-dd"), 
            slots);


    }
    public IActionResult OnGet()
    {
        this.desc="";
        var sDate= "2024-12-02";
        var eDate ="2024-12-07";
        ViewData["startDate"] = Convert.ToDateTime(sDate);
        ViewData["endDate"] = Convert.ToDateTime(eDate);;
        this.startDate = Convert.ToDateTime(sDate);
       this.endDate = Convert.ToDateTime(eDate);;
         GenerateData(sDate,eDate);
            return Page();
    }
   public IActionResult OnGetReadMsg()
        {
            var sDate= "2024-11-25";
            var eDate ="2024-11-30";
             ViewData["StartDate"] = Convert.ToDateTime(sDate);
            ViewData["EndDate"] = Convert.ToDateTime(eDate);;
            GenerateData(sDate,eDate);
            return Partial("_partial_Booking",this);
        }
    public IActionResult OnPostQuery(string startDate,string endDate)//[FromBody] string serializedModel
        {
            // Deserialize the model
           // var model = JsonConvert.DeserializeObject<PrivacyModel>(serializedModel);

            // Add a new item to the SelectedValues list
            //model.SelectedValues ??= new List<string>();
            //model.SelectedValues.Add("Default");
            this.desc=startDate;
            var sDate= startDate;
            var eDate =endDate;
             ViewData["StartDate"] = Convert.ToDateTime(sDate);
            ViewData["EndDate"] = Convert.ToDateTime(eDate);
            this.startDate = Convert.ToDateTime(sDate);
            this.endDate = Convert.ToDateTime(eDate);;
            GenerateData(sDate,eDate);
            // Return the partial view with the updated model
            return Partial("_partial_Booking",this);
        }
}
 public class BookingSlot
    {
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public bool IsAvailable { get; set; }
    }
