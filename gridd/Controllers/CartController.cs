using gridd.Models;
using gridd;
using Microsoft.AspNetCore.Mvc;
using gridd.Extensions;
using System.Net.Mail;
using System.Net;
using System.Collections.Generic;
using System.Linq;

public class CartController : Controller
{
    private readonly MyDbContext _context;

    public CartController(MyDbContext context)
    {
        _context = context;
    }

    public IActionResult CartPage()
    {
        var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
        return View(cart);
    }

    [HttpPost]
    public IActionResult AddToCart(int productId)
    {
        var product = _context.Games.FirstOrDefault(p => p.Id == productId);

        if (product == null)
        {
            return NotFound();
        }

        var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();

        var cartItem = cart.FirstOrDefault(c => c.ProductId == productId);
        if (cartItem != null)
        {
            cartItem.Quantity++;
        }
        else
        {
            cart.Add(new CartItem
            {
                ProductId = product.Id,
                ProductName = product.NameGame,
                ProductImageUrl = product.ImageUrl,
                ProductPrice = product.Price,
                Quantity = 1
            });
        }

        HttpContext.Session.SetObjectAsJson("Cart", cart);

        return RedirectToAction("CartPage");
    }

    [HttpPost]
    public IActionResult PlaceOrder(string cardName, string cardNumber, string expiryDate, string cvv, string email)
    {
        var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart");

        if (cart != null && cart.Count > 0)
        {
            var totalAmount = cart.Sum(item => item.ProductPrice * item.Quantity);

            // Логика для обработки платежа (например, интеграция с платежным шлюзом)

            // Отправка чека на почту
            SendReceipt(email, cart, totalAmount);

            // Очистка корзины после оформления заказа
            HttpContext.Session.Remove("Cart");

            return RedirectToAction("OrderSuccess");
        }

        return RedirectToAction("CartPage");
    }

    private void SendReceipt(string email, List<CartItem> cart, decimal totalAmount)
    {
        var fromAddress = new MailAddress("kurbanov.airat2017@yandex.ru", "Grid");
        var toAddress = new MailAddress(email);
        const string fromPassword = "xdaqxsvjrxycbgcy";
        const string subject = "Чек за ваш заказ";
        string body = "Спасибо за ваш заказ!\n\n";

        foreach (var item in cart)
        {
            body += $"{item.ProductName} - {item.ProductPrice} $ (Количество: {item.Quantity})\n";
        }

        body += $"\nОбщая сумма: {totalAmount} $\n";
        body += "\nВаш заказ был успешно оформлен.";

        var smtp = new SmtpClient
        {
            Host = "smtp.yandex.ru", // Убедитесь, что этот хост правильный для вашего почтового провайдера
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        };

        using (var message = new MailMessage(fromAddress, toAddress)
        {
            Subject = subject,
            Body = body
        })
        {
            smtp.Send(message);
        }
    }

    public IActionResult OrderSuccess()
    {
        return View();
    }
    public IActionResult Checkout()
    {
        var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
        return View(cart);
    }

}
