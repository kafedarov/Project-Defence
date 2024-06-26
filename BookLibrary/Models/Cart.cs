﻿namespace BookLibrary.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public List<CartItem> CartItems { get; set; }
        
    }

    public class PaymentModel
    {
        public string Amount { get; set; }
        public string Currency { get; set; }
        
    }
}
