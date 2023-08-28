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
