using Microsoft.AspNetCore.Mvc;

namespace  webapp2.Controllers
{
    public class LoginController : Controller
    {
        // 預設登入頁面
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // 處理按鈕提交邏輯
        [HttpPost]
        public IActionResult LoginAction(string ButtonOn)
        {
            if (ButtonOn == "1")
            {
                // 可以在這裡處理登入前的邏輯，例如記錄或檢查條件
                // 然後跳轉到登入頁面
                return Redirect("/Login");
            }

            // 若需要，處理其他按鈕值的情境
            return RedirectToAction("Error");
        }

        // 顯示真正的登入頁面
        [HttpGet]
        public IActionResult Login()
        {
            return View(); // 確保有對應的 Login.cshtml 視圖
        }
    }
}
