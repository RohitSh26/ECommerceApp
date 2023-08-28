# Ecommerce App - Checkout Endpoint

### Overview

This project is a simplified ecommerce api and focusses on the sigle endpoitn checkout action. This end points calculates the price for the different types o watches present at the checkout using special discoints for them.

## Requirements

Endpoint reference
As a further guideline here's an endpoint definition that you can use to design your API endpoint.

#### Request

```
POST http://localhost:8080/checkout
```

#### Headers

```
Accept: application/json
Content-Type: application/json

#### Body

[
    "001",
    "002",
    "001",
    "004",
    "003"
]
```

Response

##### Headers

```
    Content-Type: application/json

    #### Body

    { "price": 360 }
```

### Get Started

#### Prerequisite

- .NET SDK (version 7.0 or higher)
- An IDE like Visual Studio or Visual Studio Code

#### Installation

1. Clone Repository

   ```
   git clone https://github.com/RohitSh26/ECommerceApp.git
   ```

2. Navigate to directory
   ```
   cd ECommerceApp/CheckoutService
   ```
3. Restore packages
   ```
   dotnet restore
   ```

### Running the APP

To run the app, execute the following from "CheckoutService" directory:

```
dotnet run
```

Command line request response

```
 curl --request POST \
  --url http://localhost:8080/checkout \
  --header 'Accept: application/json' \
  --header 'Content-Type: application/json' \
  --data '["001", "001","001"]'
```

```
{"price":200}
```

Swaggger URL to request API:

```
http://localhost:8080/swagger/index.html
```

### Basic approach

Develop an architechture that is modular, easy to modify and extensible. Used SOLID Principle to provide modularity, maintainability, etc.

#### Checkout Service

Provides an api end-point for checkout. Checkout of list of watches and calculating the total cost after applying discounts.

1. Validation of data: input validation for list of watch ids.
2. Retrieval of Data: Used Catalogue service to get details of requested watch ids.
3. Discount and Price Calculation: Used Discount Service to apply discounts that helps in calulating total price.
4. Response to the request: Reponse for the API Call with total price.

#### Catalogue Service

Provides an api to retreive data for watches.

#### Discount Service

Serive provides methods to apply discount and provides discounted amount for watches

### Design Approach

#### SOLID Principles and Design Principles

Used SOLID priciples (Single Responsibility, Open/Close, LSP, Interface Segregation and Dependicy Inversion) along with this used Saperation of concerns, DRY and sticking to the requirements.

### Testing Approach

This project uses NUnit for unit testing and Moq for mocking dependncies.

#### Steps to Run Test

Run '**dotnet run**' from root directory or ECommerceApp.Tests directory

#### Manual Test

```
 curl --request POST \
  --url http://localhost:8080/checkout \
  --header 'Accept: application/json' \
  --header 'Content-Type: application/json' \
  --data '["001", "001","001"]'
```

```
{"price":200}
```

### Improvements

1. More extensive unit testing can be used.
2. Improved error handling, we can implement middleware that can be used for global exceptional handling.
3. Instead of using in-memory db, use of more robust DB
4. We can use standardized error code for appliation
5. Using a message queue, can make this application more decouples, but it adds complexity for this small example.
6. CI/CD can be added via Azure Deveops or Git Action
