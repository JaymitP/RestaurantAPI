# RestaurantAPI

A RESTful web API created with **ASP.NET Core 6.0**. The API is a for a restaurant POS system. It allows users to create, read, update, and delete resources based on users authorization using **JSON Web Token (JWT)**. The API is built with **Entity Framework Core 6.0** and **PostgreSQL**.

[Resource based authorization](https://learn.microsoft.com/en-us/aspnet/core/security/authorization/resourcebased?view=aspnetcore-3.1)\
[Policy based authorization](https://learn.microsoft.com/en-us/aspnet/core/security/authorization/policies?view=aspnetcore-3.1)

| Models         | Description                                               |
| -------------- | --------------------------------------------------------- |
| User           | A user of the system.                                     |
| Employee: User | An Employee of the business - Waiter, Chef, Administrator |
| Customer: User | An online customer                                        |
| Order          | An order placed by a customer or employee                 |
| OrderItem      | A singular/group of items in an order                     |
| MenuItem       | A menu item that can be ordered                           |
| Delivery       | The delivery details of an order                          |

| Policies | Users                       | Description                                                                           |
| -------- | --------------------------- | ------------------------------------------------------------------------------------- |
|          | Waiter, Administrator, Chef | Ability to read some _standard_ resources: Orders, Delieveries, MenuItems             |
|          | Waiter, Administrator, Chef | Ability to modify **all** _standard_ resources: Orders                                |
|          | Administrator               | Ability to read and modify **all** management related resources: MenuItems, Employees |

| Resource           | GET                                   | POST                   | DELETE                | PATCH                                           |
| ------------------ | ------------------------------------- | ---------------------- | --------------------- | ----------------------------------------------- |
| /orders            | Retrieve all orders                   | Create a new order     | Remove all orders     | Error                                           |
| /orders/1          | Retrieve the details for order 1      | Error                  | Remove order 1        | Update the details for order 1 if it exists     |
| /orders/tables     | Retrieve all tables                   | Create a new table     | Remove all tables     | Error                                           |
| /orders/tables/1   | Retrieve all the orders for table 1   | Error                  | Error                 | Error                                           |
| /menuitem/         | Retrieve all menu items               | Add a menu item        | Delete all menu items | Bulk update of menu items                       |
| /menuitem/1        | Retrieve the details for menu item 1  | Error                  | Delete menu item 1    | Update the details for menu item 1 if it exists |
| /customer/         | Retrieve all online customers         | Add an online customer | Delete all customers  | Error                                           |
| /customer/1        | Retrieve the details for customer 1   | Error                  | Delete customer 1     | Update the details for customer 1 if it exists  |
| /customer/orders   | Retrieve all orders for all customers | Error                  | Error                 | Error                                           |
| /customer/orders/1 | Retrieve the details for order 1      | Error                  | Error                 | Update details for order if it is not completed |
| /employee/         | Retrieve all employees                | Add an employee        | Delete all employees  | Error                                           |
| /employee/1        | Retrieve the details for employee 1   | Error                  | Delete employee 1     | Update the details for employee 1 if it exists  |

### Notes

It would be sufficient to only have authentication and not authorization since once a user is authenticated the system they are using would only allow the user to access the data they are authorized to access. However, I decided to implement authorization since it is good practice and provides an extra layer of security.

### To do

- Change role based auth to policy-based auth
- Change UserLogin from a model to a DTO
