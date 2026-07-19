using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdersWebApi.Controllers;
using OrdersWebApi.Database.Contexts;
using OrdersWebApi.DTOs.OrderDto;
using OrdersWebApi.DTOs.OrderDtos;
using OrdersWebApi.DTOs.OrderItemDtos;
using OrdersWebApi.Models;

public class OrdersController(ApplicationDbContext context) : CustomControllerBase
{
    private readonly ApplicationDbContext context = context;
    /// <summary>
    /// Retrieves a list of all orders.
    /// </summary>
    /// <response code="200">Returns the list of orders.</response>
    // GET /api/orders
    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        var orders = await context.Orders
            .Select(o => OrderResponse.CreateFromOrder(o))
            .ToListAsync();

        return Ok(orders);
    }
    /// <summary>
    /// Retrieves an order by its ID.
    /// </summary>
    /// <param name="id">The ID of the order to retrieve.</param>
    /// <response code="200">The order was found and returned.</response>
    /// <response code="404">No order exists with the given ID.</response>
    // GET /api/orders/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetOrderById([FromRoute] Guid id)
    {
        var order = await context.Orders.FirstOrDefaultAsync(o => o.OrderId == id);
        if (order == null)
            return NotFound();

        return Ok(OrderResponse.CreateFromOrder(order));
    }
    /// <summary>
    /// Adds a new order along with its order items.
    /// </summary>
    /// <param name="request">The order details, including at least one item.</param>
    /// <response code="201">The order was created successfully.</response>
    /// <response code="400">The request failed validation (e.g. missing items).</response>
    // POST /api/orders
    [HttpPost]
    [ProducesResponseType(typeof(OrderResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
    {
        var orderItems = request.Items!.Select(i => i.ToOrderItem()).ToList();

        var order = new Order
        {
            CustomerName = request.CustomerName,
            TotalAmount = orderItems.Sum(i => i.TotalPrice),
            OrderItems = orderItems
        };

        context.Orders.Add(order);
        await context.SaveChangesAsync(); // EF assigns OrderId and fixes up each item's OrderId via the navigation property

        var response = OrderResponse.CreateFromOrder(order);
        return CreatedAtAction(nameof(GetOrderById), new { id = order.OrderId }, response);
    }
    /// <summary>
    /// Updates an existing order's customer name.
    /// </summary>
    /// <param name="id">The ID of the order to update, from the route.</param>
    /// <param name="request">The updated order details.</param>
    /// <response code="200">The order was updated successfully.</response>
    /// <response code="400">The ID in the route does not match the ID in the body.</response>
    /// <response code="404">No order exists with the given ID.</response>
    // PUT /api/orders/{id}
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateOrder([FromRoute] Guid id, [FromBody] OrderUpdateRequest request)
    {
        if (id != request.OrderId)
            return BadRequest("Order ID in the route does not match the ID in the request body.");

        var order = await context.Orders.FirstOrDefaultAsync(o => o.OrderId == id);
        if (order == null)
            return NotFound();

        order.CustomerName = request.CustomerName;
        await context.SaveChangesAsync();

        return Ok(OrderResponse.CreateFromOrder(order));
    }
    // <summary>
    /// Deletes an order by its ID.
    /// </summary>
    /// <param name="id">The ID of the order to delete.</param>
    /// <response code="204">The order was deleted successfully.</response>
    /// <response code="404">No order exists with the given ID.</response>
    // DELETE /api/orders/{id}
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteOrder([FromRoute] Guid id)
    {
        var order = await context.Orders.FirstOrDefaultAsync(o => o.OrderId == id);
        if (order == null)
            return NotFound();

        context.Orders.Remove(order);
        await context.SaveChangesAsync(); // related OrderItems are removed via DB cascade delete (required FK)

        return NoContent();
    }
    /// <summary>
    /// Retrieves all order items belonging to a specific order.
    /// </summary>
    /// <param name="orderId">The ID of the order whose items are being retrieved.</param>
    /// <response code="200">Returns the list of order items.</response>
    /// <response code="404">No order exists with the given ID.</response>
    // GET /api/orders/{orderId}/items
    // GET /api/orders/{orderId}/items
    [HttpGet("{orderId:guid}/items")]
    public async Task<IActionResult> GetAllOrderItems([FromRoute] Guid orderId)
    {
        var orderExists = await context.Orders.AnyAsync(o => o.OrderId == orderId);
        if (!orderExists)
            return NotFound();

        var items = await context.OrderItems
            .Where(i => i.OrderId == orderId)
            .Select(i => OrderItemResponse.CreateFromOrderItem(i))
            .ToListAsync();

        return Ok(items);
    }
    /// <summary>
    /// Retrieves a single order item by its ID.
    /// </summary>
    /// <param name="orderId">The ID of the order the item belongs to.</param>
    /// <param name="id">The ID of the order item to retrieve.</param>
    /// <response code="200">The order item was found and returned.</response>
    /// <response code="404">No order item exists with the given ID.</response>
    // GET /api/orders/{orderId}/items/{id}
    // GET /api/orders/{orderId}/items/{id}
    [HttpGet("{orderId:guid}/items/{id:guid}")]
    public async Task<IActionResult> GetOrderItemById([FromRoute] Guid orderId, [FromRoute] Guid id)
    {
        var item = await context.OrderItems
            .FirstOrDefaultAsync(i => i.OrderId == orderId && i.OrderItemId == id);

        if (item == null)
            return NotFound();

        return Ok(OrderItemResponse.CreateFromOrderItem(item));
    }
    /// <summary>
    /// Adds a new order item to an existing order. The item's total price is
    /// calculated automatically, and the parent order's total amount is updated.
    /// </summary>
    /// <param name="orderId">The ID of the order to add the item to.</param>
    /// <param name="request">The order item details (product name, quantity, unit price).</param>
    /// <response code="201">The order item was created successfully.</response>
    /// <response code="400">The request failed validation.</response>
    /// <response code="404">No order exists with the given ID.</response>
    // POST /api/orders/{orderId}/items
    [HttpPost("{orderId:guid}/items")]
    public async Task<IActionResult> AddOrderItem([FromRoute] Guid orderId, [FromBody] OrderItemAddRequest request)
    {
        var order = await context.Orders
            .Include(o => o.OrderItems)
            .FirstOrDefaultAsync(o => o.OrderId == orderId);

        if (order == null)
            return NotFound();

        var newItem = request.ToOrderItem();
        newItem.OrderId = orderId;

        context.OrderItems.Add(newItem);
        order.TotalAmount = order.OrderItems.Sum(i => i.TotalPrice) + newItem.TotalPrice; // include the new item not yet in the loaded collection

        await context.SaveChangesAsync();

        var response = OrderItemResponse.CreateFromOrderItem(newItem);
        return CreatedAtAction(nameof(GetOrderItemById), new { orderId, id = newItem.OrderItemId }, response);
    }
    /// <summary>
    /// Updates an existing order item. The total price is recalculated from the
    /// new quantity and unit price, and the parent order's total amount is updated.
    /// </summary>
    /// <param name="orderId">The ID of the order the item belongs to.</param>
    /// <param name="id">The ID of the order item to update, from the route.</param>
    /// <param name="request">The updated order item details.</param>
    /// <response code="200">The order item was updated successfully.</response>
    /// <response code="400">The ID in the route does not match the ID in the body.</response>
    /// <response code="404">No order or order item exists with the given ID.</response>
    // PUT /api/orders/{orderId}/items/{id}
    [HttpPut("{orderId:guid}/items/{id:guid}")]
    public async Task<IActionResult> UpdateOrderItem(
        [FromRoute] Guid orderId, [FromRoute] Guid id, [FromBody] OrderItemUpdateRequest request)
    {
        if (id != request.OrderItemId)
            return BadRequest("Order item ID in the route does not match the ID in the request body.");

        var order = await context.Orders
            .Include(o => o.OrderItems)
            .FirstOrDefaultAsync(o => o.OrderId == orderId);

        if (order == null)
            return NotFound();

        var orderItem = order.OrderItems.FirstOrDefault(i => i.OrderItemId == id);
        if (orderItem == null)
            return NotFound();

        orderItem.ProductName = request.ProductName;
        orderItem.Quantity = request.Quantity;
        orderItem.UnitPrice = request.UnitPrice;
        orderItem.TotalPrice = request.Quantity * request.UnitPrice; // recalculated, never trusted from client

        order.TotalAmount = order.OrderItems.Sum(i => i.TotalPrice) ?? 0;

        await context.SaveChangesAsync();

        return Ok(OrderItemResponse.CreateFromOrderItem(orderItem));
    }
    /// <summary>
    /// Deletes an order item and updates the parent order's total amount accordingly.
    /// </summary>
    /// <param name="orderId">The ID of the order the item belongs to.</param>
    /// <param name="id">The ID of the order item to delete.</param>
    /// <response code="204">The order item was deleted successfully.</response>
    /// <response code="404">No order or order item exists with the given ID.</response>
    // DELETE /api/orders/{orderId}/items/{id}
    // DELETE /api/orders/{orderId}/items/{id}
    [HttpDelete("{orderId:guid}/items/{id:guid}")]
    public async Task<IActionResult> DeleteOrderItem([FromRoute] Guid orderId, [FromRoute] Guid id)
    {
        var order = await context.Orders
            .Include(o => o.OrderItems)
            .FirstOrDefaultAsync(o => o.OrderId == orderId);

        if (order == null)
            return NotFound();

        var orderItem = order.OrderItems.FirstOrDefault(i => i.OrderItemId == id);
        if (orderItem == null)
            return NotFound();

        context.OrderItems.Remove(orderItem);
        order.TotalAmount = order.OrderItems.Where(i => i.OrderItemId != id).Sum(i => i.TotalPrice) ?? 0;

        await context.SaveChangesAsync();

        return NoContent();
    }
}