This is Demo application to demonstrate some parts of EF Core.

Application have just a few entities: Customer, Contact, Product and Order.

Relationships:
  Customer can have multiple Orders and Contacts.
  Contact can have just one Customer.
  Product can have multiple Orders. (In our system product is not one unit, its just "type" of product that can be bought).
  Order have Product and Customer.

This demo contains configuration and usage of EF Core in "real world" scenario without implementation of repository.


