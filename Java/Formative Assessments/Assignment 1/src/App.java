
import java.util.ArrayList;
import java.util.InputMismatchException;
import java.util.List;
import java.util.Scanner;

public class App {

    public static Scanner scanner = new Scanner(System.in);
    public static Inventory bookstore = new Inventory(); //CREATE BOOKSTORE

    public static void main(String[] args) throws Exception, BookNotFoundException {
        System.out.println("_______________________________");
        System.out.println("Welcome to the Bookstore System!");
        System.out.println("_______________________________\n");

        //CREATE BOOKS
        Book book1 = new Book("English HL", "Ntini", 75.00);
        Book book2 = new Book("Afrikaans FAL", "Jonker", 75.00);
        Book book3 = new Book("Mathematics", "Tinarow", 77.00);
        Book book4 = new Book("Accounting", "Samuels", 77.00);
        Book book5 = new Book("Life Orientation", "Joubert", 81.00);
        Book book6 = new Book("Phsyical Sciences", "George", 82.00);
        Book book7 = new Book("Information Technology", "Taute", 88.00);

        //CREATE CUSTOMERS
        Customer Thoriso = new Customer("Thoriso", "thoriso@gmail.com");
        Customer Peter = new Customer("Peter", "peter@gmail.com");
        Customer John = new Customer("John", "john@gmail");

        // ADD BOOKS TO BOOK STORE
        bookstore.addBook(book1);
        bookstore.addBook(book2);
        bookstore.addBook(book3);
        bookstore.addBook(book4);
        bookstore.addBook(book5);
        bookstore.addBook(book6);

        //CREATE ORDERS
        Order order1 = new Order(Thoriso);
        Order order2 = new Order(Peter);
        Order order3 = new Order(John);

        //DISPLAY ALL AVAILABLE BOOKS
        displayBooks(bookstore.getInventory());

        addBookToOrder(order1, book1);
        addBookToOrder(order1, book2);
        addBookToOrder(order1, book3);
        addBookToOrder(order2, book4);
        addBookToOrder(order2, book5);
        addBookToOrder(order2, book6);
        addBookToOrder(order2, book7); //ADD A BOOK THAT ISN'T IN THE BOOKSTORE INVENTORY

        try {
            processOrder(order1);
        } catch (InvalidOrderException e) {
            System.out.println(e.getMessage());
        }

        try {
            processOrder(order2);
        } catch (InvalidOrderException e) {
            System.out.println(e.getMessage());
        }

        try {
            processOrder(order3);
        } catch (InvalidOrderException e) {
            System.out.println(e.getMessage());
        }
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
        System.out.println();
    }

    private static void addBookToOrder(Order order, Book book) {
        try {
            order.addBook(bookstore.findBook(book.getTitle()));
        } catch (BookNotFoundException e) {
            System.out.println(e.getMessage());
        }
    }

    private static void processOrder(Order order) throws InvalidOrderException {
        System.out.println("Processing Order for " + order.getCustomer().getName());

        if (order.getBooks().size() > 0) {
            System.out.print("Order [Customer = Customer[Name = " + order.getCustomer().getName() + ", Email: " + order.getCustomer().getEmail() + "],\nBooks = ");

            int numOrders = order.getBooks().size();
            for (int i = 0; i < numOrders - 1; i++) {
                System.out.print("[Book [Title = " + order.getBooks().get(i).getTitle() + ", Author = " + order.getBooks().get(i).getAuthor() + ", Price = " + order.getBooks().get(i).getPrice() + "]],");
            }
            System.out.print("[Book [Title = " + order.getBooks().get(numOrders - 1).getTitle() + ", Author = " + order.getBooks().get(numOrders - 1).getAuthor() + ", Price = " + order.getBooks().get(numOrders - 1).getPrice() + "]]");
            System.out.println("]");

        } else {
            throw new InvalidOrderException();
        }
        System.out.println();
    }

}
/*
         create menu for displaying all books
 *c
ode createOrder 
 */
