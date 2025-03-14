
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class App {

    public static Scanner scanner = new Scanner(System.in);

    public static void main(String[] args) throws Exception {
        // bookTest();
        // customerTest();
        inventoryTest();
        // orderTest();

        int option = 0;
        Inventory inventory = new Inventory();

        do {
            menu();
            System.out.print("Enter option : ");
            option = scanner.nextInt();

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
                        e.getMessage();
                    }
                    break;
                case 4:
                    try {
                        createOrder(inventory);
                    } catch (InvalidOrderException e) {
                        e.getMessage();
                    } catch (Exception e) {
                        e.getMessage();
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

    private static void bookTest() {
        System.out.println("///////////////////////////////////////////////////////////////////////////////");
        System.out.println("///////////////////////////////////BOOK TEST//////////////////////////////////");
        System.out.println("///////////////////////////////////////////////////////////////////////////////");

        Book book2 = new Book("Java", "John Doe", 50);

        System.out.println("Book 2 using parameter constructor:");
        System.out.println("\tTitle: " + book2.getTitle());
        System.out.println("\tAuthor: " + book2.getAuthor());
        System.out.println("\tPrice: " + book2.getPrice());
        System.out.println();

    }

    private static void customerTest() {
        System.out.println("///////////////////////////////////////////////////////////////////////////////");
        System.out.println("///////////////////////////////////CUSTOMER TEST//////////////////////////////////");
        System.out.println("///////////////////////////////////////////////////////////////////////////////");

        Customer customer2 = new Customer("John Doe", "jdoe@gmail.com");

        System.out.println("Customer 2 using parameter constructor:");
        System.out.println("\tName: " + customer2.getName());
        System.out.println("\tEmail: " + customer2.getEmail());
        System.out.println();

    }

    private static void inventoryTest() {
        System.out.println("///////////////////////////////////////////////////////////////////////////////");
        System.out.println("///////////////////////////////////INVENTORY TEST//////////////////////////////////");
        System.out.println("///////////////////////////////////////////////////////////////////////////////");

        Inventory library = new Inventory();
        Book book1 = new Book("HTML", "Jane Doe", 100);
        Book book2 = new Book("Java", "John Doe", 50);

        System.out.println("Search on an empty inventory list");
        try {
            System.out.println(library.findBook("Java"));
        } catch (BookNotFoundException e) {
            System.out.println(e.getMessage());
        }

        library.addBook(book1);
        library.addBook(book2);

        System.out.println("Search for a book that exists in a filled list");
        try {
            System.out.println(library.findBook("HTML"));
        } catch (BookNotFoundException e) {
            System.out.println(e.getMessage());
        }

        try {
            System.out.println(library.findBook("Java"));
        } catch (BookNotFoundException e) {
            System.out.println(e.getMessage());
        }

        System.out.println("Search for a book that does not exist in a filled list");
        try {
            System.out.println(library.findBook("Project Management"));
        } catch (BookNotFoundException e) {
            System.out.println(e.getMessage());
        }
    }

    private static void orderTest() {
        System.out.println("///////////////////////////////////////////////////////////////////////////////");
        System.out.println("///////////////////////////////////ORDER TEST//////////////////////////////////");
        System.out.println("///////////////////////////////////////////////////////////////////////////////");

        Customer customer = new Customer("John Doe", "jdoe@gmail.com");
        Order textbooks = new Order(customer);

        Book book1 = new Book("HTML", "Jane Doe", 100);
        Book book2 = new Book("Java", "John Doe", 50);

        textbooks.addBook(book1);
        textbooks.addBook(book2);

        System.out.println("Order details:");
        System.out.println("\tCustomer Name: " + textbooks.getCustomer().getName());
        System.out.println("\tNumber of books ordered: " + textbooks.getBooks().size());
        for (int i = 0, n = textbooks.getBooks().size(); i < n; i++) {
            System.out.println("\tBook " + (i + 1) + ": " + textbooks.getBooks().get(i).getTitle());
        }
        System.out.println();

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

    private static Order createOrder(Inventory inventory) throws InvalidOrderException {
        System.out.println("Create Order:");
        System.out.println("Customer details:");

        System.out.print("\tCustomer Name: ");
        String name = scanner.next();

        System.out.print("\tCustomer email: ");
        String email = scanner.next();

        Customer customer = new Customer(name, email);
        Order order = new Order(customer);
        List<Book> books = new ArrayList<Book>();

        System.out.println("Enter the Title of the book you you would like to add to your order and -99 to stop.");
        String title;
        do {
            System.out.print("Title:");
            title = scanner.next();

            try {
                order.addBook(inventory.findBook(title));
            } catch (BookNotFoundException e) {
                e.getMessage();
            }

        } while (title != "-99");

        if (order.getBooks().size() > 0) {
            return order;

        }

        throw new InvalidOrderException("Invalid order");
    }
}


/*
*create menu for displaying all books
 *c
ode createOrder 
 */
