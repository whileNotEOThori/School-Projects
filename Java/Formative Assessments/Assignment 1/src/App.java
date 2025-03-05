
public class App {

    public static void main(String[] args) throws Exception {
        // System.out.println("Hello, World!");
        bookTest();
        customerTest();
        inventoryTest();
        orderTest();
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

        System.out.println("Search on an empty inventory list");
        System.out.println(library.findBook("Java"));

        library.addBook(book1);
        library.addBook(book2);

        System.out.println("Search for a book that exists in a filled list");
        System.out.println(library.findBook("HTML"));
        System.out.println(library.findBook("Java"));

        System.out.println("Search for a book that does not exist in a filled list");
        System.out.println(library.findBook("Project Management"));
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
}
