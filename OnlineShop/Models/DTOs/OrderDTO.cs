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
}