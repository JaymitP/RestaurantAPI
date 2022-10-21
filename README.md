# RestaurantAPI

A RESTful web API created with **ASP.NET Core 6.0**. The API is a for a restaurant POS system. It allows users to create, read, update, and delete resources based on users authorization using **JSON Web Token (JWT)**. The API is built with **Entity Framework Core 6.0** and **PostgreSQL**.

### Notes

It would be sufficient to only have authentication and not authorization since once a user is authenticated the system they are using would only allow the user to access the data they are authorized to access. However, I decided to implement authorization since it is good practice and provides an extra layer of security.
