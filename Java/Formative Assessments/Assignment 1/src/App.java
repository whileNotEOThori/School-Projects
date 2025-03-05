
public class App {

    public static void main(String[] args) throws Exception {
        // System.out.println("Hello, World!");
        bookTest();
        customerTest();
        inventoryTest();
    }

    private static void bookTest() {
        System.out.println("///////////////////////////////////////////////////////////////////////////////");
        System.out.println("///////////////////////////////////BOOK TEST//////////////////////////////////");
        System.out.println("///////////////////////////////////////////////////////////////////////////////");

        Book book1 = new Book();
        Book book2 = new Book("Java", "John Doe", 50);

        System.out.println("Book 1 using default constructor:");
        System.out.println("\tTitle: " + book1.getTitle());
        System.out.println("\tAuthor: " + book1.getAuthor());
        System.out.println("\tPrice: " + book1.getPrice());
        System.out.println();

        book1.setTitle("HTML");
        book1.setAuthor("Jane Doe");
        book1.setPrice(100.00);

        System.out.println("Book 2 using parameter constructor:");
        System.out.println("\tTitle: " + book2.getTitle());
        System.out.println("\tAuthor: " + book2.getAuthor());
        System.out.println("\tPrice: " + book2.getPrice());
        System.out.println();

        System.out.println("Book 1 after setters:");
        System.out.println("\tTitle: " + book1.getTitle());
        System.out.println("\tAuthor: " + book1.getAuthor());
        System.out.println("\tPrice: " + book1.getPrice());
        System.out.println();

    }

    private static void customerTest() {
        System.out.println("///////////////////////////////////////////////////////////////////////////////");
        System.out.println("///////////////////////////////////CUSTOMER TEST//////////////////////////////////");
        System.out.println("///////////////////////////////////////////////////////////////////////////////");

        Customer customer1 = new Customer();
        Customer customer2 = new Customer("John Doe", "jdoe@gmail.com");

        System.out.println("Customer 1 using default constructor:");
        System.out.println("\tName: " + customer1.getName());
        System.out.println("\tEmail: " + customer1.getEmail());
        System.out.println();

        customer1.setName("Jane Doe");
        customer1.setEmail("janedoegmail.com");

        System.out.println("Customer 2 using parameter constructor:");
        System.out.println("\tName: " + customer2.getName());
        System.out.println("\tEmail: " + customer2.getEmail());
        System.out.println();

        System.out.println("Customer 1 after setters:");
        System.out.println("\tName: " + customer1.getName());
        System.out.println("\tEmail: " + customer1.getEmail());
        System.out.println();

    }

    private static void inventoryTest() {
        System.out.println("///////////////////////////////////////////////////////////////////////////////");
        System.out.println("///////////////////////////////////INVENTORY TEST//////////////////////////////////");
        System.out.println("///////////////////////////////////////////////////////////////////////////////");

        Inventory library = new Inventory();
        Book book1 = new Book("HTML", "Jane Doe", 100);
        Book book2 = new Book("Java", "John Doe", 50);

        library.addBook(book1);
        library.addBook(book2);

        System.out.println(library.findBook("HTML"));
        System.out.println(library.findBook("Java"));
    }
}
