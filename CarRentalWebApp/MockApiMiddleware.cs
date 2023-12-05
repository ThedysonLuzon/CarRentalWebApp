using System.Text.Json;
using CarRentalWebApp.MockRepositories;
using CarRentalWebApp.Models;
using CarRentalWebApp.Repositories;
using Microsoft.AspNetCore.JsonPatch;

public class MockApiMiddleware
{
   /* private readonly RequestDelegate _next;
   // private readonly MockCarRepository _mockCarRepository;
    private readonly MockBookingRepository _mockBookingRepository;
    private readonly MockCarRentalRepository _mockCarRentalRepository; 

    public MockApiMiddleware(RequestDelegate next)
    {
        _next = next;
     //   _mockCarRepository = new MockCarRepository();
        _mockBookingRepository = new MockBookingRepository();
        _mockCarRentalRepository = new MockCarRentalRepository();
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/mock/api/cars"))
        {
            await HandleMockCarRequests(context);
            return;
        }
        else if (context.Request.Path.StartsWithSegments("/mock/api/bookings"))
        {
            await HandleMockBookingRequests(context);
            return;
        }
        else if (context.Request.Path.StartsWithSegments("/mock/api/carrentals")) 
        {
            await HandleMockCarRentalRequests(context); 
            return;
        }
        await _next(context);
    }

    private async Task HandleMockCarRequests(HttpContext context)
    {
        switch (context.Request.Method)
        {
            case "GET":
                await HandleGet(context);
                break;
            case "POST":
                await HandlePost(context);
                break;
            case "PUT":
                await HandlePut(context);
                break;
            case "PATCH":
                await HandlePatch(context);
                break;
            case "DELETE":
                await HandleDelete(context);
                break;
            default:
                context.Response.StatusCode = StatusCodes.Status405MethodNotAllowed;
                break;
        }
    }
    private async Task HandleMockBookingRequests(HttpContext context)
    {
        switch (context.Request.Method)
        {
            case "GET":
                await HandleGetBookings(context);
                break;
            case "PATCH":
                await HandlePatchBooking(context);
                break;
            case "POST":
                await HandlePostBooking(context);
                break;
            case "PUT":
                await HandlePutBooking(context);
                break;
            case "DELETE":
                await HandleDeleteBooking(context);
                break;
            default:
                context.Response.StatusCode = StatusCodes.Status405MethodNotAllowed;
                break;
        }

    }
    private async Task HandleMockCarRentalRequests(HttpContext context)
    {
        switch (context.Request.Method)
        {
            case "GET":
                await HandleGetCarRentals(context);
                break;
            case "POST":
                await HandlePostCarRental(context);
                break;
            case "PUT":
                await HandlePutCarRental(context);
                break;
            case "PATCH":
                await HandlePatchCarRental(context);
                break;
            case "DELETE":
                await HandleDeleteCarRental(context);
                break;
            default:
                context.Response.StatusCode = StatusCodes.Status405MethodNotAllowed;
                break;
        }
    }

    private async Task HandleGet(HttpContext context)
    {
        var id = context.Request.Query["id"].FirstOrDefault();
        if (string.IsNullOrEmpty(id))
        {
           // var cars = await _mockCarRepository.GetAllAsync();
            await RespondWithJson(context, cars);
        }
        else
        {
           // var car = await _mockCarRepository.GetByIdAsync(id);
            if (car != null)
            {
                await RespondWithJson(context, car);
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
            }
        }
    }
    private async Task HandleDelete(HttpContext context)
    {
        var id = context.Request.Query["id"].FirstOrDefault();
        if (!string.IsNullOrEmpty(id))
        {
          //  await _mockCarRepository.DeleteAsync(id);
            context.Response.StatusCode = StatusCodes.Status204NoContent;
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
    private async Task HandlePut(HttpContext context)
    {
        var id = context.Request.Query["id"].FirstOrDefault();
        if (string.IsNullOrEmpty(id))
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            return;
        }

        try
        {
            var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
            var updatedCar = JsonSerializer.Deserialize<Car>(requestBody);

            if (updatedCar == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }

            //await _mockCarRepository.UpdateAsync(id, updatedCar);
            context.Response.StatusCode = StatusCodes.Status204NoContent;
        }
        catch (JsonException)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
        catch (KeyNotFoundException)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
        }
    }
    private async Task HandlePost(HttpContext context)
    {
        try
        {
            var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
            var newCar = JsonSerializer.Deserialize<Car>(requestBody);

            if (newCar == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }

          //  await _mockCarRepository.AddAsync(newCar);
            context.Response.StatusCode = StatusCodes.Status201Created;
        }
        catch (JsonException)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
    private async Task HandlePatch(HttpContext context)
    {
        var id = context.Request.Query["id"].FirstOrDefault();
        if (string.IsNullOrEmpty(id))
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            return;
        }

        try
        {
           // var carToUpdate = await _mockCarRepository.GetByIdAsync(id);
            if (carToUpdate == null)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }

            var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
            var carUpdates = JsonSerializer.Deserialize<Car>(requestBody);

            if (carUpdates == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }

            // Apply the changes to carToUpdate based on carUpdates object
            // Example: carToUpdate.CarModel = carUpdates.CarModel ?? carToUpdate.CarModel;
            // Repeat for other properties as necessary

           // await _mockCarRepository.UpdateAsync(id, carToUpdate);
            context.Response.StatusCode = StatusCodes.Status204NoContent;
        }
        catch (JsonException)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
    private async Task HandleGetBookings(HttpContext context)
    {
        var id = context.Request.Query["id"].FirstOrDefault();
        if (string.IsNullOrEmpty(id))
        {
            var bookings = await _mockBookingRepository.GetAllAsync();
            await RespondWithJson(context, bookings);
        }
        else
        {
            if (int.TryParse(id, out int bookingId))
            {
                var booking = await _mockBookingRepository.GetByIdAsync(bookingId);
                if (booking != null)
                {
                    await RespondWithJson(context, booking);
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                }
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }
    }
    private async Task HandlePostBooking(HttpContext context)
    {
        try
        {
            var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
            var newBooking = JsonSerializer.Deserialize<Booking>(requestBody);

            if (newBooking == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }

            await _mockBookingRepository.AddAsync(newBooking);
            context.Response.StatusCode = StatusCodes.Status201Created;
        }
        catch (JsonException)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
    private async Task HandlePutBooking(HttpContext context)
    {
        var id = context.Request.Query["id"].FirstOrDefault();
        if (!int.TryParse(id, out int bookingId))
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            return;
        }

        try
        {
            var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
            var updatedBooking = JsonSerializer.Deserialize<Booking>(requestBody);

            if (updatedBooking == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }

            await _mockBookingRepository.UpdateAsync(bookingId, updatedBooking);
            context.Response.StatusCode = StatusCodes.Status204NoContent;
        }
        catch (JsonException)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
        catch (KeyNotFoundException)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
        }
    }
    private async Task HandleDeleteBooking(HttpContext context)
    {
        var id = context.Request.Query["id"].FirstOrDefault();
        if (!int.TryParse(id, out int bookingId))
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            return;
        }

        try
        {
            await _mockBookingRepository.DeleteAsync(bookingId);
            context.Response.StatusCode = StatusCodes.Status204NoContent;
        }
        catch (KeyNotFoundException)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
        }
    }
    private async Task HandlePatchBooking(HttpContext context)
    {
        var id = context.Request.Query["id"].FirstOrDefault();
        if (!int.TryParse(id, out int bookingId))
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            return;
        }

        try
        {
            var existingBooking = await _mockBookingRepository.GetByIdAsync(bookingId);
            if (existingBooking == null)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }

            var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
            var bookingUpdates = JsonSerializer.Deserialize<Booking>(requestBody);

            if (bookingUpdates == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }

            // Apply changes to existingBooking from bookingUpdates
            // Example: existingBooking.Customername = bookingUpdates.Customername ?? existingBooking.Customername;
            // Repeat for other properties as necessary

            await _mockBookingRepository.UpdateAsync(bookingId, existingBooking);
            context.Response.StatusCode = StatusCodes.Status204NoContent;
        }
        catch (JsonException)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }

    private async Task HandleGetCarRentals(HttpContext context)
    {
        var carRentals = await _mockCarRentalRepository.GetAllAsync();
        await RespondWithJson(context, carRentals);
    }

    private async Task HandlePostCarRental(HttpContext context)
    {
        var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
        var carRental = JsonSerializer.Deserialize<Carrental>(requestBody);
        if (carRental != null)
        {
            await _mockCarRentalRepository.AddAsync(carRental);
            context.Response.StatusCode = StatusCodes.Status201Created;
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }

    private async Task HandlePutCarRental(HttpContext context)
    {
        var id = context.Request.Query["id"].FirstOrDefault();
        var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
        var carRental = JsonSerializer.Deserialize<Carrental>(requestBody);
        if (carRental != null && id == carRental.Carrentalid)
        {
            await _mockCarRentalRepository.UpdateAsync(carRental);
            context.Response.StatusCode = StatusCodes.Status204NoContent;
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }

    private async Task HandlePatchCarRental(HttpContext context)
    {
        var id = context.Request.Query["id"].FirstOrDefault();
        if (string.IsNullOrEmpty(id))
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            return;
        }

        Carrental carRentalToUpdate = _mockCarRentalRepository.GetByIdAsync(id).Result;
        if (carRentalToUpdate == null)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            return;
        }

        var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
        var patchDoc = JsonSerializer.Deserialize<JsonPatchDocument<Carrental>>(requestBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        if (patchDoc != null)
        {
            patchDoc.ApplyTo(carRentalToUpdate); // Apply the patch operations to carRentalToUpdate

            await _mockCarRentalRepository.UpdateAsync(carRentalToUpdate); // Assume this method handles the update logic
            context.Response.StatusCode = StatusCodes.Status204NoContent;
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }

    private async Task HandleDeleteCarRental(HttpContext context)
    {
        var id = context.Request.Query["id"].FirstOrDefault();
        if (!string.IsNullOrEmpty(id))
        {
            await _mockCarRentalRepository.DeleteAsync(id);
            context.Response.StatusCode = StatusCodes.Status204NoContent;
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }

    private async Task RespondWithJson(HttpContext context, object data)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status200OK;
        var jsonResponse = JsonSerializer.Serialize(data);
        await context.Response.WriteAsync(jsonResponse);
    }*/

}