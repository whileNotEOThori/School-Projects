
import java.util.ArrayList;
import java.util.InputMismatchException;
import java.util.List;
import java.util.Scanner;

public class App {

    public static Scanner scanner = new Scanner(System.in);

    public static void main(String[] args) throws Exception, BookNotFoundException {
        int option = 0;
        Inventory inventory = new Inventory();

        do {
            menu();
            System.out.print("Enter option : ");
            option = scanner.nextInt();

            /*try {
                
            } catch (InputMismatchException e) {
                e.getMessage();
            }
             */
            switch (option) {
                case 1:
                    displayBooks(inventory.getInventory());
                    break;
                case 2:
                    inventory.addBook(addBookToInventory());
                    System.out.println("Book added to inventory");
                    break;
                case 3:
                    System.out.print("Enter Title : ");
                    String title = scanner.next();

                    try {
                        Book book = inventory.findBook(title);

                        System.out.println("Book titled '" + title + "' found");
                        System.out.println("Book [Title = " + book.getTitle() + ", Author = " + book.getAuthor() + ", Price = " + book.getPrice() + "]");

                    } catch (BookNotFoundException e) {
                        System.out.println(e.getMessage());
                    }
                    break;
                case 4:
                    try {
                        System.out.println("Create Order:");
                        System.out.println("Customer details:");

                        System.out.print("\tCustomer Name: ");
                        String name = scanner.next();

                        System.out.print("\tCustomer email: ");
                        String email = scanner.next();

                        Customer customer = new Customer(name, email);
                        System.out.println("Processing Order for " + name);
                        Order order = createOrder(inventory, customer);

                        System.out.println("Order [Customer = Customer[Name = " + customer.getName() + ", Email: " + customer.getEmail() + "],");
                        System.out.print("Books = [");
                        for (int i = 0, numOrders = order.getBooks().size(); i < numOrders; i++) {
                            System.out.print("Book [Title = " + order.getBooks().get(i).getTitle() + ", Author = " + order.getBooks().get(i).getAuthor() + ", Price = " + order.getBooks().get(i).getPrice() + "],");
                        }
                        System.out.println("]");

                    } catch (InvalidOrderException e) {
                        System.out.println(e.getMessage());
                    } catch (Exception e) {
                        System.out.println(e.getMessage());
                    }
                    break;
                case 99:
                    System.out.println("Thank you for using the Bookstore System.");
                    break;
                default:
                    System.out.println("Invalid option entered. Enter a number between 1 and 4");
                    break;
            }
            System.out.println();
        } while (option != 99);
    }

    private static void menu() {
        System.out.println("_______________________________");
        System.out.println("Welcome to the Bookstore System!");
        System.out.println("_______________________________\n");

        System.out.println("Options:");
        System.out.println("1.\tDisplay the available books");
        System.out.println("2.\tAdd book to the inventory");
        System.out.println("3.\tFind a book");
        System.out.println("4.\tCreate an order");
        System.out.println("99.\tExit");
    }

    private static void displayBooks(List<Book> inventory) {
        System.out.println("Available Books:");
        if (inventory.size() == 0) {
            System.out.println("No books available.");
        } else {
            for (int i = 0, n = inventory.size(); i < n; i++) {
                System.out.println("Book [Title = " + inventory.get(i).getTitle() + ", Author = " + inventory.get(i).getAuthor() + ", Price = " + inventory.get(i).getPrice() + "]");
            }
        }
    }

    private static Book addBookToInventory() {
        System.out.println("Add book:");

        System.out.print("Book Title: ");
        String title = scanner.next();

        System.out.print("Book Author: ");
        String author = scanner.next();

        System.out.print("Book Price: ");
        double price = scanner.nextDouble();

        return new Book(title, author, price);
    }

    private static Order createOrder(Inventory inventory, Customer customer) throws InvalidOrderException {
        Order order = new Order(customer);

        System.out.println("Enter the Title of the book you you would like to add to your order and -99 to stop.");
        String title;
        do {
            System.out.print("Title:");
            title = scanner.next();

            try {
                order.addBook(inventory.findBook(title));
            } catch (BookNotFoundException e) {
                System.out.println(e.getMessage());
            }

        } while (!title.equals("-99"));

        if (order.getBooks().size() > 0) {
            return order;
        }

        throw new InvalidOrderException();
    }
}


/*
*create menu for displaying all books
 *c
ode createOrder 
 */
