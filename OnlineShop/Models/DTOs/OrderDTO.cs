namespace OnlineShop.Models.DTOs;

public class OrderDTO
{
    public int Id { get; set; }
    public UserDTO? UserDTO { get; set; }
    public decimal TotalPrice {get; set;}
    public List<OrderItemDTO> OrderItemsDTO {get; set;} = new();

    public OrderDTO(int id, UserDTO userDTO, decimal totalPrice, List<OrderItemDTO> orderItemsDTO)
    {
        Id = id;
        UserDTO = userDTO;
        TotalPrice = totalPrice;
        OrderItemsDTO = orderItemsDTO;
    }

    public async Task<OrderDTO> ToDto(Order order) => new(order.Id, new(order.User.UserName, order.User.Email, order.User.Id), order.TotalPrice, await order.OrderItemsListToDto(order.OrderItems));


}