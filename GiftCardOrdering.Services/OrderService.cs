using GiftCardOrdering.Data;
using GiftCardOrdering.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCardOrdering.Services
{
    public class OrderService
    {
        private readonly UserRepository _userRepository;
        private readonly OrderRepository _orderRepository;

        public OrderService(UserRepository userRepository, OrderRepository orderRepository)
        {
            _userRepository = userRepository;
            _orderRepository = orderRepository;
        }

        public void CreateOrder(Order order)
        {
            // Calculate the total amount for the order
            decimal totalAmount = CalculateTotalAmount(order);

            // Set the total amount and order date
            order.TotalAmount = totalAmount;
            order.OrderDate = DateTime.Now;

            // Save the order and associated gift cards
            _orderRepository.AddOrder(order);
        }      

        public Order GetOrder(int orderId)
        {
            return _orderRepository.GetOrderById(orderId);
        }

        private decimal CalculateTotalAmount(Order order)
        {
            decimal totalFaceValue = order.OrderGiftCards.Sum(ogc => ogc.GiftCard.FaceValue * ogc.Quantity);
            decimal totalServiceCost = order.OrderGiftCards.Sum(ogc => ogc.GiftCard.ServiceCost * ogc.Quantity);
            decimal deliveryCost = order.DeliveryOption.Cost;
            decimal subtotal = totalFaceValue + totalServiceCost + deliveryCost;
            decimal creditCardSurcharge = subtotal * (order.CreditCardSurcharge / 100);
            decimal totalAmount = subtotal + creditCardSurcharge;

            return totalAmount;
        }
      
    }
}
