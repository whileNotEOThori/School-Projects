
public class App {

    public static void main(String[] args) throws Exception {
        // bookTest();
        // customerTest();
        inventoryTest();
        // orderTest();
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

}


/*
*create menu for displaying all books
 *code createOrder 
 */